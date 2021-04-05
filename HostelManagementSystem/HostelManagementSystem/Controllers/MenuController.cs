using HostelManagementSystem.Data;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostelManagementSystem.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public MenuController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult AddMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMenu(Menu m)
        {
            if (ModelState.IsValid)
            {
                Menu mn = new Menu
                {
                    id=m.id,
                    Date=m.Date,
                    BreakFastItem1=m.BreakFastItem1,
                    BreakFastItem2=m.BreakFastItem2,
                    BreakFastItem3=m.BreakFastItem3,
                    LunchItem1=m.LunchItem1,
                    LunchItem2=m.LunchItem2,
                    LunchItem3=m.LunchItem3,
                    LunchItem4=m.LunchItem4,
                    LunchItem5=m.LunchItem5,
                    LunchItem6=m.LunchItem6,
                    DinnerItem1=m.DinnerItem1,
                    DinnerItem2=m.DinnerItem2,
                    DinnerItem3=m.DinnerItem3,
                    DinnerItem4=m.DinnerItem4,
                    DinnerItem5=m.DinnerItem5 
                };

                _context.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("ViewMenu", "Menu");
            }
            return View();


        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenu(int? id)
        {
            Menu m = await _context.Menu.FindAsync(id);

            if (m == null)
            {
                return NotFound();
            }

            return View(m);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateMenu(Menu m)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(m);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(ViewMenu));
            }

            return View(m);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMenu(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Menu m = await _context.Menu.FindAsync(id);
            if (m == null)
            {
                return NotFound();
            }

            return View(m);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var m = await _context.Menu.FindAsync(id);
            _context.Menu.Remove(m);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewMenu));
        }
        public IActionResult ViewMenu()
        {
            return View(_context.Menu.ToList());
        }
        public IActionResult ViewMenuStudent()
        {
            return View(_context.Menu.ToList());
        }
    }
}
