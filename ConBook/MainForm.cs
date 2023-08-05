using System.ComponentModel;

namespace ConBook {
  public partial class MainForm : Form {

    private cContactListUtils mContactListUtils;                 // Klasa mContactListUtils - do operacji na kontaktach
    private frmContactEditor mEditor;                            // Klasa frmContactEditor - okienko dodawania / edycji kontaktów

    private string? mCurrentFile;                                // Ścieżka pliku, w którym zapisana jest otwarta lista
    private FileTypes mDefaultFileType;                          // Domyślny typ pliku autozapisu
    private enum SortType { byName = 0, bySurname = 1 }          // Możliwe tryby sortowania listy kontaktów



    public MainForm() {

      InitializeComponent();

      mCurrentFile = null;

      mContactListUtils = new cContactListUtils();
      mEditor = new frmContactEditor();


      mDefaultFileType = FileTypes.CSV;

    }

    #region Zdarzenia

    private void MainForm_Load(object sender, EventArgs e) {

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

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {

      SaveRecentFile();

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      cContact pContact = new cContact();

      if (!mEditor.ShowMe(pContact))
        return;

      mContactListUtils.AddContact(pContact);

      RefreshDataGridView();

      AutoSave();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      mContactListUtils.DeleteContact(dgvContacts.SelectedRows[0].Index);

      RefreshDataGridView();

      AutoSave();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      cContact pContact = mContactListUtils.Contacts[dgvContacts.SelectedRows[0].Index];

      if (mEditor.ShowMe(pContact))
        RefreshDataGridView();

      AutoSave();

    }

    private void dgvContacts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

      SortList((SortType)e.ColumnIndex);

    }

    #endregion

    #region Metody

    public void DeleteContact() {
      //funkcja obsługująca usuwanie kontaktu z listy

      mContactListUtils.DeleteContact(dgvContacts.SelectedRows[0].Index);

      RefreshDataGridView();

      AutoSave();
    }

    public void AddContact() {
      //funkcja obsługująca usuwanie kontaktu z listy

      cContact pContact = new cContact();

      if (!mEditor.ShowMe(pContact))
        return;

      mContactListUtils.AddContact(pContact);

      RefreshDataGridView();

      AutoSave();

    }

    public void EditContact() {
      //funkcja obsługująca usuwanie kontaktu z listy

      cContact pContact = mContactListUtils.Contacts[dgvContacts.SelectedRows[0].Index];

      if (mEditor.ShowMe(pContact))
        RefreshDataGridView();

      AutoSave();

    }

    public void RefreshDataGridView() {
      //funkcja odświeżająca DataGridView oraz przyciski Edytuj / Usuń

      dgvContacts.DataSource = mContactListUtils.Contacts;


      DataGridViewColumn pDgvColumnSurname = dgvContacts.Columns["Surname"];
      DataGridViewColumn pDgvColumnName = dgvContacts.Columns["Name"];
      DataGridViewColumn pDgvColumnPhone = dgvContacts.Columns["Phone"];

      pDgvColumnName.HeaderText = "Imię";
      pDgvColumnSurname.HeaderText = "Nazwisko";
      pDgvColumnPhone.HeaderText = "Telefon";
      pDgvColumnSurname.Width = 215;
      pDgvColumnName.Width = 215;
      pDgvColumnPhone.Width = 147;

      if (mContactListUtils.Contacts.Count == 0) {
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
        "Ikona: Icongeek26 @ flaticon.com", "ConBook v1.1", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

    }

    private void ClearList() {
      //funkcja tworząca nową listę

      DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
        "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      switch (pSaveQueryResult) {
        case DialogResult.Yes:
          SaveFile();
          mContactListUtils.Contacts.Clear();
          RefreshDataGridView();
          mCurrentFile = null;
          break;
        case DialogResult.No:
          mContactListUtils.Contacts.Clear();
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
                mContactListUtils.Contacts = mContactListUtils.Serializer.LoadXmlFile(pFile);
              } else {
                mContactListUtils.Contacts = mContactListUtils.Serializer.LoadTxtFile(pFile);
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
          mContactListUtils.Serializer.LoadXmlFile(pFile);
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
          Filter = "Wszystkie pliki (*.*)|*.*|Plik CSV (rozdzielany przecinkami) (*.csv)|*.csv|Plik TSV (rozdzielany znakiem tabulacji) (*.tsv)|*.tsv|Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
          Title = "Otwórz..."
        };
        if (OpenFileDialog.ShowDialog() == DialogResult.OK) {
          string pFileName = OpenFileDialog.FileName;
          string pFileExtension = Path.GetExtension(pFileName);
          if (pFileExtension == ".xml") {
            mContactListUtils.Contacts.Clear();
            mContactListUtils.Contacts = mContactListUtils.Serializer.LoadXmlFile(pFileName);
          } else if (pFileExtension == ".txt" || pFileExtension == ".tsv" || pFileExtension == ".csv") {
            mContactListUtils.Contacts.Clear();
            mContactListUtils.Contacts = mContactListUtils.Serializer.LoadTxtFile(pFileName);
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

      if (mContactListUtils.Contacts.Count > 0) {
        try {
          SaveFileDialog SaveFileDialog = new SaveFileDialog() {
            Filter = "Plik CSV (rozdzielany przecinkami) (*.csv)|*.csv|Plik TSV (rozdzielany znakiem tabulacji) " +
              "(*.tsv)|*.tsv|Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
            Title = "Zapisz jako..."
          };
          if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
            string fileName = SaveFileDialog.FileName;
            string fileExtension = Path.GetExtension(fileName);
            if (fileExtension == ".xml") {
              mContactListUtils.Serializer.SaveToNewXmlFile(fileName, mContactListUtils.Contacts, ref mCurrentFile);
            } else if (fileExtension == ".txt" || fileExtension == ".tsv" || fileExtension == ".csv") {
              mContactListUtils.Serializer.SaveToNewTxtFile(fileName, mContactListUtils.Contacts, ref mCurrentFile);
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
        if (mContactListUtils.Contacts.Count > 0) {
          if (mCurrentFile != null) {
            if (Path.GetExtension(mCurrentFile) == ".xml") {
              mContactListUtils.Serializer.SaveToExistingXmlFile(mCurrentFile, mContactListUtils.Contacts);
            } else {
              mContactListUtils.Serializer.SaveToExistingTxtFile(mCurrentFile, mContactListUtils.Contacts);
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
        mContactListUtils.Serializer.SaveToNewTxtFile("conctact_list." + pExt, mContactListUtils.Contacts);
        mCurrentFile = "conctact_list." + pExt;
      } else {
        SaveFile();
      }

    }

    private void SortList(SortType xSortType) {
      //funkcja sortująca listę kontaktów

      if (xSortType == SortType.byName) {
        if (mContactListUtils.Contacts.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactListUtils.Contacts);
          pTempContactList.Sort(new cContact.NamesComparer());
          mContactListUtils.Contacts = new BindingList<cContact>(pTempContactList);
          RefreshDataGridView();
        }
      } else if (xSortType == SortType.bySurname) {
        if (mContactListUtils.Contacts.Count > 0) {
          List<cContact> pTempContactList = new List<cContact>(mContactListUtils.Contacts);
          pTempContactList.Sort();
          mContactListUtils.Contacts = new BindingList<cContact>(pTempContactList);
          RefreshDataGridView();
        }
      }

    }

  }
  #endregion

}
