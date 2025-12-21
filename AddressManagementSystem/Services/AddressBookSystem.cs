using System;
using System.Collections.Generic;
using AddressManagementSystem.Entity;

namespace AddressManagementSystem.Services
{
    internal class AddressBookSystem
    {
        private readonly Dictionary<string, AddressBookService> books =
            new Dictionary<string, AddressBookService>(StringComparer.OrdinalIgnoreCase);

        public void CreateAddressBook(string name)
        {
            if (!books.ContainsKey(name))
            {
                books[name] = new AddressBookService();
                Console.WriteLine("Address Book created");
            }
            else
            {
                Console.WriteLine("Address Book already exists");
            }
        }

        public AddressBookService GetBook(string name)
        {
            return books[name];
        }

        // UC8
        public void SearchByCityOrState(string value)
        {
            foreach (var book in books)
            {
                foreach (Contact c in book.Value.GetAllContacts())
                {
                    if (c.City.Equals(value, StringComparison.OrdinalIgnoreCase) ||
                        c.State.Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{c.FirstName} {c.LastName} - {c.City}, {c.State}");
                    }
                }
            }
        }
    }
}
