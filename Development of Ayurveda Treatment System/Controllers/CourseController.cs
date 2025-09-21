using Microsoft.AspNetCore.Mvc;
using Development_of_Ayurveda_Treatment_System.Models;
using Development_of_Ayurveda_Treatment_System.Services;

namespace Development_of_Ayurveda_Treatment_System.Controllers
{
    public class CourseController : Controller
    {
        private readonly AyurgrowDBContext _db;
        public CourseService _courseService;
        public CourseController(AyurgrowDBContext db, CourseService courseService)
        {
            _db = db;
            _courseService = courseService;
        }
        // GET: CourseController
        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            try
            {
                course.CourseId = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
                ModelState.Remove(nameof(course.CourseId));
                if (ModelState.IsValid)
                {
                    var courseAddResult = await _courseService.AddNewCourse(course);
                    if (courseAddResult.IsSuccess)
                    {
                        return PartialView("~/Views/Courses/CourseManage.cshtml", _db.Courses.ToList());
                    }
                    else
                    {
                        return Json(new { success = false, message = courseAddResult.message });
                    }
                }
                else
                {
                    return PartialView("~/Views/Courses/CourseManage.cshtml", _db.Courses.ToList());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            try
            {
                var result = await _courseService.DeleteCourse(id);
                if (result)
                {
                    return Json(new { success = true });
                    //return PartialView("~/Views/Courses/CourseManage.cshtml", _db.Courses.ToList());
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
                //return View(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditCourse(string id)
        {
            try
            {
                Course model = await _courseService.GetCourse(id);
                if (model != null)
                {
                    return PartialView("~/Views/Courses/EditCourse.cshtml", model);
                }
                else
                {
                    return PartialView("~/Views/Courses/EditCourse.cshtml", new Course());
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(Course model)
        {
            try
            {
                ModelState.Remove(nameof(model.CourseId));
                if (ModelState.IsValid)
                {
                    var result = await _courseService.EditCourseAsync(model);
                    if (result)
                    {
                        //return Json(new { success = true });
                        return PartialView("~/Views/Courses/CourseManage.cshtml", _db.Courses.ToList());
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    //return Json(new { success = true });
                    return PartialView("~/Views/Courses/CourseManage.cshtml", _db.Courses.ToList());
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
                //return View(ex);
            }
        }
        public IActionResult CourseDetails(string id)
        {
            var course = _db.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course == null) return NotFound();
            return PartialView("~/Views/Courses/CourseDetails.cshtml", course); // Partial view for AJAX
        }
        public IActionResult Course()
        {
            var courses = _db.Courses.ToList();
            if (courses== null) return NotFound();
            return PartialView("~/Views/Courses/Courses.cshtml", courses); // Partial view for AJAX
        }
    }
}
