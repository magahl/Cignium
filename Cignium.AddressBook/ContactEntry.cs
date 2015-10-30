using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Cignium.AddressBooks
{
    public abstract class ContactEntry
    {
        public abstract string Name { get; } 
        public string Info { get; set; }

        public abstract bool IsValid();
        public abstract bool IsMatch(string query);
    }

    public class Email : ContactEntry
    {
        public Email(string email)
        {
            Info = email;
        }

        public override string Name { get { return "Email";  } }

        public override bool IsValid()
        {
            try
            {
                new MailAddress(Info);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public override bool IsMatch(string query)
        {
            query = query.Replace("@", "");
            return query.Length > 0 && Info.Contains(query);
        }
    }

    public class PhoneNumer : ContactEntry
    {
        public PhoneNumer(string number)
        {
            Info = number;
        }

        public override string Name { get { return "Phone"; } }

        public override bool IsValid()
        {
            return Regex.Replace(Info, @"[-+ ]|[\d+]", "").Length == 0;
        }

        public override bool IsMatch(string query)
        {
            var regex = new Regex(@"\D", RegexOptions.IgnoreCase);
            return regex.Replace(Info, "").Contains(regex.Replace(query, ""));
        }
    }
}