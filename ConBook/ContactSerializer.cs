using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

// Klasa odpowiadająca za zapisywanie i wczytywanie listy kontaków
namespace ConBook {
    internal class cContactSerializer {
        private IMainComponents mMainForm;

        public cContactSerializer(IMainComponents xMainForm) {
            mMainForm = xMainForm;
        }

        // funkcja zapisująca do nowego pliku XML
        public void SaveToNewXmlFile(string xFileName) {
            XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

            using (FileStream pFileStream = new FileStream(xFileName, FileMode.Create)) {
                pSerializer.Serialize(pFileStream, mMainForm.mContacts);

                if (mMainForm.mCurrentFile == null) {
                    mMainForm.mCurrentFile = xFileName;
                }
            }
        }

        // funkcja zapisująca do istniejącego pliku XML
        public void SaveToExistingXmlFile(string xFileName) {
            string pTempFileName = Path.GetTempFileName();

            try {
                SaveToNewXmlFile(pTempFileName);
                // File.Replace(tempFileName, fileName, null);
                File.Delete(xFileName);
                File.Move(pTempFileName, xFileName);
            }
            finally {
                if (File.Exists(pTempFileName)) {
                    File.Delete(pTempFileName);
                }
            }
        }

        // funkcja funkcja odczytująca dane z pliku XML
        public void LoadXmlFile(string xFileName) {
            XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

            using (FileStream pFileStream = new FileStream(xFileName, FileMode.Open)) {
                BindingList<cContact> pLoadedContacts = (BindingList<cContact>)pSerializer.Deserialize(pFileStream);

                mMainForm.mContacts.Clear();
                mMainForm.mContacts = new BindingList<cContact>(pLoadedContacts);
            }
        }

        // funkcja funkcja odczytująca dane z pliku typu tekstowego (TXT, CSV, TSV)
        public void LoadTxtFile(string xFileName) {
            mMainForm.mContacts.Clear();
            using (StreamReader reader = new StreamReader(xFileName)) {
                string? pData = string.Empty;
                string[]? pDataSplit = null;
                do {
                    pData = reader.ReadLine();
                    if (pData == null) continue;
                    if (Path.GetExtension(xFileName) == ".txt") {
                        pDataSplit = pData.Split(' ');
                    }
                    else if (Path.GetExtension(xFileName) == ".csv") {
                        pDataSplit = pData.Split(',');
                    }
                    else if (Path.GetExtension(xFileName) == ".tsv") {
                        pDataSplit = pData.Split('\t');
                    }
                    mMainForm.mContacts.Add(new cContact(pDataSplit[0], pDataSplit[1], pDataSplit[2]));
                    pDataSplit = null;
                } while (pData != null);
            }
        }

        // funkcja zapisująca do nowego pliku typu tekstowego (TXT, CSV, TSV)
        public void SaveToNewTxtFile(string xFileName) {
            if (Path.GetExtension(xFileName) == ".csv") {
                using (StreamWriter writer = new StreamWriter(xFileName)) {
                    Regex pSpacePatternRegex = new Regex("\\s+");
                    foreach (cContact contact in mMainForm.mContacts) {
                        string pContactFormatted = pSpacePatternRegex.Replace(contact.ToString(), ",");
                        writer.WriteLine(pContactFormatted);
                    }
                }
            }
            else if (Path.GetExtension(xFileName) == ".tsv") {
                using (StreamWriter writer = new StreamWriter(xFileName)) {
                    Regex pSpacePatternRegex = new Regex("\\s+");
                    foreach (cContact contact in mMainForm.mContacts) {
                        string pContactFormatted = pSpacePatternRegex.Replace(contact.ToString(), "\t");
                        writer.WriteLine(pContactFormatted);
                    }
                }
            }
            else {
                using (StreamWriter writer = new StreamWriter(xFileName)) {
                    foreach (cContact contact in mMainForm.mContacts) {
                        writer.WriteLine(contact);
                    }
                }
            }
        }

        public void SaveToExistingTxtFile(string xFileName) {
            string pTempFileName = Path.GetTempFileName();
            try {
                SaveToNewTxtFile(pTempFileName);
                // File.Replace(tempFileName, fileName, null);
                File.Delete(xFileName);
                File.Move(pTempFileName, xFileName);
            }
            finally {
                if (File.Exists(pTempFileName)) {
                    File.Delete(pTempFileName);
                }
            }
        }
    }
}
