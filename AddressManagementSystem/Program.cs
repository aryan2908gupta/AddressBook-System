using System;
using AddressManagementSystem.Services;

namespace AddressManagementSystem
{
    internal class Program
    {
        static void Main()
        {
            AddressBookSystem system = new AddressBookSystem();

            system.CreateAddressBook("Friends");
            AddressBookService book = system.GetBook("Friends");

            while (true)
            {
                Console.WriteLine("\n1 Add  2 Edit  3 Delete  4 Search City/State  5 Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: book.AddContact(); break;
                    case 2: book.EditContact(); break;
                    case 3: book.DeleteContact(); break;
                    case 4:
                        Console.Write("Enter City or State: ");
                        system.SearchByCityOrState(Console.ReadLine());
                        break;
                    case 5: return;
                }
            }
        }
    }
}
