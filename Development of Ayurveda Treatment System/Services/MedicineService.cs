using System;
using Development_of_Ayurveda_Treatment_System.Interface;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Services;

public class MedicineService
{
    private readonly IMedicine _medicine;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public MedicineService(IMedicine medicine, IWebHostEnvironment webHostEnvironment)
    {
        _medicine = medicine;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<(bool IsSuccess, string message)> AddNewMedicine(Medicine medicine)
    {
        var medicineExist = await _medicine.GetByMedicineNumberAsync(medicine.MedicineNo);
        if (medicineExist != null)
        {
            return (false, "Medicine already exists.");
        }
        else
        {
            if (medicine.UploadedFile != null && medicine.UploadedFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid() + Path.GetExtension(medicine.UploadedFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await medicine.UploadedFile.CopyToAsync(stream);
                }

                medicine.MedicinePhoto = "/uploads/" + fileName; // save path

                using (var ms = new MemoryStream())
                {
                    await medicine.UploadedFile.CopyToAsync(ms);
                    medicine.Image = ms.ToArray(); // save bytes
                }
            }
            Medicine medicieAdd = new Medicine
            {
                ID = medicine.ID,
                MedicineNo = medicine.MedicineNo,
                MedicineName = medicine.MedicineName,
                MedicineBatchNo = medicine.MedicineBatchNo,
                ManufacturerName = medicine.ManufacturerName,
                ManufacturerAddress = medicine.ManufacturerAddress,
                DateOfManufactured = medicine.DateOfManufactured,
                DateOfExpire = medicine.DateOfExpire,
                MedicinePhoto = medicine.MedicinePhoto,
                Image = medicine.Image,
                Price = medicine.Price,
                Stock = medicine.Stock,
                UserID = string.Empty,
                VendorID = string.Empty
            };
            var newMedicine = await _medicine.AddMedicine(medicieAdd);
            if (newMedicine != null)
            {
                return (true, "Medicine added successfully.");
            }
            else
            {
                return (false, "Medicine already exists.");
            }
        }
    }
    public async Task<bool> DeleteMedicineAsync(string medId)
    {
        bool result = await _medicine.DeleteByIdAsync(medId);
        if (result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task<Medicine> GetMedicineAsync(string id)
    {
        Medicine medicine = await _medicine.GetByIdAsync(id);
        if (medicine != null)
        {
            return medicine;
        }
        else
        {
            return new Medicine();
        }
    }
    public async Task<bool> EditMedicineAsync(Medicine model)
    {
        if (model.UploadedFile != null && model.UploadedFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = Guid.NewGuid() + Path.GetExtension(model.UploadedFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.UploadedFile.CopyToAsync(stream);
                }

                model.MedicinePhoto = "/uploads/" + fileName; // save path

                using (var ms = new MemoryStream())
                {
                    await model.UploadedFile.CopyToAsync(ms);
                    model.Image = ms.ToArray(); // save bytes
                }
            }
        bool result = await _medicine.EditByIdAsync(model);
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
