using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook {
    public partial class MainForm : Form, IMainComponents {
        public BindingList<cContact> mContacts { get; set; }
        public int mSelectedRowIndex { get; set; }
        public string? mCurrentFile { get; set; }

        public MainForm() {
            InitializeComponent();
            mSelectedRowIndex = -1;
            mCurrentFile = null;
            mContacts = new BindingList<cContact>();
        }

        // *****************************
        // *          Zdarzenia        *
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
                            cContactSerializer pSerializer = new cContactSerializer(this);
                            pSerializer.SaveToExistingXmlFile(mCurrentFile);
                        }
                        else {
                            cContactSerializer pSerializer = new cContactSerializer(this);
                            pSerializer.SaveToExistingTxtFile(mCurrentFile);
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
                            cContactSerializer pSerializer = new cContactSerializer(this);
                            pSerializer.SaveToNewXmlFile(fileName);
                        }
                        else if (fileExtension == ".txt" || fileExtension == ".tsv" || fileExtension == ".csv") {
                            cContactSerializer pSerializer = new cContactSerializer(this);
                            pSerializer.SaveToNewTxtFile(fileName);
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
                        cContactSerializer pSerializer = new cContactSerializer(this);
                        pSerializer.LoadXmlFile(fileName);
                    }
                    else if (fileExtension == ".txt" || fileExtension == ".tsv" || fileExtension == ".csv") {
                        cContactSerializer pSerializer = new cContactSerializer(this);
                        pSerializer.LoadTxtFile(fileName);
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
            // TO DO: Zmienić automatyczne wczytywanie istniejącego pliku jeżeli plik "recent" jest pusty
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
                                cContactSerializer pSerializer = new cContactSerializer(this);
                                pSerializer.LoadXmlFile(pFile);
                            }
                            else {
                                cContactSerializer pSerializer = new cContactSerializer(this);
                                pSerializer.LoadXmlFile(pFile);
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
                    cContactSerializer pSerializer = new cContactSerializer(this);
                    pSerializer.LoadXmlFile(pFile);
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
            pDataForm.DataFormLoaded += DataForm_DataFormLoaded;
            pDataForm.DataFormClosed += DataForm_DataFormClosed;
            pDataForm.Location = CalculateDataFormAppearLocation(pDataForm);
            pDataForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            mSelectedRowIndex = dgvContacts.SelectedRows[0].Index;
            cContactListUtils pListUtils = new cContactListUtils(this);
            pListUtils.DeleteContact();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            mSelectedRowIndex = dgvContacts.SelectedRows[0].Index;
            DataForm pDataForm = new DataForm(this, true);
            pDataForm.DataFormLoaded += DataForm_DataFormLoaded;
            pDataForm.DataFormClosed += DataForm_DataFormClosed;
            pDataForm.Location = CalculateDataFormAppearLocation(pDataForm);
            pDataForm.Show();
        }

        // zdarzenie wyłączające kontrolę nad MainForm po włączeniu DataForm
        private void DataForm_DataFormLoaded(object sender, EventArgs e) {
            this.Enabled = false;
        }

        // zdarzenie włączające kontrolę nad MainForm po wyłączeniu DataForm
        private void DataForm_DataFormClosed(object sender, EventArgs e) {
            this.Enabled = true;
        }

        // funkcja odświeżająca DataGridView oraz przyciski Edytuj / Usuń
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

            if (mContacts.Count == 0) {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }

            dgvContacts.Refresh();
        }

        // funkcja obliczająca wyśrodkowaną względem głównego formularza pozycję okienka dodawania i edycji kontaktu
        Point CalculateDataFormAppearLocation(DataForm xDataForm) {
            int pParentCenterX = this.Left + this.Width / 2;
            int pParentCenterY = this.Top + this.Height / 2;
            int pChildFormX = pParentCenterX - xDataForm.Width / 2;
            int pChildFormY = pParentCenterY - xDataForm.Height / 2;
            return new Point(pChildFormX, pChildFormY);
        }
    }
}
