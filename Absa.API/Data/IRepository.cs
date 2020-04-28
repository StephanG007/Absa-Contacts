using Absa.API.Models;
using Absa.API.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Absa.API.Data
{
  public interface IRepository
  {
    Task<List<Contact>> Get();
    Task<Contact> Get(int id);
    Task<List<Contact>> Search(string query);
    Task Create(Contact contact);
    Task Edit(int id, ContactDto contactDto);
    Task Delete(int id);
  }
}
