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
    public class NoticeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public NoticeController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult AddNotice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotice(Notice n)
        {
            if (ModelState.IsValid)
            {
                Notice nc = new Notice                
                {
                    id=n.id,
                    Date=n.Date,
                    Title=n.Title,
                    Description=n.Description
                };

                _context.Add(nc);
                _context.SaveChanges();
                return RedirectToAction("ViewNotice", "Notice");
            }
            return View();


        }
        [HttpGet]
        public async Task<IActionResult> UpdateNotice(int? id)
        {
            Notice nc = await _context.Notice.FindAsync(id);

            if (nc == null)
            {
                return NotFound();
            }

            return View(nc);
        }
        [HttpPost]

        public async Task<IActionResult> UpdateNotice(Notice nc)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nc);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(ViewNotice));
            }

            return View(nc);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteNotice(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Notice nc = await _context.Notice.FindAsync(id);
            if (nc == null)
            {
                return NotFound();
            }

            return View(nc);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteNotice(int id)
        {
            var nc = await _context.Notice.FindAsync(id);
            _context.Notice.Remove(nc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewNotice));
        }
        public IActionResult ViewNotice()
        {
            return View(_context.Notice.ToList());
        }
        public IActionResult ViewNoticeStudent()
        {
            return View(_context.Notice.ToList());
        }
    }
}
