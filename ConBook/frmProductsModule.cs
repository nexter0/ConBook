namespace ConBook {
  public partial class frmProductsModule : Form {

    private cProductListUtils mProductListUtils;

    public frmProductsModule() {
      InitializeComponent();

      mProductListUtils = new cProductListUtils();

      BindDataGridView();

    }

    #region Events

    private void btnAdd_Click(object sender, EventArgs e) {

      mProductListUtils.AddProduct();

      SaveProducts();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      if (mProductListUtils.ProductsList.Count > 0)
        mProductListUtils.EditProduct(dgvProducts.SelectedRows[0].Index);

      SaveProducts();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      if (mProductListUtils.ProductsList.Count > 0)
        mProductListUtils.DeleteProduct(dgvProducts.SelectedRows[0].Index);

      SaveProducts();

    }

    private void frmProductsModule_Load(object sender, EventArgs e) {

      LoadProducts();

    }

    private void frmProductsModule_FormClosing(object sender, FormClosingEventArgs e) {

      SaveProducts();

    }

    private void frmProductsModule_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {
        this.Close();
      }

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

    private void SaveProducts() {
      // funkcja do automatycznego zapisu kolekcji produktów

      string pDefaultFilePath = cProductsSerializer.DEFAULT_SAVE_FILE_PATH;

      if (!File.Exists(pDefaultFilePath)) {
        cProductsSerializer.SaveToNewTxtFile(pDefaultFilePath, mProductListUtils.ProductsList);
      } else {
        SaveToFile();
      }


    }

    private void SaveToFile() {
      //funkcja obsługująca zapis do istniejącego pliku

      string pDefaultFilePath = cProductsSerializer.DEFAULT_SAVE_FILE_PATH;

      try {
        if (mProductListUtils.ProductsList.Count > 0) {
          if (File.Exists(pDefaultFilePath))
            cProductsSerializer.SaveToExistingTxtFile(pDefaultFilePath, mProductListUtils.ProductsList);
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

    private void LoadProducts() {
      //funkcja wczytująca kolekcję produktów z pliku

      string pDefaultFilePath = cProductsSerializer.DEFAULT_SAVE_FILE_PATH;

      try {
        if (File.Exists(pDefaultFilePath)) {
          mProductListUtils.ProductsList = cProductsSerializer.GetProductsList();
        }
      } catch (Exception ex) {
        MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pDefaultFilePath}", "Błąd wczytywania",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

      }

      BindDataGridView();

    }

    private void BindDataGridView() {
      //funkcja bindująca data grid view z kolekcją produktów

      dgvProducts.DataSource = null;
      dgvProducts.DataSource = mProductListUtils.ProductsList;
      ConfigureDataGridView();

    }

  }
}
