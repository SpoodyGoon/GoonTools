using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookmarkSharp.DataAccess.Controllers
{
    public class ResearchController : ApiController
    {
        // GET api/research
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/research/5
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/research
        public void Post([FromBody]string value)
        {
        }

        // PUT api/research/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/research/5
        public void Delete(int id)
        {
        }
    }
}
