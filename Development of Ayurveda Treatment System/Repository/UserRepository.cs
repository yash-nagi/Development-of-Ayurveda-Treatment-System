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
    public async Task<Users> EditUserAsync(Users model)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == model.UserId);
        if (user == null)
        {
            return null;
        }
        user.UserId = model.UserId;
        user.UserName = model.UserName;
        user.Email = model.Email;
        user.Password = model.Password ;// Hash password if needed
        user.FirstName = model.FirstName;
        user.MiddleName = model.MiddleName;
        user.LastName = model.LastName;
        user.Gender = model.Gender;
        user.DOB = model.DOB;
        user.MobileNo = model.MobileNo;
        user.PhoneNo = model.PhoneNo;
        user.Address = model.Address;
        user.City = model.City;
        user.PostalCode = model.PostalCode;
        user.Region = model.Region;
        user.Country = model.Country;
        user.Nationality = model.Nationality;
        user.Religion = model.Religion;
        user.UserType = model.UserType;
        user.ProfilePhoto = model.ProfilePhoto;
        user.Image = model.Image;
        await _context.SaveChangesAsync();
        return user;
    }
}
