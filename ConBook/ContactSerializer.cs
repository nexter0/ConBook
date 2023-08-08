using System.ComponentModel;
using System.Xml.Serialization;

namespace ConBook {
  internal class cContactSerializer {
    // Klasa odpowiadająca za zapisywanie i wczytywanie listy kontaków

    #region XML Serializer
    public void SaveToNewXmlFile(string xFileName, BindingList<cContact> xContactList, ref string? xCurrentFile) {
      // funkcja zapisująca do nowego pliku XML

      XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

      using (FileStream pFileStream = new FileStream(xFileName, FileMode.Create)) {
        pSerializer.Serialize(pFileStream, xContactList);

        xCurrentFile ??= xFileName;

      }

    }

    public void SaveToNewXmlFile(string xFileName, BindingList<cContact> xContactList) {

      string? pTemp = null;
      SaveToNewXmlFile(xFileName, xContactList, ref pTemp);

    }


    public void SaveToExistingXmlFile(string xFileName, BindingList<cContact> xContactList) {
      // funkcja zapisująca do istniejącego pliku XML

      string pTempFileName = Path.GetTempFileName();

      try {

        SaveToNewXmlFile(pTempFileName, xContactList);

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
    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactList, ref string? xCurrentFile) {

      //string pExtension;

      //if (xExtension != null) {
      //  pExtension = xExtension;
      //} else {
      //  pExtension = Path.GetExtension(xFileName);
      //}

      using (StreamWriter pWriter = new StreamWriter(xFileName)) {

        foreach (cContact contact in xContactList) { 
        
          pWriter.WriteLine(contact.ToString());

        }

          xCurrentFile ??= xFileName;

      }

    }

    public void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactList) {

      string pTempFileName = Path.GetTempFileName();

      try {

        SaveToNewTxtFile(pTempFileName, xContactList);

        File.Delete(xFileName);
        File.Move(pTempFileName, xFileName);

      } finally {

        if (File.Exists(pTempFileName)) {
          File.Delete(pTempFileName);
        }

      }

    }

    public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactList) {

      string? pTemp = null;
      SaveToNewTxtFile(xFileName, xContactList, ref pTemp);

    }

    public BindingList<cContact> LoadTxtFile(string xFileName) {
      // funkcja funkcja odczytująca dane z pliku typu tekstowego (TXT, CSV, TSV)

      BindingList<cContact> pLoadedContacts = new BindingList<cContact>();

      using (StreamReader reader = new StreamReader(xFileName)) {

        string? pLine = string.Empty;
        string pData = string.Empty;
        string[]? pDataSplit = null;

        while ((pLine = reader.ReadLine()) != null) {
          if (pLine == "<") continue;

          if (pLine != ">") {
            pData += pLine + "\n";
          } else {
            pDataSplit = pData.Split("|");
            pLoadedContacts.Add(new cContact(pDataSplit));
            pData = string.Empty;
          }

        }
      }

      return pLoadedContacts;

    }


    #endregion

  }

}
