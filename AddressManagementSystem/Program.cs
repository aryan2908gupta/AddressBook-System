using AddressManagementSystem.Services;

namespace AddressManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBookService service = new AddressBookService();
            // service.AddContact();
            
            service.EditContact();
        }
    }
}
