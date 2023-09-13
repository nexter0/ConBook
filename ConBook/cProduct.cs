using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConBook {
  internal class cProduct : INotifyPropertyChanged {

    private int mIndex;                                                 // indeks produktu                                             
    private string mName;                                               // nazwa produktu
    private string mSymbol;                                             // symbol produktu
    private double mPrice;                                              // cena produktu

    public event PropertyChangedEventHandler PropertyChanged;           // zdarzenie zmiany właściwości Towaru (pozwalające na data binding)

    #region Properties
    public int Index { get; set; }

    public string Name {

      get { return mName; }
      set {

        if (mName != value) {
          mName = value;
          OnPropertyChanged(nameof(Name));
        }

      }

    }


    public string Symbol {

      get { return mSymbol; }
      set {

        if (mSymbol != value) {
          mSymbol = value;
          OnPropertyChanged(nameof(Symbol));
        }

      }

    }
    public double Price {

      get { return mPrice; }
      set { 
      
        if (value < 0) throw new ArgumentOutOfRangeException("Nieprawidłowa wartość Ceny produktu");

        if (mPrice != value) {
          mPrice = value;
          OnPropertyChanged(nameof(Price));
        }

      }

    }

    public cProduct(string xName, string xSymbol, double xPrice) {

      Name = xName;
      Symbol = xSymbol;
      Price = xPrice;
    
    }

    public cProduct() {

      Name = string.Empty;
      Symbol = string.Empty;
      Price = 0.00;

    }
    #endregion

    protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    public bool IsEmpty() {
      //funkcja sprawdzająca, czy produkt jest pusty

      return (Name == string.Empty) && (Symbol == string.Empty) && (Price == 0);

    }

    public static bool CheckIfSymbolExists(BindingList<cProduct> xProductsList, string xSymbol) {
      //funkcja sprawdzająca czy w liście produktów istnieje produkt z danym symbolem

      return xProductsList.Any(pProduct => pProduct.Symbol == xSymbol);

    }

  }

  internal class cOrderedProduct : INotifyPropertyChanged {

    private int? mIndex;
    private int? mAmount;
    private double? mSellPrice;
    private double? mTotalPrice;

    public event PropertyChangedEventHandler PropertyChanged;          // zdarzenie zmiany właściwości Zamówienia (pozwalające na data binding)

    public int? Index {

      get { return mIndex; }

      set {

        if (mIndex != value) {
          mIndex = value;
          OnPropertyChanged(nameof(Index));
        }

      }
    }

    public int? Amount {

      get { return mAmount; }

      set {

        if (mAmount != value) {
          mAmount = value;
          OnPropertyChanged(nameof(Amount));
        }

        UpdateTotalPrice();
      }
    }

    public double? SellPrice {

      get { return mSellPrice; }

      set {

        if (mSellPrice != value) {
          mSellPrice = value;
          OnPropertyChanged(nameof(SellPrice));
        }

        UpdateTotalPrice();
      }
    }

    public double? TotalPrice {

      get { return mTotalPrice; }
    }

    public cOrderedProduct(int? xIndex, int? xAmount, double? xSellPrice) {

      Index = xIndex;
      Amount = xAmount;
      SellPrice = xSellPrice;
      UpdateTotalPrice();

    }

    public cOrderedProduct() {

      new cOrderedProduct(null, null, null);

    }

    protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    private void UpdateTotalPrice() {
      //funkcja aktualizująca property TotalPrice

      if (Amount != null && SellPrice != null)
        mTotalPrice = Math.Round((double)(Amount * SellPrice), 2);
      else
        mTotalPrice = 0;
    }

  }

}
