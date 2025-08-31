using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class EbooksController : Controller
    {
        [HttpGet]
        public IActionResult AddEbooks()
        {
            var model = new EBooks(); // empty model
            return PartialView(model); // return PartialView if loading via AJAX
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEbooks(EBooks model)
        {
            if (ModelState.IsValid)
            {
                // Save logic here
                return RedirectToAction("ManageEbooks");
            }
            return PartialView(model);
        }
    }
}
