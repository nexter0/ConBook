using System.Xml.Linq;

namespace ConBook {
  public class cContact : IComparable<cContact> {

    private string mName;
    private string mSurname;
    private string mPhone;
    private string mDescription;
    private string mNotes;

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }


    public cContact() {

      Name = string.Empty;
      Surname = string.Empty;
      Phone = string.Empty;
      Description = string.Empty;
      Notes = string.Empty;

    }

    public cContact(string xName, string xSurname, string xPhone, string xDescription = "", string xNotes = "") {

      Name = xName;
      Surname = xSurname;
      Phone = xPhone;
      Description = xDescription;
      Notes = xNotes;

    }

    public cContact(string[] xData) {

      Name = xData[0];
      Surname = xData[1];
      Phone = xData[2];
      Description = xData.Length >= 4 ? xData[3] : string.Empty;
      Notes = xData.Length >= 5 ? xData[4] : string.Empty;

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

      return $"<\n{Name}|{Surname}|{Phone}|{Description}|{Notes}\n>";

    }

    public bool IsEmpty() {

      return (Name == string.Empty) && (Surname == string.Empty) && (Phone == string.Empty);

    }

  }
}
