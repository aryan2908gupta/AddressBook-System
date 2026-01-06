using AddressManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AddressManagementSystem.Services
{
    public class AddressBookService : IAddressBookService
    {

        private const string filepath = @"C:\Users\aryan\OneDrive\Desktop\AdressBookManagementSystem\AddressBook-System\AddressManagementSystem\contact.txt";

        private readonly Dictionary<string, Contact> contacts = new Dictionary<string, Contact>(StringComparer.OrdinalIgnoreCase);

        //private readonly List<Contact> contacts = new List<Contact>();
        //UC6 and UC7 DONE IN SAME

        public void AddContact()
        {
            string choice;
            do
            {


                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                string key = firstName + " " + lastName;

                if (contacts.ContainsKey(key))
                {
                    Console.WriteLine($"User Already exists with this {key} name ");
                }
                else
                {
                    Contact contact = new Contact();

                    contact.FirstName = firstName;
                    contact.LastName = lastName;

                    Console.Write("Enter Address: ");
                    contact.Address = Console.ReadLine();

                    Console.Write("Enter City: ");
                    contact.City = Console.ReadLine();

                    Console.Write("Enter State: ");
                    contact.State = Console.ReadLine();

                    Console.Write("Enter Zip Code: ");
                    contact.ZipCode = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    contact.PhoneNumber = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    contact.Email = Console.ReadLine();

                    contacts.Add(key, contact);

                    Console.WriteLine();
                    Console.WriteLine("Contacts Added Successfully");

                }
                Console.Write("Do you want to add another contact? (Y/N): ");
                choice = Console.ReadLine();

            } while (choice.Equals("Y", StringComparison.OrdinalIgnoreCase));
        }

        public void EditContact()
        {
            Console.Write("Enter Your First Name : ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Your Last Name : ");
            string lastName = Console.ReadLine();

            string key = firstname + " " + lastName;

            if (contacts.ContainsKey(key))
            {

                Contact contact = contacts[key];
                Console.Write("Enter the new Phone Number : ");
                contact.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Contact Updated Successfully!");
            }
            else
            {
                Console.WriteLine("User Doesn't Exists ");
            }
        }
        public void DeleteContact()
        {
            Console.Write("Enter Your First Name : ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Your Last Name : ");
            string lastName = Console.ReadLine();

            string key = firstname + " " + lastName;

            if (contacts.ContainsKey(key))
            {

                contacts.Remove(key);
            }
            else
            {
                Console.WriteLine("User Doesnt Exists");
            }
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return contacts.Values;
        }

        // Testing Done ........
        public void AddContact(Contact contact)
        {
            string key = contact.FirstName + " " + contact.LastName;

            if (!contacts.ContainsKey(key))
            {
                contacts.Add(key, contact);
            }
        }

        public bool DeleteContact(string firstName, string lastName)
        {
            string key = firstName + " " + lastName;

            return contacts.Remove(key);
        }

        public bool EditContact(string firstName, string lastName, string newPhoneNumber)
        {
            bool isChanged = false;
            string key = firstName + " " + lastName;

            if (contacts.ContainsKey(key))
            {
                contacts[key].PhoneNumber = newPhoneNumber;
                isChanged = true;
                return isChanged;
            }

            return isChanged;
        }

        public async Task WriteContactsToFile()
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (var contact in contacts.Values)
                {
                    await writer.WriteLineAsync(
                        $"{contact.FirstName}|{contact.LastName}|{contact.Address}|" +
                        $"{contact.City}|{contact.State}|{contact.ZipCode}|" +
                        $"{contact.PhoneNumber}|{contact.Email}"
                    );
                }
            }

            Console.WriteLine("Contacts saved to AddressBook.txt successfully.");
        }


        public async Task ReadContactFromFile()
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("AddressBook.txt file not found.");
                return;
            }
            contacts.Clear();

            string[] lines = await File.ReadAllLinesAsync(filepath);

            foreach (string line in lines)
            {

                string[] data = line.Split('|');

                Contact contact = new Contact
                {
                    FirstName = data[0],
                    LastName = data[1],
                    Address = data[2],
                    City = data[3],
                    State = data[4],
                    ZipCode = data[5],
                    PhoneNumber = data[6],
                    Email = data[7]
                };

                string key = contact.FirstName + " " + contact.LastName;
                contacts[key] = contact;
            }
            Console.WriteLine("Contacts loaded from AddressBook.txt successfully.");
        }

        private const string csvpathfile = @"C:\Users\aryan\OneDrive\Desktop\AdressBookManagementSystem\AddressBook-System\AddressManagementSystem\contact.csv";

        public async Task WriteCsvFile()
        {
            using (StreamWriter writer = new StreamWriter(csvpathfile))
            {
                await writer.WriteLineAsync("FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,Email");
                foreach(var contact  in contacts.Values)
                {
                    writer.WriteLine(
               $"{contact.FirstName},{contact.LastName},{contact.Address}," +
               $"{contact.City},{contact.State},{contact.ZipCode}," +
               $"{contact.PhoneNumber},{contact.Email}"
           );
                }
            }

        }

        public async Task ReadCsvFile()
        {
            if (!File.Exists(csvpathfile))
            {
                Console.WriteLine("CSV file not found.");
                return;
            }
            string[]lines = await File.ReadAllLinesAsync(csvpathfile);

            for (int i = 1; i < lines.Length; i++) {
                string[] data = lines[i].Split(',');
                if (data.Length < 8)
                    continue;
                Contact contact = new Contact
                {
                    FirstName = data[0],
                    LastName = data[1],
                    Address = data[2],
                    City = data[3],
                    State = data[4],
                    ZipCode = data[5],
                    PhoneNumber = data[6],
                    Email = data[7]
                };

                string key = contact.FirstName + " " + contact.LastName;
                contacts[key] = contact;
            }
            Console.WriteLine("Contacts loaded from AddressBook.csv successfully.");
        }
        string path = @"C:\Users\aryan\OneDrive\Desktop\AdressBookManagementSystem\AddressBook-System\AddressManagementSystem\contact.json";
        public async Task WriteContactsToJsonFile()
        {
            var contactList = contacts.Values.ToList();

            string jsonData = JsonSerializer.Serialize(
                contactList,
                new JsonSerializerOptions { WriteIndented = true }
            );

            await File.WriteAllTextAsync(path, jsonData);


            Console.WriteLine("Contacts saved to AddressBook.json successfully.");
        }

        public async Task ReadContactsFromJsonFile()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("JSON file not found.");
                return;
            }

            string jsonData = await File.ReadAllTextAsync(path);

            List<Contact> contactList =
                JsonSerializer.Deserialize<List<Contact>>(jsonData);

            contacts.Clear();

            foreach (Contact contact in contactList)
            {
                string key = contact.FirstName + " " + contact.LastName;
                contacts[key] = contact;
            }

            Console.WriteLine("Contacts loaded from AddressBook.json successfully.");
        }



    }
}

