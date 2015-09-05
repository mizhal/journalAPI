using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Journal2API.Models;

namespace Journal2API.Controllers
{
    public class QuestsController : ApiController
    {
        // GET: api/Quests
        public Quest[] Get()
        {
            return new Quest[] {
                new Quest
                {
                    Id = 1,
                    Title = "Quest 1",
                    Description = "xxxxx",
                }
            };
        }

        // GET: api/Quests/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quests
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quests/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quests/5
        public void Delete(int id)
        {
        }
    }
}
