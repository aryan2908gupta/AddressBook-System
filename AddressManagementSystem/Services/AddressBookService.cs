using AddressManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressManagementSystem.Services
{
    internal class AddressBookService : IAddressBookService
    {
        private readonly List<Contact> contacts = new List<Contact>();

        public void AddContact()
        {
            Contact contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

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

            contacts.Add(contact);

            Console.WriteLine();
            Console.WriteLine("Contacts Added Successfully");
        }

        public void EditContact()
        {
            Console.Write("Enter name : ");
           string name1 = Console.ReadLine();
            Console.WriteLine();
            foreach (Contact contact in contacts) {
                if (contact.FirstName == name1)
                {

                    Console.WriteLine("Enter the Phone number to be Changed : ");
                    contact.PhoneNumber = Console.ReadLine();

                    return;
                }
                else
                {
                    Console.WriteLine($"No user exist with this name : ${name}");
                }
            }
        }
    }
}
