using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memories.Data;
//using Memories.Interfaces;
using Memories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Memories.Controllers
{
    public class FamilyController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FamilyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var family = _context.Families.ToList();
            return View(family);
        }

        public IActionResult Detail(int id)
        {
            Family family = _context.Families.FirstOrDefault(f => f.Id == id);
            return View(family);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Family family)
        {

            if (!ModelState.IsValid)
            {
                return View(family);
            }

            _context.Add(family);
            //_context.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public IActionResult Create(Family family)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(family);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(family);
        //    }
        //}




        //private readonly IFamilyRepository _familyRepository;

        //public FamilyController(IFamilyRepository familyRepository)
        //{
        //    _familyRepository = familyRepository;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    IEnumerable<Family> families = await _familyRepository.GetAll();
        //    return View(families);
        //}

        //public async Task<IActionResult> Detail(int id)
        //{
        //    Family family = await _familyRepository.GetByIdAsync(id);
        //    return View(family);
        //}
    }
}