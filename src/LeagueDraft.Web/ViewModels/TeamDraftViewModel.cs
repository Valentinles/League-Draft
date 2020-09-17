using LeagueDraft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueDraft.Web.ViewModels
{
    public class TeamDraftViewModel
    {
        public IEnumerable<RandomDraftViewModel> TeamSet { get; set; }
    }
}
