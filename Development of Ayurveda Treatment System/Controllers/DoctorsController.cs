using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AyurgrowDBContext _db;
        private readonly DoctorsService _doctorsService;
        public DoctorsController(AyurgrowDBContext db, DoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
            _db = db;
        }
        // GET: DoctorsController
        [HttpGet]
        public ActionResult AddDoctor()
        {
            return PartialView("~/Views/Doctors/AddDoctors.cshtml", new Doctor());
        }

    }
}
