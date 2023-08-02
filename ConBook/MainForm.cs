using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace ConBook {
  public partial class MainForm : Form {
    wydaje się, że cContactListUtils jest tutaj zbędna bo nic szczególnego nie robi
    zalecam jednak żeby ją zostawić i wpakować do niej ContactSerializer oraz mContacts
    przy czym wtedy do serializera mozesz robic dostęp w stylu ContactListUtils.Serializer
    takie rzeczy dojrzewają poźniej, gdy kod się rozrasta

    private cContactListUtils mContactListUtils;                 // Klasa mContactListUtils - do operacji na kontaktach
    private cContactSerializer mContactSerializer;               // Klasa mContactSerializer - do zapisu i odczytu plików
    private frmContactEditor mEditor;                            // Klasa frmContactEditor - okienko dodawania / edycji kontaktów

    public BindingList<cContact> mContacts;                      // Lista kontaktów
    private string? mCurrentFile;                                // Ścieżka pliku, w którym zapisana jest otwarta lista
    private cContactSerializer.mFileTypes mDefaultFileType;      // Domyślny typ pliku autozapisu



    public MainForm() {

      InitializeComponent();

      mCurrentFile = null;
      mContacts = new BindingList<cContact>();

      mContactListUtils = new cContactListUtils();
      mContactSerializer = new cContactSerializer();
      mEditor = new frmContactEditor();


      mDefaultFileType = cContactSerializer.mFileTypes.CSV;

    }

    // *****************************
    // *          Zdarzenia        *
    // *****************************

    private void MainForm_Load(object sender, EventArgs e) {

      OpenRecentFile();

      RefreshDataGridView();

    }

    private void tsmiSave_Click(object sender, EventArgs e) {

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

    private void tsmiAbout_Click(object sender, EventArgs e) {

      ShowAboutInfo();

    }

    private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {

      SaveRecentFile();

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      AddAction();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      DeleteContact();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      EditAction();

    }

    private void dgvContacts_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {

      SortList(e.ColumnIndex);

    }
    
    formatuję kod w tej klasie i proszę przyjrzyj się co jest formatowane i staraj się potem to zastosować 

    // *****************************
    // *          Metody           *
    // *****************************

    public void DeleteContact() {
      //funkcja obsługująca usuwanie kontaktu z listy

      mContactListUtils.DeleteContact(mContacts, dgvContacts.SelectedRows[0].Index);

      RefreshDataGridView();

      AutoSave();

    }

    funkcja ma złą nazwę, ona musi oddawać to, co robi, jeśli ten formularz bedzie dodawał jeszcze jakis inny obiekt, to bedziesz miał balagan
      funkcja powinna po prostu nazywac sie AddContact
    public void AddAction() {
      //funkcja obsługująca usuwanie kontaktu z listy

      //jeśli w funkcji jest mało zmiennych i jest krótka, to zalecałbym unikanie sufiksow lub prefiksow 
      //tutaj wystarczy po procstu pContact
      //gdyby funkcja była większa i wystąpiłyby inne obiekty konaktu, wtedy obowiązkowo prefiks lub sufiks

      cContact pNewContact = new cContact();

      if (!mEditor.ShowMe(pNewContact))
        return;

      mContactListUtils.AddContact(pNewContact, mContacts);

      RefreshDataGridView();
      
      AutoSave();

    }

    zła nazwa funkcji
    public void EditAction() {
      //funkcja obsługująca usuwanie kontaktu z listy

      cContact pContact = mContacts[dgvContacts.SelectedRows[0].Index];

      if (mEditor.ShowMe(pContact))
        RefreshDataGridView();

      AutoSave();

    }

    public void RefreshDataGridView() {
      //funkcja odświeżająca DataGridView oraz przyciski Edytuj / Usuń

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
          SaveFileAction();
          mContacts.Clear();
          RefreshDataGridView();
          mCurrentFile = null;
          break;
        case DialogResult.No: 
          mContacts.Clear();
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

    wywal dopisek action z naz. funkcji
    private void OpenFileAction() {
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
      //funkcja obsługująca zapis do nowego pliku

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

    wywal słowo Action z nazwy funkcji
    private void SaveFileAction() {
      //funkcja obsługująca zapis do istniejącego pliku

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

    private void AutoSave() {
      brak opisu funkcji

      if (mCurrentFile == null) {
        string pExt = mDefaultFileType.ToString().ToLower();
        mContactSerializer.SaveToNewTxtFile("conctact_list." + pExt, mContacts);
        mCurrentFile = "conctact_list." + pExt;
      } else {
        SaveFileAction();
      }

    }

    xSortTypeId nie moze byc int-em. zrob numerator do tego parametru, który bedzie czytelny
    private void SortList(int xSortTypeId) {
      //funkcja sortująca listę kontaktów

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
