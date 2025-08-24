using System;
using Microsoft.EntityFrameworkCore;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Development_of_Ayurveda_Treatment_System.Service;

public class LoginSevice
{
    private readonly ILogin _loginRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginSevice(ILogin loginRepository, IHttpContextAccessor httpContextAccessor)
    {
        _loginRepository = loginRepository;
        _httpContextAccessor = httpContextAccessor;
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
    public async Task<(bool IsValidate, string Message, Login login)> Login(Login login)
    {
        // Check if login exists
        var existingUser = await _loginRepository.GetByEmailAndPasswordAsync(login.Email, login.Password);
        if (existingUser != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, existingUser.Email),
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            // ✅ Respect "Remember Me"
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe,   // <-- here!
                ExpiresUtc = login.RememberMe ? DateTimeOffset.UtcNow.AddDays(30) : DateTimeOffset.UtcNow.AddHours(1)
            };

            await _httpContextAccessor.HttpContext.SignInAsync("Cookies",
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            return (true, "Email and Password verified", existingUser);
        }
        else
        {
            return (false, "Email and Password not verified", existingUser);
        }
    }
    public async Task<(bool IsFound, string message)> GetUserByEmailAsync(string email)
    {
        var loggedInUser = await _loginRepository.GetUserByEmailAsync(email);
        if (loggedInUser != null)
        {
            return (true, "Email found successfully");
        }
        else
        {
            return (false, "Email not found");
        }
    }
    public async Task<bool> UpdatePassword(string email, string password)
    {
        var updatePassword = await _loginRepository.UpdatePassword(email, password);
        if (updatePassword != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
