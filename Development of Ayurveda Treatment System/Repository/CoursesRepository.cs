using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class CoursesRepository : ICourses
{
    private readonly AyurgrowDBContext _context;
    public CoursesRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<Course> AddCourse(Course course)
    {
        try
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<Course> GetByIdAsync(string Id)
    {
        try
        {
            var course = _context.Courses.FirstOrDefault(id => id.CourseId == Id.ToString());
            if (course != null)
            {
                return course;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<bool> DeleteByIdAsync(string Id)
    {
        try
        {
            var course = _context.Courses.FirstOrDefault(id => id.CourseId == Id.ToString());
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public async Task<bool> EditByIdAsync(Course model)
    {
        try
        {
            var course = _context.Courses.FirstOrDefault(id => id.CourseId == model.CourseId.ToString());
            if (course != null)
            {
                course.CourseName = model.CourseName;
                course.CourseDuration = model.CourseDuration;
                course.CourseFeeStruc = model.CourseFeeStruc;
                course.Benefits = model.Benefits;
                course.InstituteName = model.InstituteName;
                course.InstituteContactNo = model.InstituteContactNo;
                course.InstituteAddress = model.InstituteAddress;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
