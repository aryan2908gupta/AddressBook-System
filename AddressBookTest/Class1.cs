using AddressManagementSystem.Services;
using NUnit.Framework;

namespace AddressBookTest
{
    [TestFixture]
    public class Class1
    {
        private AddressBookService addressBookService;

        [SetUp]
        public void Init()
        {
            addressBookService = new AddressBookService();
        }


    }
}
