using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


namespace ConBook
{
    public partial class MainForm : Form
    {
        public BindingList<Contact> contacts = new BindingList<Contact>();

        private string? currentFile = null;
        private bool currentFileEdited = false;

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

            DataGridViewColumn dgvColumnSurname = dgvContacts.Columns[0];
            DataGridViewColumn dgvColumnName = dgvContacts.Columns[1];
            DataGridViewColumn dgvColumnPhone = dgvContacts.Columns[2];

            dgvColumnSurname.HeaderText = "Nazwisko";
            dgvColumnName.HeaderText = "Imię";
            dgvColumnPhone.HeaderText = "Telefon";
            dgvColumnSurname.Width = 215;
            dgvColumnName.Width = 215;
            dgvColumnPhone.Width = 147;

            //foreach (DataGridViewRow row in dgvContacts.Rows)
            //{
            //    row.HeaderCell.Value = (row.Index + 1).ToString();
            //}

            dgvContacts.Refresh();
        }

        private void SumbitContact()
        {
            int validation = ValidateTextBoxes();
            if (validation == 0)
            {
                Contact newContact = new Contact(nameTextBox.Text, surnameTextBox.Text, phoneTextBox.Text);
                contacts.Add(newContact);

                nameTextBox.Text = string.Empty;
                surnameTextBox.Text = string.Empty;
                phoneTextBox.Text = string.Empty;
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

        private int ValidateTextBoxes()
        {
            string patternPhone = @"[^0-9\s-+]";
            string patternDigit = @"\d";

            if (string.IsNullOrEmpty(nameTextBox.Text)) { return 1; }
            if (string.IsNullOrEmpty(surnameTextBox.Text)) { return 1; }
            if (string.IsNullOrEmpty(phoneTextBox.Text)) { return 1; }
            if (Regex.IsMatch(phoneTextBox.Text, patternPhone)) { return 2; };
            if (Regex.IsMatch(nameTextBox.Text, patternDigit)) { return 3; };
            if (Regex.IsMatch(surnameTextBox.Text, patternDigit)) { return 3; };

            return 0;
        }

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


        private void submitButton_Click(object sender, EventArgs e)
        {
            SumbitContact();
        }

        private void sortujToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (contacts.Count > 0)
                {
                    if (currentFile != null)
                    {
                        SaveToExistingFile(currentFile);
                    }
                    else
                    {
                        otwórzToolStripMenuItem_Click(sender, e);
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

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
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
                    RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Podczas wczytywania wystąpił błąd: \n" + ex.Message, "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            string? file = Directory.EnumerateFiles(path, "*.xml").FirstOrDefault();
            if (file != null)
            {
                try
                {
                    LoadFile(file);
                    currentFile = file;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Podczas wczytywania wystąpił błąd: \n" + ex.Message + "\n\nWczytywany plik: " + file, "Błąd wczytywania",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            RefreshDataGridView();
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SumbitContact();
            }
        }

        private void surnameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SumbitContact();
            }
        }

        private void phoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SumbitContact();
            }
        }
    }
}