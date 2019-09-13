using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Absa.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Absa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext db;
        public ContactsController(DataContext context)
        {
            db = context;
        }

        // GET api/Contacts
        [HttpGet]
        public IActionResult Get()
        {
            var contacts = db.Contacts.OrderBy(x => x.FirstName).ToList();
            return Ok(contacts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var contact = db.Contacts.FirstOrDefault(x => x.Id == id);
            return Ok(contact);
        }

        // POST api/values
        [HttpGet("search/{query}")]
        public IActionResult Search(string query)
        {
            if (String.IsNullOrEmpty(query))
                return Ok(db.Contacts.ToList());

            try
            {
                var contacts = db.Contacts.Where(x =>
                    x.FirstName.Contains(query) ||
                    x.LastName.Contains(query) ||
                    x.Email.Contains(query) ||
                    x.Address.Contains(query) ||
                    x.Phone.Contains(query)
                ).OrderBy(c => c.FirstName).ToList();

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occurred retrieving contacts");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
