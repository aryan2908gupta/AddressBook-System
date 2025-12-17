using AddressManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressManagementSystem.Services
{
    internal class AddressBookService : IAddressBookService
    {
        private List<Contact> contacts = new List<Contact>();

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
    }
}
