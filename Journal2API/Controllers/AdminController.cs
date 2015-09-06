using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Journal2API.Models;

namespace Journal2API.Controllers
{
    public class AdminController : ApiController
    {
        // POST: api/Admin
        public void Post([FromBody]string value)
        {
            using (var context = new JournalContext())
            {
                var todo = context.TodoItems.Create();
                todo.Title = "Todo 1";
                context.TodoItems.Add(todo);
            }
        }
    }
}