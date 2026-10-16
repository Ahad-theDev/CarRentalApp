using Microsoft.AspNetCore.Mvc;
using CarRentalApp.Models;

namespace CarRentalApp.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> avaiableCars = new List<Car>
        {
            new Car {Id =1,Name="Alto",PricePerDay=3000m},
            new Car {Id =2,Name="Corolla",PricePerDay=6000m},
            new Car {Id =3,Name="Civic",PricePerDay=8000m},
        };
        private static List<Car> bookedCars = new List<Car>();
        [HttpGet]
        public IActionResult Index()
        {
            return View(avaiableCars);
        }
        [HttpPost]
        public IActionResult Book(int id)
        {
            var car = avaiableCars.FirstOrDefault(c=>c.Id == id);
            if (car == null)
            {
                return RedirectToAction("Index");
            }
            avaiableCars.Remove(car);
            bookedCars.Add(car);
            return RedirectToAction("Booked");
        }
        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}