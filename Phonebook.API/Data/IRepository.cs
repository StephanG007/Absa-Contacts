using Phonebook.API.Models;
using Phonebook.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phonebook.API.Data
{
  public interface IRepository
  {
    Task<List<Contact>> GetAll();
    Task<Contact> Get(Guid id);
    Task<List<Contact>> Search(string query);
    Task<Contact> Create(Contact contact);
    Task<Contact> Edit(Guid id, ContactDto contactDto);
    Task Delete(Guid id);
  }
}
