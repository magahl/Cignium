using NUnit.Framework;

namespace Cignium.AddressBooks.Tests
{
    public class AddressBookUT : BaseTest
    {
        [Test]
        public void Ctor_EmptyContacts()
        {
            var addressBook = new AddressBook();
            Assert.That(addressBook.GetContacts(), Is.Empty);
        }
        
        [Test]
        public void AddContact_CorrectOrder()
        {
            var addressBook = new AddressBook();
            addressBook.AddContact(new Contact()
            {
                FirstName = "Magnus",
                LastName = "Ahlberg"
            });

            Assert.That(addressBook.GetContacts(), Has.Count.EqualTo(1));
        }

        [Test]
        public void AddContact_TwoContact_CorrectOrder()
        {
            var addressBook = new AddressBook();

            addressBook.AddContact(new Contact()
            {
                FirstName = "Magnus",
                LastName = "Ahlberg"
            });
            
            addressBook.AddContact(new Contact()
            {
                FirstName = "Hans",
                LastName = "Fjällmark"
            });

            Assert.That(addressBook.GetContacts(), Has.Count.EqualTo(2));
        }

        [Test]
        public void AddContact_GetContactsByLastName_CorrectOrder()
        {
            var addressBook = new AddressBook();

            addressBook.AddContact(new Contact()
            {
                FirstName = "Hans",
                LastName = "Fjällmark"
            });
            addressBook.AddContact(new Contact()
            {
                FirstName = "Magnus",
                LastName = "Ahlberg"
            });

            var contacts = addressBook.GetContactsOrderedByLastName();
            
            Assert.That(contacts, Has.Count.EqualTo(2));
            Assert.That(contacts[0].FirstName, Is.EqualTo("Magnus"));
            Assert.That(contacts[1].FirstName, Is.EqualTo("Hans"));
        }

        [Test]
        public void AddContact_GetContactsByFirstName_CorrectOrder()
        {
            var addressBook = new AddressBook();

            addressBook.AddContact(new Contact
            {
                FirstName = "Hans",
                LastName = "Fjällmark"
            });

            addressBook.AddContact(new Contact
            {
                FirstName = "Magnus",
                LastName = "Ahlberg"
            });

            var contacts = addressBook.GetContactsOrderedByFirstName();
            
            Assert.That(contacts, Has.Count.EqualTo(2));
            Assert.That(contacts[0].FirstName, Is.EqualTo("Hans"));
            Assert.That(contacts[1].FirstName, Is.EqualTo("Magnus"));
        }

        [TestCase("0702", 1)]
        [TestCase("0702-", 1)]
        [TestCase("07029", 1)]
        [TestCase("070", 2)]
        public void Search_SearchingForNumber_CorrectHits(string query, int hits)
        {
            var addressBook = new AddressBook();

            var contact = Contact();
            contact.AddContactEntry(new PhoneNumer("0702-937123"));
            addressBook.AddContact(contact);

            var contact2 = Contact();
            contact2.AddContactEntry(new PhoneNumer("0701-879874"));
            addressBook.AddContact(contact2);

            var contacts = addressBook.Search(query);
            
            Assert.That(contacts, Has.Count.EqualTo(hits));
        }

        [TestCase("magnus", 1)]
        [TestCase("hans", 1)]
        [TestCase("cignium", 2)]
        [TestCase("@", 0)]
        public void Search_SearchingForEmail_CorrectHits(string query, int hits)
        {
            var addressBook = new AddressBook();

            var contact = Contact();
            contact.AddContactEntry(new Email("magnus.ahlberg@cignium.com"));
            addressBook.AddContact(contact);

            var contact2 = Contact();
            contact2.AddContactEntry(new Email("Hhans.fjallmark@cignium.com"));
            addressBook.AddContact(contact2);

            var contacts = addressBook.Search(query);
            
            Assert.That(contacts, Has.Count.EqualTo(hits));
        }

        private static Contact Contact()
        {
            return new Contact
            {
                FirstName = "Test",
                LastName = "User"
            };
        }
    }
}