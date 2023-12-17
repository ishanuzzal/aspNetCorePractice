using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContexts studentsDB;
        public HomeController(ILogger<HomeController> logger, StudentDbContexts s)
        {
            _logger = logger;
            this.studentsDB = s;
        }

        [Route("~/")]
        [Route("~/Home")]
        public IActionResult Index()
        {
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
                   await studentsDB.Students.AddAsync(st);
                   await studentsDB.SaveChangesAsync();
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
       
        public async Task<IActionResult> Display()
        {
            var st = await studentsDB.Students.ToListAsync();
            return View(st);
        }

        public async Task<String> Details(int id)
        {
            var st = await studentsDB.Students.FirstOrDefaultAsync(x=>id==x.Id);
            return "Id: "+st.Id+" name: "+st.Name;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var st = await studentsDB.Students.FirstOrDefaultAsync(x => id == x.Id);
            if (st != null)
            {
                studentsDB.Students.Remove(st);
                await studentsDB.SaveChangesAsync();
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
            TempData["d3"] = 24;
            TempData.Keep("d3");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

