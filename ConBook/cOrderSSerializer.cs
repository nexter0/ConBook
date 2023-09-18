using System.ComponentModel;

namespace ConBook {
  internal class cOrderSSerializer : cSerializer {

    public const string DEFAULT_SAVE_FILE_PATH = "orders_list.txt";

    private const string INDEX_TAG = $"{BEGIN_TAG}IDX{END_TAG}";
    private const string NUMBER_TAG = $"{BEGIN_TAG}NUMBER{END_TAG}";
    private const string CONTACT_TAG = $"{BEGIN_TAG}CONTACT{END_TAG}";
    private const string PRODUCTS_TAG = $"{BEGIN_TAG}PRODUCTS{END_TAG}";
    private const string PRODUCT_INDEX_TAG = $"{BEGIN_TAG}PRD_IDX{END_TAG}";
    private const string PRODUCT_AMOUNT_TAG = $"{BEGIN_TAG}PRD_AMNT{END_TAG}";
    private const string PRODUCT_SELLPRICE_TAG = $"{BEGIN_TAG}PRD_PRC{END_TAG}";
    private const string PRD_INNER_SEPARATOR = ";;";
    private const string PRD_OUTER_SEPARATOR = "||";

    private static string GetFormattedOrderString(cOrder xOrder) {
      //funkcja zwracająca zamówienie w sformatowanej postaci (gotowej do zapisu do pliku)
      //xOrder - zamówienie do sformatowania

      string pFormattedOderedProductsListString = OrderedProductsListToString(xOrder.OrderedProductsList);

      return $"{BEGIN_MARKER}\n" +
        $"{INDEX_TAG}{xOrder.Index}{SEPARATOR}" +
        $"{NUMBER_TAG}{xOrder.Number}{SEPARATOR}" +
        $"{CONTACT_TAG}{xOrder.IdxContact}{SEPARATOR}" +
        $"{PRODUCTS_TAG}{pFormattedOderedProductsListString}{SEPARATOR}\n" +
        $"{END_MARKER}";

    }

    private static string GetFormattedOrderedProductString(cOrderedProduct xOrderedProduct) {
      //funkcja zwracająca zamówiony produkt w sformatowanej postaci (gotowej do zapisu do pliku)
      //xOrderedProduct - zamówiony produkt do sformatowania

      return $" {PRODUCT_INDEX_TAG}{xOrderedProduct.Index}{PRD_INNER_SEPARATOR}" +
        $"{PRODUCT_AMOUNT_TAG}{xOrderedProduct.Amount}{PRD_INNER_SEPARATOR}" +
        $"{PRODUCT_SELLPRICE_TAG}{xOrderedProduct.Price_Sold}{PRD_OUTER_SEPARATOR}";

    }

    private static string OrderedProductsListToString(BindingList<cOrderedProduct> xOrderedProductsList) {
      //funkcja zwracająca listę zamówionych produktów w sformatowanej postaci (gotowej do zapisu do pliku)
      //xOrderedProductsList - lista zamówionych produktów

      string pResult = string.Empty;

      foreach (cOrderedProduct pOrderedProduct in xOrderedProductsList) {
        pResult += GetFormattedOrderedProductString(pOrderedProduct);
      }

      return pResult;

    }

    private static BindingList<cOrderedProduct> GetOrderedProductsListFromData(string xData) {
      //funkcja zwracająca listę zamówionych produktów wna podstawie sformatowanych danych z pliku
      //xData - 

      List<string> pSplittedDataList;
      BindingList<cOrderedProduct> pOrderedProductsList = new BindingList<cOrderedProduct>();
      cOrderedProduct pOrderedProduct = new cOrderedProduct(); ;

      xData = xData.Replace("$<PRODUCTS>$ ", string.Empty);
      xData = xData.Replace("::", string.Empty);
      xData = xData.Replace(">*", string.Empty);

      pSplittedDataList = xData.Split(PRD_OUTER_SEPARATOR).ToList();

      foreach (string pData in pSplittedDataList) {

        if (pData == string.Empty)
          continue;

        pOrderedProduct = new cOrderedProduct();

        List<string> pSplittedSingleProductDataList;
        pSplittedSingleProductDataList = pData.Split(PRD_INNER_SEPARATOR).ToList();


        foreach (string pSingleProductData in pSplittedSingleProductDataList) {

          if (pSingleProductData == string.Empty)
            continue;

          if (pSingleProductData.Contains($"{PRODUCT_INDEX_TAG}")) { pOrderedProduct.Index = int.Parse(RemoveTags(pSingleProductData)); continue; }
          if (pSingleProductData.Contains($"{PRODUCT_AMOUNT_TAG}")) { pOrderedProduct.Amount = int.Parse(RemoveTags(pSingleProductData)); continue; }
          if (pSingleProductData.Contains($"{PRODUCT_SELLPRICE_TAG}")) { pOrderedProduct.Price_Sold = double.Parse(RemoveTags(pSingleProductData)); continue; }

        }
        if (pOrderedProduct != null)
          pOrderedProductsList.Add(pOrderedProduct);
      }

      return pOrderedProductsList;
    }

    private static cOrder GetOrderFromFormattedData(string[] xSplittedOrderData) {
      //funkcja zwracająca zamówienie na podstawie tablicy sformatowanych danych
      //xSplittedOrderData - tablica zawierająca rodzielone, sformatowane dane zamówienieu

      cOrder pOrder = new cOrder();

      foreach (string pData in xSplittedOrderData) {
        if (pData == string.Empty)
          continue;
        if (pData.Contains($"{INDEX_TAG}")) { pOrder.Index = int.Parse(RemoveTags(pData)); continue; }
        if (pData.Contains($"{NUMBER_TAG}")) { pOrder.Number = RemoveTags(pData); continue; }
        if (pData.Contains($"{CONTACT_TAG}")) { pOrder.IdxContact = int.Parse(RemoveTags(pData)); continue; }
        if (pData.Contains($"{PRODUCTS_TAG}")) { pOrder.OrderedProductsList = GetOrderedProductsListFromData(pData); continue; }
      }

      return pOrder;
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
