using System.ComponentModel;

namespace ConBook {
  internal class cOrderSerializer : cSerializer {

    public const string DEFAULT_SAVE_FILE_PATH = "orders_list.txt";

    private const string INDEX_TAG = $"{BEGIN_TAG}IDX{END_TAG}";
    private const string NUMBER_TAG = $"{BEGIN_TAG}NUMBER{END_TAG}";
    private const string CONTACTS_TAG = $"{BEGIN_TAG}CONTACTS{END_TAG}";
    private const string PRODUCTS_TAG = $"{BEGIN_TAG}PRODUCTS{END_TAG}";


    private static string GetFormattedOrderString(cOrder xOrder) {
      //funkcja zwracająca zamówienie w sformatowanej postaci (gotowej do zapisu do pliku)
      //xOrder - zamówienie do sformatowania

      string pOrdersIndexesString = string.Join(",", xOrder.IdxsProducts);

      return $"{BEGIN_MARKER}\n" +
        $"{INDEX_TAG}{xOrder.Index}{SEPARATOR}" +
        $"{NUMBER_TAG}{xOrder.Number}{SEPARATOR}" +
        $"{CONTACTS_TAG}{xOrder.IdxContact}{SEPARATOR}" +
        $"{PRODUCTS_TAG}{pOrdersIndexesString}{SEPARATOR}\n" +
        $"{END_MARKER}";

    }

    private static cOrder GetOrderFromFormattedData(string[] xSplittedOrderData) {
      //funkcja zwracająca zamówienie na podstawie tablicy sformatowanych danych
      //xSplittedOrderData - tablica zawierająca rodzielone, sformatowane dane zamówienieu

      cOrder pOrder = new cOrder();

      foreach (string xData in xSplittedOrderData) {
        if (xData.Contains($"{INDEX_TAG}")) { pOrder.Index = int.Parse(RemoveTags(xData)); continue; }
        if (xData.Contains($"{NUMBER_TAG}")) { pOrder.Number = RemoveTags(xData); continue; }
        if (xData.Contains($"{CONTACTS_TAG}")) { pOrder.IdxContact = int.Parse(RemoveTags(xData)); continue; }
        if (xData.Contains($"{PRODUCTS_TAG}")) { pOrder.IdxsProducts = ConvertStringIndexesToList(RemoveTags(xData)); continue; }
      }

      return pOrder;
    }

    private static List<int> ConvertStringIndexesToList(string xStringIndexes) {

      string[] pSplittedIndexesArray = xStringIndexes.Split(',');
      int[] pConvertedIndexesArray = Array.ConvertAll(pSplittedIndexesArray, s => int.Parse(s));

      List<int> pConvertedIndexesList = new List<int>(pConvertedIndexesArray);

      return pConvertedIndexesList;

    }

    private static BindingList<cOrder> GetOrdersListFromFile(string xFileName) {
      //funkcja zwracająca kolekcję zamówień na podstawie sformatowanych danych z pliku
      //xFileName - nazwa pliku do wczytania


      List<string[]> pFormattedDataList = cSerializer.LoadTxtFile(xFileName);
      BindingList<cOrder> pOrdersList = new BindingList<cOrder>();

      foreach (string[] pFormattedData in pFormattedDataList) {
        cOrder pOrder = GetOrderFromFormattedData(pFormattedData);
        pOrdersList.Add(pOrder);
      }

      return pOrdersList;
    }

    private static BindingList<cOrder> GetOrdersListFromFile() {

      return GetOrdersListFromFile(DEFAULT_SAVE_FILE_PATH);


    }

    private static List<string> GetFormattedDataList(BindingList<cOrder> xOrdersList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie kolekcji zamówień
      //xOrdersList - lista zamówień do sformatowania

      List<string> pFormattedDataList = new List<string>();

      foreach (cOrder pOrder in xOrdersList) {
        string pFormattedOrderString = GetFormattedOrderString(pOrder);
        pFormattedDataList.Add(pFormattedOrderString);
      }

      return pFormattedDataList;
    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cOrder> xOrdersList) {
      //funkcja zapisująca kolekcję zamówień do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xOrdersList - lista zamówień do zapisania

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xOrdersList), ref pTemp);

    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cOrder> xOrdersList, ref string? xCurrentFilePath) {
      //funkcja zapisująca kolekcję prouktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xOrdersList - lista zamówień do zapisania
      //xCurrentFilePath - ścieżka aktualnie otwartego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xOrdersList), ref xCurrentFilePath);

    }

    public static void SaveToExistingTxtFile(string xFileName, BindingList<cOrder> xOrdersList) {
      //funkcja zapisująca listę zamówień do istniejącego pliku
      //xFileName - nazwa pliku do wczytania
      //xOrdersList - lista zamówień do zapisania

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xOrdersList));

    }

    private static new BindingList<cOrder> LoadTxtFile(string xFileName) {
      //funkcja wczytująca listę zamówień z pliku
      //xFileName - nazwa pliku do wczytania

      return GetOrdersListFromFile(xFileName);

    }

    public static new BindingList<cOrder> GetOrdersList() {
      //funkcja zwracajca kolekcję zamówień

      return LoadTxtFile(DEFAULT_SAVE_FILE_PATH);

    }


  }
}
