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
    public class FamilyMemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IPhotoService _photoService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FamilyMemberController(ApplicationDbContext context, IFamilyMemberRepository familyMemberRepository, IPhotoService photoService)
        {

            _context = context;
            _familyMemberRepository = familyMemberRepository;
            _photoService = photoService;
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
            return View();
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
                    LastName=familyMemberVM.LastName,

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


    }
}