using System.ComponentModel;

namespace ConBook {
  internal class cProductSerializer : cSerializer {

    private string GetFormattedContactString(cProduct xProduct) {
      //funkcja zwracająca kontakt w postaci gotowej do zapisu do pliku
      //xContact - kontakt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{BEGIN_TAG}NAME{END_TAG}{xProduct.Name}{SEPARATOR}" +
        $"{BEGIN_TAG}SYMBOL{END_TAG}{xProduct.Symbol}{SEPARATOR}" +
        $"{BEGIN_TAG}PRICE{END_TAG}{xProduct.Price}{SEPARATOR}\n" +
        $"{END_MARKER}";

    }

    private cProduct GetContactFromFormattedData(string[] xSplittedProductData) {
      //funkcja tworząca kontakt na podstawie sformatowanych danych z pliku
      //xSplittedContactData - tablica zawierająca rodzielone dane kontaktu

      cProduct pProduct = new cProduct();

      foreach (string xData in xSplittedProductData) {
        if (xData.Contains($"{BEGIN_TAG}NAME{END_TAG}")) { pProduct.Name = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}SYMBOL{END_TAG}")) { pProduct.Symbol = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}PRICE{END_TAG}")) { pProduct.Price = double.Parse(RemoveTags(xData)); continue; }
      }

      return pProduct;
    }

    private BindingList<cProduct> GetProductListFromFormatedData(string xFileName) {
      //funkcja tworząca listę kontaktów na podstawie sformatowanych danych z pliku

      List<string[]> pFormattedDataList = base.LoadTxtFile(xFileName);
      BindingList<cProduct> pProductList = new BindingList<cProduct>();

      foreach (string[] pFormattedData in pFormattedDataList) {
        pProductList.Add(GetContactFromFormattedData(pFormattedData));
      }

      return pProductList;
    }

    private List<string> GetFormattedDataList(BindingList<cProduct> xProductsList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie listy kontaków

      List<string> pFormattedDataList = new List<string>();

      foreach (cProduct pProduct in xProductsList) {
        pFormattedDataList.Add(GetFormattedContactString(pProduct));
      }

      return pFormattedDataList;
    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cProduct> xProductsList) {
      //funkcja zapisująca listę kontaktów do nowego pliku

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xProductsList), ref pTemp);

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cProduct> xProductsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca listę kontaktów do nowego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xProductsList), ref xCurrentFilePath);

    }

    public void SaveToExistingTxtFile(string xFileName, BindingList<cProduct> xProductsList) {
      //funkcja zapisująca listę kontaktów do istniejącego pliku

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xProductsList));

    }

    public new BindingList<cProduct> LoadTxtFile(string xFileName) {

      return GetProductListFromFormatedData(xFileName);

    }

  }
}
