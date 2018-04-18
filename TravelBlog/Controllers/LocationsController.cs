using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        private TravelDbContext db = new TravelDbContext();
        public IActionResult Index()
        {
            List<Location> model = db.Locations.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(Locations => Locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(Locations => Locations.LocationId == id);
            return View(thisLocation);
        }

        public IActionResult Delete(int id) 
        {
            var thisLocation = db.Locations.FirstOrDefault(Locations => Locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id) 
        {
            var thisLocation = db.Locations.FirstOrDefault(Locations => Locations.LocationId == id);
            db.Locations.Remove(thisLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
