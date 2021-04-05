using HostelManagementSystem.Data;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HostelManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        
      
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetPass()
        {
            return View();
        }
        [HttpPost]
         public IActionResult GetPass(GetPass gp)
        {
            if (ModelState.IsValid)
            {
                GetPass g = new GetPass
                {
                    StudentId = gp.StudentId,
                    Name = gp.Name,
                    Place = gp.Place,
                    Dept_date = gp.Dept_date,
                    Arrival_date=gp.Arrival_date
                    
                    
                };

                _context.Add(g);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();

            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGetPass(int? id)
        {
            GetPass gp = await _context.GetPass.FindAsync(id);

            if (gp == null)
            {
                return NotFound();
            }

            return View(gp);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateGetPass(GetPass gp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gp);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(gp);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGetPass(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            GetPass gp = await _context.GetPass.FindAsync(id);
            if (gp == null)
            {
                return NotFound();
            }

            return View(gp);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteGetPass(int id)
        {
            var gp = await _context.GetPass.FindAsync(id);
            _context.GetPass.Remove(gp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewGetPass()
        {
            return View(_context.GetPass.ToList());
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
