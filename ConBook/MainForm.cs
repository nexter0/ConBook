using System.ComponentModel;
using System.Media;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook {
    public partial class MainForm : Form {
        public BindingList<cContact> mContacts = new BindingList<cContact>();

        private string? mCurrentFile = null;

        int mCurrentMouseOverRow = -1;

        bool mIsCurrentMouseOverRowLocked = false;

        public MainForm() {
            InitializeComponent();
        }

        // *****************************
        // *          Events           *
        // *****************************

        private void btnSubmit_Click(object sender, EventArgs e) {
            SumbitContact();
        }

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
                        if (mIsCurrentMouseOverRowLocked) {
                            StopEditMode();
                        }
                        SaveToExistingFile(mCurrentFile);
                    }
                    else {
                        if (mIsCurrentMouseOverRowLocked) {
                            StopEditMode();
                        }
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
                        Filter = "Dokument XML (*.xml)|*.xml",
                        Title = "Zapisz jako..."
                    };

                    if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
                        if (mIsCurrentMouseOverRowLocked) {
                            StopEditMode();
                        }
                        string fileName = SaveFileDialog.FileName;
                        SaveToNewFile(fileName);
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
                    Filter = "Dokument XML (*.xml)|*.xml",
                    Title = "Otwórz..."
                };

                if (OpenFileDialog.ShowDialog() == DialogResult.OK) {
                    string fileName = OpenFileDialog.FileName;

                    LoadFile(fileName);
                    mCurrentFile = fileName;
                    if (mIsCurrentMouseOverRowLocked) {
                        StopEditMode();
                    }
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
                    string fileTmp = reader.ReadToEnd();
                    if (File.Exists(fileTmp) && fileTmp != string.Empty && fileTmp != null) {
                        pFile = fileTmp;
                    }
                    try {
                        if (pFile != string.Empty && pFile != null) {
                            LoadFile(pFile);
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
                    LoadFile(pFile);
                    mCurrentFile = pFile;
                }
                catch (Exception ex) {
                    MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshDataGridView();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                if (!mIsCurrentMouseOverRowLocked) {
                    SumbitContact();
                }
                else {
                    EditContact();
                }
            }
        }

        private void txtSurname_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                if (!mIsCurrentMouseOverRowLocked) {
                    SumbitContact();
                }
                else {
                    EditContact();
                }
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                if (!mIsCurrentMouseOverRowLocked) {
                    SumbitContact();
                }
                else {
                    EditContact();
                }
            }
        }

        private void dgvContacts_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                if (!mIsCurrentMouseOverRowLocked) {
                    mCurrentMouseOverRow = dgvContacts.HitTest(e.X, e.Y).RowIndex;

                    if (mCurrentMouseOverRow < 0) {
                        return;
                    }
                    cmsRows.Show(dgvContacts, new Point(e.X, e.Y));
                }
                else {
                    SystemSounds.Beep.Play();
                }
            }
        }

        private void cmiDelete_Click(object sender, EventArgs e) {
            mIsCurrentMouseOverRowLocked = true;
            DeleteContact();
            mIsCurrentMouseOverRowLocked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            cContact editedContact = new cContact(txtName.Text, txtSurname.Text, txtPhone.Text);
            mContacts[mCurrentMouseOverRow] = editedContact;
            RefreshDataGridView();

            StopEditMode();
        }

        private void cmiEdit_Click(object sender, EventArgs e) {
            StartEditMode();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e) {
            StopEditMode();
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
                        if (mIsCurrentMouseOverRowLocked) {
                            StopEditMode();
                        }
                        break;
                    }
                case DialogResult.No: {
                        mContacts.Clear();
                        RefreshDataGridView();
                        mCurrentFile = null;
                        if (mIsCurrentMouseOverRowLocked) {
                            StopEditMode();
                        }
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

        // *****************************
        // *          Methods          *
        // *****************************

        // funkcja odświeżająca DataGridView z danymi
        private void RefreshDataGridView() {
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

        // funkcja dodająca kontakt do listy
        private void SumbitContact() {
            int pValidation = ValidateTextBoxes();
            if (pValidation == 0) {
                cContact pNewContact = new cContact(txtName.Text, txtSurname.Text, txtPhone.Text);
                mContacts.Add(pNewContact);

                txtName.Text = string.Empty;
                txtSurname.Text = string.Empty;
                txtPhone.Text = string.Empty;
            }
            else {
                string pCaption = "Błąd";
                string pMessage = "Nieprawdiłowe dane!\n\n";
                switch (pValidation) {
                    case 1: { pMessage += "Wszystkie pola są wymagane."; break; }
                    case 2: { pMessage += "Niedozwolone znaki w polu Telefon."; break; }
                    case 3: { pMessage += "Pola Imię i Nazwisko nie mogą zawierać cyfr."; break; }
                }

                MessageBox.Show(pCaption, pMessage, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // funkcja edytująca kontakt
        private void EditContact() {
            cContact editedContact = new cContact(txtName.Text, txtSurname.Text, txtPhone.Text);
            mContacts[mCurrentMouseOverRow] = editedContact;
            RefreshDataGridView();

            StopEditMode();
        }

        // funkcja rozpoczynająca tryb edycji kontaktu
        private void StartEditMode() {
            mIsCurrentMouseOverRowLocked = true;

            btnSubmit.Enabled = false;
            btnSubmit.Visible = false;
            btnEdit.Enabled = true;
            btnEdit.Visible = true;
            btnCancelEdit.Enabled = true;
            btnCancelEdit.Visible = true;

            txtName.Text = mContacts[mCurrentMouseOverRow].Name;
            txtSurname.Text = mContacts[mCurrentMouseOverRow].Surname;
            txtPhone.Text = mContacts[mCurrentMouseOverRow].Phone;
        }

        // funkcja zatrzymująca tryb edycji kontaktu
        private void StopEditMode() {
            mIsCurrentMouseOverRowLocked = false;

            btnSubmit.Enabled = true;
            btnSubmit.Visible = true;
            btnEdit.Enabled = false;
            btnEdit.Visible = false;
            btnCancelEdit.Enabled = false;
            btnCancelEdit.Visible = false;

            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        // funkcja usuwająca kontakt
        private void DeleteContact() {
            DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt {mContacts[mCurrentMouseOverRow].Name} {mContacts[mCurrentMouseOverRow].Surname} z listy?",
                "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deletionQueryResult == DialogResult.Yes) {
                mContacts.RemoveAt(mCurrentMouseOverRow);
                RefreshDataGridView();
            }
        }

        // funkcja weryfikująca poprawność wpisanych danych w pola tekstowe
        private int ValidateTextBoxes() {
            string pPatternPhone = @"[^0-9\s-+]";
            string pPatternDigit = @"\d";

            if (string.IsNullOrEmpty(txtName.Text)) { return 1; }
            if (string.IsNullOrEmpty(txtSurname.Text)) { return 1; }
            if (string.IsNullOrEmpty(txtPhone.Text)) { return 1; }
            if (Regex.IsMatch(txtPhone.Text, pPatternPhone)) { return 2; };
            if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return 3; };
            if (Regex.IsMatch(txtSurname.Text, pPatternDigit)) { return 3; };

            return 0;
        }

        // ************************
        // Serializacja 

        // funkcja funkcja odczytująca dane z pliku XML
        private void LoadFile(string fileName) {
            XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

            using (FileStream pFileStream = new FileStream(fileName, FileMode.Open)) {
                BindingList<cContact> pLoadedContacts = (BindingList<cContact>)pSerializer.Deserialize(pFileStream);

                mContacts.Clear();
                mContacts = new BindingList<cContact>(pLoadedContacts);
            }
        }

        // funkcja zapisująca do nowego pliku
        private void SaveToNewFile(string fileName) {
            XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

            using (FileStream pFileStream = new FileStream(fileName, FileMode.Create)) {
                pSerializer.Serialize(pFileStream, mContacts);

                if (mCurrentFile == null) {
                    mCurrentFile = fileName;
                }
            }
        }

        // funkcja zapisująca do istniejącego pliku
        private void SaveToExistingFile(string fileName) {
            string pTempFileName = Path.GetTempFileName();

            try {
                XmlSerializer pSerializer = new XmlSerializer(typeof(BindingList<cContact>));

                using (FileStream pFileStream = new FileStream(pTempFileName, FileMode.Create)) {
                    pSerializer.Serialize(pFileStream, mContacts);
                }
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
    }
}
