using System;
using Microsoft.EntityFrameworkCore;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Interface;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class UserRepository : IUser
{
    private readonly AyurgrowDBContext _context;
    public UserRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<Users> GetByEmailOrUsernameAsync(string email, string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email || u.UserName == username);
    }
    public async Task<Users> AddUserAsync(Users user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<Users> UpdatePassword(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return null;
        }
        user.Password = password;
        await _context.SaveChangesAsync();
        return user;
    }
}
