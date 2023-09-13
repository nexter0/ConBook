using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ConBook {
  public partial class frmOrderEditor : Form {

    BindingList<cOrderedProduct> mOrderedProductsList;                  // lista wybranych przez użytkownika produktów
    BindingList<cProduct>? mProductsList;                               // pełna lista produktów

    bool mIsCanceled;

    public frmOrderEditor() {

      InitializeComponent();

      mOrderedProductsList = new BindingList<cOrderedProduct>();

    }

    private void btnSubmit_Click(object sender, EventArgs e) {

      this.Close();

    }

    private void btnCancel_Click(object sender, EventArgs e) {
      mIsCanceled = true;
      this.Close();
    }

    private void btnAddProduct_Click(object sender, EventArgs e) {

      cOrderedProduct pOrderedProduct = GetOrderedProduct();

      mOrderedProductsList.Add(pOrderedProduct);

    }

    private void cbxProducts_SelectedIndexChanged(object sender, EventArgs e) {

      cProduct pProduct = cbxProducts.SelectedItem as cProduct;

      mtxtPrice.Text = pProduct.Price.ToString();

    }

    private void dgvSelectedProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {

      if (e.RowIndex >= 0 && e.ColumnIndex == dgvSelectedProducts.Columns["Index"].Index) {
        int productIndex = (int)e.Value;

        cProduct pProduct = mProductsList.FirstOrDefault(p => p.Index == productIndex);


        if (pProduct != null) {
          e.Value = pProduct.Name;
        }
      }

    }

    private void mtxtAmount_Validating(object sender, CancelEventArgs e) {

      TextBox pTextBox = (TextBox)sender;

      string pInput = pTextBox.Text;


      if (Regex.IsMatch(pInput, @"\D")) {

        MessageBox.Show("Niewłaściwy format danych w polu Ilość");
        e.Cancel = true;

      }

    }

    internal bool ShowMe(cOrder xOrder, BindingList<cProduct>? xProductsList, BindingList<cContact>? xContactList) {
      //funkcja wywołująca formularz

      List<int> pSelectedProductsIndexes = new List<int>();
      bool pIsOrderEmpty = xOrder.IdxContact == -1;

      mProductsList = xProductsList;

      cbxProducts.DataSource = xProductsList;
      cbxProducts.DisplayMember = "Name";
      cbxClients.DataSource = xContactList;
      cbxClients.DisplayMember = "ToString";

      InitializeDataGridView();
      InitializeTextBoxes(xOrder);
      CustomizeWidow(pIsOrderEmpty);

      this.ShowDialog();

      if (mIsCanceled)
        return false;

      cContact pContact = cbxClients.SelectedItem as cContact;

      xOrder.Number = txtOrderNumber.Text;
      xOrder.CreationDate = dtpCreationDate.Value;
      xOrder.IdxContact = pContact.Index;
      xOrder.OrderedProductsList = mOrderedProductsList;

      return true;

    }

    private void CustomizeWidow(bool xIsEmptyProduct) {
      //funkcja ustawiająca właściwości okna w zależności od trybu edycji / dodawania

      if (!xIsEmptyProduct) {

        btnSubmit.Text = "Edytuj";
        this.Text = "Edytuj zamówienie";
        this.Icon = Properties.Resources.editIcon;

      } else {

        btnSubmit.Text = "Dodaj";
        this.Text = "Dodaj zamówienie";
        this.Icon = Properties.Resources.plusIcon;

      }

    }

    private void InitializeTextBoxes(cOrder? xOrder) {
      //funkcja czyszcząca lub uzupełniająca pola tekstowa

      if (xOrder != null && xOrder.IdxContact != -1) {
        txtOrderNumber.Text = xOrder.Number;
        dtpCreationDate.Value = xOrder.CreationDate;
        mOrderedProductsList = xOrder.OrderedProductsList;
        dgvSelectedProducts.DataSource = null;
        dgvSelectedProducts.DataSource = mOrderedProductsList;

      } else {
        txtOrderNumber.Text = string.Empty;
        dtpCreationDate.Value = DateTime.Now;
      }

    }

    private cOrderedProduct GetOrderedProduct() {
      //funkcja zwracająca obiekt OrderedProduct na podstawie danych z formularza

      cProduct pProduct = cbxProducts.SelectedItem as cProduct;

      int pAmount = int.Parse(mtxtAmount.Text);
      if (mtxtPrice.Text.Contains('.')) {
        string pPriceFormatted = mtxtPrice.Text.Replace('.', ',');
        mtxtPrice.Text = pPriceFormatted;
      }
      double pPrice = double.Parse(mtxtPrice.Text);

      return new cOrderedProduct(pProduct.Index, pAmount, pPrice);

    }

    private void InitializeDataGridView() {
      //funkcja inicjalizująca DataGridView

      dgvSelectedProducts.DataSource = mOrderedProductsList;

      dgvSelectedProducts.Columns["Index"].HeaderText = "Nazwa";
      dgvSelectedProducts.Columns["Amount"].HeaderText = "Ilość";
      dgvSelectedProducts.Columns["SellPrice"].HeaderText = "Cena sprzedaży";
      dgvSelectedProducts.Columns["TotalPrice"].HeaderText = "Cena łączna";

      dgvSelectedProducts.Columns["Index"].Width = 243;
      dgvSelectedProducts.Columns["Amount"].Width = 50;
      dgvSelectedProducts.Columns["SellPrice"].Width = 120;
      dgvSelectedProducts.Columns["TotalPrice"].Width = 120;

    }

    
  }
}
