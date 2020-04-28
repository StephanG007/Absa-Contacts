using Absa.API.Data;
using Absa.API.Models;
using Absa.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Absa.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly IRepository _repository;
    public ContactsController(IRepository repository)
    {
      _repository = repository;
    }

    // GET api/Contacts
    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
      try
      {
        var contacts = await _repository.Get();
        return Ok(contacts);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.InnerException.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(int id)
    {
      try
      {
        var contact = await _repository.Get(id);
        return Ok(contact);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.InnerException.Message);
      }
    }

    // POST api/values
    [HttpGet("search/{query}")]
    public async Task<IActionResult> Search(string query)
    {
      try
      {
        var contacts = await _repository.Search(query);
        return Ok(contacts);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.InnerException.Message);
      }
    }

    // PUT api/values/5
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Contact newContact)
    {
      ModelState.Remove("Id");
      if (!ModelState.IsValid)
        return BadRequest("Invalid Model State");

      try
      {
        await _repository.Create(newContact);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest("Failed to create contact: " + ex.InnerException.Message);
      }
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, [FromBody] ContactDto contactDto)
    {
      try
      {
        await _repository.Edit(id, contactDto);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest("Failed to update contact: " + ex.InnerException.Message);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await _repository.Delete(id);
        return Ok($"Successfully Deleted Contact {id}");
      }
      catch (Exception ex)
      {
        return BadRequest($"Error Deleting Contact {id}: {ex.InnerException.Message}");
      }
    }
  }
}
