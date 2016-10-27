using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using FetchNStore.Models;

namespace FetchNStore.DAL
{
    public class StoreContext : DbContext
    {
        public virtual DbSet<URL> URL {get;set;}
    }
}