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
            var contacts = db.Contacts.ToList();
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
        [HttpPost]
        public IActionResult Post([FromBody] string search)
        {
            if (String.IsNullOrEmpty(search))
                return Ok(db.Contacts.ToList());

            try
            {
                var contacts = db.Contacts.Where(x =>
                    x.FirstName.Contains(search) ||
                    x.LastName.Contains(search) ||
                    x.Email.Contains(search) ||
                    x.Address.Contains(search) ||
                    x.Phone.Contains(search)
                ).ToList();

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
