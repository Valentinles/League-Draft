using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueDraft.Web.ViewModels
{
    public class RandomDraftViewModel
    {
        public Champion Champion { get; set; }

        public IEnumerable<Item> Build { get; set; }

        public IEnumerable<SummonerSpell> SummonerSpells { get; set; }
    }
}
