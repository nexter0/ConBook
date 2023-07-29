using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ConBook {

  public partial class frmContactEditor : Form {

    public event EventHandler? DataFormClosed;        // Zdarzenie - zamknięcie formularza

    private cContactListUtils mContactListUtils;      // Obiekt klasy mContactListUtils do operacji na kontaktach
    private BindingList<cContact> mContacts;          // Lista kontatków
   
    zmienne typu bool muszą zaczynać się od czasownika w tym wypadku powinno być mIsInEditMode
    private bool mInEditMode;                         // Boolean - formularz w trybie edycji
    private int mContactIndex;                        // Indeks edytowanego kontaktu na liście kontaktów

    public frmContactEditor(BindingList<cContact> xContactList, bool xInEditMode = false, int xContactIndex = -1) {

      InitializeComponent();

      pole mContacts jest tutaj dosyć karkołomne 
        tak samo mContactListUtils
      ten formularz ma operować wyłącznie na klasie cContact
      on generalnie nie ma prawa ingerować w żadne kolecje
      jesli usuniesz mContact to on Ci się uprości
        nie bedziesz musiał używać żadnego znacznika, czy jest w trybie edycji czy dodawania
        formularza ma to w ogóle nie obchodzić
        on ma przyjąć dane kontaktu i je zwrócić nowe
        póżniej niżej piszę jaką funkcję zrobić

      mContacts = xContactList;
      mInEditMode = xInEditMode;
      mContactIndex = xContactIndex;

      mContactListUtils = new cContactListUtils();

    }

    void btnSubmit_Click(object sender, EventArgs e) {

      int pValidation = ValidateTextBoxes();

      if (pValidation == 0) {

        if (!mInEditMode) {

          mContactListUtils.AddContact(txtName.Text, txtSurname.Text, txtPhone.Text, mContacts);

          Close();

        } else {

          mContactListUtils.EditContact(txtName.Text, txtSurname.Text, txtPhone.Text, mContacts, mContactIndex);

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

      mInEditMode = false;
      Close();

    }

    private void DataForm_Load(object sender, EventArgs e) {

      if (mInEditMode) {

        btnSubmit.Text = "Edytuj";
        this.Text = "Edytuj kontakt";
        this.Icon = Properties.Resources.editIcon;

        txtName.Text = mContacts[mContactIndex].Name;
        txtSurname.Text = mContacts[mContactIndex].Surname;
        txtPhone.Text = mContacts[mContactIndex].Phone;

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

      to jest w ogóle niepotrzebne, funkcja ShowMe umozliwi Ci ominięcie takiej konstrukcji

      DataFormClosed?.Invoke(this, EventArgs.Empty);

    }
    
    to jest oczywiście jedna z wielu, wielu możliwości
    utwórz funkcję:
      internal bool ShowMe(cContact xContact){

    ...
      this.ShowDialog();
    ..

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
