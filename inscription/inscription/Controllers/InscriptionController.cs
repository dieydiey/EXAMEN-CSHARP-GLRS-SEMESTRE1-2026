using Microsoft.AspNetCore.Mvc;
using inscription.Data;
using inscription.Services.Interfaces;

namespace inscription.Controllers
{
    public class InscriptionController : Controller
    {
        private readonly IInscriptionServiceInterface _service;
        private readonly AppDbContext _context;

        public InscriptionController(
            IInscriptionServiceInterface service,
            AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Etudiants = _context.Etudiants.ToList();
            ViewBag.Classes = _context.Classes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(int etudiantId, int classeId)
        {
            _service.Inscrire(etudiantId, classeId);
            return RedirectToAction("Index", new { classeId });
        }

        public IActionResult Index(int classeId)
        {
            var inscriptions = _service.ListerParClasse(classeId);
            return View(inscriptions);
        }
    }
}
