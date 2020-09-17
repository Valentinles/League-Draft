using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueDraft.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
