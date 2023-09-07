namespace ConBook {
  public partial class frmOrdersModule : Form {

    private cOrdersListUtils mOrdersListUtils;

    public frmOrdersModule() {

      InitializeComponent();

      mOrdersListUtils = new cOrdersListUtils();

      BindDataGridView();

    }

    private void frmOrdersModule_Load(object sender, EventArgs e) {

    }

    internal bool ShowMe() {
      //funkcja wywołująca formularz

      this.ShowDialog();

      return true;

    }

    private void BindDataGridView() {
      //funkcja bindująca DataGridView z listą zamówień

      dgvOrders.DataSource = null;
      dgvOrders.DataSource = mOrdersListUtils.OrdersList;
      ConfigureDataGridView();

    }

    private void ConfigureDataGridView() {
      //funkcja kofigurująca DataGridView

      DataGridViewColumn pDgvColumnNumber = dgvOrders.Columns["OrderNumber"];
      DataGridViewColumn pDgvColumnDate = dgvOrders.Columns["CreationDate"];
      DataGridViewColumn pDgvColumnIndex = dgvOrders.Columns["Index"];
      DataGridViewColumn pDgvColumnClient = dgvOrders.Columns["IdxContact"];

      pDgvColumnNumber.HeaderText = "Numer zamówienia";
      pDgvColumnDate.HeaderText = "Data utworzenia";
      pDgvColumnIndex.HeaderText = "Indeks";
      pDgvColumnClient.HeaderText = "Klient";

      pDgvColumnNumber.Width = 250;
      pDgvColumnDate.Width = 250;
      pDgvColumnIndex.Width = 50;
      pDgvColumnClient.Width = 73;

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      mOrdersListUtils.AddOrder();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

    }

    private void btnDelete_Click(object sender, EventArgs e) {

    }
  }
}
