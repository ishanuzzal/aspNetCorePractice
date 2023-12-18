using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Repository;
using Microsoft.AspNetCore.Http;

namespace WebApplication2.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContexts studentsDBContext;
        public HomeController(ILogger<HomeController> logger, StudentDbContexts s)
        {
            _logger = logger;
            this.studentsDBContext = s;
        }

        [Route("~/")]
        [Route("~/Home")]
        public IActionResult Index()
        {
            string? s = HttpContext.Session.GetString("user");
            if (s == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(); 
        }
        [Route("~/Home")]
        [HttpPost]
        public async Task<IActionResult> Index(StudentModel st)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   await studentsDBContext.Students.AddAsync(st);
                   await studentsDBContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                return RedirectToAction("Display", "Home");
            }
            //return RedirectToAction("Privacy", "Home");
            return View(st);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            var validUser = studentsDBContext.Users.Where(x=>(x.UserName==user.UserName) && x.Password==user.Password).FirstOrDefault();
            if (validUser != null)
            {
                HttpContext.Session.SetString("user", user.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = user;
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Display()
        {
            var st = await studentsDBContext.Students.ToListAsync();
            return View(st);
        }

        public async Task<String> Details(int id)
        {
            var st = await studentsDBContext.Students.FirstOrDefaultAsync(x=>id==x.Id);
            return "Id: "+st.Id+" name: "+st.Name;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var st = await studentsDBContext.Students.FirstOrDefaultAsync(x => id == x.Id);
            if (st != null)
            {
                studentsDBContext.Students.Remove(st);
                await studentsDBContext.SaveChangesAsync();
                return RedirectToAction("Display", "Home");
            }
            return NotFound();
            
        }


        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult About()
        {
            ViewData["d1"] = "data1";
            ViewBag.d2 = new List<int>(){1,2,3,4};
            if (HttpContext.Session.GetString("key") != null)
            {
                ViewBag.key = HttpContext.Session.GetString("key");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

