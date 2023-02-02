using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Memories.Controllers
{
    public class FamilyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}