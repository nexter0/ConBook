using System.Configuration;
using System.Text.RegularExpressions;

namespace ConBook {

  public partial class frmContactEditor : Form {

    bool mIsCanceled;             // Zmienna przechowująca info, czy formularz anulowany

    public frmContactEditor() {

      InitializeComponent();
      mIsCanceled = false;

    }


    private void btnSubmit_Click(object sender, EventArgs e) {

      SubmitAction();

    }

    private void btnCancel_Click(object sender, EventArgs e) {

      CancelAction();

    }

    private void CancelAction() {

      this.mIsCanceled = true;
      this.Close();

    }

    private void SubmitAction() {

      int pValidation = ValidateTextBoxes();

      if (pValidation == 0) {

        //mContact = new cContact(txtName.Text, txtSurname.Text, txtPhone.Text);
        this.Close();

      } else {

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

    private void InitializeTextBoxes(cContact xContact) {

      if (xContact != null) {
        txtName.Text = xContact.Name;
        txtSurname.Text = xContact.Surname;
        txtPhone.Text = xContact.Phone;
      } else {
        txtName.Text = string.Empty;
        txtSurname.Text = string.Empty;
        txtPhone.Text = string.Empty;
      }

    }

    private void CustomizeWidow(bool xIsEmptyContact) {

      if (!xIsEmptyContact) {

        btnSubmit.Text = "Edytuj";
        this.Text = "Edytuj kontakt";
        this.Icon = Properties.Resources.editIcon;

      } else {

        btnSubmit.Text = "Dodaj";
        this.Text = "Dodaj kontakt";
        this.Icon = Properties.Resources.plusIcon;

      }

    }

    internal bool ShowMe(cContact xContact) {

      mIsCanceled = false;

      InitializeTextBoxes(xContact);
      CustomizeWidow(xContact.IsEmpty());
      this.ShowDialog();

      if (mIsCanceled)
        return false;

      xContact.Name = txtName.Text;
      xContact.Surname = txtSurname.Text;
      xContact.Phone = txtPhone.Text;

      return true;

    }

    private int ValidateTextBoxes() {
      //funkcja weryfikująca poprawność wpisanych danych w pola tekstowe      

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
