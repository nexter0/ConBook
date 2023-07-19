using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook {
    public partial class MainForm : Form {
        public BindingList<cContact> mContacts = new BindingList<cContact>();
        public int mSelectedRowIndex = -1;

        private string? mCurrentFile = null;

        public MainForm() {
            InitializeComponent();
        }

        // *****************************
        // *          Events           *
        // *****************************

        private void tsmiSort_Click(object sender, EventArgs e) {
            if (mContacts.Count > 0) {
                List<cContact> pTempContactList = new List<cContact>(mContacts);
                pTempContactList.Sort();
                mContacts = new BindingList<cContact>(pTempContactList);
                RefreshDataGridView();
            }
            else {
                MessageBox.Show("Lista jest pusta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e) {
            try {
                if (mContacts.Count > 0) {
                    if (mCurrentFile != null) {
                        if (Path.GetExtension(mCurrentFile) == ".xml") {

                            SaveToExistingXmlFile(mCurrentFile);
                        }
                        else {
                            SaveToExistingTxtFile(mCurrentFile);
                        }
                    }
                    else {
                        tsmiSaveAs_Click(sender, e);
                    }
                }
                else {
                    MessageBox.Show("Nie można zapisać pustej listy.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                if (ex.InnerException != null) {
                    Exception pInnerException = ex.InnerException;

                    string pMessage = "Błąd: \n" + pInnerException.Message + "\n"
                        + "InnerException StackTrace: \n" + pInnerException.StackTrace;
                    MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    string pMessage = "Błąd: \n" + ex.Message + "\n"
                        + "StackTrace: \n" + ex.StackTrace;
                    MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e) {
            if (mContacts.Count > 0) {
                try {
                    SaveFileDialog SaveFileDialog = new SaveFileDialog() {
                        Filter = "Plik CSV (rozdzielany przecinkami) (*.csv)|*.csv|Plik TSV (rozdzielany znakiem tabulacji) (*.tsv)|*.tsv|Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
                        Title = "Zapisz jako..."
                    };

                    if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
                        string fileName = SaveFileDialog.FileName;
                        string fileExtension = Path.GetExtension(fileName);
                        if (fileExtension == ".xml") {
                            SaveToNewXmlFile(fileName);
                        }
                        else if (fileExtension == ".txt" || fileExtension == ".tsv" || fileExtension == ".csv") {
                            SaveToNewTxtFile(fileName);
                        }
                        else {
                            MessageBox.Show("Nieobsługiwany format pliku.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex) {
                    if (ex.InnerException != null) {
                        Exception pInnerException = ex.InnerException;

                        string pMessage = "Błąd: \n" + pInnerException.Message + "\n"
                            + "InnerException StackTrace: \n" + pInnerException.StackTrace;
                        MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        string pMessage = "Błąd: \n" + ex.Message + "\n"
                            + "StackTrace: \n" + ex.StackTrace;
                        MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else {
                MessageBox.Show("Nie można zapisać pustej listy.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void tsmiOpen_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog OpenFileDialog = new OpenFileDialog() {
                    Filter = "Wszystkie pliki (*.*)|*.*|Plik CSV (rozdzielany przecinkami) (*.csv)|*.csv|Plik TSV (rozdzielany znakiem tabulacji) (*.tsv)|*.tsv|Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
                    Title = "Otwórz..."
                };

                if (OpenFileDialog.ShowDialog() == DialogResult.OK) {
                    string fileName = OpenFileDialog.FileName;
                    string fileExtension = Path.GetExtension(fileName);
                    if (fileExtension == ".xml") {
                        LoadXmlFile(fileName);
                    }
                    else if (fileExtension == ".txt" || fileExtension == ".tsv" || fileExtension == ".csv") {
                        LoadTxtFile(fileName);
                    }
                    else {
                        MessageBox.Show("Nieobsługiwany format pliku.", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    mCurrentFile = fileName;
                    RefreshDataGridView();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Podczas wczytywania wystąpił błąd: \n {ex.Message}", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {

            string pPath = Directory.GetCurrentDirectory();
            string? pFile = Directory.EnumerateFiles(pPath, "*.xml").FirstOrDefault();
            if (File.Exists("recent")) {
                using (StreamReader reader = new StreamReader("recent")) {
                    string pFileTmp = reader.ReadToEnd();
                    if (File.Exists(pFileTmp) && pFileTmp != string.Empty && pFileTmp != null) {
                        pFile = pFileTmp;
                    }
                    try {
                        if (pFile != string.Empty && pFile != null) {
                            if (Path.GetExtension(pFile) == ".xml") {
                                LoadXmlFile(pFile);
                            }
                            else {
                                LoadTxtFile(pFile);
                            }
                            mCurrentFile = pFile;
                        }

                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (pFile != string.Empty && pFile != null) {
                try {
                    LoadXmlFile(pFile);
                    mCurrentFile = pFile;
                }
                catch (Exception ex) {
                    MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshDataGridView();
        }

        private void tsmiNew_Click(object sender, EventArgs e) {
            DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
                "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (pSaveQueryResult) {
                case DialogResult.Yes: {
                        tsmiSave_Click(sender, e);
                        mContacts.Clear();
                        RefreshDataGridView();
                        mCurrentFile = null;
                        break;
                    }
                case DialogResult.No: {
                        mContacts.Clear();
                        RefreshDataGridView();
                        mCurrentFile = null;
                        break;
                    }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
                "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (pSaveQueryResult) {
                case DialogResult.Yes: {
                        tsmiSave_Click(sender, e);
                        break;
                    }
                case DialogResult.No: {
                        break;
                    }
                default: {
                        e.Cancel = true;
                        break;
                    }
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            MessageBox.Show("ConBook - Nikodem Przbyszewski 2023\n\n" +
                "Oprogramowanie: Visual Studio 2022 (.NET Framework 64-bit)\n" +
                "Ikona: Icongeek26 @ flaticon.com", "ConBook v1.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (mCurrentFile != string.Empty && mCurrentFile != null) {
                using (StreamWriter writer = new StreamWriter("recent")) {
                    writer.Write(mCurrentFile);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            DataForm pDataForm = new DataForm(this, false);
            pDataForm.Location = CalculateDataFormAppearLocation(pDataForm);
            pDataForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            mSelectedRowIndex = dgvContacts.SelectedRows[0].Index;
            DeleteContact();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            mSelectedRowIndex = dgvContacts.SelectedRows[0].Index;
            DataForm pDataForm = new DataForm(this, true);
            pDataForm.Location = CalculateDataFormAppearLocation(pDataForm);
            pDataForm.Show();
        }

        // *****************************
        // *          Metody           *
        // *****************************

        // funkcja odświeżająca DataGridView z danymi
        public void RefreshDataGridView() {
            dgvContacts.DataSource = null;
            dgvContacts.DataSource = mContacts;

            dgvContacts.Columns["Surname"].DisplayIndex = 0;
            dgvContacts.Columns["Name"].DisplayIndex = 1;
            dgvContacts.Columns["Phone"].DisplayIndex = 2;

            DataGridViewColumn pDgvColumnSurname = dgvContacts.Columns["Surname"];
            DataGridViewColumn pDgvColumnName = dgvContacts.Columns["Name"];
            DataGridViewColumn pDgvColumnPhone = dgvContacts.Columns["Phone"];

            pDgvColumnSurname.HeaderText = "Nazwisko";
            pDgvColumnName.HeaderText = "Imię";
            pDgvColumnPhone.HeaderText = "Telefon";
            pDgvColumnSurname.Width = 215;
            pDgvColumnName.Width = 215;
            pDgvColumnPhone.Width = 147;

            dgvContacts.Refresh();
        }

        // funkcja usuwająca kontakt
        private void DeleteContact() {
            DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt {mContacts[mSelectedRowIndex].Name} {mContacts[mSelectedRowIndex].Surname} z listy?",
                "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deletionQueryResult == DialogResult.Yes) {
                mContacts.RemoveAt(mSelectedRowIndex);
                RefreshDataGridView();
            }
        }

        // ************************
        // Serializacja 


        // funkcja zapisująca do nowego pliku XML
        private void SaveToNewXmlFile(string fileName) {
            XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

            using (FileStream pFileStream = new FileStream(fileName, FileMode.Create)) {
                pSerializer.Serialize(pFileStream, mContacts);

                if (mCurrentFile == null) {
                    mCurrentFile = fileName;
                }
            }
        }

        // funkcja zapisująca do istniejącego pliku XML
        private void SaveToExistingXmlFile(string fileName) {
            string pTempFileName = Path.GetTempFileName();

            try {
                SaveToNewXmlFile(pTempFileName);
                // File.Replace(tempFileName, fileName, null);
                File.Delete(fileName);
                File.Move(pTempFileName, fileName);
            }
            finally {
                if (File.Exists(pTempFileName)) {
                    File.Delete(pTempFileName);
                }
            }
        }

        // funkcja funkcja odczytująca dane z pliku XML
        private void LoadXmlFile(string fileName) {
            XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

            using (FileStream pFileStream = new FileStream(fileName, FileMode.Open)) {
                BindingList<cContact> pLoadedContacts = (BindingList<cContact>)pSerializer.Deserialize(pFileStream);

                mContacts.Clear();
                mContacts = new BindingList<cContact>(pLoadedContacts);
            }
        }

        // funkcja funkcja odczytująca dane z pliku typu tekstowego (TXT, CSV, TSV)
        private void LoadTxtFile(string fileName) {
            mContacts.Clear();
            using (StreamReader reader = new StreamReader(fileName)) {
                string? pData = string.Empty;
                string[]? pDataSplit = null;
                do {
                    pData = reader.ReadLine();
                    if (pData == null) continue;
                    if (Path.GetExtension(fileName) == ".txt") {
                        pDataSplit = pData.Split(' ');
                    }
                    else if (Path.GetExtension(fileName) == ".csv") {
                        pDataSplit = pData.Split(',');
                    }
                    else if (Path.GetExtension(fileName) == ".tsv") {
                        pDataSplit = pData.Split('\t');
                    }
                    mContacts.Add(new cContact(pDataSplit[0], pDataSplit[1], pDataSplit[2]));
                    pDataSplit = null;
                } while (pData != null);
            }
        }

        // funkcja zapisująca do nowego pliku typu tekstowego (TXT, CSV, TSV)
        private void SaveToNewTxtFile(string fileName) {
            if (Path.GetExtension(fileName) == ".csv") {
                using (StreamWriter writer = new StreamWriter(fileName)) {
                    Regex pSpacePatternRegex = new Regex("\\s+");
                    foreach (cContact contact in mContacts) {
                        string pContactFormatted = pSpacePatternRegex.Replace(contact.ToString(), ",");
                        writer.WriteLine(pContactFormatted);
                    }
                }
            }
            else if (Path.GetExtension(fileName) == ".tsv") {
                using (StreamWriter writer = new StreamWriter(fileName)) {
                    Regex pSpacePatternRegex = new Regex("\\s+");
                    foreach (cContact contact in mContacts) {
                        string pContactFormatted = pSpacePatternRegex.Replace(contact.ToString(), "\t");
                        writer.WriteLine(pContactFormatted);
                    }
                }
            }
            else {
                using (StreamWriter writer = new StreamWriter(fileName)) {
                    foreach (cContact contact in mContacts) {
                        writer.WriteLine(contact);
                    }
                }
            }
        }

        private void SaveToExistingTxtFile(string fileName) {
            string pTempFileName = Path.GetTempFileName();
            try {
                SaveToNewTxtFile(pTempFileName);
                // File.Replace(tempFileName, fileName, null);
                File.Delete(fileName);
                File.Move(pTempFileName, fileName);
            }
            finally {
                if (File.Exists(pTempFileName)) {
                    File.Delete(pTempFileName);
                }
            }
        }


        // funkcja obliczająca wyśrodkowaną względem głównego formularza pozycję okienka dodawania i edycji kontaktu
        Point CalculateDataFormAppearLocation(DataForm dataForm) {
            int pParentCenterX = this.Left + this.Width / 2;
            int pParentCenterY = this.Top + this.Height / 2;
            int pChildFormX = pParentCenterX - dataForm.Width / 2;
            int pChildFormY = pParentCenterY - dataForm.Height / 2;
            return new Point(pChildFormX, pChildFormY);
        }
    }
}
