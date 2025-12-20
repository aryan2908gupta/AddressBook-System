using AddressManagementSystem.Entity;
using AddressManagementSystem.Services;

namespace AddressManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookService service = new AddressBookService();

            while (true)
            {

                Console.WriteLine("\n--- ADDRESS BOOK ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        service.AddContact();
                        break;

                    case 2:
                        service.EditContact();
                        break;

                    case 3:
                        service.DeleteContact();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            
        }
    }
}
