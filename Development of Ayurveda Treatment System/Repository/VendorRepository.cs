using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Repository;

public class VendorRepository : IVendor
{
    private readonly AyurgrowDBContext _context;
    public VendorRepository(AyurgrowDBContext context)
    {
        _context = context;
    }
    public async Task<Vendor> AddVendor(Vendor vendor)
    {
        _context.Vendors.Add(vendor);
        await _context.SaveChangesAsync();
        return vendor;
    }
    public async Task<bool> DeleteByIdAsync(string Id)
    {
        try
        {
            var vendor = _context.Vendors.FirstOrDefault(id => id.VendorId == Id.ToString());
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
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
    public async Task<bool> EditByIdAsync(Vendor model)
    {
        try
        {
            var vendor = _context.Vendors.FirstOrDefault(id => id.VendorId == model.VendorId.ToString());
            if (vendor != null)
            {
                vendor.VendorName = model.VendorName;
                vendor.Email = model.Email;
                vendor.ContactNo = model.ContactNo;
                vendor.Address = model.Address;
                vendor.RegistrationNo = model.RegistrationNo;
                vendor.FaxNo = model.FaxNo;
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
    public async Task<Vendor> GetByIdAsync(string Id)
    {
        try
        {
            var vendor = _context.Vendors.FirstOrDefault(id => id.VendorId == Id.ToString());
            if (vendor != null)
            {
                return vendor;
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
