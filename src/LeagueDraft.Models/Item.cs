using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueDraft.Models
{
    public class Item : BaseEntity
    {
        public ItemType Type { get; set; }
    }
}
