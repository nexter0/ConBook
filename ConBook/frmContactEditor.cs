using System.Text.RegularExpressions;

namespace ConBook {

  public partial class frmContactEditor : Form {

    bool mIsCanceled;             // Zmienna przechowująca info, czy formularz anulowany

    private enum mValidationResult { OK, FIELD_EMPTY, PHONE_ERROR, DIGIT_ERROR, MARKERS_ERROR }

    public frmContactEditor() {

      InitializeComponent();
      mIsCanceled = false;

    }


    private void btnSubmit_Click(object sender, EventArgs e) {

      Submit();

    }

    private void btnCancel_Click(object sender, EventArgs e) {

      Cancel();

    }

    private void Cancel() {

      this.mIsCanceled = true;
      this.Close();

    }

    private void Submit() {

      mValidationResult pValidation = ValidateTextBoxes();

      if (pValidation == mValidationResult.OK) {
        this.Close();
      } else {
        string pCaption = "Błąd";
        string pMessage = "Nieprawdiłowe dane!\n\n";

        switch (pValidation) {
          case mValidationResult.FIELD_EMPTY: { pMessage += "Pola Imię, Nazwisko, Telefon są wymagane."; break; }
          case mValidationResult.PHONE_ERROR: { pMessage += "Niedozwolone znaki w polu Telefon."; break; }
          case mValidationResult.DIGIT_ERROR: { pMessage += "Pola Imię i Nazwisko nie mogą zawierać cyfr."; break; }
          case mValidationResult.MARKERS_ERROR: { pMessage += "Niedozwolona kombinacja znaków ('~~', '~<', '>~')."; break; }

        }

        MessageBox.Show(pMessage, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      }

    }

    private void InitializeTextBoxes(cContact xContact) {

      if (xContact != null) {
        txtName.Text = xContact.Name;
        txtSurname.Text = xContact.Surname;
        txtPhone.Text = xContact.Phone;
        rtbDescription.Text = xContact.Description;
        //rtbNotes.Text = xContact.Notes;
      } else {
        txtName.Text = string.Empty;
        txtSurname.Text = string.Empty;
        txtPhone.Text = string.Empty;
        rtbDescription.Text = string.Empty;
        //rtbNotes.Text = string.Empty;
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
      xContact.Description = rtbDescription.Text;
      //xContact.Notes = rtbNotes.Text;

      if (xContact.IsEmpty())
        return false;

      return true;

    }

    private mValidationResult ValidateTextBoxes() {
      //funkcja weryfikująca poprawność wpisanych danych w pola tekstowe      

      string pPatternPhone = @"[^0-9\s-+]";
      string pPatternDigit = @"\d";
      string pPatternMarkers = @"~~|~<|>~";

      if (string.IsNullOrEmpty(txtName.Text)) { return mValidationResult.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtSurname.Text)) { return mValidationResult.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtPhone.Text)) { return mValidationResult.FIELD_EMPTY; }
      if (Regex.IsMatch(txtPhone.Text, pPatternPhone)) { return mValidationResult.PHONE_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return mValidationResult.DIGIT_ERROR; };
      if (Regex.IsMatch(txtSurname.Text, pPatternDigit)) { return mValidationResult.DIGIT_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return mValidationResult.DIGIT_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternMarkers)) { return mValidationResult.MARKERS_ERROR; };
      if (Regex.IsMatch(txtSurname.Text, pPatternMarkers)) { return mValidationResult.MARKERS_ERROR; };
      if (Regex.IsMatch(rtbDescription.Text, pPatternMarkers)) { return mValidationResult.MARKERS_ERROR; };

      return mValidationResult.OK;

    }
  }
}
