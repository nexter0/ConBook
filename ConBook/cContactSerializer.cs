using System.ComponentModel;
using System.Xml.Serialization;

namespace ConBook {
  internal class cContactSerializer {
    // Klasa odpowiadająca za zapisywanie i wczytywanie listy kontaków

    private const string BEGIN_MARKER = "~<";
    private const string END_MARKER = ">~";
    private const string SEPARATOR = "~~";

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

      return $"{BEGIN_MARKER}\n{xContact.Name}{SEPARATOR}{xContact.Surname}{SEPARATOR}" +
        $"{xContact.Phone}{SEPARATOR}{xContact.Description}\n{END_MARKER}";

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList, ref string? xCurrentFilePath) {
      //funkcja zapisująca dane do nowego pliku tekstowego

      using (StreamWriter pWriter = new StreamWriter(xFileName)) {

        foreach (cContact pContact in xContactsList) { 
          pWriter.WriteLine(GetFormattedContactString(pContact));
        }

          xCurrentFilePath ??= xFileName;

      }

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactsList) {

      string? pTemp = null;
      SaveToNewTxtFile(xFileName, xContactsList, ref pTemp);

    }

    public void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactsList) {
      //funkcja zapisująca dane do istniejącego pliku tekstowego

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

            pLoadedContacts.Add(new cContact(pDataSplitted));

            pData = string.Empty;
          }

        }
      }

      return pLoadedContacts;

    }


    #endregion

  }

}
