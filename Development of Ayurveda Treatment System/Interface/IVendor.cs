using System;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Interface;

public interface IVendor
{
    Task<Vendor> AddVendor(Vendor vendor);
    Task<bool> DeleteByIdAsync(string Id);
    Task<bool> EditByIdAsync(Vendor vendor);
    Task<Vendor> GetByIdAsync(string Id);
}
