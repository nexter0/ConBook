using System.ComponentModel;

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

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      if (mProductListUtils.ProductsList.Count > 0)
        mProductListUtils.EditProduct(dgvProducts.SelectedRows[0].Index);

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      if (mProductListUtils.ProductsList.Count > 0)
        mProductListUtils.DeleteProduct(dgvProducts.SelectedRows[0].Index);

    }

    private void frmProductsModule_Load(object sender, EventArgs e) {

      LoadProducts();

    }

    private void frmProductsModule_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {
        this.Close();
      }

    }

    private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
      if (e.RowIndex >= 0 && e.ColumnIndex == dgvProducts.Columns["Price"].Index) {

        e.Value = ((double)e.Value).ToString("C");

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

    private void LoadProducts() {
      //funkcja wczytująca kolekcję produktów z bazy danych

      cProduct_DAO pProduct_DAO = new cProduct_DAO();

      List<cProduct>? pProductsList = pProduct_DAO.GetProductsList();

      if (pProductsList != null)
        mProductListUtils.ProductsList = new BindingList<cProduct>(pProductsList);


      BindDataGridView();

    }

    private void BindDataGridView() {
      //funkcja bindująca data grid view z kolekcją produktów

      mProductListUtils.UpdateProductsList();

      dgvProducts.DataSource = null;
      dgvProducts.DataSource = mProductListUtils.ProductsList;
      ConfigureDataGridView();

    }
  }
}
