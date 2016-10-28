using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FetchNStore.Models;

namespace FetchNStore.DAL
{
    public class FetchNStoreRepository
    {
        public FetchNStoreContext Context { get; set; }
        public List<URL> URL_List { get; set; }

        public FetchNStoreRepository()
        {
            Context = new FetchNStoreContext();   
        }
        public FetchNStoreRepository(FetchNStoreContext _context)
        {
            Context = _context;
        }


        public List<URL> GetURLs()
        {
            List<URL> url_list = new List<URL>();
            url_list = Context.URL.ToList();
            return url_list;
        }

        public URL AddURLToDataBase(URL new_url)
        {
            Context.URL.Add(new_url);
            Context.SaveChanges();
            return new_url;
        }
    }
}