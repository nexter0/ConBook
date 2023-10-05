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

    private int mIndex;
    private int mIdxProduct;
    private int mIdxOrder;
    private int mQuantity;
    private double mPrice_Sold;
    private double mPrice_Total;

    public event PropertyChangedEventHandler? PropertyChanged;          // zdarzenie zmiany właściwości Zamówienia (pozwalające na data binding)

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

    public int IdxProduct {

      get { return mIdxProduct; }

      set {

        if (mIdxProduct != value) {
          mIdxProduct = value;
          OnPropertyChanged(nameof(IdxProduct));
        }

      }
    }

    public int IdxOrder {

      get { return mIdxOrder; }

      set {

        if (mIdxOrder != value) {
          mIdxOrder = value;
          OnPropertyChanged(nameof(IdxOrder));
        }

      }
    }

    public int Quantity {

      get { return mQuantity; }

      set {

        if (mQuantity != value) {
          mQuantity = value;
          OnPropertyChanged(nameof(Quantity));
        }

        UpdateTotalPrice();
      }
    }

    public double Price_Sold {

      get { return mPrice_Sold; }

      set {

        if (mPrice_Sold != value) {
          mPrice_Sold = value;
          OnPropertyChanged(nameof(Price_Sold));
        }

        UpdateTotalPrice();
      }
    }

    public double Price_Total {

      get { return mPrice_Total; }
    }

    #endregion

    public cOrderedProduct(int xIdxOrder, int xIdxProduct, int xQuantity, double xSellPrice) {

      Index = 0;
      IdxOrder = xIdxOrder;
      IdxProduct = xIdxProduct;
      Quantity = xQuantity;
      Price_Sold = xSellPrice;
      UpdateTotalPrice();

    }

    public cOrderedProduct() {

      new cOrderedProduct(0, 0, 0, 0);

    }

    protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    public override bool Equals(object? obj) {

      try {

        if (obj != null)
          return this.Index == ((cOrderedProduct)obj).Index;

        return false;

      } catch { return false; }

    }

    private void UpdateTotalPrice() {
      //funkcja aktualizująca property TotalPrice

      if (Quantity != 0 && Price_Sold != 0)
        mPrice_Total = Math.Round((double)(Quantity * Price_Sold), 2);
      else
        mPrice_Total = 0;
    }

  }

}
