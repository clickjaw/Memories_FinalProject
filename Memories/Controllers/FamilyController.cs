using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memories.Data;
using Memories.Interfaces;
using Memories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Memories.Controllers
{
    public class FamilyController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IFamilyRepository _familyRepository;

        public FamilyController(ApplicationDbContext context, IFamilyRepository familyRepository)
        {

            _context = context;
            _familyRepository = familyRepository;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Family> families = await _familyRepository.GetAll();
            return View(families);
        }

        //public IActionResult Index()
        //{
        //    var family = _context.Families.ToList();
        //    return View(family);
        //}

        public async Task<IActionResult> Detail(int id)
        {
            Family family = await _familyRepository.GetByIdAsync(id);
                return View(family);
        }

        //public IActionResult Detail(int id)
        //{
        //    Family family = _context.Families.FirstOrDefault(f => f.Id == id);
        //    return View(family);
        //}

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Family family)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(family);
        //    }
        //    _familyRepository.Add(family);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Family family)
        {
            if (ModelState.IsValid)
            {
                _familyRepository.Add(family);
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("","It fucked up");
            }

            return View(family);
        }


    }
}