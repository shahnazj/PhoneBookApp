using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class JsonIncludePrivateFieldsAttribute : Attribute { }

    [JsonIncludePrivateFields]
    class ContactEntity
    {
        private string _Id;
        [JsonIgnore]
        public string Id
        {
            get => _Id;
            set => _Id = value;
        }
        private string _FirstName;
        [JsonIgnore]
        public string FirstName
        {
            get => _FirstName;
            set => _FirstName = value;
        }

        private string _LastName;
        [JsonIgnore]
        public string LastName
        {
            get => _LastName;
            set => _LastName = value;
        }
        private string _PhoneNumber;
        [JsonIgnore]
        public string PhoneNumber
        {
            get => _PhoneNumber;
            set => _PhoneNumber = value;
        }

        private string _Email;
        [JsonIgnore]
        public string Email
        {
            get => _Email;
            set => _Email = value;
        }

        private string _Address;
        [JsonIgnore]
        public string Address
        {
            get => _Address;
            set => _Address = value;
        }

        private string _City;
        [JsonIgnore]
        public string City
        {
            get => _City;
            set => _City = value;
        }

        private string _Street;
        [JsonIgnore]
        public string Street
        {
            get => _Street;
            set => _Street = value;
        }

        private string _PostalCode;
        [JsonIgnore]
        public string PostalCode
        {
            get => _PostalCode;
            set => _PostalCode = value;
        }
        
    }
    }
