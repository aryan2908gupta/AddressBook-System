using System;
using System.Collections.Generic;
using AddressManagementSystem.Entity;
using System.Linq;

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


        public void CountByCityOrState()
        {
            var allContacts = books.Values
                                   .SelectMany(b => b.GetAllContacts());

            var cityCount = allContacts
                            .GroupBy(c => c.City)
                            .Select(g => new { City = g.Key, Count = g.Count() });

            var stateCount = allContacts
                             .GroupBy(c => c.State)
                             .Select(g => new { State = g.Key, Count = g.Count() });

            Console.WriteLine("\nCount by City:");
            foreach (var c in cityCount)
                Console.WriteLine($"{c.City} : {c.Count}");

            Console.WriteLine("\nCount by State:");
            foreach (var s in stateCount)
                Console.WriteLine($"{s.State} : {s.Count}");
        }


        public void SortContactsByName()
        {
            var sortedContacts = books.Values
                                              .SelectMany(b => b.GetAllContacts())
                                              .OrderBy(c => c.FirstName)
                                              .ThenBy(c => c.LastName);

            Console.WriteLine("\nContacts sorted by Name:");
            foreach (var contact in sortedContacts)
                Console.WriteLine(contact);
        }

        public void SortContactsByCity()
        {
            var contacts = books.Values
                                        .SelectMany(b => b.GetAllContacts())
                                        .OrderBy(c => c.City);

            Console.WriteLine("\nContacts sorted by City:");
            foreach (var c in contacts)
                Console.WriteLine(c);
        }

        public void SortContactsByState()
        {
            var contacts = books.Values
                                        .SelectMany(b => b.GetAllContacts())
                                        .OrderBy(c => c.State);

            Console.WriteLine("\nContacts sorted by State:");
            foreach (var c in contacts)
                Console.WriteLine(c);
        }

        public void SortContactsByZip()
        {
            var contacts = books.Values
                                        .SelectMany(b => b.GetAllContacts())
                                        .OrderBy(c => c.ZipCode);

            Console.WriteLine("\nContacts sorted by Zip:");
            foreach (var c in contacts)
                Console.WriteLine(c);
        }


    }
    }
