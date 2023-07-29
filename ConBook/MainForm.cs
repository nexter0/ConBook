using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ConBook {
  public partial class MainForm : Form {

    public BindingList<cContact> mContacts;               // Lista kontaktów
    private string? mCurrentFile;                         // Ścieżka pliku, w którym zapisana jest otwarta lista

    private cContactListUtils mContactListUtils;          // Klasa mContactListUtils - do operacji na kontaktach
    private cContactSerializer mContactSerializer;        // Klasa mContactSerializer - do zapisu i odczytu plików

    public MainForm() {

      InitializeComponent();

      mCurrentFile = null;
      mContacts = new BindingList<cContact>();

      mContactListUtils = new cContactListUtils();
      mContactSerializer = new cContactSerializer();

    }

    // *****************************
    // *          Zdarzenia        *
    // *****************************

    private void MainForm_Load(object sender, EventArgs e) {

      OpenRecentFile();

      RefreshDataGridView();

    }


    private void tsmiSort_Click(object sender, EventArgs e) {

      tak, wyrzuć sortowanie za pomoca przycisku, ono jest totalnie niepraktyczne i daj mozliwosc sortowania klikajac na kolumne

      SortList(0); // TO DO: USUNĄĆ LUB PRZEROBIĆ PRZYCISK DO SORTOWANIA W MENU

    }

    private void tsmiSave_Click(object sender, EventArgs e) {

      usuń konieczność ręcznego zapisu danych przez użytkownika, to jest bardzo niepraktyczne
        dane mają się wczytywać od razu po odpalniu programu
        typ pliku ktory program wykorzystuje możesz rozwiązac na szytwno w kodzie
        ale w taki sposbo, zeby latwo go mozna bylo zmienic
        np. jesli wprowadzisz pole mFileTyp_Data
        to jesli stworzysz numerator npo Enum FileType_DataEnum{ CSV, txt, ... }
       to jesli przed kompilacją dasz mi mozliwość wyboru np. mFileType_Data = FileType_DataEnum.CSV
        to będzie super

      SaveFileAction();

    }

    private void tsmiSaveAs_Click(object sender, EventArgs e) {

      SaveFileAsAction();

    }

    private void tsmiOpen_Click(object sender, EventArgs e) {

      OpenFileAction();

    }

    private void tsmiNew_Click(object sender, EventArgs e) {

      ClearList();

    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {

      SaveOnClose(e);

    }

    private void tsmiAbout_Click(object sender, EventArgs e) {

      ShowAboutInfo();

    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {

      SaveRecentFile();

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      frmContactEditor pContactEditor = new frmContactEditor(mContacts);


      pContactEditor.DataFormClosed += DataForm_DataFormClosed;

      pContactEditor.ShowDialog();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      DeleteContact();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      frmContactEditor pContactEditor = new frmContactEditor(mContacts, true, dgvContacts.SelectedRows[0].Index);

      pContactEditor.DataFormClosed += DataForm_DataFormClosed;

      pContactEditor.ShowDialog();

    }

    private void dgvContacts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

      SortList(e.ColumnIndex);

    }

    private void DataForm_DataFormClosed(object sender, EventArgs e) {

      RefreshDataGridView();

    }

    // *****************************
    // *          Metody           *
    // *****************************

    public void DeleteContact() {
      //funkcja obsługująca usuwanie kontaktu z listy

      mContactListUtils.DeleteContact(mContacts, dgvContacts.SelectedRows[0].Index);

      RefreshDataGridView();

    }

    public void RefreshDataGridView() {
      //funkcja odświeżająca DataGridView oraz przyciski Edytuj / Usuń

      dgvContacts.DataSource = null;
      dgvContacts.DataSource = mContacts;


      DataGridViewColumn pDgvColumnSurname = dgvContacts.Columns["Surname"];
      DataGridViewColumn pDgvColumnName = dgvContacts.Columns["Name"];
      DataGridViewColumn pDgvColumnPhone = dgvContacts.Columns["Phone"];

      pDgvColumnName.HeaderText = "Imię";
      pDgvColumnSurname.HeaderText = "Nazwisko";
      pDgvColumnPhone.HeaderText = "Telefon";
      pDgvColumnSurname.Width = 215;
      pDgvColumnName.Width = 215;
      pDgvColumnPhone.Width = 147;

      if (mContacts.Count == 0) {
        btnEdit.Enabled = false;
        btnDelete.Enabled = false;
      } else {
        btnEdit.Enabled = true;
        btnDelete.Enabled = true;
      }

      dgvContacts.Refresh();

    }

    private void SaveOnClose(FormClosingEventArgs e) {
      // funkcja wyświetlająca dialog zapisu przy zamknięciu programu

      DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
    "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      switch (pSaveQueryResult) {

        case DialogResult.Yes: {

            SaveFileAction();
            break;

          }
        case DialogResult.No: {

            break;

          }
        default: {

            e.Cancel = true;
            break;

          }
      }

    }

    private void ShowAboutInfo() {
      //funkcja wyświetlająca okienko z informacjami o proramie

      MessageBox.Show("ConBook - Nikodem Przbyszewski 2023\n\n" +
        "Oprogramowanie: Visual Studio 2022 (.NET Framework 64-bit)\n" +
        "Ikona: Icongeek26 @ flaticon.com", "ConBook v1.0", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

    }

    private void ClearList() {
      //funkcja tworząca nową listę


      DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
        "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      switch (pSaveQueryResult) {
        case DialogResult.Yes: {
            SaveFileAction();
            mContacts.Clear();
            RefreshDataGridView();
            mCurrentFile = null;
            break;
          }
        case DialogResult.No: {
            mContacts.Clear();
            RefreshDataGridView();
            mCurrentFile = null;
            break;
          }
      }

    }

    private void SaveRecentFile() {
      // funkcja zapsiująca ostatnio otwartą listę kontaktów do pliku "recent"

      if (mCurrentFile != string.Empty && mCurrentFile != null) {
        using (StreamWriter pStreamWriter = new StreamWriter("recent")) {
          pStreamWriter.Write(mCurrentFile);
        }
      }

    }

    private void OpenRecentFile() {
      // funkcja automatycznie wczytująca ostatnio edytowaną listę kontaktów

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
                mContacts = mContactSerializer.LoadXmlFile(pFile);
              } else {
                mContacts = mContactSerializer.LoadTxtFile(pFile);
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

          mContactSerializer.LoadXmlFile(pFile);
          mCurrentFile = pFile;

        } catch (Exception ex) {

          MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }

    }

    private void OpenFileAction() {
      // funkcja obsługująca otwieranie plików

      try {

        OpenFileDialog OpenFileDialog = new OpenFileDialog() {

          Filter = "Wszystkie pliki (*.*)|*.*|Plik CSV (rozdzielany przecinkami) (*.csv)|*.csv|Plik TSV (rozdzielany znakiem tabulacji) (*.tsv)|*.tsv|Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
          Title = "Otwórz..."

        };

        if (OpenFileDialog.ShowDialog() == DialogResult.OK) {

          string pFileName = OpenFileDialog.FileName;
          string pFileExtension = Path.GetExtension(pFileName);

          if (pFileExtension == ".xml") {

            mContacts.Clear();
            mContacts = mContactSerializer.LoadXmlFile(pFileName);

          } else if (pFileExtension == ".txt" || pFileExtension == ".tsv" || pFileExtension == ".csv") {

            mContacts.Clear();
            mContacts = mContactSerializer.LoadTxtFile(pFileName);

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

    private void SaveFileAsAction() {
      // funkcja obsługująca zapis do nowego pliku


      if (mContacts.Count > 0) {
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

              mContactSerializer.SaveToNewXmlFile(fileName, mContacts, ref mCurrentFile);

            } else if (fileExtension == ".txt" || fileExtension == ".tsv" || fileExtension == ".csv") {

              mContactSerializer.SaveToNewTxtFile(fileName, mContacts, ref mCurrentFile);

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

    private void SaveFileAction() {
      // funkcja obsługująca zapis do istniejącego pliku

      try {
        if (mContacts.Count > 0) {

          if (mCurrentFile != null) {

            if (Path.GetExtension(mCurrentFile) == ".xml") {

              mContactSerializer.SaveToExistingXmlFile(mCurrentFile, mContacts);

            } else {

              mContactSerializer.SaveToExistingTxtFile(mCurrentFile, mContacts);

            }

          } else {

            SaveFileAsAction();

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

    private void SortList(int xSortTypeId) {
      // funkcja sortująca listę kontaktów

      if (xSortTypeId == 0) {

        if (mContacts.Count > 0) {

          List<cContact> pTempContactList = new List<cContact>(mContacts);
          pTempContactList.Sort(new cContact.NamesComparer());
          mContacts = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();

        }

      } else if (xSortTypeId == 1) {

        if (mContacts.Count > 0) {

          List<cContact> pTempContactList = new List<cContact>(mContacts);
          pTempContactList.Sort();
          mContacts = new BindingList<cContact>(pTempContactList);

          RefreshDataGridView();

        }

      }

    }

  }
}
