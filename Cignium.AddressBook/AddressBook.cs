using System.Collections.Generic;
using System.Linq;
using Cignium.AddressBooks.Tests;

namespace Cignium.AddressBooks
{
    public class AddressBook
    {
        public AddressBook()
        {
            Contacts = new List<Contact>();
        }

        private IList<Contact> Contacts { get; set; }
        public SortBy SortBy { get; set; }

        public Contact AddContact(Contact contact)
        {
            Contacts.Add(contact);
            return contact;
        }

        public IList<Contact> GetContacts()
        {
            return Contacts;
        }

        public IList<Contact> GetContactsOrderedByLastName()
        {
            return GetSorter(SortBy.LastName).Sort(Contacts);
        }

        public IList<Contact> GetContactsOrderedByFirstName()
        {
            return GetSorter(SortBy.FirstName).Sort(Contacts);
        }

        public IList<Contact> Search(string query)
        {
            var matches = Contacts.Where(x => x.IsMatch(query)).ToList();
            return GetSorter().Sort(matches);
        }

        private ContactSorter GetSorter(SortBy? sortBy = null)
        {
            return SortOrderFactory.GetSorter(sortBy ?? SortBy);
        }
    }
}