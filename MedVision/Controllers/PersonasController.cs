using MedVision.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedVision.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContest _context;

        public PersonasController(ApplicationDbContest context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(persona);
        }
    }
}