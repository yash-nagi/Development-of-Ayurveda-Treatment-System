using System;
using Microsoft.EntityFrameworkCore;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Interface;

namespace Development_of_Ayurveda_Treatment_System.Service;

public class UserService
{
    private readonly IUser _userRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UserService(IUser userRepository, IWebHostEnvironment webHostEnvironment)
    {
        _userRepository = userRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<(bool IsSuccess, string Message)> RegisterUserAsync(Users model)
    {
        // Check if user exists
        var existingUser = await _userRepository.GetByEmailOrUsernameAsync(model.Email, model.UserName);
        if (existingUser != null)
        {
            return (false, "Username or Email already exists");
        }
        if (model.UploadedFile != null && model.UploadedFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid() + Path.GetExtension(model.UploadedFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.UploadedFile.CopyToAsync(stream);
            }

            model.ProfilePhoto = "/uploads/" + fileName; // save path

            using (var ms = new MemoryStream())
            {
                await model.UploadedFile.CopyToAsync(ms);
                model.Image = ms.ToArray(); // save bytes
            }
        }
        // Create User entity
        var user = new Users
        {
            UserId = model.UserId,
            UserName = model.UserName,
            Email = model.Email,
            Password = model.Password, // Hash password if needed
            FirstName = model.FirstName,
            MiddleName = model.MiddleName,
            LastName = model.LastName,
            Gender = model.Gender,
            DOB = model.DOB,
            MobileNo = model.MobileNo,
            PhoneNo = model.PhoneNo,
            Address = model.Address,
            City = model.City,
            PostalCode = model.PostalCode,
            Region = model.Region,
            Country = model.Country,
            Nationality = model.Nationality,
            Religion = model.Religion,
            UserType = model.UserType,
            ProfilePhoto = model.ProfilePhoto,
            Image = model.Image
        };

        await _userRepository.AddUserAsync(user);
        return (true, "User registered successfully");
    }
    public async Task<bool> UpdatePassword(string email, string password)
    {
        var updatePassword = await _userRepository.UpdatePassword(email, password);
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
