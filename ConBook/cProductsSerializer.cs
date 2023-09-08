using System.ComponentModel;

namespace ConBook {
  internal class cProductsSerializer : cSerializer {

    public const string DEFAULT_SAVE_FILE_PATH = "product_list.txt";

    private static string GetFormattedProductString(cProduct xProduct) {
      //funkcja zwracająca produkt w sformatowanej postaci (gotowej do zapisu do pliku)
      //xProduct - produkt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{BEGIN_TAG}IDX{END_TAG}{xProduct.Index}{SEPARATOR}" +
        $"{BEGIN_TAG}NAME{END_TAG}{xProduct.Name}{SEPARATOR}" +
        $"{BEGIN_TAG}SYMBOL{END_TAG}{xProduct.Symbol}{SEPARATOR}" +
        $"{BEGIN_TAG}PRICE{END_TAG}{xProduct.Price}{SEPARATOR}\n" +
        $"{END_MARKER}";

    }

    private static cProduct GetProductFromFormattedData(string[] xSplittedProductData) {
      //funkcja zwracająca produkt na podstawie tablicy sformatowanych danych
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

    private static BindingList<cProduct> GetProductListFromFile(string xFileName) {
      //funkcja zwracająca kolekcję produktow na podstawie sformatowanych danych z pliku
      //xFileName - nazwa pliku do wczytania


      List<string[]> pFormattedDataList = cSerializer.LoadTxtFile(xFileName);
      BindingList<cProduct> pProductsList = new BindingList<cProduct>();

      foreach (string[] pFormattedData in pFormattedDataList) {
        cProduct pProduct = GetProductFromFormattedData(pFormattedData);
        pProductsList.Add(pProduct);
      }

      return pProductsList;
    }

    private static BindingList<cProduct> GetProductListFromFile() {

      return GetProductListFromFile(DEFAULT_SAVE_FILE_PATH);


    }

    private static List<string> GetFormattedDataList(BindingList<cProduct> xProductsList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie kolekcji produktów
      //xProductsList - lista produktów do sformatowania

      List<string> pFormattedDataList = new List<string>();

      foreach (cProduct pProduct in xProductsList) {
        string pFormattedProductString = GetFormattedProductString(pProduct);
        pFormattedDataList.Add(pFormattedProductString);
      }

      return pFormattedDataList;
    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cProduct> xProductsList) {
      //funkcja zapisująca kolekcję produktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xProductsList - lista produktów do zapisania

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xProductsList), ref pTemp);

    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cProduct> xProductsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca kolekcję prouktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xProductsList - lista produktów do zapisania
      //xCurrentFilePath - ścieżka aktualnie otwartego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xProductsList), ref xCurrentFilePath);

    }

    public static void SaveToExistingTxtFile(string xFileName, BindingList<cProduct> xProductsList) {
      //funkcja zapisująca listę produktów do istniejącego pliku
      //xFileName - nazwa pliku do wczytania
      //xProductsList - lista produktów do zapisania

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xProductsList));

    }

    private static new BindingList<cProduct> LoadTxtFile(string xFileName) {
      //funkcja wczytująca listę produktów z pliku
      //xFileName - nazwa pliku do wczytania

      return GetProductListFromFile(xFileName);

    }

    public static new BindingList<cProduct> GetProductsList() {
      //funkcja zwracajca kolekcję produktów

      return LoadTxtFile(DEFAULT_SAVE_FILE_PATH);

    }

  }
}
