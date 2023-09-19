using System.ComponentModel;

namespace ConBook {
  internal class cContactsSerializer : cSerializer {
    //klasa odpowiadająca za zapis listy konktatków

    #region Constants
    public const string DEFAULT_SAVE_FILE_PATH = "contacts_list.txt";

    private const string DESCRIPTION_TAG = $"{BEGIN_TAG}DESCRIPTION{END_TAG}";
    private const string INDEX_TAG = $"{BEGIN_TAG}IDX{END_TAG}";
    private const string NAME_TAG = $"{BEGIN_TAG}NAME{END_TAG}";
    private const string NOTES_TAG = $"{BEGIN_TAG}NOTES{END_TAG}";
    private const string PHONE_TAG = $"{BEGIN_TAG}PHONE{END_TAG}";
    private const string SURNAME_TAG = $"{BEGIN_TAG}SURNAME{END_TAG}";
    #endregion

    private static string GetFormattedContactString(cContact xContact) {
      //funkcja zwracająca kontakt w sformatowanej postaci (gotowej do zapisu do pliku)
      //xContact - kontakt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{INDEX_TAG}{xContact.Index}{SEPARATOR}" +
        $"{NAME_TAG}{xContact.Name}{SEPARATOR}" +
        $"{SURNAME_TAG}{xContact.Surname}{SEPARATOR}" +
        $"{PHONE_TAG}{xContact.Phone}{SEPARATOR}" +
        $"{NOTES_TAG}{xContact.Notes}{SEPARATOR}" +
        $"{DESCRIPTION_TAG}{xContact.Description}\n" +
        $"{END_MARKER}";

    }

    private static cContact GetContactFromFormattedData(string[] xSplittedContactData) {
      //funkcja zwracająca kontakt na podstawie sformatowanych danych z pliku
      //xSplittedContactData - tablica zawierająca rodzielone, sformatowane dane kontaktu

      cContact pContact = new cContact();

      foreach (string xData in xSplittedContactData) {
        if (xData.Contains($"{INDEX_TAG}")) { pContact.Index = int.Parse(RemoveTags(xData)); continue; }
        if (xData.Contains($"{NAME_TAG}")) { pContact.Name = RemoveTags(xData); continue; }
        if (xData.Contains($"{SURNAME_TAG}")) { pContact.Surname = RemoveTags(xData); continue; }
        if (xData.Contains($"{PHONE_TAG}")) { pContact.Phone = RemoveTags(xData); continue; }
        if (xData.Contains($"{DESCRIPTION_TAG}")) { pContact.Description = RemoveTags(xData); continue; }
        if (xData.Contains($"{NOTES_TAG}")) { pContact.Notes = RemoveTags(xData); continue; }
      }

      return pContact;
    }

    private static BindingList<cContact> GetContactsListFromFile(string xFileName) {
      //funkcja zwracająca listę kontaktów na podstawie sformatowanych danych z pliku
      //xFileName - nazwa pliku do wczytania

      List<string[]> pFormattedDataList = cSerializer.LoadTxtFile(xFileName);
      BindingList<cContact> pContactsList = new BindingList<cContact>();
    
      foreach (string[] pFormattedData in pFormattedDataList) {
        pContactsList.Add(GetContactFromFormattedData(pFormattedData));
      }

      return pContactsList;
    }

    private static List<string> GetFormattedDataList(BindingList<cContact> xContactList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie kolekcji produktów
      //xContactList - lista kontaktów do sformatowania

      List<string> pFormattedDataList = new List<string>();

      foreach (cContact pContact in xContactList) {
        pFormattedDataList.Add(GetFormattedContactString(pContact));
      }

      return pFormattedDataList;
    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca kolekcję kontaktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xContactsList - lista kontaktów do zapisania

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xContactsList), ref pTemp);

    }

    public static void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca kolekcję kontaktów do nowego pliku
      //xFileName - nazwa pliku do wczytania
      //xContactsList - lista kontaktów do zapisania
      //xCurrentFilePath - ścieżka aktualnie otwartego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xContactsList), ref xCurrentFilePath);

    }

    public static void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca kolekcję produktów do istniejącego pliku
      //xFileName - nazwa pliku do wczytania
      //xContactsList - lista kontaktów do zapisania

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xContactsList));

    }

    private static new BindingList<cContact> LoadTxtFile(string xFileName) {
      //funkcja wczytująca kolekcję kontaktów z pliku
      //xFileName - nazwa pliku do wczytania

      return GetContactsListFromFile(xFileName);

    }

    public static BindingList<cContact> GetContactsList() {
      //funkcja zwracająca kolekcję kontaktów z pliku

      return LoadTxtFile(DEFAULT_SAVE_FILE_PATH);

    }

  }
}
