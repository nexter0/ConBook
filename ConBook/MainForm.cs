namespace ConBook {
  public partial class MainForm : Form {

    public MainForm() {

      InitializeComponent();

      ConnectWithDataBase();

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

    private void ConnectWithDataBase() {

      cDataBaseService pDataBaseService = new cDataBaseService();
      var pConnectionResult = pDataBaseService.TestConnection();

      if (pConnectionResult == null) {

        lbDataBaseStatus.Text = "Pomyślnie połączono z bazą danych";
        lbDataBaseStatus.ForeColor = Color.Green;
      } else {
        lbDataBaseStatus.Text = $"Błąd bazy danych: {pConnectionResult.Message}";
        lbDataBaseStatus.ForeColor = Color.Red;
      }

    }

    private void tsbCreateDataBase_Click(object sender, EventArgs e) {
      cDataBaseService pDataBaseSerivce = new cDataBaseService();

      pDataBaseSerivce.CreateDBTables();
      pDataBaseSerivce.TestConnection();

    }
  }
}
