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
    public class FamilyMemberController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyMemberController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var familyMembers = _context.FamilyMembers.ToList();
            return View(familyMembers);
        }

        public IActionResult Detail(int id)
        {
            FamilyMember familyMember = _context.FamilyMembers.FirstOrDefault(f => f.Id == id);
            return View(familyMember);
        }

        public IActionResult Create()
        {
            return View();
        }

        


        //private readonly IFamilyMemberRepository _familyMemberRepository;

        //public FamilyMemberController(IFamilyMemberRepository familyMemberRepository)
        //{
        //    _familyMemberRepository = familyMemberRepository;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    IEnumerable<FamilyMember> familyMembers = await _familyMemberRepository.GetAll();
        //    return View(familyMembers);
        //}

        //public async Task<IActionResult> Detail(int id)
        //{
        //    FamilyMember familyMember = await _familyMemberRepository.GetByIdAsync(id);
        //    return View(familyMember);
        //}
    }
}