using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Services;

public class DoctorsService
{
    private readonly IDoctor _doctor;
    public DoctorsService(IDoctor doctor)
    {
        _doctor = doctor;
    }
    public async Task<(bool IsSuccess, string message)> AddDoctor(Doctor doctor)
    {
        var doctorExist = await _doctor.GetByIdAsync(doctor.DoctorId);
        if (doctorExist != null)
        {
            return (false, "Doctor already exists.");
        }
        else
        {
            Doctor doctorAdd = new Doctor
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Email = doctor.Email,
                ContactNo = doctor.ContactNo,
                Department = doctor.Department,
                AppointmentID = doctor.AppointmentID,
                AppointmentDate = doctor.AppointmentDate,
                AppointmentTime = doctor.AppointmentTime,
                ConsultationFees = doctor.ConsultationFees
            };
            var newDoctor = await _doctor.AddDoctor(doctorAdd);
            if (newDoctor != null)
            {
                return (true, "Doctor added successfully.");
            }
            else
            {
                return (false, "Doctor failed to add.");
            }
        }
    }
    public async Task<Doctor> GetDoctor(string id)
    {
        var doctorExist = await _doctor.GetByIdAsync(id);
        if (doctorExist != null)
        {
            return doctorExist;
        }
        else
        {
            return null;
        }
    }
    public async Task<(bool IsSuccess, string message)> EditDoctor(Doctor doctor)
    {
        var doctorExist = await _doctor.GetByIdAsync(doctor.DoctorId);
        if (doctorExist == null)
        {
            return (false, "Doctor not found.");
        }
        else
        {
            Doctor doctorUpdate = new Doctor
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Email = doctor.Email,
                ContactNo = doctor.ContactNo,
                Department = doctor.Department,
                AppointmentID = doctor.AppointmentID,
                AppointmentDate = doctor.AppointmentDate,
                AppointmentTime = doctor.AppointmentTime,
                ConsultationFees = doctor.ConsultationFees
            };
            var newDoctor = await _doctor.EditByIdAsync(doctorUpdate);
            if (newDoctor != null)
            {
                return (true, "Doctor added successfully.");
            }
            else
            {
                return (false, "Doctor failed to add.");
            }
        }
    }
    public async Task<bool> DeleteDoctor(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var IsDelete = await _doctor.DeleteByIdAsync(id);
            if (IsDelete)
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
}
