using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memories.Data;
using Memories.Interfaces;
using Memories.Models;
using Memories.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Memories.Controllers
{
    public class FamilyController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IFamilyRepository _familyRepository;
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FamilyController(ApplicationDbContext context, IFamilyRepository familyRepository, IPhotoService photoService)
        {

            _context = context;
            _familyRepository = familyRepository;
            _photoService = photoService;
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


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFamilyViewModel familyVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(familyVM.Image);

                var family = new Family
                {
                    FamilyName = familyVM.FamilyName,
                    Image = result.Url.ToString(),
                };

                _familyRepository.Add(family);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Upload Failed");
            }

            return View(familyVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var family = await _familyRepository.GetByIdAsync(id);
            if (family == null) return View("Error");
            var familyVM = new EditFamilyViewModel
            {
                FamilyName = family.FamilyName,
                URL = family.Image,
                FamilyCategory = family.FamilyCategory
            };
            return View(familyVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditFamilyViewModel familyVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", familyVM);
            }

            var userFamily = await _familyRepository.GetByIdAsyncNoTracking(id);

            if (userFamily == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(familyVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(familyVM);
            }

            if (!string.IsNullOrEmpty(userFamily.Image))
            {
                _ = _photoService.DeletePhotoAsync(userFamily.Image);
            }

            var family = new Family
            {
                Id = id,
                FamilyName = familyVM.FamilyName,
                Image = photoResult.Url.ToString(),
               
            };

            _familyRepository.Update(family);

            return RedirectToAction("Index");
        }



    }
}