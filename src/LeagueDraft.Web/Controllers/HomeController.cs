using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LeagueDraft.Web.ViewModels;
using LeagueDraft.Data;
using LeagueDraft.Models;
using LeagueDraft.Services.Interfaces;

namespace LeagueDraft.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChampionService championService;

        public HomeController(ILogger<HomeController> logger, IChampionService championService)
        {
            _logger = logger;
            this.championService = championService;
        }

        public async Task<IActionResult> Index()
        {
            var allChampions = await this.championService.GetAllChampionsAsync();

            var listedViewModel = new List<AllChampionsViewModel>();

            foreach (var champion in allChampions)
            {
                var viewModel = new AllChampionsViewModel();

                viewModel.Id = champion.Id;
                viewModel.Name = champion.Name;
                viewModel.ImageUrl = champion.ImageUrl;

                listedViewModel.Add(viewModel);
            }

            return View(listedViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
