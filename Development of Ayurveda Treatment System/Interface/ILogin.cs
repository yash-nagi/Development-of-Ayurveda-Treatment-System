using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface ILogin
{
    Task<Login> GetByEmailAndPasswordAsync(string email, string password);
    Task<Login> AddLoginAsync(Login login);
    Task<Login> GetUserByEmailAsync(string email);
    Task<Login> UpdatePassword(string email, string password);
}
