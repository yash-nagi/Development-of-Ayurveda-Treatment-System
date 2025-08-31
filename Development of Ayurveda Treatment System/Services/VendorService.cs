using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Services;

public class VendorService
{
    private readonly IVendor _vendor;
    public VendorService(IVendor vendor)
    {
        _vendor = vendor;
    }
    public async Task<(bool IsSuccess, string message)> AddNewVendor(Vendor vendor)
    {
        var vendorExist = await _vendor.GetByIdAsync(vendor.VendorId);
        if (vendorExist != null)
        {
            return (false, "Vendor already exists.");
        }
        else
        {
            Vendor vendorAdd = new Vendor
            {
                VendorId = vendor.VendorId,
                VendorName = vendor.VendorName,
                Email = vendor.Email,
                ContactNo = vendor.ContactNo,
                Address = vendor.Address,
                RegistrationNo = vendor.RegistrationNo,
                FaxNo = vendor.FaxNo
            };
            var newVendor = await _vendor.AddVendor(vendorAdd);
            if (newVendor != null)
            {
                return (true, "Vendor added successfully.");
            }
            else
            {
                return (false, "Vendor already exists.");
            }
        }
    }
    public async Task<bool> EditVendorAsync(Vendor model)
    {
        bool result = await _vendor.EditByIdAsync(model);
        if (result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<Vendor> GetVendor(string Id)
    {
        Vendor vendor = await _vendor.GetByIdAsync(Id);
        if (vendor != null)
        {
            return vendor;
        }
        else
        {
            return new Vendor();
        }
    }
    public async Task<bool> DeleteVendor(string id)
    {
        bool IsDeleted = await _vendor.DeleteByIdAsync(id);
        if (IsDeleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
