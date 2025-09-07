using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Services;

public class DoctorsService
{
    private readonly IDoctor _doctor;
    public DoctorsService(IDoctor doctor)
    {
        _doctor = doctor;
    }
    public async Task<(bool IsSuccess, string message)> AddDoctor()
    {
        return (true, "Success");
    }
}
