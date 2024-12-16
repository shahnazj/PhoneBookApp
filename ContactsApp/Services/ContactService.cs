
using ContactsApp.Model;
using ContactsApp.Factories;
using ContactsApp.Helpers;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using System.Reflection;
namespace ContactsApp.Services

{
    public class ContactService
    {
        private List<ContactEntity> _contacts = [];

        public ContactService()
        {
            Start();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Select(ContactFactory.Create);
        }

        public bool Create(ContactRegistrationForm form)
        {
            try
            {
                ContactEntity contactEntity = ContactFactory.Create(form);
                contactEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();

                _contacts.Add(contactEntity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        static void AddPrivateFieldsModifier(JsonTypeInfo jsonTypeInfo)
        {
            if (jsonTypeInfo.Kind != JsonTypeInfoKind.Object)
                return;

            if (!jsonTypeInfo.Type.IsDefined(typeof(JsonIncludePrivateFieldsAttribute), inherit: false))
                return;

            foreach (var field in jsonTypeInfo.Type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var jsonPropertyInfo = jsonTypeInfo.CreateJsonPropertyInfo(field.FieldType, field.Name);
                jsonPropertyInfo.Get = field.GetValue;
                jsonPropertyInfo.Set = field.SetValue;

                jsonTypeInfo.Properties.Add(jsonPropertyInfo);
            }
        }

        private void Start()
        {
            Console.WriteLine("Loading from Contacs Database ...");
            var options = new JsonSerializerOptions
            {
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { AddPrivateFieldsModifier }
                }
            };

            if (File.Exists("./ContactsDB.json"))
            {
                string readText = File.ReadAllText("./ContactsDB.json");
                if (!string.IsNullOrEmpty(readText))
                {
                    _contacts = JsonSerializer.Deserialize<List<ContactEntity>>(readText, options) ?? new List<ContactEntity>();
                }
            }
        }

        public void persistContacts()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver
                {
                    Modifiers = { AddPrivateFieldsModifier }
                }
            };

            string json = JsonSerializer.Serialize(_contacts, options);
            File.WriteAllText("./ContactsDB.json", json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contacts are saved in file!");
            Console.ResetColor();
        }
        public void ClearList()
        {
            _contacts.Clear();
        }
    }

}

