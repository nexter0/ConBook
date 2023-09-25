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

    private void frmContactsModule_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {
        this.Close();
      }

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
    }

    public void AddContact() {
      //funkcja obsługująca dodawanie kontaktu

      cContact pContact = new cContact();
      frmContactEditor pContactEditor = new frmContactEditor();

      if (!pContactEditor.ShowMe(pContact))
        return;

      mContactsListUtils.AddContact(pContact);

      RefreshDataGridView();

    }

    public void EditContact() {
      //funkcja obsługująca edycję kontaktu

      int pContactIndex = dgvContacts.SelectedRows[0].Index;
      cContact pContact = mContactsListUtils.ContactsList[pContactIndex];
      frmContactEditor pContactEditor = new frmContactEditor();

      if (pContactEditor.ShowMe(pContact)) {
        mContactsListUtils.EditContact(pContact);
        RefreshDataGridView();
      }


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



    private void LoadContacts() {
      //funkcja wczytująca listę produktów

      string pDefaultFilePath = cProductsSerializer.DEFAULT_SAVE_FILE_PATH;

      cContactDAO pContactDAO = new cContactDAO();
      List<cContact>? pContactsList = pContactDAO.GetContactList();

      if (pContactsList != null)
        mContactsListUtils.ContactsList = new BindingList<cContact>(pContactsList);

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
