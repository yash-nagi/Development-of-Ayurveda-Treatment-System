using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface IDoctor
{
    Task<Doctor> AddDoctor(Doctor model);
    Task<Doctor> GetByIdAsync(string Id);
    Task<bool> DeleteByIdAsync(string Id);
    Task<bool> EditByIdAsync(Doctor model);
}
