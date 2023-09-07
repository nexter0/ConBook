namespace ConBook {
  public partial class frmProductsModule : Form {

    private cProductListUtils mProductListUtils;
    private string? mCurrentFile;
    private const string DEFAULT_FILENAME = "product_list";

    public frmProductsModule() {
      InitializeComponent();

      mProductListUtils = new cProductListUtils();

      BindDataGridView();

    }

    #region Events

    private void btnAdd_Click(object sender, EventArgs e) {

      mProductListUtils.AddProduct();

      AutoSave();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      if (mProductListUtils.ProductsList.Count > 0)
        mProductListUtils.EditProduct(dgvProducts.SelectedRows[0].Index);

      AutoSave();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      mProductListUtils.DeleteProduct(dgvProducts.SelectedRows[0].Index);

      AutoSave();

    }

    private void frmProductsModule_Load(object sender, EventArgs e) {

      OpenRecentFile();

    }

    private void frmProductsModule_FormClosing(object sender, FormClosingEventArgs e) {

      AutoSave();
      SaveRecentFile();

    }

    private void tsmiOpen_Click(object sender, EventArgs e) {

      OpenFile();

    }

    private void tsmiNew_Click(object sender, EventArgs e) {

      ClearList();

    }

    private void tsmiSave_Click(object sender, EventArgs e) {

      SaveFile();

    }

    private void tsmiSaveAs_Click(object sender, EventArgs e) {

      SaveFileAs();

    }

    #endregion

    internal bool ShowMe() {
      //funkcja wywołująca formularz

      this.ShowDialog();
      return true;
    }

    private void ConfigureDataGridView() {

      DataGridViewColumn pDgvColumnName = dgvProducts.Columns["Name"];
      DataGridViewColumn pDgvColumnSymbol = dgvProducts.Columns["Symbol"];
      DataGridViewColumn pDgvColumnPrice = dgvProducts.Columns["Price"];
      DataGridViewColumn pDgvColumnIndex = dgvProducts.Columns["Index"];

      pDgvColumnName.HeaderText = "Nazwa";
      pDgvColumnSymbol.HeaderText = "Symbol";
      pDgvColumnPrice.HeaderText = "Cena";
      pDgvColumnIndex.HeaderText = "Indeks";

      pDgvColumnName.Width = 457;
      pDgvColumnSymbol.Width = 158;
      pDgvColumnPrice.Width = 158;
      pDgvColumnIndex.Width = 50;

    }

    private void AutoSave() {
      // funkcja do automatycznego zapisu listy

      if (mCurrentFile == null) {
        string pExt = "txt";

        cProductSerializer.SaveToNewTxtFile(DEFAULT_FILENAME + "." + pExt, mProductListUtils.ProductsList);
        mCurrentFile = DEFAULT_FILENAME + "." + pExt;
      } else {
        SaveFile();
      }


    }

    private void SaveFile() {
      //funkcja obsługująca zapis do istniejącego pliku

      try {
        if (mProductListUtils.ProductsList.Count > 0) {
          if (mCurrentFile != null) {
            cProductSerializer.SaveToExistingTxtFile(mCurrentFile, mProductListUtils.ProductsList);
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

    private void SaveFileAs() {
      //funkcja obsługująca zapis do nowego pliku

      if (mProductListUtils.ProductsList.Count > 0) {
        try {
          SaveFileDialog SaveFileDialog = new SaveFileDialog() {
            Filter = "Plik tekstowy (*.txt)|*.txt|Dokument XML (*.xml)|*.xml",
            Title = "Zapisz jako..."
          };
          if (SaveFileDialog.ShowDialog() == DialogResult.OK) {
            string fileName = SaveFileDialog.FileName;
            string fileExtension = Path.GetExtension(fileName);

            if (fileExtension == ".txt") {
              cProductSerializer.SaveToNewTxtFile(fileName, mProductListUtils.ProductsList, ref mCurrentFile);
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

    private void SaveRecentFile() {
      //funkcja zapsiująca ostatnio otwartą listę kontaktów do pliku "recent"

      if (mCurrentFile != string.Empty && mCurrentFile != null) {
        using (StreamWriter pStreamWriter = new StreamWriter("recent_prod")) {
          pStreamWriter.Write(mCurrentFile);
        }
      }

    }

    private void OpenRecentFile() {
      //funkcja automatycznie wczytująca ostatnio edytowaną listę kontaktów

      string pPath = Directory.GetCurrentDirectory();
      string? pFile = null;

      if (File.Exists("recent_prod")) {
        using (StreamReader pStreamReader = new StreamReader("recent_prod")) {
          string pFileTmp = pStreamReader.ReadToEnd();

          if (File.Exists(pFileTmp) && pFileTmp != string.Empty && pFileTmp != null) {
            pFile = pFileTmp;
          }

          try {
            if (pFile != string.Empty && pFile != null) {
              mProductListUtils.ProductsList = cProductSerializer.LoadTxtFile(pFile);

              mCurrentFile = pFile;
            }
          } catch (Exception ex) {
            MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

          }
        }
      } else if (pFile != string.Empty && pFile != null) {
        try {
          cProductSerializer.LoadTxtFile(pFile);
          mCurrentFile = pFile;
        } catch (Exception ex) {
          MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pFile}", "Błąd wczytywania",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }

      BindDataGridView();

    }

    private void OpenFile() {
      //funkcja obsługująca otwieranie plików

      try {
        OpenFileDialog OpenFileDialog = new OpenFileDialog() {
          Filter = "Wszystkie pliki (*.*)|*.*|Plik tekstowy (*.txt)|*.txt",
          Title = "Otwórz..."
        };
        if (OpenFileDialog.ShowDialog() == DialogResult.OK) {
          string pFileName = OpenFileDialog.FileName;
          string pFileExtension = Path.GetExtension(pFileName);

          if (pFileExtension == ".txt") {
            mProductListUtils.ProductsList.Clear();
            mProductListUtils.ProductsList = cProductSerializer.LoadTxtFile(pFileName);
          } else {
            MessageBox.Show("Nieobsługiwany format pliku.", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }

          mCurrentFile = pFileName;
        }
      } catch (Exception ex) {
        MessageBox.Show($"Podczas wczytywania wystąpił błąd: \n {ex.Message}", "Błąd wczytywania", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      BindDataGridView();

    }

    private void ClearList() {
      //funkcja tworząca nową listę

      DialogResult pSaveQueryResult = MessageBox.Show("Niezapisane zmiany zostaną utracone. \nCzy chcesz zapisać teraz?",
        "Zapisz zmiany", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      switch (pSaveQueryResult) {
        case DialogResult.Yes:
          SaveFile();
          mProductListUtils.ProductsList.Clear();
          mCurrentFile = null;
          break;
        case DialogResult.No:
          mProductListUtils.ProductsList.Clear();
          mCurrentFile = null;
          break;
      }

    }

    private void BindDataGridView() {
      //funkcja bindująca data grid view z listą kontaktów

      dgvProducts.DataSource = null;
      dgvProducts.DataSource = mProductListUtils.ProductsList;
      ConfigureDataGridView();

    }
  }
}
