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
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();
            bool isFound = false;
            foreach (Contact contact in contacts)
            {
                if (contact.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {


                    Console.Write("Enter new Phone Number: ");
                    contact.PhoneNumber = Console.ReadLine();


                    Console.WriteLine("Contact updated successfully");
                    isFound = true;

                    return;

                }


            }

            if (!isFound)
            {
                Console.WriteLine("User Doesn't Exists");
            }
        }
    }
    }

