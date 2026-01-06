using AddressManagementSystem.Entity;
using AddressManagementSystem.Services;
using NUnit.Framework;
using System.Reflection.Emit;
using AddressManagementSystem.Exceptions;


namespace AddressBookTest
{
    [TestFixture]
    public class Class1
    {
        private AddressBookService addressBookService;
        private AddressBookSystem addressBookSystem;

        
            [SetUp]
            public void Init()
            {
            //addressBookService = new AddressBookService();
                addressBookSystem = new AddressBookSystem();
                addressBookSystem.CreateAddressBook("Friend");
                addressBookService = addressBookSystem.GetBook("Friend");
            }

        



        // Initially Contact should be empty
        [Test]
        public void GetAllContacts_WhenNoContactAdded_ShouldReturnEmpty()
        {
           var allContact =  addressBookService.GetAllContacts();
            Assert.That(allContact, Is.Empty);
        }


        [Test]  // Aryan
        public void AddContact_ShouldIncreaseContactContact()
        {
            var contact = new Contact()
            {

                FirstName = "Aryan",
                LastName = "Gupta",
                City = "Delhi",
                State = "Delhi",
                ZipCode = "110001",
                PhoneNumber = "9999999999",
                Email = "aryan@test.com"
            };
            addressBookService.AddContact(contact);
            var allContacts = addressBookService.GetAllContacts();

            Assert.That(allContacts.Count(), Is.EqualTo(1));
        }
        [Test]
        public void AddDuplicateContact_ShouldNotIncreaseCount()
        {
            var contact1 = new Contact { FirstName = "A", LastName = "B", City = "Pune" };

            var contact2 = new Contact { FirstName = "A", LastName = "B", City = "Mumbai" };

            addressBookService.AddContact(contact1);
            addressBookService.AddContact(contact2);

            var allContacts = addressBookService.GetAllContacts();
            Assert.That(allContacts.Count(), Is.EqualTo(1));

        }

        [Test]
        public void AddMultipleContacts_ShouldIncreaseCount() {
            var contact1 = new Contact { FirstName = "A", LastName = "X", City = "Pune" };

            var contact2 = new Contact { FirstName = "Y", LastName = "D", City = "Mumbai" };
            addressBookService.AddContact(contact1);
            addressBookService.AddContact(contact2);

            var allContacts = addressBookService.GetAllContacts();
            Assert.That(allContacts.Count(), Is.EqualTo(2));

        }

        [Test]
        public void GetAllContacts_ShouldReturnCorrectCity()
        {
            var contact1 = new Contact { FirstName = "A", LastName = "B", City = "Pune" };
            addressBookService.AddContact(contact1);

            var Allcontact = addressBookService.GetAllContacts().FirstOrDefault();
            string city = Allcontact.City;
            Assert.That(city, Is.EqualTo("Pune"));
        }

        [Test]
        public void DeleteContact_ShouldRemoveContact()
        {
            var contact1 = new Contact { FirstName = "A", LastName = "B", City = "Pune" };
            addressBookService.AddContact(contact1);
           bool result =  addressBookService.DeleteContact("A","B");
            Assert.That(result, Is.True);
           
        }

        [Test]
      public void  EditContact_WhenUpdatePhoneNumber_ThenContactExists()
        {

            var contact = new Contact
            {
                FirstName = "Edit",
                LastName = "User",
                PhoneNumber = "1111"
            };
            addressBookService.AddContact(contact);
            bool result = addressBookService.EditContact("Edit", "User", "2222");
            Assert.That(result, Is.True);
        }

        // LINQ

        [Test]
        public void GetAllContacts_Any_ShouldReturnTrue_WhenContactExists()
        {
            addressBookService.AddContact(new Contact
            {
                FirstName = "Test",
                LastName = "User"
            });

            bool exists = addressBookService.GetAllContacts()
                                            .Any(c => c.FirstName == "Test");

            Assert.That(exists, Is.True);
        }

        // ✅ Exception Test Case: Invalid Email
        [Test]
        public void AddContact_InvalidEmail_ShouldThrowEmailException()
        {
            var contact = new Contact
            {
                FirstName = "Aryan",
                LastName = "Gupta",
                City = "Delhi",
                State = "Delhi",
                ZipCode = "110001",
                PhoneNumber = "9999999999",
                Email = "invalid-email" // ❌ wrong email
            };

            Assert.Throws<EmailException>(() =>
            {
                addressBookService.AddContact(contact);
            });
        }




    }
}