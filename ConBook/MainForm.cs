using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;


namespace ConBook
{
    public partial class MainForm : Form
    {
        public BindingList<Contact> contacts = new();

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
            XmlSerializer serializer = new(typeof(BindingList<Contact>));

            using FileStream fileStream = new(fileName, FileMode.Open);
            BindingList<Contact> loadedContacts = (BindingList<Contact>)serializer.Deserialize(fileStream);

            contacts.Clear();
            contacts = new BindingList<Contact>(loadedContacts);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int validation = ValidateTextBoxes();
            if (validation == 0)
            {
                Contact newContact = new(nameTextBox.Text, surnameTextBox.Text, phoneTextBox.Text);
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

        private void sortujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Contact> tempContactList = new(contacts);
            tempContactList.Sort();
            contacts = new BindingList<Contact>(tempContactList);
            RefreshDataGridView();
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to do
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new()
                {
                    Filter = "Dokument XML (*.xml)|*.xml",
                    Title = "Zapisz jako..."
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    XmlSerializer serializer = new(typeof(BindingList<Contact>));

                    using FileStream fileStream = new(fileName, FileMode.Create);
                    serializer.Serialize(fileStream, contacts);

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

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new()
                {
                    Filter = "Dokument XML (*.xml)|*.xml",
                    Title = "Otwórz..."
                };


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    LoadFile(fileName);
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
            var file = Directory.EnumerateFiles(path, "*.xml").FirstOrDefault();
            if (file != null) 
            {
                try
                {
                    LoadFile(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Podczas wczytywania wystąpił błąd: \n" + ex.Message + "\n\nWczytywany plik: " + file, "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            RefreshDataGridView();
        }
    }
}