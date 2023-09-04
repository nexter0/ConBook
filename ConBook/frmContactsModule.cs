using System.ComponentModel;

namespace ConBook {
  public partial class frmContactsModule : Form {

    private cContactsListUtils mContactsListUtils;               // klasa cContactsListUtils - do operacji na kontaktach
    private frmContactEditor mEditor;                            // klasa frmContactEditor - okienko dodawania / edycji kontaktów

    private string? mCurrentFile;                                // ścieżka pliku, w którym zapisana jest otwarta lista
    private FileTypesEnum mDefaultFileType;                      // domyślny typ pliku autozapisu

    private enum SortTypeEnum {                                  // numerator sposobu sortowania listy kontaktów
      ByName = 0,
      bySurname = 1
    }

    private const string DEFAULT_FILENAME = "contact_list";      // domyślna nazwa pliku do autozapisu

    public frmContactsModule() {
      InitializeComponent();

      mCurrentFile = null;

      mContactsListUtils = new cContactsListUtils();
      mEditor = new frmContactEditor();

      mDefaultFileType = FileTypesEnum.TXT;

    }

    #region Zdarzenia

    private void frmContactsModule_Load(object sender, EventArgs e) {

      OpenRecentFile();

      RefreshDataGridView();

    }

    private void tsmiSave_Click(object sender, EventArgs e) {

      SaveFile();

    }

    private void tsmiSaveAs_Click(object sender, EventArgs e) {

      SaveFileAs();

    }

    private void tsmiOpen_Click(object sender, EventArgs e) {

      OpenFile();

    }

    private void tsmiNew_Click(object sender, EventArgs e) {

      ClearList();

    }

    private void tsmiAbout_Click(object sender, EventArgs e) {

      ShowAboutInfo();

    }

    private void frmContactsModule_FormClosed(object sender, FormClosedEventArgs e) {

      SaveRecentFile();

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

      cContact pContact = mContactsListUtils.Contacts[dgvContacts.SelectedRows[0].Index];

      EditContact();

    }

    private void dgvContacts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

      SortList((SortTypeEnum)e.ColumnIndex);

    }

    #endregion

    #region Metody

    internal bool ShowMe() {
      //funkcja wywołująca formularz

      this.ShowDialog();

      return true;

    }

    public void DeleteContact() {
      //funkcja obsługująca usuwanie kontaktu

      mContactsListUtils.DeleteContact(dgvContacts.SelectedRows[0].Index);

      RefreshDataGridView();

      AutoSave();
    }

    public void AddContact() {
      //funkcja obsługująca dodawanie kontaktu

      cContact pContact = new cContact();

      if (!mEditor.ShowMe(pContact))
        return;

      mContactsListUtils.AddContact(pContact);

      RefreshDataGridView();

      AutoSave();

    }

    public void EditContact() {
      //funkcja obsługująca edycję kontaktu

      cContact pContact = mContactsListUtils.Contacts[dgvContacts.SelectedRows[0].Index];

      if (mEditor.ShowMe(pContact))
        RefreshDataGridView();

      AutoSave();

    }

    public void RefreshDataGridView() {
      //funkcja odświeżająca DataGridView oraz przyciski Edytuj / Usuń

      dgvContacts.DataSource = mContactsListUtils.Contacts;


      DataGridViewColumn pDgvColumnSurname = dgvContacts.Columns["Surname"];
      DataGridViewColumn pDgvColumnName = dgvContacts.Columns["Name"];
      DataGridViewColumn pDgvColumnPhone = dgvContacts.Columns["Phone"];

      pDgvColumnName.HeaderText = "Imię";
      pDgvColumnSurname.HeaderText = "Nazwisko";
      pDgvColumnPhone.HeaderText = "Telefon";
      pDgvColumnSurname.Width = 215;
      pDgvColumnName.Width = 215;
      pDgvColumnPhone.Width = 147;

      if (mContactsListUtils.Contacts.Count == 0) {
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
      } else {
        btnEdit.Enabled = true;
        btnDelete.Enabled = true;
      }

      dgvContacts.Refresh();

    }

    private void ShowAboutInfo() {
      //funkcja wyświetlająca okienko z informacjami o proramie

      MessageBox.Show("ConBook - Nikodem Przbyszewski 2023\n\n" +
        "Oprogramowanie: Visual Studio 2022 (.NET Framework 64-bit)\n" +
        "Ikona: Icongeek26 @ flaticon.com", "ConBook v1.2", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

    }

    private void ClearList() {
      //funkcja tworząca nową listę

      DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
        "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      switch (pSaveQueryResult) {
        case DialogResult.Yes:
          SaveFile();
          mContactsListUtils.Contacts.Clear();
          RefreshDataGridView();
          mCurrentFile = null;
          break;
        case DialogResult.No:
          mContactsListUtils.Contacts.Clear();
          RefreshDataGridView();
          mCurrentFile = null;
          break;
      }

    }

    private void SaveRecentFile() {
      //funkcja zapsiująca ostatnio otwartą listę kontaktów do pliku "recent"

      if (mCurrentFile != string.Empty && mCurrentFile != null) {
        using (StreamWriter pStreamWriter = new StreamWriter("recent")) {
          pStreamWriter.Write(mCurrentFile);
        }
      }

    }

    private void OpenRecentFile() {
      //funkcja automatycznie wczytująca ostatnio edytowaną listę kontaktów

      string pPath = Directory.GetCurrentDirectory();
      string? pFile = Directory.EnumerateFiles(pPath, "*.xml").FirstOrDefault();

      if (File.Exists("recent")) {
        using (StreamReader pStreamReader = new StreamReader("recent")) {
          string pFileTmp = pStreamReader.ReadToEnd();

          if (File.Exists(pFileTmp) && pFileTmp != string.Empty && pFileTmp != null) {
            pFile = pFileTmp;
          }

          try {
            if (pFile != string.Empty && pFile != null) {
              if (Path.GetExtension(pFile) == ".xml") {
                mContactsListUtils.Contacts = mContactsListUtils.Serializer.LoadXmlFile(pFile);
              } else {
                mContactsListUtils.Contacts = mContactsListUtils.Serializer.LoadTxtFile(pFile);
              }
              mCurrentFile = pFile;
            }
          } catch (Exception ex) {
            MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

          }
        }
      } else if (pFile != string.Empty && pFile != null) {
        try {
          mContactsListUtils.Serializer.LoadXmlFile(pFile);
          mCurrentFile = pFile;
        } catch (Exception ex) {
          MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }

    }

    private void OpenFile() {
      //funkcja obsługująca otwieranie plików

      try {
        OpenFileDialog OpenFileDialog = new OpenFileDialog() {
          Filter = "Wszystkie pliki (*.*)|*.*|Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
          Title = "Otwórz..."
        };
        if (OpenFileDialog.ShowDialog() == DialogResult.OK) {
          string pFileName = OpenFileDialog.FileName;
          string pFileExtension = Path.GetExtension(pFileName);

          if (pFileExtension == ".xml") {
            mContactsListUtils.Contacts.Clear();
            mContactsListUtils.Contacts = mContactsListUtils.Serializer.LoadXmlFile(pFileName);
          } else if (pFileExtension == ".txt") {
            mContactsListUtils.Contacts.Clear();
            mContactsListUtils.Contacts = mContactsListUtils.Serializer.LoadTxtFile(pFileName);
          } else {
            MessageBox.Show("Nieobsługiwany format pliku.", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }

          mCurrentFile = pFileName;
          RefreshDataGridView();
        }
      } catch (Exception ex) {
        MessageBox.Show($"Podczas wczytywania wystąpił błąd: \n {ex.Message}", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

    }

    private void SaveFileAs() {
      //funkcja obsługująca zapis do nowego pliku

      if (mContactsListUtils.Contacts.Count > 0) {
        try {
          SaveFileDialog SaveFileDialog = new SaveFileDialog() {
            Filter = "Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
            Title = "Zapisz jako..."
          };
          if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
            string fileName = SaveFileDialog.FileName;
            string fileExtension = Path.GetExtension(fileName);

            if (fileExtension == ".xml") {
              mContactsListUtils.Serializer.SaveToNewXmlFile(fileName, mContactsListUtils.Contacts, ref mCurrentFile);
            } else if (fileExtension == ".txt") {
              mContactsListUtils.Serializer.SaveToNewTxtFile(fileName, mContactsListUtils.Contacts, ref mCurrentFile);
            } else {
              MessageBox.Show("Nieobsługiwany format pliku.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
      } else {
        MessageBox.Show("Nie można zapisać pustej listy.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

    }

    private void SaveFile() {
      //funkcja obsługująca zapis do istniejącego pliku

      try {
        if (mContactsListUtils.Contacts.Count > 0) {
          if (mCurrentFile != null) {
            if (Path.GetExtension(mCurrentFile) == ".xml") {
              mContactsListUtils.Serializer.SaveToExistingXmlFile(mCurrentFile, mContactsListUtils.Contacts);
            } else {
              mContactsListUtils.Serializer.SaveToExistingTxtFile(mCurrentFile, mContactsListUtils.Contacts);
            }
          } else {
            SaveFileAs();
          }
        } else {
          MessageBox.Show("Nie można zapisać pustej listy.", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void AutoSave() {
      // funkcja automatycznie zapisująca listę po zmianie jej stanu

      if (mCurrentFile == null) {
        string pExt = mDefaultFileType.ToString().ToLower();

        mContactsListUtils.Serializer.SaveToNewTxtFile(DEFAULT_FILENAME + "." + pExt, mContactsListUtils.Contacts);
        mCurrentFile = DEFAULT_FILENAME + "." + pExt;
      } else {
        SaveFile();
      }

    }

    private void SortList(SortTypeEnum xCntSortType) {
      //funkcja sortująca listę kontaktów
      //xSortType - typ sortowania (byName, bySurname)

      if (xCntSortType == SortTypeEnum.ByName) {
        if (mContactsListUtils.Contacts.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactsListUtils.Contacts);

          pTempContactList.Sort(new cContact.NamesComparer());
          mContactsListUtils.Contacts = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();
        }
      } else if (xCntSortType == SortTypeEnum.bySurname) {
        if (mContactsListUtils.Contacts.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactsListUtils.Contacts);
          pTempContactList.Sort();
          mContactsListUtils.Contacts = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();
        }
      }

    }

  }
  #endregion

}
