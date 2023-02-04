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
        private readonly IFamilyRepository _familyRepository;

        public FamilyController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
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
    }
}