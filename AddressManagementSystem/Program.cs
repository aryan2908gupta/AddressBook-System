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
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Search by City/State");
                Console.WriteLine("5. Exit");
                Console.WriteLine("6. View by City");
                Console.WriteLine("7. View by State");

                Console.Write("Enter your choice: ");

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
                    case 6:
                        Console.Write("Enter City: ");
                        system.ViewPersonsByCity(Console.ReadLine());
                        break;

                    case 7:
                        Console.Write("Enter State: ");
                        system.ViewPersonsByState(Console.ReadLine());
                        break;

                }
            }
        }
    }
}