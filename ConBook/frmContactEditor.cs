using System.Text.RegularExpressions;

namespace ConBook {

  public partial class frmContactEditor : Form {

    bool mIsCanceled;             // Zmienna przechowująca info, czy formularz anulowany

    private enum mValidationResultEnum { OK, FIELD_EMPTY, PHONE_ERROR, DIGIT_ERROR, MARKERS_ERROR }

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


      mValidationResultEnum pCntValidation = ValidateTextBoxes();

      if (pCntValidation == mValidationResultEnum.OK) {
        this.Close();
      } else {
        string pCaption = "Błąd";
        string pMessage = "Nieprawdiłowe dane!\n\n";

        switch (pCntValidation) {
          case mValidationResultEnum.FIELD_EMPTY: { pMessage += "Pola Imię, Nazwisko, Telefon są wymagane."; break; }
          case mValidationResultEnum.PHONE_ERROR: { pMessage += "Niedozwolone znaki w polu Telefon."; break; }
          case mValidationResultEnum.DIGIT_ERROR: { pMessage += "Pola Imię i Nazwisko nie mogą zawierać cyfr."; break; }
          case mValidationResultEnum.MARKERS_ERROR: { pMessage += "Niedozwolona kombinacja znaków ('::', '$<', '>$')."; break; }

        }

        MessageBox.Show(pMessage, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      }

    }

    private void InitializeTextBoxes(cContact xContact) {
      //funkcja czyszcząca lub uzupełniająca pola tekstowa

      if (xContact != null) {
        txtName.Text = xContact.Name;
        txtSurname.Text = xContact.Surname;
        txtPhone.Text = xContact.Phone;
        rtbDescription.Text = xContact.Description;
        rtbNotes.Text = xContact.Notes;
        //rtbAddress.Text = xContact.Address;
      } else {
        txtName.Text = string.Empty;
        txtSurname.Text = string.Empty;
        txtPhone.Text = string.Empty;
        rtbDescription.Text = string.Empty;
        rtbNotes.Text = string.Empty;
        //rtbAddress.Text = string.Empty;
      }

    }

    private void CustomizeWidow(bool xIsEmptyContact) {
      //funkcja ustawiająca właściwości okna w zależności od trybu edycji / dodawania

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
      //funkcja wywołująca formularz

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
      xContact.Notes = rtbNotes.Text;

      if (xContact.IsEmpty())
        return false;

      return true;

    }

    private mValidationResultEnum ValidateTextBoxes() {
      //funkcja weryfikująca poprawność wpisanych danych w pola tekstowe      

      string pPatternPhone = @"[^0-9.,]";
      string pPatternDigit = @"\d";
      string pPatternMarkers = @"(::|\$<|\>\$)";

      if (string.IsNullOrEmpty(txtName.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtSurname.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtPhone.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (Regex.IsMatch(txtPhone.Text, pPatternPhone)) { return mValidationResultEnum.PHONE_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return mValidationResultEnum.DIGIT_ERROR; };
      if (Regex.IsMatch(txtSurname.Text, pPatternDigit)) { return mValidationResultEnum.DIGIT_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return mValidationResultEnum.DIGIT_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(txtSurname.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(rtbDescription.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };

      return mValidationResultEnum.OK;

    }
  }
}
