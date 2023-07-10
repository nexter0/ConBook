using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace ConBook
{
    public partial class Form1 : Form
    {
        private BindingList<Contact> contacts = new BindingList<Contact>();

        public Form1()
        {
            InitializeComponent();
            BindContactsToDataGridView();
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
                // Initializes the variables to pass to the MessageBox.Show method.
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

        private void BindContactsToDataGridView()
        {
            dataGridViewContacts.DataSource = contacts;
            dataGridViewContacts.Columns["Surname"].HeaderText = "Nazwisko";
            dataGridViewContacts.Columns["Name"].HeaderText = "Imię";
            dataGridViewContacts.Columns["Phone"].HeaderText = "Telefon";
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

    }
}