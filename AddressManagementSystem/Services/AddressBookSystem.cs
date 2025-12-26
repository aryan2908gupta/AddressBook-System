using System;
using System.Collections.Generic;
using AddressManagementSystem.Entity;

namespace AddressManagementSystem.Services
{
    public class AddressBookSystem
    {
        private readonly Dictionary<string, AddressBookService> books =
            new Dictionary<string, AddressBookService>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, List<Contact>> personsByCity =
    new Dictionary<string, List<Contact>>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, List<Contact>> personsByState =
            new Dictionary<string, List<Contact>>(StringComparer.OrdinalIgnoreCase);

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
            bool found = false;

            foreach (var book in books)
            {
                foreach (Contact c in book.Value.GetAllContacts())
                {
                    if (c.City.Equals(value, StringComparison.OrdinalIgnoreCase) ||
                        c.State.Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            $"{c.FirstName} {c.LastName} | {c.City}, {c.State} | {book.Key}"
                        );
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No person found in given city/state.");
            }
        }
        public void BuildCityAndStateDictionary()
        {
            personsByCity.Clear();
            personsByState.Clear();

            foreach (var book in books.Values)
            {
                foreach (Contact c in book.GetAllContacts())
                {
                    // City Dictionary
                    if (!personsByCity.ContainsKey(c.City))
                        personsByCity[c.City] = new List<Contact>();

                    personsByCity[c.City].Add(c);

                    // State Dictionary
                    if (!personsByState.ContainsKey(c.State))
                        personsByState[c.State] = new List<Contact>();

                    personsByState[c.State].Add(c);
                }
            }
        }

        public void ViewPersonsByCity(string city)
        {
            BuildCityAndStateDictionary();

            if (personsByCity.ContainsKey(city))
            {
                foreach (var c in personsByCity[city])
                {
                    Console.WriteLine($"{c.FirstName} {c.LastName} | {c.City}, {c.State}");
                }
            }
            else
            {
                Console.WriteLine("No persons found in this city.");
            }
        }

        public void ViewPersonsByState(string state)
        {
            BuildCityAndStateDictionary();

            if (personsByState.ContainsKey(state))
            {
                foreach (var c in personsByState[state])
                {
                    Console.WriteLine($"{c.FirstName} {c.LastName} | {c.City}, {c.State}");
                }
            }
            else
            {
                Console.WriteLine("No persons found in this state.");
            }
        }



    }
}
