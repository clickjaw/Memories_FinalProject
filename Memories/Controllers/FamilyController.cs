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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FamilyController(ApplicationDbContext context, IFamilyRepository familyRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            
            _context = context;
            _familyRepository = familyRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Family> families = await _familyRepository.GetAll();
            return View(families);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Family family = await _familyRepository.GetByIdAsync(id);
                return View(family);
        }


        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createFamilyViewModel = new CreateFamilyViewModel { ApplicationUserId = curUserId };
            return View(createFamilyViewModel);

            //If it never works just delete ApplicationUserId and use return View()

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
                    ApplicationUserId = familyVM.ApplicationUserId
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

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var familyDetails = await _familyRepository.GetByIdAsync(id);
            if (familyDetails == null) return View("Error");
            return View(familyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            var familyDetails = await _familyRepository.GetByIdAsync(id);

            if (familyDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(familyDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(familyDetails.Image);
            }

            _familyRepository.Delete(familyDetails);
            return RedirectToAction("Index");
        }



    }
}