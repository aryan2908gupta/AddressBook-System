using AddressManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressManagementSystem.Services
{
    internal class AddressBookService : IAddressBookService
    {

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

                string key = firstName + " " +lastName;
                
                if (contacts.ContainsKey(key))
                {
                    Console.WriteLine($"User Already exists with this {key} name ");
                }
                else {
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

                    contacts.Add(key,contact);

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

            if (contacts.ContainsKey(key)) { 
            
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

            if (contacts.ContainsKey(key)) { 
            
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


    }
}

