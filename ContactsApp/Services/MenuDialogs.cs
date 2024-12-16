
using ContactsApp.Factories;
using ContactsApp.Model;
using ContactsApp.Interfaces;

namespace ContactsApp.Services
{
    public class MenuDialogs : IMenuDialogs
    {
        private readonly ContactService _contactService = new ContactService();
        public void Show()
        {
            while (true)
            {
                MainMenu();
            }
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"{"1.", -3}Show all contacts");
            Console.WriteLine($"{"2.",-3}Add a contact");
            Console.WriteLine($"{"Q.",-3}Quit Application");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Choose your option:");
            string option = Console.ReadLine();
            

            switch (option.ToLower())
            {
                case "q":
                    QuitOption();
                    break;
                case "1":
                    ViewOption();
                    break;

                case "2":
                    CreateOption();
                    break;
                default:
                    InvalidOption();
                    break;
            }

        }

        private void QuitOption()
        {
            Console.Clear();
            Console.WriteLine("Do you really want to close? (y/n)");
            string userChoice = Console.ReadLine();

            if(userChoice.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            {
                _contactService.persistContacts();
                Environment.Exit(0);
            }
        }

        private void ViewOption()
        {
            var contacts = _contactService.GetAll();
            Console.Clear();
            if (contacts.Any()) {
                foreach (var contact in contacts)
                {
                    contact.printContact();
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("You have no contacts!");
            }
            
            Console.ReadKey();

        }

        private void CreateOption()
        {
            ContactRegistrationForm rf = ContactFactory.Create();
            Console.Clear();
            Console.WriteLine("Please enter First Name");
            rf._FirstName = Console.ReadLine()!;
            Console.WriteLine("Please enter Last Name");
            rf._LastName = Console.ReadLine()!;
            Console.WriteLine("Please enter Phone Number");
            rf._Phone = Console.ReadLine()!;
            Console.WriteLine("Please enter Email");
            rf._Email = Console.ReadLine()!;
            Console.WriteLine("Please enter Address");
            rf._Address = Console.ReadLine()!;
            Console.WriteLine("Please enter City");
            rf._City = Console.ReadLine()!;
            Console.WriteLine("Please enter Street");
            rf._Street = Console.ReadLine()!;
            Console.WriteLine("Please enter Postal Code");
            rf._PostalCode = Console.ReadLine()!;
            bool result = _contactService.Create(rf);
            if (result)
            {
                OutputDialog("Contact was successfully created.");
            }
            else
            {
                OutputDialog("Contact was not created successfully.");
            }
        }

        public void InvalidOption()
        {
            Console.Clear();
            Console.WriteLine("Please enter 1 or 2 or q");
            Console.ReadKey();
        }

        public void OutputDialog(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }


    }
}
