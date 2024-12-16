
using System.Diagnostics;
using System.IO;
using System.Net;
using ContactsApp.Model;
namespace ContactsApp.Factories
{
    class ContactFactory
    {
        public static ContactRegistrationForm Create()
        {
            return new ContactRegistrationForm();
        }

        public static ContactEntity Create(ContactRegistrationForm form)
        {
            return new ContactEntity()
            {
                FirstName = form._FirstName,
                LastName = form._LastName,
                PhoneNumber = form._Phone,
                Email = form._Email,
                Address = form._Address,
                City = form._City,
                Street = form._Street,
                PostalCode = form._PostalCode,
            };

        }
        public static Contact Create(ContactEntity entity)
        {
            return new Contact
            {
                _FirstName = entity.FirstName,
                _LastName = entity.LastName,
                _Email = entity.Email,
                _Id = entity.Id,  

            };

        }
    }
}
