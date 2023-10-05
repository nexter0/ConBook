﻿using System;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace ConBook {
  public partial class frmOrderEditor : Form {

    BindingList<cOrderedProduct> mOrderedProductsList;                  // lista wybranych przez użytkownika produktów
    BindingList<cProduct>? mProductsList;                               // pełna lista produktów

    private enum EmptyTextBoxValidatonResult { OK, NUMBER_EMPTY,        // numerator błędów walidacji pól tekstowych
      AMOUNT_EMPTY, PRICE_EMPTY };

    bool mIsCanceled;                                                   // zmienna, czy formularz anulowany
    bool mIsApplied;                                                    // zmienna, czy formularz akceptowany
    int mEditedOrderIndex;                                              // indeks zamówienia do którego dodawany jest produkt

    public bool IsCanceled { get { return mIsCanceled; } set { mIsCanceled = value; } }

    public bool IsApplied { get { return mIsApplied; } set { mIsApplied = value; } }

    public int EditedOrderIndex { get { return mEditedOrderIndex; } set { mEditedOrderIndex = value; } }


    public frmOrderEditor() {

      InitializeComponent();

      mOrderedProductsList = new BindingList<cOrderedProduct>();
      IsCanceled = false;
      IsApplied = false;
      EditedOrderIndex = 0;

    }

    private void btnSubmit_Click(object sender, EventArgs e) {

      DialogResult cntValidationResult = ValidateOrder();

      if (cntValidationResult == DialogResult.Yes) {
        IsCanceled = true;
        this.Close();
      } else if (cntValidationResult == DialogResult.Ignore) {
        this.Close();
        IsApplied = true;
      }

    }

    private void frmOrderDetails_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {
        IsCanceled = true;
        this.Close();
      }

    }

    private void btnCancel_Click(object sender, EventArgs e) {

      IsCanceled = true;
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

      if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrderedProducts.Columns["IdxProduct"].Index) {
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

      if (xOrder.Index > 0)
        EditedOrderIndex = xOrder.Index;

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

      if (IsCanceled || !IsApplied)
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

        btnSubmit.Text = "Zapisz";
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
        mtxtAmount.Text = "1";
        UpdateTotalSum();

      } else {
        txtOrderNumber.Text = string.Empty;
        dtpCreationDate.Value = DateTime.Now;
        mtxtAmount.Text = "1";
      }

    }

    private cOrderedProduct GetOrderedProduct() {
      //funkcja zwracająca obiekt OrderedProduct na podstawie danych z formularza

      cProduct pProduct = cbxProducts.SelectedItem as cProduct;

      int pQuantity = int.Parse(mtxtAmount.Text);
      if (mtxtPrice.Text.Contains('.')) {
        string pPriceFormatted = mtxtPrice.Text.Replace('.', ',');
        mtxtPrice.Text = pPriceFormatted;
      }
      double pPrice = double.Parse(mtxtPrice.Text);

      return new cOrderedProduct(EditedOrderIndex, pProduct.Index, pQuantity, pPrice);

    }

    private void AddOrderedProduct() {
      //funkcja dodająca produkt do listy wybranych produktów

      if (mtxtAmount.Text == string.Empty)
        MessageBox.Show("Należy podać ilość.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      else if (mtxtPrice.Text == string.Empty)
        MessageBox.Show("Należy podać cenę sprzedaży.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);

      cOrderedProduct pOrderedProduct = GetOrderedProduct();

      mOrderedProductsList.Add(pOrderedProduct);
      UpdateTotalSum();

    }

    private void DeleteOrderedProduct() {
      //funkcja usuwająca produkt z listy wybranych produktów

      int pListIndex = dgvOrderedProducts.SelectedRows[0].Index;

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć produkt" +
          $" {mProductsList[pListIndex].Name} z listy?",
          "Usuń produkt z listy wybranych", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        mOrderedProductsList.RemoveAt(pListIndex);
        UpdateTotalSum();

      }

    }

    private void InitializeDataGridView() {
      //funkcja inicjalizująca DataGridView

      dgvOrderedProducts.DataSource = mOrderedProductsList;

      dgvOrderedProducts.Columns[nameof(cOrderedProduct.IdxProduct)].HeaderText = "Nazwa";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Quantity)].HeaderText = "Ilość";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Sold)].HeaderText = "Cena sprzedaży";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Total)].HeaderText = "Wartość";
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Sold)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Total)].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

      dgvOrderedProducts.Columns[nameof(cOrderedProduct.IdxProduct)].Width = 243;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Quantity)].Width = 50;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Sold)].Width = 120;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Price_Total)].Width = 120;

      dgvOrderedProducts.Columns[nameof(cOrderedProduct.Index)].Visible = false;
      dgvOrderedProducts.Columns[nameof(cOrderedProduct.IdxOrder)].Visible = false;

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

        lbTotalSum.Text = Math.Round(pTotalSum, 2).ToString("C");
      }

    }
  }
}
