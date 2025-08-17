using System;
using Microsoft.EntityFrameworkCore;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Interface;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class LoginRepository : ILogin
{
    private readonly AyurgrowDBContext _context;
    public LoginRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<Login> GetByEmailAndPasswordAsync(string email, string password)
    {
        return await _context.Login.FirstOrDefaultAsync(l => l.Email == email && l.Password == password);
    }
    public async Task<Login> AddLoginAsync(Login login)
    {
        _context.Login.Add(login);
        await _context.SaveChangesAsync();
        return login;
    }
}
