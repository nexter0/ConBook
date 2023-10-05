using System.ComponentModel;

namespace ConBook {
  public class cContact : IComparable<cContact>, INotifyPropertyChanged {

    private string mDescription;                        // opis kontaktu
    private int mIndex;                                 // indeks kontaktu
    private string mName;                               // imię
    private string mNotes;                              // notatki
    private string mPhone;                              // nr telefonu
    private string mSurname;                            // nazwisko

    public event PropertyChangedEventHandler PropertyChanged;          // zdarzenie zmiany właściwości Zamówienia (pozwalające na data binding)

    #region Properties
    public int Index {

      get { return mIndex; }

      set {

        if (mIndex != value) {
          mIndex = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }
    public string Name {

      get { return mName; }

      set {

        if (mName != value) {
          mName = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }
    public string Surname {

      get { return mSurname; }

      set {

        if (mSurname != value) {
          mSurname = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }
    public string Phone {
      get { return mPhone; }

      set {

        if (mPhone != value) {
          mPhone = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }
    public string Description {
      get { return mDescription; }

      set {

        if (mDescription != value) {
          mDescription = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }
    public string Notes {
      get { return mNotes; }

      set {

        if (mNotes != value) {
          mNotes = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }
    public string DisplayText {

      get { return ToString(); }

    }

    #endregion

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

    #region Comparers
    public class NamesComparer : IComparer<cContact> {

      public int Compare(cContact? xContact, cContact? xOther) {
        //funkcja porównująca kontakty po imionach

        if (xContact == null || xOther == null) return 1;
        return xContact.Name.CompareTo(xOther.Name);

      }

    }

    public class IndexComparer : IComparer<cContact> {

      public int Compare(cContact? xContact, cContact? xOther) {
        //funkcja porównująca kontakty po indeksach

        if (xContact == null || xOther == null) return 1;
        return xContact.Index.CompareTo(xOther.Index);

      }

    }

    #endregion

    public override string ToString() {

      return $"{Name} {Surname}";

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

    protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

  }
}
