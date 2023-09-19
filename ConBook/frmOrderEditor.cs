using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace ConBook {
  public partial class frmOrderEditor : Form {

    BindingList<cOrderedProduct> mOrderedProductsList;                  // lista wybranych przez użytkownika produktów
    BindingList<cProduct>? mProductsList;                               // pełna lista produktów

    private enum EmptyTextBoxValidatonResult { OK, NUMBER_EMPTY, AMOUNT_EMPTY, PRICE_EMPTY };

    bool mIsCanceled;
    bool mIsApplied;

    public frmOrderEditor() {

      InitializeComponent();

      mOrderedProductsList = new BindingList<cOrderedProduct>();
      mIsCanceled = false;
      mIsApplied = false;

    }

    private void btnSubmit_Click(object sender, EventArgs e) {

      DialogResult cntValidationResult = ValidateOrder();

      if (cntValidationResult == DialogResult.Yes) {
        mIsCanceled = true;
        this.Close();
      } else if (cntValidationResult == DialogResult.Ignore) {
        this.Close();
        mIsApplied = true;
      }

    }

    private void frmOrderDetails_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {
        mIsCanceled = true;
        this.Close();
      }

    }

    private void btnCancel_Click(object sender, EventArgs e) {

      mIsCanceled = true;
      this.Close();

    }

    private void btnAddProduct_Click(object sender, EventArgs e) {

      AddOrderedProduct();
      UpdateTotalSum();

    }

    private void btnDeleteProduct_Click(object sender, EventArgs e) {

      DeleteOrderedProduct();

    }

    private void cbxProducts_SelectedIndexChanged(object sender, EventArgs e) {

      cProduct pProduct = cbxProducts.SelectedItem as cProduct;

      mtxtPrice.Text = pProduct.Price.ToString();

    }

    private void dgvSelectedProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {

      if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrderedProducts.Columns["Index"].Index) {
        int productIndex = (int)e.Value;

        cProduct pProduct = mProductsList.FirstOrDefault(p => p.Index == productIndex);


        if (pProduct != null) {
          e.Value = pProduct.Name;
        }
      }
      if (e.RowIndex >= 0 && (e.ColumnIndex == dgvOrderedProducts.Columns["Price_Sold"].Index || e.ColumnIndex == dgvOrderedProducts.Columns["Price_Total"].Index)) {
        string pTotalPriceCellValue = e.Value.ToString();
        if (!pTotalPriceCellValue.Contains(","))
          e.Value = e.Value + ",00";
      }


    }

    private void mtxtAmount_Validating(object sender, CancelEventArgs e) {

      TextBox pTextBox = (TextBox)sender;

      string pInput = pTextBox.Text;

      if (pInput == string.Empty) {
        MessageBox.Show("Należy podać ilość.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        e.Cancel = true;
      }

      if (Regex.IsMatch(pInput, @"\D")) {
        MessageBox.Show("Niewłaściwy format danych w polu Ilość", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
      cbxClients.ValueMember = "Index";
      cbxClients.DisplayMember = "DisplayText";


      InitializeTextBoxes(xOrder, xContactList);
      InitializeDataGridView();
      CustomizeWidow(pIsOrderEmpty);

      this.ShowDialog();

      if (mIsCanceled || !mIsApplied)
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

    private void InitializeTextBoxes(cOrder? xOrder, BindingList<cContact> xContactsList) {
      //funkcja czyszcząca lub uzupełniająca pola tekstowa

      if (xOrder != null && xOrder.IdxContact != -1) {
        cContact pContact = xContactsList.FirstOrDefault(c => c.Index == xOrder.IdxContact);

        txtOrderNumber.Text = xOrder.Number;
        dtpCreationDate.Value = xOrder.CreationDate;
        mOrderedProductsList = xOrder.OrderedProductsList;
        cbxClients.SelectedValue = pContact.Index;
        dgvOrderedProducts.DataSource = null;
        dgvOrderedProducts.DataSource = mOrderedProductsList;

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

    private void AddOrderedProduct() {
      //funkcja dodająca produkt do listy wybranych produktów

      if (mtxtAmount.Text == string.Empty)
        MessageBox.Show("Należy podać ilość.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      else if (mtxtPrice.Text == string.Empty)
        MessageBox.Show("Należy podać cenę sprzedaży.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

      cOrderedProduct pOrderedProduct = GetOrderedProduct();

      if (CheckIfIndexExists(mOrderedProductsList, pOrderedProduct.Index)) {
        MessageBox.Show("Dany produkt został już dodany do listy produktów.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      } else {

        mOrderedProductsList.Add(pOrderedProduct);
      }

    }

    private void DeleteOrderedProduct() {
      //funkcja usuwająca produkt z listy wybranych produktów

      int pListIndex = dgvOrderedProducts.SelectedRows[0].Index;
      int pProductIndex = mOrderedProductsList[pListIndex].Index - 1;

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć produkt" +
          $" {mProductsList[pProductIndex].Name} z listy?",
          "Usuń produkt z listy wybranych", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        mOrderedProductsList.RemoveAt(pListIndex);

      }

    }

    private void InitializeDataGridView() {
      //funkcja inicjalizująca DataGridView

      dgvOrderedProducts.DataSource = mOrderedProductsList;

      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Index)].HeaderText = "Nazwa";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Amount)].HeaderText = "Ilość";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Sold)].HeaderText = "Cena sprzedaży";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Total)].HeaderText = "Cena łączna";

      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Index)].Width = 243;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Amount)].Width = 50;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Sold)].Width = 120;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Total)].Width = 120;

    }


    private bool CheckIfIndexExists(BindingList<cOrderedProduct> xOrderedProductsList, int xIndex) {
      //funkcja sprawdzająca czy w liście wybranych produktów istnieje produkt z danym indeksem

      return xOrderedProductsList.Any(pProduct => pProduct.Index == xIndex);

    }

    private DialogResult ValidateOrder() {
      //funkcja sprawdzająca, czy wszystkie dane zostały wpisane
      //funkcja zwraca DialogResult.YesNo, czy formularz powinien zostać zamknięy

      if (txtOrderNumber.Text == string.Empty) {
        return MessageBox.Show("Nie wprowadzono numeru zamówienia. Zamówienie nie zostanie utworzone.\nCzy na pewno zamknąć to okno?", "Błąd tworzenia zamówienia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      }
      if (mOrderedProductsList.Count == 0) {
        return MessageBox.Show("Lista wybranych produktów jest pusta. Zamówienie nie zostanie utworzone.\nCzy na pewno zamknąć to okno?", "Błąd tworzenia zamówienia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      }

      return DialogResult.Ignore;
    }

    private void UpdateTotalSum() {
      //funkcja aktualizująca łączną cenę zamówienia

      if (mOrderedProductsList.Count > 0) {
        lbSuma.Visible = true;
        lbTotalSum.Visible = true;

        double pTotalSum = mOrderedProductsList.Sum(p => p.Price_Total);

        lbTotalSum.Text = "PLN " + Math.Round(pTotalSum, 2).ToString();
      }

    }

  }
}
