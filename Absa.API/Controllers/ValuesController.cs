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
    public class ValuesController : ControllerBase
    {
        private readonly DataContext db;
        public ValuesController(DataContext context)
        {
            db = context;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var values = db.Values.ToList();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var value = db.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
