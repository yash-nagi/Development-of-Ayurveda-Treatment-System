using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly AyurgrowDBContext _db;
        public AdminController(AyurgrowDBContext db)
        {
            _db = db;
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
            switch (section)
            {
                case "Medicine": return PartialView("~/Views/Admin/Medicine.cshtml", _db.Medicines.ToList());
                case "Vendors": return PartialView("~/Views/Admin/Vendors.cshtml", _db.Vendors.ToList());
                case "Courses": return PartialView("~/Views/Admin/Courses.cshtml", _db.Courses.ToList());
                case "EBooks": return PartialView("~/Views/Admin/EBooks.cshtml", _db.EBooks.ToList());
                case "Billings": return PartialView("~/Views/Admin/Billings.cshtml", _db.Payments.ToList());
                case "Doctors": return PartialView("~/Views/Admin/Doctors.cshtml", _db.Doctors.ToList());
                default: return Content("Section not found.");
            }
        }
    }
}
