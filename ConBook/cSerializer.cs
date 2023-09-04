using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook {
  internal class cSerializer {
    // Klasa odpowiadająca za zapisywanie i wczytywanie listy kontaków

    protected const string BEGIN_MARKER = "*<";
    protected const string END_MARKER = ">*";
    protected const string BEGIN_TAG = "$<";
    protected const string END_TAG = ">$";
    protected const string SEPARATOR = "::";

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

    protected string RemoveTags(string xString) {
      //funkcja usuwająca tagi z danych

      string pTagPattern = "\\$<.*?>\\$";

      return Regex.Replace(xString, pTagPattern, "");

    }

    protected void SaveToNewTxtFile(string xFileName, List<string> xList, ref string? xCurrentFilePath) {
      //funkcja zapisująca dane do nowego pliku tekstowego
      //xFileName - nazwa pliku do zapisu
      //xList - sformatowana lista do zapisu
      //xCurrentFilePath - ścieżka do aktualnie otwartego pliku

      using (StreamWriter pWriter = new StreamWriter(xFileName)) {

        foreach (string pItem in xList) { 
          pWriter.WriteLine(pItem);
        }

          xCurrentFilePath ??= xFileName;

      }

    }

    protected void SaveToNewTxtFile(string xFileName, List<string> xList) {
      //funkcja zapisująca dane do nowego pliku tekstowego
      //xFileName - nazwa pliku do zapisu
      //xList - lista kontaktów do zapisu

      string? pTemp = null;
      SaveToNewTxtFile(xFileName, xList, ref pTemp);

    }

    protected void SaveToExistingTxtFile(string xFileName, List<string> xList) {
      //funkcja zapisująca dane do istniejącego pliku tekstowego
      //xFileName - nazwa pliku do zapisu
      //xList - lista kontaktów do zapisu

      string pTempFileName = Path.GetTempFileName();

      try {

        SaveToNewTxtFile(pTempFileName, xList);

        File.Delete(xFileName);
        File.Move(pTempFileName, xFileName);

      } finally {

        if (File.Exists(pTempFileName)) {
          File.Delete(pTempFileName);
        }

      }

    }

    protected List<string[]> LoadTxtFile(string xFileName) {
      //funkcja odczytująca dane z pliku tekstowego
      //xFileName - nazwa pliku do odczytu

      List<string[]> pFormattedDataList = new List<string[]>();

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

            pFormattedDataList.Add(pDataSplitted);

            pData = string.Empty;
          }

        }
      }

      return pFormattedDataList;

    }


    #endregion

  }

}
