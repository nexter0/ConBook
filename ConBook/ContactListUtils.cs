using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook {
  internal class cContactListUtils {
    //Klasa odpowiadająca za funkcje typu CRUD konktatków

    private BindingList<cContact> mContacts;                  // Lista przechowująca kontakty
    private cContactSerializer mSerializer;                   // Klasa mContactSerializer - do zapisu i odczytu plików

    public BindingList<cContact> Contacts { get { return mContacts; } set { mContacts = value; } }
    public cContactSerializer Serializer { get { return mSerializer; } }

    public cContactListUtils() {

      mContacts = new BindingList<cContact>();
      mSerializer = new cContactSerializer();

    }

    public void DeleteContact(int xIndex) {
      //funkcja usuwająca kontakt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {Contacts[xIndex].Name} {Contacts[xIndex].Surname} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        Contacts.RemoveAt(xIndex);

      }

    }

    public void AddContact(cContact xContact) {
      //funkcja dodająca kontakt do listy

      Contacts.Add(xContact);

    }

    public void AddContact(string xName, string xSurname, string xPhone) {
      //funkcja dodająca kontakt do listy

      cContact pNewContact = new cContact(xName, xSurname, xPhone);

      Contacts.Add(pNewContact);

    }

    public void EditContact(cContact xEditedContact, int xIndex) {
      //funkcja edytująca istniejący kontakt

      Contacts[xIndex] = xEditedContact;

    }

    public void EditContact(string xNewName, string xNewSurname, string xNewPhone, int xIndex) {
      // unkcja edytująca istniejący kontakt

      cContact pEditedContact = new cContact(xNewName, xNewSurname, xNewPhone);

      Contacts[xIndex] = pEditedContact;

    }

    internal class cContactSerializer {
      // Klasa odpowiadająca za zapisywanie i wczytywanie listy kontaków

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

      public BindingList<cContact> LoadTxtFile(string xFileName) {
        // funkcja funkcja odczytująca dane z pliku typu tekstowego (TXT, CSV, TSV)

        BindingList<cContact> pLoadedContacts = new BindingList<cContact>();

        using (StreamReader reader = new StreamReader(xFileName)) {

          string? pData = string.Empty;
          string[]? pDataSplit = null;

          do {

            pData = reader.ReadLine();

            if (pData == null) continue;

            if (Path.GetExtension(xFileName) == ".txt") {

              pDataSplit = pData.Split(":");

            } else if (Path.GetExtension(xFileName) == ".csv") {

              pDataSplit = pData.Split(',');

            } else if (Path.GetExtension(xFileName) == ".tsv") {

              pDataSplit = pData.Split('\t');

            }

            pLoadedContacts.Add(new cContact(pDataSplit[0], pDataSplit[1], pDataSplit[2], pDataSplit[3], pDataSplit[4]));
            pDataSplit = null;

          } while (pData != null);

        }

        return pLoadedContacts;

      }

      // funkcja zapisująca do nowego pliku typu tekstowego (TXT, CSV, TSV)
      public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactList, ref string? xCurrentFile, string? xExtension = null) {

        string pExtension;

        if (xExtension != null) {
          pExtension = xExtension;
        } else {
          pExtension = Path.GetExtension(xFileName);
        }

        using (StreamWriter pWriter = new StreamWriter(xFileName)) {

          if (pExtension == ".csv") {
            WriteContactList(pWriter, xContactList, ",");
          } else if (pExtension == ".tsv") {
            WriteContactList(pWriter, xContactList, "\t");
          } else {
            WriteContactList(pWriter, xContactList, null);
          }

          xCurrentFile ??= xFileName;

        }

      }

      private void WriteContactList(StreamWriter xWriter, BindingList<cContact> xContactList, string? xDelimiter) {

        Regex pSpacePatternRegex = new Regex(":+");

        foreach (cContact contact in xContactList) {
          string pContactFormatted;

          if (xDelimiter != null) {
            pContactFormatted = pSpacePatternRegex.Replace(contact.ToString(), xDelimiter);
          } else {
            pContactFormatted = contact.ToString();
          }

          xWriter.WriteLine(pContactFormatted);


        }

      }

      public void SaveToExistingTxtFile(string xFileName, BindingList<cContact> xContactList) {

        string pTempFileName = Path.GetTempFileName();

        try {

          SaveToNewTxtFile(pTempFileName, xContactList, Path.GetExtension(xFileName));

          File.Delete(xFileName);
          File.Move(pTempFileName, xFileName);

        } finally {

          if (File.Exists(pTempFileName)) {
            File.Delete(pTempFileName);
          }

        }

      }

      public void SaveToNewTxtFile(string xFileName, BindingList<cContact> xContactList, string? xExtension = null) {

        string? pTemp = null;
        SaveToNewTxtFile(xFileName, xContactList, ref pTemp, xExtension);

      }

    }

  }
}
