using Absa.API.Models;
using Absa.API.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Absa.API.Data
{
  public class ContactRepository : IRepository
  {
    private DataContext db;
    public ContactRepository(DataContext context)
    {
      db = context;
    }

    public async Task Create(Contact contact)
    {
      db.Contacts.Add(contact);
      await db.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      var contact = db.Contacts.Find(id);
      db.Contacts.Remove(contact);
      await db.SaveChangesAsync();
    }

    public async Task Edit(int id, ContactDto contactDto)
    {
      var contact = db.Contacts.Find(id);
      contactDto.modifyDbModel(contact);
      await db.SaveChangesAsync();
    }

    public async Task<Contact> Get(int id)
    {
      var contact = await db.Contacts.FindAsync(id);
      return contact;
    }

    public async Task<List<Contact>> Get()
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
