using System.Text.RegularExpressions;

namespace ConBook {
    public partial class DataForm : Form {
        private bool mIsEditing = false;
        private readonly MainForm mMainForm;

        public DataForm(MainForm mainForm, bool isEditing) {
            InitializeComponent();
            mMainForm = mainForm;
            mIsEditing = isEditing;
        }

        void btnSubmit_Click(object sender, EventArgs e) {
            int pValidation = ValidateTextBoxes();
            if (pValidation == 0) {
                if (!mIsEditing) {
                    // dodaj kontakt do listy
                    cContact pNewContact = new cContact(txtName.Text, txtSurname.Text, txtPhone.Text);
                    mMainForm.mContacts.Add(pNewContact);
                    mMainForm.RefreshDataGridView();
                    Close();

                }
                else {
                    // edytuj istniejący kontakt
                    cContact pEditedContact = new cContact(txtName.Text, txtSurname.Text, txtPhone.Text);
                    mMainForm.mContacts[mMainForm.mSelectedRowIndex] = pEditedContact;
                    mMainForm.RefreshDataGridView();
                    Close();
                }

            }
            else {
                string pCaption = "Błąd";
                string pMessage = "Nieprawdiłowe dane!\n\n";
                switch (pValidation) {
                    case 1: { pMessage += "Wszystkie pola są wymagane."; break; }
                    case 2: { pMessage += "Niedozwolone znaki w polu Telefon."; break; }
                    case 3: { pMessage += "Pola Imię i Nazwisko nie mogą zawierać cyfr."; break; }
                }

                MessageBox.Show(pMessage, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e) {
            mIsEditing = false;
            Close();
        }

        private void DataForm_Load(object sender, EventArgs e) {
            mMainForm.Enabled = false;
            if (mIsEditing) {
                btnSubmit.Text = "Edytuj";
                this.Text = "Edytuj kontakt";
                this.Icon = Properties.Resources.editIcon;

                txtName.Text = mMainForm.mContacts[mMainForm.mSelectedRowIndex].Name;
                txtSurname.Text = mMainForm.mContacts[mMainForm.mSelectedRowIndex].Surname;
                txtPhone.Text = mMainForm.mContacts[mMainForm.mSelectedRowIndex].Phone;
            }
            else {
                btnSubmit.Text = "Dodaj";
                this.Text = "Dodaj kontakt";
                this.Icon = Properties.Resources.plusIcon;

                txtName.Text = String.Empty;
                txtSurname.Text = String.Empty;
                txtPhone.Text = String.Empty;
            }
        }

        private void DataForm_FormClosed(object sender, FormClosedEventArgs e) {
            mMainForm.Enabled = true;
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
    }
}
