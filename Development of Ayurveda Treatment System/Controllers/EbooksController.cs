using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;
using System.Threading.Tasks;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class EbooksController : Controller
    {
        public EbookService _ebookService;
        private readonly AyurgrowDBContext _db;
        public EbooksController(EbookService ebookService, AyurgrowDBContext context)
        {
            _ebookService = ebookService;
            _db = context;
        }
        [HttpGet]
        public IActionResult AddEbooks()
        {
            var model = new EBooks(); // empty model
            return PartialView("~/Views/Ebooks/AddEbooks.cshtml", model); // return PartialView if loading via AJAX
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEbooks(EBooks model)
        {
            model.BookId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            ModelState.Remove(nameof(model.BookId));
            if (ModelState.IsValid)
            {
                // Save logic here
                var result = await _ebookService.AddNewBook(model);
                if (result.IsSuccess)
                {
                    return PartialView("~/Views/Ebooks/AdminEbooks.cshtml", _db.EBooks.ToList());
                }
                else
                {
                    return Json(new { success = false, message = result.message });
                }
            }
            else
            {
                return Json(new { success = false });
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditEbooks(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                // Save logic here
                var model = await _ebookService.GetEbook(id);
                if (model != null)
                {
                    return PartialView("~/Views/Ebooks/EditEbooks.cshtml", model);
                }
                else
                {
                    return Json(new { success = false, message = "Ebook not exists!" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Id not found" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditEbooks(EBooks eBooks)
        {
            ModelState.Remove(nameof(eBooks.BookId));
            if (ModelState.IsValid)
            {
                if (eBooks == null)
                {
                    return Json(new { success = false, message = "model is null." });
                }
                // Save logic here
                var result = await _ebookService.EditEbook(eBooks);
                if (result.IsSuccess)
                {
                    return PartialView("~/Views/Ebooks/AdminEbooks.cshtml", _db.EBooks.ToList());
                }
                else
                {
                    return Json(new { success = false, message = result.message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Id not found" });
            }
        }
        public async Task<IActionResult> DeleteEbooks(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var result = await _ebookService.DeleteEbook(id);
                if (result.IsSuccess)
                {
                    return PartialView("~/Views/Ebooks/AdminEbooks.cshtml", _db.EBooks.ToList());
                }
                else
                {
                    return Json(new { success = result.IsSuccess, message = result.message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Id not found." });
            }
        }
    }
}
