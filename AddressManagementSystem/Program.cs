using AddressManagementSystem.Entity;
using AddressManagementSystem.Services;

namespace AddressManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookService service = new AddressBookService();
          
            service.AddContact();
            Console.WriteLine("Now running edit");
            service.EditContact();
            Console.WriteLine("Now running delete");
            service.DeleteContact();
            
        }
    }
}
