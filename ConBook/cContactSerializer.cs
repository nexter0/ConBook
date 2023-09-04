using System.ComponentModel;

namespace ConBook {
  internal class cContactSerializer : cSerializer {

    private string GetFormattedContactString(cContact xContact) {
      //funkcja zwracająca kontakt w postaci gotowej do zapisu do pliku
      //xContact - kontakt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{BEGIN_TAG}NAME{END_TAG}{xContact.Name}{SEPARATOR}" +
        $"{BEGIN_TAG}SURNAME{END_TAG}{xContact.Surname}{SEPARATOR}" +
        $"{BEGIN_TAG}PHONE{END_TAG}{xContact.Phone}{SEPARATOR}" +
        $"{BEGIN_TAG}NOTES{END_TAG}{xContact.Notes}{SEPARATOR}" +
        $"{BEGIN_TAG}DESCRIPTION{END_TAG}{xContact.Description}\n" +
        $"{END_MARKER}";

    }

    private cContact GetContactFromFormattedData(string[] xSplittedContactData) {
      //funkcja tworząca kontakt na podstawie sformatowanych danych z pliku
      //xSplittedContactData - tablica zawierająca rodzielone dane kontaktu

      cContact pContact = new cContact();

      foreach (string xData in xSplittedContactData) {
        if (xData.Contains($"{BEGIN_TAG}NAME{END_TAG}")) { pContact.Name = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}SURNAME{END_TAG}")) { pContact.Surname = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}PHONE{END_TAG}")) { pContact.Phone = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}DESCRIPTION{END_TAG}")) { pContact.Description = RemoveTags(xData); continue; }
        if (xData.Contains($"{BEGIN_TAG}NOTES{END_TAG}")) { pContact.Notes = RemoveTags(xData); continue; }
        //if (xData.Contains($"{BEGIN_TAG}ADDRESS{END_TAG}")) { pContact.Address = RemoveTags(xData); continue; }
      }

      return pContact;
    }

    private BindingList<cContact> GetContactListFromFormatedData(string xFileName) {
      //funkcja tworząca listę kontaktów na podstawie sformatowanych danych z pliku

      List<string[]> pFormattedDataList = base.LoadTxtFile(xFileName);
      BindingList<cContact> pContactList = new BindingList<cContact>();
    
      foreach (string[] pFormattedData in pFormattedDataList) {
        pContactList.Add(GetContactFromFormattedData(pFormattedData));
      }

      return pContactList;
    }

    private List<string> GetFormattedDataList(BindingList<cContact> xContactList) {
      //funkcja tworząca sformatowane dane do zapisu na podstawie listy kontaków

      List<string> pFormattedDataList = new List<string>();

      foreach (cContact pContact in xContactList) {
        pFormattedDataList.Add(GetFormattedContactString(pContact));
      }

      return pFormattedDataList;
    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca listę kontaktów do nowego pliku

      string? pTemp = null;

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xContactsList), ref pTemp);

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca listę kontaktów do nowego pliku

      SaveToNewTxtFile(xFileName, GetFormattedDataList(xContactsList), ref xCurrentFilePath);

    }

    public void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca listę kontaktów do istniejącego pliku

      SaveToExistingTxtFile(xFileName, GetFormattedDataList(xContactsList));

    }

    public new BindingList<cContact> LoadTxtFile(string xFileName) {

      return GetContactListFromFormatedData(xFileName);

    }

  }
}
