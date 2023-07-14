using System.ComponentModel;
using System.Media;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ConBook
{
    public partial class MainForm : Form
    {
        public BindingList<Contact> contacts = new BindingList<Contact>();

        private string? currentFile = null;

        int currentMouseOverRow = -1;
        // this variable prevents the user from changing selected row during deleting or editing an entry
        bool isCurrentMouseOverRowLocked = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void RefreshDataGridView()
        {
            dgvContacts.DataSource = null;
            dgvContacts.DataSource = contacts;

            dgvContacts.Columns["Surname"].DisplayIndex = 0;
            dgvContacts.Columns["Name"].DisplayIndex = 1;
            dgvContacts.Columns["Phone"].DisplayIndex = 2;

            DataGridViewColumn dgvColumnSurname = dgvContacts.Columns["Surname"];
            DataGridViewColumn dgvColumnName = dgvContacts.Columns["Name"];
            DataGridViewColumn dgvColumnPhone = dgvContacts.Columns["Phone"];

            dgvColumnSurname.HeaderText = "Nazwisko";
            dgvColumnName.HeaderText = "Imię";
            dgvColumnPhone.HeaderText = "Telefon";
            dgvColumnSurname.Width = 215;
            dgvColumnName.Width = 215;
            dgvColumnPhone.Width = 147;

            dgvContacts.Refresh();
        }

        // ************************
        // Contact CRUD

        private void SumbitContact()
        {
            int validation = ValidateTextBoxes();
            if (validation == 0)
            {
                Contact newContact = new Contact(NameTextBox.Text, SurnameTextBox.Text, PhoneTextBox.Text);
                contacts.Add(newContact);

                NameTextBox.Text = string.Empty;
                SurnameTextBox.Text = string.Empty;
                PhoneTextBox.Text = string.Empty;
            }
            else
            {
                string caption = "Błąd";
                string message = "Nieprawdiłowe dane!\n\n";
                switch (validation)
                {
                    case 1: { message += "Wszystkie pola są wymagane."; break; }
                    case 2: { message += "Niedozwolone znaki w polu Telefon."; break; }
                    case 3: { message += "Pola Imię i Nazwisko nie mogą zawierać cyfr."; break; }
                }

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void EditContact()
        {
            Contact editedContact = new Contact(NameTextBox.Text, SurnameTextBox.Text, PhoneTextBox.Text);
            contacts[currentMouseOverRow] = editedContact;
            RefreshDataGridView();

            StopEditMode();
        }

        private void StartEditMode()
        {
            isCurrentMouseOverRowLocked = true;

            SubmitButton.Enabled = false;
            SubmitButton.Visible = false;
            EditButton.Enabled = true;
            EditButton.Visible = true;
            CancelEditButton.Enabled = true;
            CancelEditButton.Visible = true;

            NameTextBox.Text = contacts[currentMouseOverRow].Name;
            SurnameTextBox.Text = contacts[currentMouseOverRow].Surname;
            PhoneTextBox.Text = contacts[currentMouseOverRow].Phone;
        }

        private void StopEditMode()
        {
            isCurrentMouseOverRowLocked = false;

            SubmitButton.Enabled = true;
            SubmitButton.Visible = true;
            EditButton.Enabled = false;
            EditButton.Visible = false;
            CancelEditButton.Enabled = false;
            CancelEditButton.Visible = false;

            NameTextBox.Text = string.Empty;
            SurnameTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
        }

        private void DeleteContact()
        {
            DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt {contacts[currentMouseOverRow].Name} {contacts[currentMouseOverRow].Surname} z listy?",
                "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deletionQueryResult == DialogResult.Yes)
            {
                contacts.RemoveAt(currentMouseOverRow);
                RefreshDataGridView();
            }
        }

        private int ValidateTextBoxes()
        {
            string patternPhone = @"[^0-9\s-+]";
            string patternDigit = @"\d";

            if (string.IsNullOrEmpty(NameTextBox.Text)) { return 1; }
            if (string.IsNullOrEmpty(SurnameTextBox.Text)) { return 1; }
            if (string.IsNullOrEmpty(PhoneTextBox.Text)) { return 1; }
            if (Regex.IsMatch(PhoneTextBox.Text, patternPhone)) { return 2; };
            if (Regex.IsMatch(NameTextBox.Text, patternDigit)) { return 3; };
            if (Regex.IsMatch(SurnameTextBox.Text, patternDigit)) { return 3; };

            return 0;
        }

        // ************************
        // Serialization 

        private void LoadFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Contact>));

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                BindingList<Contact> loadedContacts = (BindingList<Contact>)serializer.Deserialize(fileStream);

                contacts.Clear();
                contacts = new BindingList<Contact>(loadedContacts);
            }
        }

        private void SaveToNewFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Contact>));

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, contacts);

                if (currentFile == null)
                {
                    currentFile = fileName;
                }
            }
        }

        // This method is to prevent data loss during saving to an existing file
        // in case of an exception
        private void SaveToExistingFile(string fileName)
        {
            string tempFileName = Path.GetTempFileName();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Contact>));

                using (FileStream fileStream = new FileStream(tempFileName, FileMode.Create))
                {
                    serializer.Serialize(fileStream, contacts);
                }
                // File.Replace(tempFileName, fileName, null);
                File.Delete(fileName);
                File.Move(tempFileName, fileName);
            }
            finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }
        }

        // *****************************
        // *          Actions          *
        // *****************************

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SumbitContact();
        }

        private void SortTsmItem_Click(object sender, EventArgs e)
        {
            if (contacts.Count > 0)
            {
                List<Contact> tempContactList = new List<Contact>(contacts);
                tempContactList.Sort();
                contacts = new BindingList<Contact>(tempContactList);
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Lista jest pusta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SaveTsmItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (contacts.Count > 0)
                {
                    if (currentFile != null)
                    {
                        if (isCurrentMouseOverRowLocked)
                        {
                            StopEditMode();
                        }
                        SaveToExistingFile(currentFile);
                    }
                    else
                    {
                        if (isCurrentMouseOverRowLocked)
                        {
                            StopEditMode();
                        }
                        SaveAsTsmItem_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Nie można zapisać pustej listy.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Exception innerException = ex.InnerException;

                    string message = "Błąd: \n" + innerException.Message + "\n"
                        + "InnerException StackTrace: \n" + innerException.StackTrace;
                    MessageBox.Show(message, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string message = "Błąd: \n" + ex.Message + "\n"
                        + "StackTrace: \n" + ex.StackTrace;
                    MessageBox.Show(message, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveAsTsmItem_Click(object sender, EventArgs e)
        {
            if (contacts.Count > 0)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog()
                    {
                        Filter = "Dokument XML (*.xml)|*.xml",
                        Title = "Zapisz jako..."
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (isCurrentMouseOverRowLocked)
                        {
                            StopEditMode();
                        }
                        string fileName = saveFileDialog.FileName;
                        SaveToNewFile(fileName);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        Exception innerException = ex.InnerException;

                        string message = "Błąd: \n" + innerException.Message + "\n"
                            + "InnerException StackTrace: \n" + innerException.StackTrace;
                        MessageBox.Show(message, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string message = "Błąd: \n" + ex.Message + "\n"
                            + "StackTrace: \n" + ex.StackTrace;
                        MessageBox.Show(message, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie można zapisać pustej listy.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void OpenTsmItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Dokument XML (*.xml)|*.xml",
                    Title = "Otwórz..."
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    LoadFile(fileName);
                    currentFile = fileName;
                    if (isCurrentMouseOverRowLocked)
                    {
                        StopEditMode();
                    }
                    RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas wczytywania wystąpił błąd: \n {ex.Message}", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            string path = Directory.GetCurrentDirectory();
            string? file = Directory.EnumerateFiles(path, "*.xml").FirstOrDefault();
            if (File.Exists("recent"))
            {
                using (StreamReader reader = new StreamReader("recent"))
                {
                    string fileTmp = reader.ReadToEnd();
                    if (File.Exists(fileTmp) && fileTmp != string.Empty && fileTmp != null)
                    {
                        file = fileTmp;
                    }
                    try
                    {
                        if (file != string.Empty && file != null)
                        {
                            LoadFile(file);
                            currentFile = file;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {file}", "Błąd wczytywania",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (file != string.Empty && file != null)
            {
                try
                {
                    LoadFile(file);
                    currentFile = file;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {file}", "Błąd wczytywania",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshDataGridView();
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!isCurrentMouseOverRowLocked)
                {
                    SumbitContact();
                }
                else
                {
                    EditContact();
                }
            }
        }

        private void SurnameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!isCurrentMouseOverRowLocked)
                {
                    SumbitContact();
                }
                else
                {
                    EditContact();
                }
            }
        }

        private void PhoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!isCurrentMouseOverRowLocked)
                {
                    SumbitContact();
                }
                else
                {
                    EditContact();
                }
            }
        }

        private void dgvContacts_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!isCurrentMouseOverRowLocked)
                {
                    currentMouseOverRow = dgvContacts.HitTest(e.X, e.Y).RowIndex;

                    if (currentMouseOverRow < 0)
                    {
                        return;
                    }
                    cmsRows.Show(dgvContacts, new Point(e.X, e.Y));
                }
                else
                {
                    SystemSounds.Beep.Play();
                }
            }
        }

        private void DeleteCmItem_Click(object sender, EventArgs e)
        {
            isCurrentMouseOverRowLocked = true;
            DeleteContact();
            isCurrentMouseOverRowLocked = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Contact editedContact = new Contact(NameTextBox.Text, SurnameTextBox.Text, PhoneTextBox.Text);
            contacts[currentMouseOverRow] = editedContact;
            RefreshDataGridView();

            StopEditMode();
        }

        private void EditCmItem_Click(object sender, EventArgs e)
        {
            StartEditMode();
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            StopEditMode();
        }

        private void NewTsmItem_Click(object sender, EventArgs e)
        {
            DialogResult saveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
                "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (saveQueryResult)
            {
                case DialogResult.Yes:
                    {
                        SaveTsmItem_Click(sender, e);
                        contacts.Clear();
                        RefreshDataGridView();
                        currentFile = null;
                        if (isCurrentMouseOverRowLocked)
                        {
                            StopEditMode();
                        }
                        break;
                    }
                case DialogResult.No:
                    {
                        contacts.Clear();
                        RefreshDataGridView();
                        currentFile = null;
                        if (isCurrentMouseOverRowLocked)
                        {
                            StopEditMode();
                        }
                        break;
                    }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult saveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
                "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (saveQueryResult)
            {
                case DialogResult.Yes:
                    {
                        SaveTsmItem_Click(sender, e);
                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
                default:
                    {
                        e.Cancel = true;
                        break;
                    }
            }
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ConBook - Nikodem Przbyszewski 2023\n\n" +
                "Oprogramowanie: Visual Studio 2022 (.NET Framework 64-bit)\n" +
                "Ikona: Icongeek26 @ flaticon.com", "ConBook v1.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (currentFile != string.Empty && currentFile != null)
            {
                using (StreamWriter writer = new StreamWriter("recent"))
                {
                    writer.Write(currentFile);
                }
            }
        }
    }
}