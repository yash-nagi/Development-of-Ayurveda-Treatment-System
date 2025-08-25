using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly AyurgrowDBContext _db;
        public MedicineService _medicineService;
        public AdminController(AyurgrowDBContext db, MedicineService medicineService)
        {
            _db = db;
            _medicineService = medicineService;
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
                    case "Vendors": return PartialView("~/Views/Admin/Vendors.cshtml", _db.Vendors.ToList());
                    case "Courses": return PartialView("~/Views/Admin/Courses.cshtml", _db.Courses.ToList());
                    case "EBooks": return PartialView("~/Views/Admin/EBooks.cshtml", _db.EBooks.ToList());
                    case "Billings": return PartialView("~/Views/Admin/Billings.cshtml", _db.Payments.ToList());
                    case "Doctors": return PartialView("~/Views/Admin/Doctors.cshtml", _db.Doctors.ToList());
                    case "CreateMedicine": return PartialView("~/Views/Medicine/AddMedicine.cshtml");
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
        public async Task<IActionResult> GetMedicineAsync(string id)
        {
            try
            {
                Medicine medicine = await _medicineService.GetMedicineAsync(id);
                if (medicine != null)
                {
                    return PartialView("~/Views/Medicine/EditMedicineView.cshtml", medicine);
                }
                else
                {
                    return PartialView("~/Views/Medicine/EditMedicineView.cshtml", new Medicine());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
