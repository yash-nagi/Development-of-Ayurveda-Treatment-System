using Development_of_Ayurveda_Treatment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly AyurgrowDBContext _db;
        // GET: FeedbackController
        public FeedbackController(AyurgrowDBContext dBContext)
        {
            _db = dBContext;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Feedback(Feedback feedback)
        {
            ModelState.Remove(nameof(feedback.FeedbackId));
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }
        
            try
            {
                feedback.FeedbackId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                _db.Feedbacks.Add(feedback);
                await _db.SaveChangesAsync();
        
                TempData["Message"] = "Thank you for your feedback!";
                return RedirectToAction("Feedback");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while submitting your feedback. Please try again.");
                return View(feedback);
            }
        }
    }
}
