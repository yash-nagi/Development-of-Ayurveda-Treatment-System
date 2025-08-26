using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly AyurgrowDBContext _db;
        public MedicineService _medicineService;
        public VendorService _vendorervice;
        public AdminController(AyurgrowDBContext db, MedicineService medicineService, VendorService vendorService)
        {
            _db = db;
            _medicineService = medicineService;
            _vendorervice = vendorService;
        }
        // GET: AdminController
        public ActionResult AdminDashboard()
        {
            var model = new Admin
            {
                FullName = User.Identity.Name, // logged-in Admin name
                TotalMedicines = _db.Medicines.Count(),
                TotalVendors = _db.Vendors.Count(),
                TotalCourses = _db.Courses.Count(),
                TotalDoctors = _db.Doctors.Count(),
                TotalEBooks = _db.EBooks.Count(),
                TotalBillings = _db.Payments.Count(),
                TotalUsers = _db.Users.Count()
            };
            return View(model);
        }
        public IActionResult LoadSection(string section)
        {
            try
            {
                switch (section)
                {
                    case "MedicineManage": return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                    case "Vendors": return PartialView("~/Views/Vendors/VendorsManage.cshtml", _db.Vendors.ToList());
                    case "Courses": return PartialView("~/Views/Admin/Courses.cshtml", _db.Courses.ToList());
                    case "EBooks": return PartialView("~/Views/Admin/EBooks.cshtml", _db.EBooks.ToList());
                    case "Billings": return PartialView("~/Views/Admin/Billings.cshtml", _db.Payments.ToList());
                    case "Doctors": return PartialView("~/Views/Admin/Doctors.cshtml", _db.Doctors.ToList());
                    case "CreateMedicine": return PartialView("~/Views/Medicine/AddMedicine.cshtml");
                    case "CreateVendor": return PartialView("~/Views/Vendors/AddVendor.cshtml");
                    default: return Content("Section not found.");
                }
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
        // Medicine Management
        // Medicine Create.
        [HttpPost]
        public async Task<ActionResult> AddMedicine(Medicine medicine)
        {
            try
            {
                medicine.ID = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                ModelState.Remove(nameof(medicine.ID));
                ModelState.Remove(nameof(medicine.UserID));
                ModelState.Remove(nameof(medicine.VendorID));
                ModelState.Remove(nameof(medicine.Image));
                ModelState.Remove(nameof(medicine.MedicinePhoto));
                if (ModelState.IsValid)
                {
                    var medicieAddResult = await _medicineService.AddNewMedicine(medicine);
                    if (medicieAddResult.IsSuccess)
                    {
                        return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                    }
                    else
                    {
                        return Json(new { success = false, message = medicieAddResult.message });
                    }
                }
                else
                {
                    return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<IActionResult> DeleteMedicine(string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _medicineService.DeleteMedicineAsync(id);
                    if (result)
                    {
                        return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditMedicine(string id)
        {
            try
            {
                Medicine model = await _medicineService.GetMedicineAsync(id);
                if (model != null)
                {
                    return PartialView("~/Views/Medicine/EditMedicine.cshtml", model);
                }
                else
                {
                    return PartialView("~/Views/Medicine/EditMedicine.cshtml", new Medicine());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditMedicine(Medicine model)
        {
            try
            {
                ModelState.Remove(nameof(model.ID));
                ModelState.Remove(nameof(model.UserID));
                ModelState.Remove(nameof(model.VendorID));
                ModelState.Remove(nameof(model.Image));
                ModelState.Remove(nameof(model.MedicinePhoto));
                model.UserID = string.Empty;
                model.VendorID = string.Empty;
                if (ModelState.IsValid)
                {
                    var result = await _medicineService.EditMedicineAsync(model);
                    if (result)
                    {
                        return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    return PartialView("~/Views/Medicine/MedicineManage.cshtml", _db.Medicines.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicine(string id)
        {
            try
            {
                Medicine medicine = await _medicineService.GetMedicineAsync(id);
                if (medicine != null)
                {
                    return PartialView("~/Views/Medicine/AdminMedicineView.cshtml", medicine);
                }
                else
                {
                    return PartialView("~/Views/Medicine/AdminMedicineView.cshtml", new Medicine());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        // Vendor Management
        // Vendore Section. Create, Delete, Update, Read by admin.
        public async Task<ActionResult> AddVendor(Vendor vendor)
        {
            try
            {
                vendor.VendorId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                ModelState.Remove(nameof(vendor.VendorId));
                if (ModelState.IsValid)
                {
                    var vendorAddResult = await _vendorervice.AddNewVendor(vendor);
                    if (vendorAddResult.IsSuccess)
                    {
                        return PartialView("~/Views/Vendors/VendorsManage.cshtml", _db.Vendors.ToList());
                    }
                    else
                    {
                        return Json(new { success = false, message = vendorAddResult.message });
                    }
                }
                else
                {
                    return PartialView("~/Views/Vendors/VendorsManage.cshtml", _db.Vendors.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditVendor(string Id)
        {
            try
            {
                Vendor model = await _vendorervice.GetVendor(Id);
                if (model != null)
                {
                    return PartialView("~/Views/Vendors/EditVendor.cshtml", model);
                }
                else
                {
                    return PartialView("~/Views/Vendors/EditVendor.cshtml", new Medicine());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditVendor(Vendor model)
        {
            try
            {
                ModelState.Remove(nameof(model.VendorId));
                if (ModelState.IsValid)
                {
                    var result = await _vendorervice.EditVendorAsync(model);
                    if (result)
                    {
                        return PartialView("~/Views/Vendors/VendorsManage.cshtml", _db.Vendors.ToList());
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    return PartialView("~/Views/Vendors/VendorsManage.cshtml", _db.Vendors.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
