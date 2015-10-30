using System;
using System.Collections.Generic;
using System.Linq;

namespace Cignium.AddressBooks
{
    public abstract class ContactSorter
    {
        public abstract IList<Contact> Sort(IList<Contact> contacts );
    }

    public class LastNameSorter : ContactSorter
    {
        public override IList<Contact> Sort(IList<Contact> contacts)
        {
            return contacts.OrderBy(x => x.LastName).ToList();
        }
    }

    public class FirstNameSorter : ContactSorter
    {
        public override IList<Contact> Sort(IList<Contact> contacts)
        {
            return contacts.OrderBy(x => x.FirstName).ToList();
        }
    }
}