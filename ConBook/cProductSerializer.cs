using System.ComponentModel;

namespace ConBook {
  internal class cProductSerializer : cSerializer {

    private const string DEFAULT_SAVE_FILE_PATH = "product_list.txt";

    private static string GetFormattedContactString(cProduct xProduct) {
      //funkcja zwracająca produkt w sformatowanej postaci (gotowej do zapisu do pliku)
      //xProduct - produkt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{BEGIN_TAG}IDX{END_TAG}{xProduct.Index}{SEPARATOR}" +
        $"{BEGIN_TAG}NAME{END_TAG}{xProduct.Name}{SEPARATOR}" +
        $"{BEGIN_TAG}SYMBOL{END_TAG}{xProduct.Symbol}{SEPARATOR}" +
        $"{BEGIN_TAG}PRICE{END_TAG}{xProduct.Price}{SEPARATOR}\n" +
        $"{END_MARKER}";

    }

    private static cProduct GetContactFromFormattedData(string[] xSplittedProductData) {
      //funkcja tworząca produkt na podstawie sformatowanych danych z pliku
      //xSplittedProductData - tablica zawierająca rodzielone, sformatowane dane produktu

      cProduct pProduct = new cProduct();

      foreach (string xData in xSplittedProductData) {
        if (xData.Contains($"{BEGIN_TAG}IDX{END_TAG}")) { pProduct.Index = int.Parse(RemoveTags(xData)); continue; }
        if (xData.Contains($"{BEGIN_TAG}NAME{END_TAG}")) { pProduct.Name = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}SYMBOL{END_TAG}")) { pProduct.Symbol = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}PRICE{END_TAG}")) { pProduct.Price = double.Parse(RemoveTags(xData)); continue; }
      }

      return pProduct;
    }

    private static BindingList<cProduct> GetProductListFromFormatedData(string xFileName = DEFAULT_SAVE_FILE_PATH) {
      //funkcja tworząca listę produktow na podstawie sformatowanych danych z pliku
      //xFileName - nazwa pliku do wczytania


      List<string[]> pFormattedDataList = cSerializer.LoadTxtFile(xFileName);
      BindingList<cProduct> pProductList = new BindingList<cProduct>();

      foreach (string[] pFormattedData in pFormattedDataList) {
        pProductList.Add(GetContactFromFormattedData(pFormattedData));
      }

      return pProductList;
    }

    private static List<string> GetFormattedDataList(BindingList<cProduct> xProductsList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie listy produktów
      //xProductsList - lista produktów do sformatowania

      List<string> pFormattedDataList = new List<string>();

      foreach (cProduct pProduct in xProductsList) {
        pFormattedDataList.Add(GetFormattedContactString(pProduct));
      }

      return pFormattedDataList;
    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cProduct> xProductsList) {
      //funkcja zapisująca listę produktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xProductsList - lista produktów do zapisania

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xProductsList), ref pTemp);

    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cProduct> xProductsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca listę kontaktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xProductsList - lista produktów do zapisania
      //xCurrentFilePath - ścieżka aktualnie otwartego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xProductsList), ref xCurrentFilePath);

    }

    public static void SaveToExistingTxtFile(string xFileName = DEFAULT_SAVE_FILE_PATH, BindingList<cProduct> xProductsList) {
      //funkcja zapisująca listę produktów do istniejącego pliku
      //xFileName - nazwa pliku do wczytania
      //xProductsList - lista produktów do zapisania

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xProductsList));

    }

    public static new BindingList<cProduct> LoadTxtFile(string xFileName = DEFAULT_SAVE_FILE_PATH) {
      //funkcja wczytująca listę produktów z pliku
      //xFileName - nazwa pliku do wczytania

      return GetProductListFromFormatedData(xFileName);

    }

  }
}
