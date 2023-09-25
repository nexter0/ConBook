using System.Text.RegularExpressions;

namespace ConBook {

  public partial class frmContactEditor : Form {

    private bool mIsCanceled;             // Zmienna przechowująca info, czy formularz anulowany
    private bool mIsApplied;              // Zmienna przechowująca info, czy formularz zatwierdzony
    private enum mValidationResultEnum { OK, FIELD_EMPTY, PHONE_CHARACTERS_ERROR, PHONE_LENGTH_ERROR, NAME_LENGTH_ERROR, SURNAME_LENGTH_ERROR,
      DESCRIPTION_LENGTH_ERROR, NOTES_LENGTH_ERROR, DIGIT_ERROR, MARKERS_ERROR }

    public bool IsCanceled {
      get { return mIsCanceled; }
      set { mIsCanceled = value; }
    }

    public bool IsApplied {
      get { return mIsApplied; }
      set { mIsApplied = value; }
    }


    public frmContactEditor() {

      InitializeComponent();
      IsCanceled = false;
      IsApplied = false;

    }


    private void btnSubmit_Click(object sender, EventArgs e) {

      Submit();

    }

    private void btnCancel_Click(object sender, EventArgs e) {

      Cancel();

    }

    private void frmContactEditor_KeyUp(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Escape) {
        Cancel();
      }
    }

    private void Cancel() {

      this.IsCanceled = true;
      this.Close();

    }

    private void Submit() {


      mValidationResultEnum pCntValidation = ValidateTextBoxes();

      if (pCntValidation == mValidationResultEnum.OK) {
        this.Close();
        IsApplied = true;
      } else
        TextBoxErrorHandler(pCntValidation);

    }

    private void TextBoxErrorHandler(mValidationResultEnum xCntValidationResult) {

      string pCaption = "Błąd";
      string pMessage = "Nieprawdiłowe dane!\n\n";

      int pNameMaxLen = cDataBaseService.CONTACT_NAME_MAXLEN;
      int pSurnameMaxLen = cDataBaseService.CONTACT_SURNAME_MAXLEN;
      int pPhoneMaxLen = cDataBaseService.CONTACT_PHONE_MAXLEN;
      int pDescMaxLen = cDataBaseService.CONTACT_DESC_MAXLEN;
      int pNotesMaxLen = cDataBaseService.CONTACT_NOTES_MAXLEN;

      switch (xCntValidationResult) {
        case mValidationResultEnum.FIELD_EMPTY: { pMessage += "Pola Imię, Nazwisko, Telefon są wymagane."; break; }
        case mValidationResultEnum.PHONE_CHARACTERS_ERROR: { pMessage += "Niedozwolone znaki w polu Telefon."; break; }
        case mValidationResultEnum.DIGIT_ERROR: { pMessage += "Pola Imię i Nazwisko nie mogą zawierać cyfr."; break; }
        case mValidationResultEnum.MARKERS_ERROR: { pMessage += "Niedozwolona kombinacja znaków ('::', '$<', '>$')."; break; }
        case mValidationResultEnum.NAME_LENGTH_ERROR: { pMessage += $"Zbyt dużo znaków w polu Imię (max. {pNameMaxLen})."; break; }
        case mValidationResultEnum.SURNAME_LENGTH_ERROR: { pMessage += $"Zbyt dużo znaków w polu Nazwisko (max. {pSurnameMaxLen})."; break; }
        case mValidationResultEnum.PHONE_LENGTH_ERROR: { pMessage += $"Zbyt dużo znaków w polu Telefon (max. {pPhoneMaxLen})."; break; }
        case mValidationResultEnum.DESCRIPTION_LENGTH_ERROR: { pMessage += $"Zbyt dużo znaków w polu Opis (max. {pDescMaxLen})."; break; }
        case mValidationResultEnum.NOTES_LENGTH_ERROR: { pMessage += $"Zbyt dużo znaków w polu Notatki (max. {pNotesMaxLen})."; break; }

      }

      MessageBox.Show(pMessage, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
        btnSubmit.Text = "Zapisz";
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

      this.IsCanceled = false;
      this.IsApplied = false;

      InitializeTextBoxes(xContact);
      CustomizeWidow(xContact.IsEmpty());
      this.ShowDialog();

      if (this.IsCanceled)
        return false;

      if (!this.IsApplied)
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

      //sprawdź, czy puste
      mValidationResultEnum pEmptyValidation = ValidateCheckBoxesEmpty();

      if (pEmptyValidation != mValidationResultEnum.OK)
        return pEmptyValidation;

      //sprawdź długość
      mValidationResultEnum pLengthValidation = ValidateCheckBoxesLength();

      if (pLengthValidation != mValidationResultEnum.OK)
        return pLengthValidation;

      //sprawdź znaki
      mValidationResultEnum pCharactersValidation = ValidateCheckBoxesCharacters();

      if (pCharactersValidation != mValidationResultEnum.OK)
        return pCharactersValidation;

      return mValidationResultEnum.OK;

    }

    private mValidationResultEnum ValidateCheckBoxesLength() {

      int pNameMaxLen = cDataBaseService.CONTACT_NAME_MAXLEN;
      int pSurnameMaxLen = cDataBaseService.CONTACT_SURNAME_MAXLEN;
      int pPhoneMaxLen = cDataBaseService.CONTACT_PHONE_MAXLEN;
      int pDescMaxLen = cDataBaseService.CONTACT_DESC_MAXLEN;
      int pNotesMaxLen = cDataBaseService.CONTACT_NOTES_MAXLEN;


      if (txtName.Text.Length > pNameMaxLen) { return mValidationResultEnum.NAME_LENGTH_ERROR; }
      if (txtSurname.Text.Length > pSurnameMaxLen) { return mValidationResultEnum.SURNAME_LENGTH_ERROR; }
      if (txtPhone.Text.Length > pPhoneMaxLen) { return mValidationResultEnum.PHONE_LENGTH_ERROR; }
      if (rtbDescription.Text.Length > pDescMaxLen) { return mValidationResultEnum.DESCRIPTION_LENGTH_ERROR; }
      if (rtbNotes.Text.Length > pNotesMaxLen) { return mValidationResultEnum.NOTES_LENGTH_ERROR; }

      return mValidationResultEnum.OK;

    }

    private mValidationResultEnum ValidateCheckBoxesCharacters() {

      string pPatternPhone = @"[^0-9.,\-\s\+\(\)]";
      string pPatternDigit = @"\d";
      string pPatternMarkers = @"(::|\$<|\>\$)";

      if (Regex.IsMatch(txtPhone.Text, pPatternPhone)) { return mValidationResultEnum.PHONE_CHARACTERS_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return mValidationResultEnum.DIGIT_ERROR; };
      if (Regex.IsMatch(txtSurname.Text, pPatternDigit)) { return mValidationResultEnum.DIGIT_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternDigit)) { return mValidationResultEnum.DIGIT_ERROR; };
      if (Regex.IsMatch(txtName.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(txtSurname.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(rtbDescription.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };

      return mValidationResultEnum.OK;

    }

    private mValidationResultEnum ValidateCheckBoxesEmpty() {

      if (string.IsNullOrEmpty(txtName.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtSurname.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtPhone.Text)) { return mValidationResultEnum.FIELD_EMPTY; }

      return mValidationResultEnum.OK;

    }

  }
}
