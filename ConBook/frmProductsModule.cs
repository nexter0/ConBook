namespace ConBook {
  public partial class frmProductsModule : Form {

    private cProductListUtils mProductListUtils;

    private const string DEFAULT_FILE_PATH = cProductSerializer.DEFAULT_SAVE_FILE_PATH;

    public frmProductsModule() {
      InitializeComponent();

      mProductListUtils = new cProductListUtils();

      BindDataGridView();

    }

    #region Events

    private void btnAdd_Click(object sender, EventArgs e) {

      mProductListUtils.AddProduct();

      SaveList();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      if (mProductListUtils.ProductsList.Count > 0)
        mProductListUtils.EditProduct(dgvProducts.SelectedRows[0].Index);

      SaveList();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      mProductListUtils.DeleteProduct(dgvProducts.SelectedRows[0].Index);

      SaveList();

    }

    private void frmProductsModule_Load(object sender, EventArgs e) {

      LoadList();

    }

    private void frmProductsModule_FormClosing(object sender, FormClosingEventArgs e) {

      SaveList();

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

    private void SaveList() {
      // funkcja do automatycznego zapisu listy

      if (!File.Exists(DEFAULT_FILE_PATH)) {
        cProductSerializer.SaveToNewTxtFile(DEFAULT_FILE_PATH, mProductListUtils.ProductsList);
      } else {
        SaveToFile();
      }


    }

    private void SaveToFile() {
      //funkcja obsługująca zapis do istniejącego pliku

      try {
        if (mProductListUtils.ProductsList.Count > 0) {
          if (File.Exists(DEFAULT_FILE_PATH))
            cProductSerializer.SaveToExistingTxtFile(DEFAULT_FILE_PATH, mProductListUtils.ProductsList);
        }
      } 
      catch (Exception ex) {
        if (ex.InnerException != null) {
          Exception pInnerException = ex.InnerException;
          string pMessage = "Błąd: \n" + pInnerException.Message + "\n"
              + "InnerException StackTrace: \n" + pInnerException.StackTrace;

          MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 
        else {
          string pMessage = "Błąd: \n" + ex.Message + "\n"
              + "StackTrace: \n" + ex.StackTrace;

          MessageBox.Show(pMessage, "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }

    }

    private void LoadList() {
      //funkcja wczytująca listę produktów

      try {
        if (File.Exists(DEFAULT_FILE_PATH)) {
          mProductListUtils.ProductsList = cProductSerializer.LoadTxtFile(DEFAULT_FILE_PATH);
        }
      } catch (Exception ex) {
        MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {DEFAULT_FILE_PATH}", "Błąd wczytywania",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

      }

      BindDataGridView();

    }

    private void BindDataGridView() {
      //funkcja bindująca data grid view z listą kontaktów

      dgvProducts.DataSource = null;
      dgvProducts.DataSource = mProductListUtils.ProductsList;
      ConfigureDataGridView();

    }
  }
}
