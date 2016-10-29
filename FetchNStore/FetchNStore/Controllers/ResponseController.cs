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

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Response/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Response
        public void Post([FromBody]dynamic value)
        {

            //Console.WriteLine(value);
            //FetchNStoreRepository repo = new FetchNStoreRepository();
            //value = new URL();
            //repo.AddURLToDataBase(value);
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
