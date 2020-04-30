using System;

namespace Phonebook.API.Models
{
  public class Contact
  {
    public int Id { get; set; }
    public Guid InstanceId { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = "Unknown";
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string PhotoUrl { get; set; }
  }
}