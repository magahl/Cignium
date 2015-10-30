using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Cignium.AddressBooks.Tests
{
    public class ContactUT : BaseTest
    {
        [Test]
        public void Ctor_EmptyNumbers()
        {
            var contact = new Contact();
            Assert.That(contact.GetContactEntries(), Is.Empty);
        }

        [Test]
        public void AddContactEntry_AddPhoneNumber_OneEntry()
        {
            var contact = new Contact();
            contact.AddContactEntry(new PhoneNumer("0702-937123"));

            var entries = contact.GetContactEntries();

            Assert.That(entries, Has.Count.EqualTo(1));
            Assert.That(entries[0].Name, Is.EqualTo("Phone"));
            Assert.That(entries[0].Info, Is.EqualTo("0702-937123"));
        }

        [Test]
        public void AddContactEntry_AddPhoneNumberWithCountryCode_OneEntry()
        {
            var contact = new Contact();
            contact.AddContactEntry(new PhoneNumer("+46702-937123"));

            var entries = contact.GetContactEntries();

            Assert.That(entries, Has.Count.EqualTo(1));
            Assert.That(entries[0].Name, Is.EqualTo("Phone"));
            Assert.That(entries[0].Info, Is.EqualTo("+46702-937123"));
        }

        [Test]
        public void AddContactEntry_Email_OneEntry()
        {
            var contact = new Contact();
            contact.AddContactEntry(new Email("mag.ahlberg@gmail.com"));

            var entries = contact.GetContactEntries();

            Assert.That(entries, Has.Count.EqualTo(1));
            Assert.That(entries[0].Name, Is.EqualTo("Email"));
            Assert.That(entries[0].Info, Is.EqualTo("mag.ahlberg@gmail.com"));
        }

        [Test]
        public void AddContactEntry_EmailAndPhone_TwoEntries()
        {
            var contact = new Contact();
            contact.AddContactEntry(new PhoneNumer("0702-937123"));
            contact.AddContactEntry(new Email("mag.ahlberg@gmail.com"));

            var entries = contact.GetContactEntries();

            Assert.That(entries, Has.Count.EqualTo(2));
        }

        [Test]
        public void AddContactEntry_InvalidEmail_NoEntry()
        {
            var contact = new Contact();
            
            Assert.Throws<ArgumentException>(() => contact.AddContactEntry(new Email("invalid.email2gmail.com")));
            var entries = contact.GetContactEntries();
            Assert.That(entries, Is.Empty);
        }

        [Test]
        public void AddContactEntry_InvalidPhone_NoEntry()
        {
            var contact = new Contact();
            
            Assert.Throws<ArgumentException>(() => contact.AddContactEntry(new PhoneNumer("0702-9371ab")));
            var entries = contact.GetContactEntries();
            Assert.That(entries, Is.Empty);
        }
    }
}