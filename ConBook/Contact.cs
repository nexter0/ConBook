namespace ConBook
{
    public class cContact : IComparable<cContact>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public cContact()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Phone = string.Empty;
        }

        public cContact(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public override bool Equals(object? obj)
        {
            return obj is cContact cContact &&
                   Name == cContact.Name &&
                   Surname == cContact.Surname &&
                   Phone == cContact.Phone;
        }

        public int CompareTo(cContact? other)
        {
            if (other == null) return 1;
            return Surname.CompareTo(other.Surname);
        }

        public override string ToString() {
            return $"{Name} {Surname} {Phone}";
        }
    }
}
