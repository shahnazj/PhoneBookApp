using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public class Contact
    {
        public string _Id { get; set; } = null!;
        public string _FirstName { get; set; } = null!;

        public string _LastName { get; set; } = null!;

        public string _Email { get; set; } = null!;


        public void printContact()
        {
            //Console.WriteLine("First Name = " + FirstName + " Last Name = " + LastName + " Phone = " + PhoneNumber + " Email = " + Email + " Address = " + Address + " City = " + City + " Street = " + Street + " Postal Code = " + PostalCode);
            Console.WriteLine($"{"Id:",-15}{_Id}");
            Console.WriteLine($"{"Name:",-15}{_FirstName}");
            Console.WriteLine($"{"Last Name:",-15}{_LastName}");
            Console.WriteLine($"{"Email: ",-15}{_Email}");
        }

    }
}
