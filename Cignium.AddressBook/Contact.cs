using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Cignium.AddressBooks
{
    public class Contact
    {
        public Contact()
        {
            Entries = new List<ContactEntry>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        private IList<ContactEntry> Entries { get; set; }

        public IList<ContactEntry> GetContactEntries()
        {
            return Entries;
        }

        public void AddContactEntry(ContactEntry entry)
        {
            if (!entry.IsValid())
            {
                throw new ArgumentException("The entry is not valid.", "entry");
            }
            Entries.Add(entry);
        }

        public bool IsMatch(string query)
        {
            return Entries.Any(x => x.IsMatch(query));
        }
    }
}