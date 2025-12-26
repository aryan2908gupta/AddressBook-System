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
                Console.WriteLine("\n===== Address Book Menu =====");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Search by City/State (UC8)");
                Console.WriteLine("5. Count Contacts by City/State (UC10)");
                Console.WriteLine("6. Sort Contacts by Name (UC11)");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        book.AddContact();
                        break;

                    case 2:
                        book.EditContact();
                        break;

                    case 3:
                        book.DeleteContact();
                        break;

                    case 4:
                        Console.Write("Enter City or State: ");
                        system.SearchByCityOrState(Console.ReadLine());
                        break;

                    case 5:
                        system.CountContactsByCityAndState(); // UC10
                        break;

                    case 6:
                        system.SortContactsByName(); // UC11
                        break;

                    case 7:
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }
    }
}
