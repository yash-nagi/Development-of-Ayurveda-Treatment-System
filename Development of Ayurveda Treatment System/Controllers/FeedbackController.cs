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
            if (string.IsNullOrWhiteSpace(feedback.Name) ||
            string.IsNullOrWhiteSpace(feedback.Email) ||
            string.IsNullOrWhiteSpace(feedback.Message))
            {
                return Json(new { success = false, message = "All fields are required." });
            }

            ModelState.Remove(nameof(feedback.FeedbackId));

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid feedback data. Please try again." });
            }

            try
            {
                feedback.FeedbackId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                _db.Feedbacks.Add(feedback);
                await _db.SaveChangesAsync();

                return Json(new { success = true, message = "Thank you for your feedback!" });
            }
            catch
            {
                return Json(new { success = false, message = "An error occurred while submitting feedback. Please try again." });
            }
        }
    }
}
