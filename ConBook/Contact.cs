using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConBook
{
    public class Contact : IComparable<Contact>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public Contact()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Phone = string.Empty;
        }

        public Contact(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override bool Equals(object? obj)
        {
            return obj is Contact contact &&
                   Name == contact.Name &&
                   Surname == contact.Surname &&
                   Phone == contact.Phone;
        }

        public int CompareTo(Contact? other)
        {
            if (other == null) return 1;
            return Surname.CompareTo(other.Surname);
        }

    }
}
