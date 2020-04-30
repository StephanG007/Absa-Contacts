using Phonebook.API.Models;
using Phonebook.API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.API.Data
{
  public class ContactRepository : IRepository
  {
    private DataContext db;
    public ContactRepository(DataContext context)
    {
      db = context;
    }

    public async Task<Contact> Create(Contact contact)
    {
      db.Contacts.Add(contact);
      await db.SaveChangesAsync();
      return contact;
    }

    public async Task Delete(Guid id)
    {
      var contact = await db.Contacts.FirstOrDefaultAsync(c => c.InstanceId == id);
      if (contact == null)
        throw new KeyNotFoundException();

      db.Contacts.Remove(contact);
      await db.SaveChangesAsync();
    }

    public async Task<Contact> Edit(Guid id, ContactDto contactDto)
    {
      var contact = db.Contacts.FirstOrDefault(c => c.InstanceId == id);
      if (contact == null)
        throw new KeyNotFoundException();

      contactDto.modifyDbModel(contact);
      await db.SaveChangesAsync();
      return contact;
    }

    public async Task<Contact> Get(Guid id)
    {
      var contact = await db.Contacts.FirstOrDefaultAsync(c => c.InstanceId == id);

      if (contact == null)
        throw new KeyNotFoundException();

      return contact;
    }

    public async Task<List<Contact>> GetAll()
    {
      var contacts = await db.Contacts.OrderBy(x => x.FirstName).ToListAsync();
      return contacts;
    }

    public async Task<List<Contact>> Search(string query)
    {
      if (String.IsNullOrEmpty(query))
        return await db.Contacts.ToListAsync();

      var contacts = await db.Contacts.Where(x =>
          x.FirstName.Contains(query) ||
          x.LastName.Contains(query) ||
          x.Email.Contains(query) ||
          x.Address.Contains(query) ||
          x.Phone.Contains(query)
      ).OrderBy(c => c.FirstName).ToListAsync();

      return contacts;
    }
  }
}
