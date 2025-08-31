using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface ICourses
{
    Task<Course> AddCourse(Course course);
    Task<Course> GetByIdAsync(string Id);
    Task<bool> EditByIdAsync(Course model);
    Task<bool> DeleteByIdAsync(string Id);
}
