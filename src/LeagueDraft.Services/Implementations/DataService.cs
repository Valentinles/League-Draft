using LeagueDraft.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueDraft.Services.Implementations
{
    public abstract class DataService
    {
        protected readonly LeagueDraftDbContext context;

        public DataService(LeagueDraftDbContext context)
        {
            this.context = context;
        }

    }
}
