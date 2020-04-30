using Phonebook.API.Data;
using Phonebook.API.Models;
using Phonebook.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Phonebook.API.Controllers
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

    [HttpGet]
    public async Task<IActionResult> GetContacts()
   {
      try
      {
        var contacts = await _repository.GetAll();
        return Ok(contacts);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.InnerException.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(Guid id)
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

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Contact newContact)
    {
      ModelState.Remove("Id");
      if (!ModelState.IsValid)
        return BadRequest("Invalid Model State");

      try
      {
        var createdContact = await _repository.Create(newContact);
        return Ok(createdContact);
      }
      catch (Exception ex)
      {
        return BadRequest("Failed to create contact: " + ex.InnerException.Message);
      }
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] ContactDto contactDto)
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

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      try
      {
        await _repository.Delete(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest($"Error Deleting Contact {id}: {ex.InnerException.Message}");
      }
    }
  }
}
