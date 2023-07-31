namespace ConBook {
  public class cContact : IComparable<cContact> {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }

    public cContact() {

      Name = string.Empty;
      Surname = string.Empty;
      Phone = string.Empty;

    }

    public cContact(string xName, string xSurname, string xPhone) {

      Name = xName;
      Surname = xSurname;
      Phone = xPhone;

    }

    public override bool Equals(object? xObject) {

      return xObject is cContact cContact &&
             Name == cContact.Name &&
             Surname == cContact.Surname &&
             Phone == cContact.Phone;

    }

    public class NamesComparer : IComparer<cContact> {

      public int Compare(cContact? xContact, cContact? xOther) {

        if (xContact == null || xOther == null) return 1;
        return xContact.Name.CompareTo(xOther.Name);

      }

    }

    public int CompareTo(cContact? xOther) {

      if (xOther == null) return 1;

      return Surname.CompareTo(xOther.Surname);

    }

    public override string ToString() {

      return $"{Name} {Surname} {Phone}";

    }

    public bool IsEmpty() {

      return (Name == string.Empty) && (Surname == string.Empty) && (Phone == string.Empty);

    }

  }
}
