using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueDraft.Common.Constants;
using LeagueDraft.Services.Interfaces;
using LeagueDraft.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LeagueDraft.Web.Controllers
{
    public class DraftController : Controller
    {
        private readonly IChampionService championService;
        private readonly IItemService itemService;
        private readonly IPositionService positionService;
        private readonly ISummonerSpellService summonerSpellService;

        public DraftController(IChampionService championService,
            IItemService itemService,
            IPositionService positionService,
            ISummonerSpellService summonerSpellService)
        {
            this.championService = championService;
            this.itemService = itemService;
            this.positionService = positionService;
            this.summonerSpellService = summonerSpellService;
        }


        [Route("/soloDraft")]
        public async Task<IActionResult> MakeSoloDraft()
        {
            var champion = await this.championService.GetRandomChampionAsync();

            var build = await this.itemService.GetRandomBuildAsync();

            var position = await this.positionService.GetRandomPositionAsync();

            var summonerSpells = await this.summonerSpellService.GetRandomSummonerSpellsAsync();

            if (PositionConstants.Jungle.Equals(position.Name))
            {
                build = await this.itemService.GetRandomJungleBuildAsync();
                summonerSpells = await this.summonerSpellService.GetJunglerSummonerSpellsAsync();
            }
            else if (PositionConstants.Support.Equals(position.Name))
            {
                build = await this.itemService.GetRandomSupportBuildAsync();
            }

            var draftViewModel = new DraftViewModel()
            {
                Champion = champion,
                Build = build,
                Position = position,
                SummonerSpells = summonerSpells
            };

            return this.View(draftViewModel);
        }

        [Route("/champion/{id}")]
        public async Task<IActionResult> MakeDraftByChampion(int id)
        {
            var champion = await this.championService.GetChampionByIdAsync(id);

            if (champion == null)
            {
                return StatusCode(404);
            };

            var build = await this.itemService.GetRandomBuildAsync();

            var position = await this.positionService.GetRandomPositionAsync();

            var summonerSpells = await this.summonerSpellService.GetRandomSummonerSpellsAsync();

            if (PositionConstants.Jungle.Equals(position.Name))
            {
                build = await this.itemService.GetRandomJungleBuildAsync();
                summonerSpells = await this.summonerSpellService.GetJunglerSummonerSpellsAsync();
            }
            else if (PositionConstants.Support.Equals(position.Name))
            {
                build = await this.itemService.GetRandomSupportBuildAsync();
            }

            var draftViewModel = new DraftViewModel()
            {
                Champion = champion,
                Build = build,
                Position = position,
                SummonerSpells = summonerSpells
            };

            return this.View(draftViewModel);
        }

        [Route("/positions")]
        public async Task<IActionResult> AllPositions()
        {
            var allPositions = await this.positionService.GetAllPositionsAsync();

            var listedViewModel = new List<AllPositionsViewModel>();

            foreach (var position in allPositions)
            {
                var viewModel = new AllPositionsViewModel();

                viewModel.Id = position.Id;
                viewModel.Name = position.Name;
                viewModel.ImageUrl = position.ImageUrl;

                listedViewModel.Add(viewModel);
            }

            return View(listedViewModel);
        }

        [Route("/position/{id}")]
        public async Task<IActionResult> MakeDraftByPosition(int id)
        {
            var position = await this.positionService.GetPositionByIdAsync(id);

            if (position == null)
            {
                return StatusCode(404);
            };

            var champion = await this.championService.GetRandomChampionAsync();

            if (champion == null)
            {
                return NotFound();
            }

            var build = await this.itemService.GetRandomBuildForPositionAsync(id);

            var summonerSpells = await this.summonerSpellService.GetRandomSummonerSpellsAsync();

            if (PositionConstants.Jungle.Equals(position.Name))
            {
                summonerSpells = await this.summonerSpellService.GetJunglerSummonerSpellsAsync();
            }

            var draftByPositionViewModel = new DraftByPositionViewModel()
            {
                Champion = champion,
                Build = build,
                Position = position,
                SummonerSpells = summonerSpells

            };

            return this.View(draftByPositionViewModel);
        }

        [Route("/teamDraft")]
        public async Task<IActionResult> MakeTeamDraft()
        {
            var teamDraft = new List<RandomDraftViewModel>();

            for (int i = 0; i < 5; i++)
            {
                var champion = await this.championService.GetRandomChampionAsync();

                var build = await this.itemService.GetRandomBuildAsync();

                var summonerSpells = await this.summonerSpellService.GetRandomSummonerSpellsAsync();

                if (i == 1)
                {
                    build = await this.itemService.GetRandomJungleBuildAsync();

                    summonerSpells = await this.summonerSpellService.GetJunglerSummonerSpellsAsync();
                }
                else if (i == 4)
                {
                    build = await this.itemService.GetRandomSupportBuildAsync();
                }

                var draft = new RandomDraftViewModel()
                {
                    Champion = champion,
                    Build = build,
                    SummonerSpells = summonerSpells

                };
                teamDraft.Add(draft);
            }

            var teamDraftViewModel = new TeamDraftViewModel()
            {
                TeamSet = teamDraft
            };

            return this.View(teamDraftViewModel);
        }
    }
}
