using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FetchNStore.DAL;
using FetchNStore.Models;

namespace FetchNStore.Controllers
{
    public class ResponseController : ApiController
    {
        // GET: api/Response

        public IEnumerable<URL> Get()
        {
            FetchNStoreRepository repo = new FetchNStoreRepository();
            List<URL> response = repo.GetURLs();
            URL[] response_string = response.ToArray();
            return response_string;
        }

        // GET: api/Response/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Response
        public void Post([FromBody]URL value)
        {

            FetchNStoreRepository repo = new FetchNStoreRepository();
            repo.AddURLToDataBase(value);
        }

        // PUT: api/Response/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Response/5
        public void Delete(int id)
        {
        }
    }
}
