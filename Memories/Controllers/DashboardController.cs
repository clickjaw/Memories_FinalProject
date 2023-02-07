using System;
using Memories.Data;
using Memories.Repository;
using Memories.Interfaces;
using Memories.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Memories.Controllers
{
	public class DashboardController:Controller
	{
		private readonly IDashboardRepository  _dashboardRepository;

		public DashboardController(IDashboardRepository dashboardRepository)
		{
			_dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Index()
		{
            var userFamilyMembers = await _dashboardRepository.GetAllUserFamilyMembers();
            var userFamilies = await _dashboardRepository.GetAllUserFamilies();
            var dashboardViewModel = new DashboardViewModel()
            {
                FamilyMembers = userFamilyMembers,
                Families = userFamilies
            };
            return View(dashboardViewModel);
        }
    }
}

