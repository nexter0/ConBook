namespace ConBook {
  public partial class MainForm : Form {

    public MainForm() {

      InitializeComponent();

    }

    private void btnContactsModule_Click(object sender, EventArgs e) {

      this.Visible = false;
      frmContactsModule mContactsModule = new frmContactsModule();
      mContactsModule.ShowMe();
      this.Visible = true;

    }

    private void btnProductsModule_Click(object sender, EventArgs e) {

      this.Visible = false;
      frmProductsModule mProductsModule = new frmProductsModule();
      mProductsModule.ShowMe();
      this.Visible = true;

    }

    private void btnOrdersModule_Click(object sender, EventArgs e) {

      this.Visible = false;
      frmOrdersModule frmOrdersModule = new frmOrdersModule();
      frmOrdersModule.ShowMe();
      this.Visible = true;

    }
  }
}
