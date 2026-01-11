using AddressManagementSystem.Entity;
using AddressManagementSystem.Services;
using System;
using System.Threading.Tasks;

namespace AddressManagementSystem
{
    internal class Program
    {

        static async Task Main()
        {
            // UC18: Choose DB repository (ADO.NET)
            IAddressBookRepository repo = new DatabaseAddressBookRepository();
            AddressBookService book = new AddressBookService(repo);

            AddressBookSystem system = new AddressBookSystem();

            while (true)
            {
                Console.WriteLine("\n===== Address Book Menu =====");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Search by City/State (UC8)");
                Console.WriteLine("5. Count Contacts by City/State");
                Console.WriteLine("6. Sort Contacts by Name");
                Console.WriteLine("7. Sort Contacts by City/State/Zip");
                Console.WriteLine("8. Save Contacts to TXT (UC13)");
                Console.WriteLine("9. Load Contacts from TXT (UC13)");
                Console.WriteLine("10. Save Contacts to CSV (UC14)");
                Console.WriteLine("11. Load Contacts from CSV (UC14)");
                Console.WriteLine("12. Save Contacts to JSON (UC15)");
                Console.WriteLine("13. Load Contacts from JSON (UC15)");
                Console.WriteLine("14. Save Contacts to Database (UC18)");
                Console.WriteLine("15. Load Contacts from Database (UC18)");
                Console.WriteLine("16. Exit");

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
                        system.CountByCityOrState();
                        break;

                    case 6:
                        system.SortContactsByName();
                        break;

                    case 7:
                        Console.WriteLine("\nSort Contacts By:");
                        Console.WriteLine("1. City");
                        Console.WriteLine("2. State");
                        Console.WriteLine("3. Zip");
                        Console.Write("Enter your choice: ");

                        if (!int.TryParse(Console.ReadLine(), out int sortChoice))
                        {
                            Console.WriteLine("Invalid input.");
                            break;
                        }

                        switch (sortChoice)
                        {
                            case 1:
                                system.SortContactsByCity();
                                break;
                            case 2:
                                system.SortContactsByState();
                                break;
                            case 3:
                                system.SortContactsByZip();
                                break;
                            default:
                                Console.WriteLine("Invalid sorting option.");
                                break;
                        }
                        break;

                    case 8:
                        await book.WriteContactsToFile();
                        break;

                    case 9:
                        await book.ReadContactFromFile();
                        break;

                    case 10:
                        await book.WriteCsvFile();
                        break;

                    case 11:
                        await book.ReadCsvFile();
                        break;

                    case 12:
                        await book.WriteContactsToJsonFile();
                        break;

                    case 13:
                        await book.ReadContactsFromJsonFile();
                        break;

                    case 14:
                        await book.SaveToRepositoryAsync();
                        break;

                    case 15:
                        await book.LoadFromRepositoryAsync();
                        break;

                    case 16:
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
