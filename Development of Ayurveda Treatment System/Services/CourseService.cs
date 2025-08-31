using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Services;

public class CourseService
{
    private readonly ICourses _courses;
    public CourseService(ICourses courses)
    {
        _courses = courses;
    }
    public async Task<(bool IsSuccess, string message)> AddNewCourse(Course course)
    {
        var courseExist = await _courses.GetByIdAsync(course.CourseId);
        if (courseExist != null)
        {
            return (false, "Course already exists.");
        }
        else
        {
            Course courseAdd = new Course
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseDuration = course.CourseDuration,
                CourseFeeStruc = course.CourseFeeStruc,
                Benefits = course.Benefits,
                InstituteName = course.InstituteName,
                InstituteContactNo = course.InstituteContactNo,
                InstituteAddress = course.InstituteAddress
            };
            var newCourse = await _courses.AddCourse(courseAdd);
            if (newCourse != null)
            {
                return (true, "Course added successfully.");
            }
            else
            {
                return (false, "Course already exists.");
            }
        }
    }
    public async Task<bool> DeleteCourse(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var course = await _courses.DeleteByIdAsync(id);
            if (course)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public async Task<Course> GetCourse(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var courseExist = await _courses.GetByIdAsync(id);
            if (courseExist != null)
            {
                return courseExist;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public async Task<bool> EditCourseAsync(Course model)
    {
        bool result = await _courses.EditByIdAsync(model);
        if (result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
