using BLL;
using DAL;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace JobNest.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        ApplicationService service = new ApplicationService();

        // returns the view for list of applications
        public IActionResult Index()
        {
            return View();
        }

        // gets the applications and passes it to view
        [HttpGet]
        public IActionResult GetApplications()
        {
            var applications = service.GetApplicationsService();
            return Json(applications);
        }

        // returns the view for job listings
        public IActionResult Jobs()
        {
            return View();
        }

        // gets the jobs posted by employer and passes it to view
        [HttpGet]
        public IActionResult GetJobs()
        {
            //*********
            JobRepository jobRepository = new JobRepository();
            List<Job> jobs = jobRepository.GetJobs();
            return Json(jobs);
        }

        private readonly UserManager<IdentityUser> _userManager;

        public ApplicationController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IdentityUser CurrentUser { get; set; }

        // returns the view to allow user apply for a job
        public async Task<IActionResult> CreateApplication(int jobId)
        {
            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser == null)
            {
                return RedirectToAction("Index");
            }

            var userEmail = CurrentUser.Email;

            TempData["JobId"] = jobId;
            TempData["UserEmail"] = userEmail;
            TempData.Keep();
            return View();
        }

        // posts an application information to repository
        [HttpPost]
        public IActionResult CreateApplication([FromBody] Entities.Entities.Application applicationFormData)
        {
            var response = service.AddApplicationService(applicationFormData);
            return Json(response);
        }

        // handles deleting an application
        [HttpPost]
        public JsonResult DeleteApplication(int applicationId)
        {
            if (service.DeleteApplicationService(applicationId))
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}
