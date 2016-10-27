using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FetchNStore.DAL
{
    public class FetchNStoreRepository
    {
        public StoreContext Context { get; set; }

        public FetchNStoreRepository()
        {
            Context = new StoreContext();
        }
        public FetchNStoreRepository(StoreContext _context)
        {
            Context = _context;
        }

    }
}