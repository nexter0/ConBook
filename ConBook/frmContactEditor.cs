﻿using System.Text.RegularExpressions;

namespace ConBook {

  public partial class frmContactEditor : Form {

    // opisuj pola klasy
    public event EventHandler? DataFormLoaded;
    public event EventHandler? DataFormClosed;

    private bool mIsEditing;
    public IMainComponents mMainForm;


    // "nie można " przekayzywac formularza do formularza, użyj do tego dedykowanej klasy
    public frmContactEditor(IMainComponents xMainForm, bool xIsEditing) {

      InitializeComponent();
      mMainForm = xMainForm;
      mIsEditing = xIsEditing;

    }

    void btnSubmit_Click(object sender, EventArgs e) {

      int pValidation = ValidateTextBoxes();

      if (pValidation == 0) {

        if (!mIsEditing) {

          cContactListUtils pListUtils = new cContactListUtils(mMainForm);
          pListUtils.AddContact(txtName.Text, txtSurname.Text, txtPhone.Text);

          Close();

        } else {

          cContactListUtils pListUtils = new cContactListUtils(mMainForm);
          pListUtils.EditContact(txtName.Text, txtSurname.Text, txtPhone.Text);

          Close();

        }

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

    private void btnCancel_Click(object sender, EventArgs e) {

      mIsEditing = false;
      Close();

    }

    private void DataForm_Load(object sender, EventArgs e) {

      DataFormLoaded?.Invoke(this, EventArgs.Empty);

      if (mIsEditing) {

        btnSubmit.Text = "Edytuj";
        this.Text = "Edytuj kontakt";
        this.Icon = Properties.Resources.editIcon;

        txtName.Text = mMainForm.mContacts[mMainForm.mSelectedRowIndex].Name;
        txtSurname.Text = mMainForm.mContacts[mMainForm.mSelectedRowIndex].Surname;
        txtPhone.Text = mMainForm.mContacts[mMainForm.mSelectedRowIndex].Phone;

      } else {

        btnSubmit.Text = "Dodaj";
        this.Text = "Dodaj kontakt";
        this.Icon = Properties.Resources.plusIcon;

        txtName.Text = String.Empty;
        txtSurname.Text = String.Empty;
        txtPhone.Text = String.Empty;

      }

    }

    private void DataForm_FormClosed(object sender, FormClosedEventArgs e) {

      DataFormClosed?.Invoke(this, EventArgs.Empty);

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
