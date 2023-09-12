using System.ComponentModel;
using System.Windows.Forms;

namespace ConBook {
  public partial class frmOrdersModule : Form {

    private cOrdersListUtils mOrdersListUtils;

    public frmOrdersModule() {

      InitializeComponent();

      mOrdersListUtils = new cOrdersListUtils();

    }

    private void frmOrdersModule_Load(object sender, EventArgs e) {

      LoadOrders();

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      mOrdersListUtils.AddOrder();

      SaveOrders();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      if (mOrdersListUtils.OrdersList.Count > 0)
        mOrdersListUtils.EditOrder(dgvOrders.SelectedRows[0].Index);

      SaveOrders();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      if (mOrdersListUtils.OrdersList.Count > 0)
        mOrdersListUtils.DeleteOrder(dgvOrders.SelectedRows[0].Index);

      SaveOrders();

    }

    private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {

      if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrders.Columns["IdxContact"].Index) {
        int contactIndex = (int)e.Value;

        BindingList<cContact> pContactsList = cContactsSerializer.GetContactsList();
        cContact pContact = pContactsList.FirstOrDefault(c => c.Index == contactIndex);


        if (pContact != null) {
          e.Value = pContact.Name[0] +". " + pContact.Surname;
        }
      }

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

      DataGridViewColumn pDgvColumnNumber = dgvOrders.Columns["Number"];
      DataGridViewColumn pDgvColumnDate = dgvOrders.Columns["CreationDate"];
      DataGridViewColumn pDgvColumnIndex = dgvOrders.Columns["Index"];
      DataGridViewColumn pDgvColumnClient = dgvOrders.Columns["IdxContact"];

      pDgvColumnNumber.HeaderText = "Numer zamówienia";
      pDgvColumnDate.HeaderText = "Data utworzenia";
      pDgvColumnIndex.HeaderText = "Indeks";
      pDgvColumnClient.HeaderText = "Klient";

      pDgvColumnNumber.Width = 170;
      pDgvColumnDate.Width = 250;
      pDgvColumnIndex.Width = 50;
      pDgvColumnClient.Width = 153;

    }

    private void SaveOrders() {
      // funkcja do automatycznego zapisu kolekcji produktów

      string pDefaultFilePath = cOrderSerializer.DEFAULT_SAVE_FILE_PATH;

      if (!File.Exists(pDefaultFilePath)) {
        cOrderSerializer.SaveToNewTxtFile(pDefaultFilePath, mOrdersListUtils.OrdersList);
      } else {
        SaveToFile();
      }


    }

    private void SaveToFile() {
      //funkcja obsługująca zapis do istniejącego pliku

      string pDefaultFilePath = cOrderSerializer.DEFAULT_SAVE_FILE_PATH;

      try {
        if (mOrdersListUtils.OrdersList.Count > 0) {
          if (File.Exists(pDefaultFilePath))
            cOrderSerializer.SaveToExistingTxtFile(pDefaultFilePath, mOrdersListUtils.OrdersList);
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

    private void LoadOrders() {
      //funkcja wczytująca kolekcję produktów z pliku

      string pDefaultFilePath = cOrderSerializer.DEFAULT_SAVE_FILE_PATH;

      try {
        if (File.Exists(pDefaultFilePath)) {
          mOrdersListUtils.OrdersList = cOrderSerializer.GetOrdersList();
        }
      } catch (Exception ex) {
        MessageBox.Show($"Podczas wczytywania wystąpił błąd:\n{ex.Message}\n\nWczytywany plik: {pDefaultFilePath}", "Błąd wczytywania",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

      }

      BindDataGridView();

    }
  }
}
