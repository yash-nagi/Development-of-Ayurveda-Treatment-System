using System;
using Microsoft.EntityFrameworkCore;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Interface;

namespace Development_of_Ayurveda_Treatment_System.Service;

public class LoginSevice
{
    private readonly ILogin _loginRepository;
    public LoginSevice(ILogin loginRepository)
    {
        _loginRepository = loginRepository;
    }
    public async Task<(bool IsSuccess, string Message)> NewLoginUserAsync(Login model)
    {
        // Check if login exists
        var existingUser = await _loginRepository.GetByEmailAndPasswordAsync(model.Email, model.Password);
        if (existingUser != null)
        {
            return (false, "Email and Password already exists");
        }

        // Create Login entity
        var login = new Login
        {
            Id = model.Id,
            Email = model.Email,
            Password = model.Password,
            Role = model.Role
        };

        await _loginRepository.AddLoginAsync(login);
        return (true, "Login registered successfully");
    }
    public async Task<(bool IsValidate, string Message)> Login(Login login)
    {
        // Check if login exists
        var existingUser = await _loginRepository.GetByEmailAndPasswordAsync(login.Email, login.Password);
        if (existingUser != null)
        {
            return (true, "Email and Password verified");
        }
        else
        {
            return (false, "Email and Password not verified");
        }
    }
}
