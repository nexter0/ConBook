using System.ComponentModel;

namespace ConBook {
  public partial class frmContactsModule : Form {

    private cContactsListUtils mContactsListUtils;               // klasa cContactsListUtils - do operacji na kontaktach


    private enum SortTypeEnum {                                  // numerator sposobu sortowania listy kontaktów
      ByIndex = 0,
      ByName = 1,
      BySurname = 2
    }



    public frmContactsModule() {
      InitializeComponent();

      mContactsListUtils = new cContactsListUtils();

    }

    #region Events

    private void frmContactsModule_Load(object sender, EventArgs e) {

      LoadContacts();

      RefreshDataGridView();

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      AddContact();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      DeleteContact();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      EditContact();

    }

    private void dgvContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {

      cContact pContact = mContactsListUtils.ContactsList[dgvContacts.SelectedRows[0].Index];

      EditContact();

    }

    private void dgvContacts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

      SortList((SortTypeEnum)e.ColumnIndex);

    }

    #endregion

    #region Methods

    internal bool ShowMe() {
      //funkcja wywołująca formularz

      this.ShowDialog();

      return true;

    }

    public void DeleteContact() {
      //funkcja obsługująca usuwanie kontaktu

      mContactsListUtils.DeleteContact(dgvContacts.SelectedRows[0].Index);

      RefreshDataGridView();

      SaveContacts();
    }

    public void AddContact() {
      //funkcja obsługująca dodawanie kontaktu

      cContact pContact = new cContact();
      frmContactEditor pContactEditor = new frmContactEditor();

      if (!pContactEditor.ShowMe(pContact))
        return;

      mContactsListUtils.AddContact(pContact);

      RefreshDataGridView();

      SaveContacts();

    }

    public void EditContact() {
      //funkcja obsługująca edycję kontaktu

      cContact pContact = mContactsListUtils.ContactsList[dgvContacts.SelectedRows[0].Index];
      frmContactEditor pContactEditor = new frmContactEditor();

      if (pContactEditor.ShowMe(pContact))
        RefreshDataGridView();

      SaveContacts();

    }

    public void RefreshDataGridView() {
      //funkcja odświeżająca DataGridView oraz przyciski Edytuj / Usuń

      dgvContacts.DataSource = mContactsListUtils.ContactsList;


      DataGridViewColumn pDgvColumnSurname = dgvContacts.Columns["Surname"];
      DataGridViewColumn pDgvColumnName = dgvContacts.Columns["Name"];
      DataGridViewColumn pDgvColumnPhone = dgvContacts.Columns["Phone"];
      DataGridViewColumn pDgvColumnIndex = dgvContacts.Columns["Index"];
      DataGridViewColumn pDgvColumnDesc = dgvContacts.Columns["Description"];
      DataGridViewColumn pDgvColumnNotes = dgvContacts.Columns["Notes"];

      pDgvColumnDesc.Visible = false;
      pDgvColumnNotes.Visible = false;
      pDgvColumnIndex.HeaderText = "Indeks";
      pDgvColumnName.HeaderText = "Imię";
      pDgvColumnSurname.HeaderText = "Nazwisko";
      pDgvColumnPhone.HeaderText = "Telefon";
      pDgvColumnSurname.Width = 215;
      pDgvColumnName.Width = 215;
      pDgvColumnPhone.Width = 150;
      pDgvColumnIndex.Width = 50;

      if (mContactsListUtils.ContactsList.Count == 0) {
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
      } else {
        btnEdit.Enabled = true;
        btnDelete.Enabled = true;
      }

      dgvContacts.Refresh();

    }

    private void SaveContacts() {
      // funkcja do automatycznego zapisu listy

      string pDefaultFilePath = cContactsSerializer.DEFAULT_SAVE_FILE_PATH;

      if (!File.Exists(pDefaultFilePath)) {
        cContactsSerializer.SaveToNewTxtFile(pDefaultFilePath, mContactsListUtils.ContactsList);
      } else {
        SaveToFile();
      }


    }

    private void SaveToFile() {
      //funkcja obsługująca zapis do istniejącego pliku

      string pDefaultFilePath = cContactsSerializer.DEFAULT_SAVE_FILE_PATH;

      try {
        if (mContactsListUtils.ContactsList.Count > 0) {
          if (File.Exists(pDefaultFilePath))
            cContactsSerializer.SaveToExistingTxtFile(pDefaultFilePath, mContactsListUtils.ContactsList);
        }
      } catch (Exception ex) {
        if (ex.InnerException != null) {
          Exception pInnerException = ex.InnerException;
          string pMessage = "Błąd: \n" + pInnerException.Message + "\n"
              + "InnerException StackTrace: \n" + pInnerException.StackTrace;

          MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } else {
          string pMessage = "Błąd: \n" + ex.Message + "\n"
              + "StackTrace: \n" + ex.StackTrace;

          MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }

    }

    private void LoadContacts() {
      //funkcja wczytująca listę produktów

      string pDefaultFilePath = cProductsSerializer.DEFAULT_SAVE_FILE_PATH;

      try {
        if (File.Exists(pDefaultFilePath)) {
          mContactsListUtils.ContactsList = cContactsSerializer.GetContactsList();
        }
      } catch (Exception ex) {
        MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pDefaultFilePath}", "Błąd wczytywania",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

      }

      RefreshDataGridView();

    }


    private void SortList(SortTypeEnum xCntSortType) {
      //funkcja sortująca listę kontaktów
      //xSortType - typ sortowania (byName, bySurname)

      if (xCntSortType == SortTypeEnum.ByName) {
        if (mContactsListUtils.ContactsList.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactsListUtils.ContactsList);

          pTempContactList.Sort(new cContact.NamesComparer());
          mContactsListUtils.ContactsList = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();
        }
      } else if (xCntSortType == SortTypeEnum.BySurname) {
        if (mContactsListUtils.ContactsList.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactsListUtils.ContactsList);
          pTempContactList.Sort();
          mContactsListUtils.ContactsList = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();
        }
      } else if (xCntSortType == SortTypeEnum.ByIndex) {
        if (mContactsListUtils.ContactsList.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactsListUtils.ContactsList);

          pTempContactList.Sort(new cContact.IndexComparer());
          mContactsListUtils.ContactsList = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();
        }
      }

    }
  }
  #endregion

}
