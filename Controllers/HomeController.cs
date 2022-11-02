using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using TestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Page(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.id = id;
            return View(db.Markets.ToList());
        }
        [HttpGet]
        public IActionResult Change(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.id = id;
            return View(db.Markets.ToList());
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Market mk = await db.Markets.FirstOrDefaultAsync(p => p.Id == id);
                if (db != null)
                {
                    ViewBag.id = id;
                    return View(db.Markets.ToList());
                }
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Change(Market mk)
        {
            db.Markets.Update(mk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(Market mk)
        {
            db.Markets.Add(mk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Market mk = await db.Markets.FirstOrDefaultAsync(p => p.Id == id);
                if (mk != null)
                {
                    db.Markets.Remove(mk);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        MarketContext db;
        public HomeController(MarketContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Markets.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}