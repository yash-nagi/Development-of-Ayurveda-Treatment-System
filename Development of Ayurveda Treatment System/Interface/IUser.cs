using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface IUser
{
    Task<Users> GetByEmailOrUsernameAsync(string email, string username);
    Task<Users> AddUserAsync(Users user);
    Task<Login> UpdatePassword(string email, string password);
}
