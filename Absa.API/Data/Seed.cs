using System;
using System.Collections.Generic;
using System.Linq;
using Absa.API.Models;
using Newtonsoft.Json;

namespace Absa.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if(!context.Contacts.Any())
            {
                Console.WriteLine("--- SEEDING DATABASE CONTACTS ---");
                var userData = System.IO.File.ReadAllText("Data/ContactSeedData.json");
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(userData);
                
                foreach (var contact in contacts)
                    context.Contacts.Add(contact);
                
                context.SaveChanges();
            }
        }
    }
}