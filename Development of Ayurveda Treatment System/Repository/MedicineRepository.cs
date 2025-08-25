using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class MedicineRepository : IMedicine
{
    private readonly AyurgrowDBContext _context;
    public MedicineRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<Medicine> AddMedicine(Medicine medicine)
    {
        _context.Medicines.Add(medicine);
        await _context.SaveChangesAsync();
        return medicine;
    }
    public async Task<Medicine> GetByMedicineNumberAsync(int medicineNumber)
    {
        return _context.Medicines.FirstOrDefault(medNum => medNum.MedicineNo == medicineNumber);
    }
    public async Task<bool> DeleteByIdAsync(string medId)
    {
        try
        {
            var medicine = _context.Medicines.FirstOrDefault(id => id.ID == medId.ToString());
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
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
    public async Task<bool> EditByIdAsync(Medicine model)
    {
        try
        {
            var medicine = _context.Medicines.FirstOrDefault(id => id.ID == model.ID.ToString());
            if (medicine != null)
            {
                medicine.MedicineNo = model.MedicineNo;
                medicine.MedicineBatchNo = model.MedicineBatchNo;
                medicine.MedicineName = model.MedicineName;
                medicine.ManufacturerName = model.ManufacturerName;
                medicine.ManufacturerAddress = model.ManufacturerAddress;
                medicine.MedicinePhoto = model.MedicinePhoto;
                medicine.Image = model.Image;
                medicine.DateOfExpire = model.DateOfExpire;
                medicine.DateOfManufactured = model.DateOfManufactured;
                medicine.Price = model.Price;
                medicine.Stock = model.Stock;
                medicine.UserID = model.UserID;
                medicine.VendorID = model.VendorID;
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
    public async Task<Medicine> GetByIdAsync(string medId)
    {
        try
        {
            var medicine = _context.Medicines.FirstOrDefault(id => id.ID == medId.ToString());
            if (medicine != null)
            {
                return medicine;
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
}
