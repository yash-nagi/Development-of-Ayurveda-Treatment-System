using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface IMedicine
{
    Task<Medicine> AddMedicine(Medicine medicine);
    Task<Medicine> GetByMedicineNumberAsync(int medicineNumber);
    Task<bool> DeleteByIdAsync(string medId);
    Task<bool> EditByIdAsync(Medicine model);
    Task<Medicine> GetByIdAsync(string medId);
}
