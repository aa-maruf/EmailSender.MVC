using EmailSender.MVC.Data;
using EmailSender.MVC.Models;
using EmailSender.MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly EmployeeDBContext _context;
        public UserController(EmployeeDBContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();

                    EmailSenderClass emailSender = new EmailSenderClass();
                    var success = emailSender.SendEmail(user.email, user.name);

                    if (success)
                    {
                        ViewBag.Message = "OTP sent successfully.";
                    }
                    else
                    {
                        ViewBag.Error = "Failed to send OTP.";
                    }

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
            }
            return View();
        }



    }
}
