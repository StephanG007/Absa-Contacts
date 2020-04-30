using System;

namespace Phonebook.API.Models.Dto
{
  public class ContactDto
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string PhotoUrl { get; set; }

    public void modifyDbModel(Contact dbModel)
    {
      dbModel.FirstName = this.FirstName;
      dbModel.LastName = this.LastName;
      dbModel.DateOfBirth = this.DateOfBirth;
      dbModel.Gender = this.Gender;
      dbModel.Email = this.Email;
      dbModel.Phone = this.Phone;
      dbModel.Address = this.Address;
      dbModel.PhotoUrl = this.PhotoUrl;
    }
  }


}