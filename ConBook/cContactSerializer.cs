using System.ComponentModel;

namespace ConBook {
  internal class cContactSerializer : cSerializer {

    private const string DEFAULT_SAVE_FILE_PATH = "contact_list.txt";

    private static string GetFormattedContactString(cContact xContact) {
      //funkcja zwracająca kontakt w sformatowanej postaci (gotowej do zapisu do pliku)
      //xContact - kontakt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{BEGIN_TAG}IDX{END_TAG}{xContact.Index}{SEPARATOR}" +
        $"{BEGIN_TAG}NAME{END_TAG}{xContact.Name}{SEPARATOR}" +
        $"{BEGIN_TAG}SURNAME{END_TAG}{xContact.Surname}{SEPARATOR}" +
        $"{BEGIN_TAG}PHONE{END_TAG}{xContact.Phone}{SEPARATOR}" +
        $"{BEGIN_TAG}NOTES{END_TAG}{xContact.Notes}{SEPARATOR}" +
        $"{BEGIN_TAG}DESCRIPTION{END_TAG}{xContact.Description}\n" +
        $"{END_MARKER}";

    }

    private static cContact GetContactFromFormattedData(string[] xSplittedContactData) {
      //funkcja tworząca kontakt na podstawie sformatowanych danych z pliku
      //xSplittedContactData - tablica zawierająca rodzielone, sformatowane dane kontaktu

      cContact pContact = new cContact();

      foreach (string xData in xSplittedContactData) {
        if (xData.Contains($"{BEGIN_TAG}IDX{END_TAG}")) { pContact.Index = int.Parse(RemoveTags(xData)); continue; }
        if (xData.Contains($"{BEGIN_TAG}NAME{END_TAG}")) { pContact.Name = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}SURNAME{END_TAG}")) { pContact.Surname = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}PHONE{END_TAG}")) { pContact.Phone = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}DESCRIPTION{END_TAG}")) { pContact.Description = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}NOTES{END_TAG}")) { pContact.Notes = RemoveTags(xData); continue; }
      }

      return pContact;
    }

    private static BindingList<cContact> GetContactListFromFormatedData(string xFileName = DEFAULT_SAVE_FILE_PATH) {
      //funkcja tworząca listę kontaktów na podstawie sformatowanych danych z pliku
      //xFileName - nazwa pliku do wczytania

      List<string[]> pFormattedDataList = cSerializer.LoadTxtFile(xFileName);
      BindingList<cContact> pContactList = new BindingList<cContact>();
    
      foreach (string[] pFormattedData in pFormattedDataList) {
        pContactList.Add(GetContactFromFormattedData(pFormattedData));
      }

      return pContactList;
    }

    private static List<string> GetFormattedDataList(BindingList<cContact> xContactList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie listy produktów
      //xContactList - lista kontaktów do sformatowania

      List<string> pFormattedDataList = new List<string>();

      foreach (cContact pContact in xContactList) {
        pFormattedDataList.Add(GetFormattedContactString(pContact));
      }

      return pFormattedDataList;
    }

    public static void SaveToNewTxtFile(string xFileName = DEFAULT_SAVE_FILE_PATH, BindingList<cContact> xContactsList) {
      //funkcja zapisująca listę kontaktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xContactsList - lista kontaktów do zapisania

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xContactsList), ref pTemp);

    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca listę kontaktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xContactsList - lista kontaktów do zapisania
      //xCurrentFilePath - ścieżka aktualnie otwartego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xContactsList), ref xCurrentFilePath);

    }

    public static void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca listę produktów do istniejącego pliku
      //xFileName - nazwa pliku do wczytania
      //xContactsList - lista kontaktów do zapisania

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xContactsList));

    }

    public static new BindingList<cContact> LoadTxtFile(string xFileName = DEFAULT_SAVE_FILE_PATH) {
      //funkcja wczytująca listę kontaktów z pliku
      //xFileName - nazwa pliku do wczytania

      return GetContactListFromFormatedData(xFileName);

    }

  }
}
