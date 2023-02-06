using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memories.Data;
using Memories.Interfaces;
using Memories.Models;
using Memories.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Memories.Controllers
{
    public class FamilyMemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFamilyMemberRepository _familyMemberRepository;

        public FamilyMemberController(ApplicationDbContext context, IFamilyMemberRepository familyMemberRepository)
        {
            _context = context;
            _familyMemberRepository = familyMemberRepository;
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

        //public IActionResult Detail(int id)
        //{
        //    FamilyMember familyMember = _context.FamilyMembers.FirstOrDefault(f => f.Id == id);
        //    return View(familyMember);
        //}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FamilyMember familyMember)
        {
            if (ModelState.IsValid)
            {
                _familyMemberRepository.Add(familyMember);
                return RedirectToAction("Index");
            }

            return View(familyMember);
        }


    }
}