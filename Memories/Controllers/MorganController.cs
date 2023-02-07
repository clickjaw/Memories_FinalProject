using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memories.Data;
using Memories.Interfaces;
using Memories.Models;
using Memories.Repository;
using Memories.Services;
using Memories.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Memories.Controllers
{
    public class MorganController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public MorganController(ApplicationDbContext context, IFamilyMemberRepository familyMemberRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {

            _context = context;
            _familyMemberRepository = familyMemberRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<FamilyMember> familyMembers = await _familyMemberRepository.GetAll();
            return View(familyMembers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            FamilyMember familyMember = await _familyMemberRepository.GetByIdAsync(id);
            return View(familyMember);
        }


        public IActionResult Create()
        {

            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createMemberViewModel = new CreateFamilyMemberViewModel { ApplicationUserId = curUserId };
            return View(createMemberViewModel);

            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFamilyMemberViewModel familyMemberVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(familyMemberVM.MemberImage);

                var familyMember = new FamilyMember
                {
                    FirstName = familyMemberVM.FirstName,
                    LastName = familyMemberVM.LastName,
                    ApplicationUserId = familyMemberVM.ApplicationUserId,

                    MemberImage = result.Url.ToString(),
                };

                _familyMemberRepository.Add(familyMember);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Upload Failed");
            }

            return View(familyMemberVM);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var familyDetails = await _familyMemberRepository.GetByIdAsync(id);
            if (familyDetails == null) return View("Error");
            return View(familyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            var familyDetails = await _familyMemberRepository.GetByIdAsync(id);

            if (familyDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(familyDetails.MemberImage))
            {
                _ = _photoService.DeletePhotoAsync(familyDetails.MemberImage);
            }

            _familyMemberRepository.Delete(familyDetails);
            return RedirectToAction("Index");
        }


    }
}