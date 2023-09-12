using System.ComponentModel;

namespace ConBook {
  internal class cOrder : INotifyPropertyChanged {

    private DateTime mCreationDate;                                    // data utworzenia zamówienia
    private int mIdxContact;                                           // indeks klienta zlecającego
    private List<int> mIdxsProducts;                                   // indeksy produktów w zamówieniu
    private int mIndex;                                                // indeks zamówienia
    private string mNumber;                                            // numer zamówienia

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

    public string Number { 
      
      get {  return mNumber; } 
      
      set {

        if (mNumber != value) {
          mNumber = value;
          OnPropertyChanged(nameof(Number));
        }

      }

    }

    public DateTime CreationDate { 
      
      get {  return mCreationDate; } 
      
      set {
        if (mCreationDate != value) {
          mCreationDate = value;
          OnPropertyChanged(nameof(CreationDate));
        }
      } 

    }
    public int IdxContact { 
      
      get {  return mIdxContact; } 
      
      set {

        if (mIdxContact != value) {
          mIdxContact = value;
          OnPropertyChanged(nameof(IdxContact));
        }

      } 

    }
    public List<int> IdxsProducts { 

      get {  return mIdxsProducts; } 

      set {

        if (mIdxsProducts != value) {
          mIdxsProducts = value;
          OnPropertyChanged(nameof(IdxsProducts));
        }

      } 
    }

    #endregion

    public cOrder() { 
    
      Number = string.Empty;
      CreationDate = DateTime.Now;
      IdxContact = -1;
      IdxsProducts = new List<int>();

    }

    public cOrder(string xNumber, DateTime xCreationDate, int xIdxContact, List<int> xIdxProducts) {

      Number = xNumber;
      CreationDate = xCreationDate;
      IdxContact = xIdxContact;
      IdxsProducts = xIdxProducts;

    }

    protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }


  }
}
