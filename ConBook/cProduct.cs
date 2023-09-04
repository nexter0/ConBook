using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConBook {
  internal class cProduct : INotifyPropertyChanged {

    public event PropertyChangedEventHandler PropertyChanged;           // zdarzenie zmiany właściwości Towaru (pozwalające na data binding)

    private string mName;
    private string mSymbol;
    private double mPrice;

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

      protected void OnPropertyChanged(string propertyName) {
      //funkcja wywołująca zdarzenie zmiany właściwości towaru

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    public bool IsEmpty() {
      //funkcja sprawdzająca, czy produkt jest pusty

      return (Name == string.Empty) && (Symbol == string.Empty) && (Price == 0);

    }

  }

}
