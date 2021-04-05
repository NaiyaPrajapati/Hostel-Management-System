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
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public ComplaintController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult AddComplaint()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComplaint(Complaint c)
        {
            if (ModelState.IsValid)
            {
               Complaint cl=new Complaint
                {
                    id = c.id,
                    Name = c.Name,
                    Subject = c.Subject,
                    Description = c.Description
                };

                _context.Add(cl);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();


        }
       
        [HttpGet]
        public async Task<IActionResult> DeleteComplaint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Complaint cl = await _context.Complaint.FindAsync(id);
            if (cl == null)
            {
                return NotFound();
            }

            return View(cl);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var cl = await _context.Complaint.FindAsync(id);
            _context.Complaint.Remove(cl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewComplaint));
        }
        public IActionResult ViewComplaint()
        {
            return View(_context.Complaint.ToList());
        }
    }
}
