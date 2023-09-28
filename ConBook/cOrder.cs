using System.ComponentModel;

namespace ConBook {
  internal class cOrder : INotifyPropertyChanged {

    private DateTime mCreationDate;                                    // data utworzenia zamówienia
    private int mIdxContact;                                           // indeks klienta zlecającego
    private int mIndex;                                                // indeks zamówienia
    private string? mNumber;                                           // numer zamówienia

    private BindingList<cOrderedProduct>? mOrderedProductsList;        // zamówione produkty (produkty wybrane w danym zamówieniu)

    public event PropertyChangedEventHandler? PropertyChanged;         // zdarzenie zmiany właściwości Zamówienia (pozwalające na data binding)

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

    public string? Number { 
      
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
    public BindingList<cOrderedProduct>? OrderedProductsList { 

      get {  return mOrderedProductsList; } 

      set {

        if (mOrderedProductsList != value) {
          mOrderedProductsList = value;
          OnPropertyChanged(nameof(OrderedProductsList));
        }

      } 
    }

    #endregion

    public cOrder() { 
    
      Number = string.Empty;
      CreationDate = DateTime.Now;
      IdxContact = -1;
      OrderedProductsList = new BindingList<cOrderedProduct>();

    }

    public cOrder(string xNumber, DateTime xCreationDate, int xIdxContact, BindingList<cOrderedProduct> xIdxProducts) {

      Number = xNumber;
      CreationDate = xCreationDate;
      IdxContact = xIdxContact;
      OrderedProductsList = xIdxProducts;

    }

    protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

  }
}
