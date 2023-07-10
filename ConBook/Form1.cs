using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConBook
{
    public partial class Form1 : Form
    {
        public BindingList<Contact> contacts = new BindingList<Contact>();

        public Form1()
        {
            InitializeComponent();
            refreshDataGridView();
        }

        private void refreshDataGridView()
        {
            dataGridViewContacts.DataSource = null;
            dataGridViewContacts.DataSource = contacts;
            dataGridViewContacts.Refresh();
            dataGridViewContacts.Columns["Surname"].DisplayIndex = 0;
            dataGridViewContacts.Columns["Name"].DisplayIndex = 1;
            dataGridViewContacts.Columns["Phone"].DisplayIndex = 2;
            dataGridViewContacts.Columns["Surname"].HeaderText = "Nazwisko";
            dataGridViewContacts.Columns["Name"].HeaderText = "Imię";
            dataGridViewContacts.Columns["Phone"].HeaderText = "Telefon";
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int validation = validateTextBoxes();
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
                }

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private int validateTextBoxes()
        {
            string patternPhone = @"[^0-9\s-+]";

            if (string.IsNullOrEmpty(nameTextBox.Text)) { return 1; }
            if (string.IsNullOrEmpty(surnameTextBox.Text)) { return 1; }
            if (string.IsNullOrEmpty(phoneTextBox.Text)) { return 1; }
            if (Regex.IsMatch(phoneTextBox.Text, patternPhone)) { return 2; };

            return 0;
        }

        private void sortujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Contact> tempContactList = new List<Contact>(contacts);
            tempContactList.Sort();
            contacts = new BindingList<Contact>(tempContactList);
            refreshDataGridView();
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to do
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Dokument XML (*.xml)|*.xml";
                saveFileDialog.Title = "Zapisz jako...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Contact>));

                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        serializer.Serialize(fileStream, contacts);
                    }

                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Podczas zapisywania wystąpił błąd: " + ex.Message, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Check if InnerException exists
                if (ex.InnerException != null)
                {
                    // Get the InnerException
                    Exception innerException = ex.InnerException;

                    // Display InnerException details in a message box
                    string message = "InnerException Message: " + innerException.Message + "\n"
                        + "InnerException StackTrace: " + innerException.StackTrace;
                    MessageBox.Show(message, "Serialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // No InnerException available, display the exception details in a message box
                    string message = "Exception Message: " + ex.Message + "\n"
                        + "Exception StackTrace: " + ex.StackTrace;
                    MessageBox.Show(message, "Serialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}