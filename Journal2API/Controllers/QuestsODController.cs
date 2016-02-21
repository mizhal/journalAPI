using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Journal2API.Models;
using Microsoft.Data.OData;

namespace Journal2API.Controllers
{
    public class QuestsODController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private JournalRepo JournalRepo = new JournalRepo();

        // GET: odata/QuestsOD
        public IHttpActionResult GetQuestsOD(ODataQueryOptions<Quest> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var quests = (IQueryable<Quest>)queryOptions.ApplyTo(JournalRepo.All<Quest>());

            return Ok<IEnumerable<Quest>>(quests);
        }

        // GET: odata/QuestsOD(5)
        public IHttpActionResult GetQuest([FromODataUri] long key, ODataQueryOptions<Quest> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var quest = JournalRepo.Get<Quest>(key);

            return Ok<Quest>(quest);
        }

        // PUT: odata/QuestsOD(5)
        public IHttpActionResult Put([FromODataUri] long key, Delta<Quest> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quest = JournalRepo.Get<Quest>(key);

            delta.Put(quest);

            JournalRepo.Update<Quest>(quest);

            return Updated(quest);
        }

        // POST: odata/QuestsOD
        public IHttpActionResult Post(Quest quest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            JournalRepo.Save<Quest>(quest);

            return Created(quest);
        }

        // PATCH: odata/QuestsOD(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<Quest> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quest = JournalRepo.Get<Quest>(key);

            delta.Put(quest);

            JournalRepo.Update<Quest>(quest);

            return Updated(quest);
        }

        // DELETE: odata/QuestsOD(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: manage delete errors.
            JournalRepo.Delete<Quest>(key);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
