﻿using System.Net.Sockets;

namespace ConBook {
  public class cContact : IComparable<cContact> {

    private string mName;
    private string mSurname;
    private string mPhone;
    private string mDescription;
    private string mNotes;
    //private string mAddress;

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    //public string Address { get; set; }


    public cContact() {

      Name = string.Empty;
      Surname = string.Empty;
      Phone = string.Empty;
      Description = string.Empty;
      Notes = string.Empty;
      //Address = string.Empty;
      
    }

    public cContact(string xName, string xSurname, string xPhone, string xDescription = "", string xNotes = "") {

      Name = xName;
      Surname = xSurname;
      Phone = xPhone;
      Description = xDescription;
      Notes = xNotes;
      //Address = xAddress;

    }

    public class NamesComparer : IComparer<cContact> {

      public int Compare(cContact? xContact, cContact? xOther) {
        //funkcja porównująca kontakty po imionach

        if (xContact == null || xOther == null) return 1;
        return xContact.Name.CompareTo(xOther.Name);

      }

    }

    public int CompareTo(cContact? xOther) {
      // funkcja porównująca kontakty po nazwiskach (domyślne porównywanie)

      if (xOther == null) return 1;

      return Surname.CompareTo(xOther.Surname);

    }

    public bool IsEmpty() {
      //funkcja sprawdzająca, czy kontakt jest pusty

      return (Name == string.Empty) && (Surname == string.Empty) && (Phone == string.Empty);

    }

  }
}
