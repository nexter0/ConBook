namespace ConBook {
  public partial class frmProductsModule : Form {

    private cProductListUtils mProductListUtils;

    public frmProductsModule() {
      InitializeComponent();

      mProductListUtils = new cProductListUtils();

      dgvProducts.DataSource = mProductListUtils.Products;
      ConfigureDataGridView();

      mProductListUtils.Products.Add(new cProduct("Test 1", "AA343", 458.59));
      mProductListUtils.Products.Add(new cProduct("Test 2", "DI230", 529.99));
      mProductListUtils.Products.Add(new cProduct("Test 3", "FD34F", 349.39));

    }

    private void btnAdd_Click(object sender, EventArgs e) {
      mProductListUtils.AddProduct();
    }

    private void btnEdit_Click(object sender, EventArgs e) {
      mProductListUtils.EditProduct(dgvProducts.SelectedRows[0].Index);
    }

    private void btnDelete_Click(object sender, EventArgs e) {

      mProductListUtils.DeleteProduct(dgvProducts.SelectedRows[0].Index);

    }

    internal bool ShowMe() {
      //funkcja wywołująca formularz

      this.ShowDialog();
      return true;
    }

    private void ConfigureDataGridView() {

      DataGridViewColumn pDgvColumnName = dgvProducts.Columns["Name"];
      DataGridViewColumn pDgvColumnSymbol = dgvProducts.Columns["Symbol"];
      DataGridViewColumn pDgvColumnPrice = dgvProducts.Columns["Price"];

      pDgvColumnName.HeaderText = "Nazwa";
      pDgvColumnSymbol.HeaderText = "Symbol";
      pDgvColumnPrice.HeaderText = "Cena";

      pDgvColumnName.Width = 457;
      pDgvColumnSymbol.Width = 158;
      pDgvColumnPrice.Width = 158;

    }
  }
}
