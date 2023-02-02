using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memories.Data;
using Microsoft.AspNetCore.Mvc;

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
            var families = _context.Families.ToList();
            return View(families);
        }
    }
}