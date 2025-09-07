using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class DoctorRepository : IDoctor
{
    private readonly AyurgrowDBContext _context;
    public DoctorRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<Doctor> AddDoctor(Doctor model)
    {
        try
        {
            _context.Doctors.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public async Task<Doctor> GetByIdAsync(string Id)
    {
        try
        {
            var model = _context.Doctors.FirstOrDefault(id => id.DoctorId == Id.ToString());
            if (model != null)
            {
                return model;
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
            var model = _context.Doctors.FirstOrDefault(id => id.DoctorId == Id.ToString());
            if (model != null)
            {
                _context.Doctors.Remove(model);
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
    public async Task<bool> EditByIdAsync(Doctor model)
    {
        try
        {
            var doctor = _context.Doctors.FirstOrDefault(id => id.DoctorId == model.DoctorId.ToString());
            if (doctor != null)
            {
                doctor.DoctorName = model.DoctorName;
                doctor.Email = model.Email;
                doctor.Department = model.Department;
                doctor.ContactNo = model.ContactNo;
                doctor.ConsultationFees = model.ConsultationFees;
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
