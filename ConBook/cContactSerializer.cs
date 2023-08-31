using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook {
  internal class cContactSerializer {
    // Klasa odpowiadająca za zapisywanie i wczytywanie listy kontaków

    private const string BEGIN_MARKER = "*<";
    private const string END_MARKER = ">*";
    private const string BEGIN_TAG = "$<";
    private const string END_TAG = ">$";
    private const string SEPARATOR = "::";

    #region XML Serializer
    public void SaveToNewXmlFile(string xFileName, BindingList<cContact> xContactsList, ref string? xCurrentFilePath) {
      // funkcja zapisująca do nowego pliku XML

      XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

      using (FileStream pFileStream = new FileStream(xFileName, FileMode.Create)) {
        pSerializer.Serialize(pFileStream, xContactsList);

        xCurrentFilePath ??= xFileName;

      }

    }

    public void SaveToNewXmlFile(string xFileName, BindingList<cContact> xContactsList) {

      string? pTemp = null;
      SaveToNewXmlFile(xFileName, xContactsList, ref pTemp);

    }


    public void SaveToExistingXmlFile(string xFileName, BindingList<cContact> xContactsList) {
      // funkcja zapisująca do istniejącego pliku XML

      string pTempFileName = Path.GetTempFileName();

      try {

        SaveToNewXmlFile(pTempFileName, xContactsList);

        File.Delete(xFileName);
        File.Move(pTempFileName, xFileName);

      } finally {

        if (File.Exists(pTempFileName))
          File.Delete(pTempFileName);

      }

    }

    public BindingList<cContact> LoadXmlFile(string xFileName) {
      // funkcja funkcja odczytująca dane z pliku XML

      BindingList<cContact> pContacts = new BindingList<cContact>();

      XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

      using (FileStream pFileStream = new FileStream(xFileName, FileMode.Open)) {

        BindingList<cContact> pLoadedContacts = (BindingList<cContact>)pSerializer.Deserialize(pFileStream);

        return pLoadedContacts;

      }

    }
    #endregion

    #region TXT Serializer

    private string GetFormattedContactString(cContact xContact) {
      //funkcja zwracająca kontakt w postaci gotowej do zapisu do pliku
      //xContact - kontakt do sformatowania

      return $"{BEGIN_MARKER}\n" +
        $"{BEGIN_TAG}NAME{END_TAG}{xContact.Name}{SEPARATOR}" +
        $"{BEGIN_TAG}SURNAME{END_TAG}{xContact.Surname}{SEPARATOR}" +
        $"{BEGIN_TAG}PHONE{END_TAG}{xContact.Phone}{SEPARATOR}" +
        $"{BEGIN_TAG}DESCRIPTION{END_TAG}{xContact.Description}\n" +
        $"{END_MARKER}";

    }

    private cContact GetContactFromData(string[] xContactData) {
      //funkcja tworząca kontakt na podstawie danych z pliku
      //xContactData - tablica zawierająca rodzielone dane kontaktu

      cContact pContact = new cContact();

      foreach (string xData in xContactData) {
        if (xData.Contains($"{BEGIN_TAG}NAME{END_TAG}")) pContact.Name = RemoveTags(xData);
        if (xData.Contains($"{BEGIN_TAG}SURNAME{END_TAG}")) pContact.Surname = RemoveTags(xData);
        if (xData.Contains($"{BEGIN_TAG}PHONE{END_TAG}")) pContact.Phone = RemoveTags(xData);
        if (xData.Contains($"{BEGIN_TAG}DESCRIPTION{END_TAG}")) pContact.Description = RemoveTags(xData);
      }

      return pContact;
    }

    private string RemoveTags(string xString) {
      //funkcja usuwająca tagi z danych

      string pTagPattern = "\\$<.*?>\\$";

      return Regex.Replace(xString, pTagPattern, "");

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca dane do nowego pliku tekstowego
      //xFileName - nazwa pliku do zapisu
      //xContactsList - lista kontaktów do zapisu
      //xCurrentFilePath - ścieżka do aktualnie otwartego pliku

      using (StreamWriter pWriter = new StreamWriter(xFileName)) {

        foreach (cContact pContact in xContactsList) { 
          pWriter.WriteLine(GetFormattedContactString(pContact));
        }

          xCurrentFilePath ??= xFileName;

      }

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca dane do nowego pliku tekstowego
      //xFileName - nazwa pliku do zapisu
      //xContactsList - lista kontaktów do zapisu

      string? pTemp = null;
      SaveToNewTxtFile(xFileName, xContactsList, ref pTemp);

    }

    public void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca dane do istniejącego pliku tekstowego
      //xFileName - nazwa pliku do zapisu
      //xContactsList - lista kontaktów do zapisu

      string pTempFileName = Path.GetTempFileName();

      try {

        SaveToNewTxtFile(pTempFileName, xContactsList);

        File.Delete(xFileName);
        File.Move(pTempFileName, xFileName);

      } finally {

        if (File.Exists(pTempFileName)) {
          File.Delete(pTempFileName);
        }

      }

    }

    public BindingList<cContact> LoadTxtFile(string xFileName) {
      //funkcja odczytująca dane z pliku tekstowego
      //xFileName - nazwa pliku do odczytu

      BindingList<cContact> pLoadedContacts = new BindingList<cContact>();

      using (StreamReader pReader = new StreamReader(xFileName)) {

        string? pLine = string.Empty;
        string pData = string.Empty;
        string[]? pDataSplitted = null;

        while ((pLine = pReader.ReadLine()) != null) {
          if (pLine == BEGIN_MARKER) continue;

          if (pLine != END_MARKER) {
            pData += pLine + "\n";

          } else {
            pData = pData.TrimEnd('\n');

            pDataSplitted = pData.Split(SEPARATOR);

            pLoadedContacts.Add(GetContactFromData(pDataSplitted));

            pData = string.Empty;
          }

        }
      }

      return pLoadedContacts;

    }


    #endregion

  }

}
