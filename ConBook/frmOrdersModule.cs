﻿using System.ComponentModel;

namespace ConBook {
  public partial class frmOrdersModule : Form {

    private cOrdersListUtils mOrdersListUtils;

    public frmOrdersModule() {

      InitializeComponent();

      mOrdersListUtils = new cOrdersListUtils();

    }

    private void btnAdd_Click(object sender, EventArgs e) {

      mOrdersListUtils.AddOrder();

      UpdateAdditionalColumns();

    }

    private void btnEdit_Click(object sender, EventArgs e) {

      if (mOrdersListUtils.OrdersList.Count > 0)
        mOrdersListUtils.EditOrder(dgvOrders.SelectedRows[0].Index);

      UpdateAdditionalColumns();

    }

    private void btnDelete_Click(object sender, EventArgs e) {

      if (mOrdersListUtils.OrdersList.Count > 0)
        mOrdersListUtils.DeleteOrder(dgvOrders.SelectedRows[0].Index);

      UpdateAdditionalColumns();

    }
    private void frmOrdersModule_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {

        this.Close();

      }
    }

    private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {

      if (e.RowIndex >= 0 && e.ColumnIndex == dgvOrders.Columns["IdxContact"].Index) {
        int contactIndex = (int)e.Value;

        BindingList<cContact> pContactsList = cContactsSerializer.GetContactsList();
        cContact pContact = pContactsList.FirstOrDefault(c => c.Index == contactIndex);


        if (pContact != null) {
          e.Value = pContact.Name[0] + ". " + pContact.Surname;
        }
      }
      FormatAdditionalCells(dgvOrders[e.ColumnIndex, e.RowIndex]);
    }

    private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {

      frmOrderDetails pFrmOrderDetails = new frmOrderDetails();

      DataGridViewRow pSelectedRow = dgvOrders.SelectedRows[0];
      cOrder pSelectedOrder = (cOrder)pSelectedRow.DataBoundItem;

      pFrmOrderDetails.ShowMe(pSelectedOrder);

    }


    internal bool ShowMe() {
      //funkcja wywołująca formularz

      AddDataGridViewCols();
      BindDataGridView();
      this.ShowDialog();

      return true;

    }

    private void BindDataGridView() {
      //funkcja bindująca DataGridView z listą zamówień

      dgvOrders.DataSource = null;
      dgvOrders.DataSource = mOrdersListUtils.OrdersList;
      ConfigureDefaultDataGridViewCols();

    }

    private void ConfigureDefaultDataGridViewCols() {
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
      pDgvColumnIndex.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

      pDgvColumnIndex.SortMode = DataGridViewColumnSortMode.Automatic;
      pDgvColumnClient.SortMode = DataGridViewColumnSortMode.Automatic;

      dgvOrders.Columns["TotalPrice"].DisplayIndex = dgvOrders.ColumnCount - 1;
      dgvOrders.Columns["TotalAmount"].DisplayIndex = dgvOrders.ColumnCount - 2;
    }

    private void AddDataGridViewCols() {
      //funkcja dodająca dodatkowe kolumny do DataGridView

      DataGridViewTextBoxColumn pDgvColumnTotalPrice = new DataGridViewTextBoxColumn() {
        Name = "TotalPrice",
        HeaderText = "Wartość zamówienia",
        ReadOnly = true,
      };

      DataGridViewTextBoxColumn pDgvColumnTotalAmount = new DataGridViewTextBoxColumn() {
        Name = "TotalAmount",
        HeaderText = "Liczba produktów",
        ReadOnly = true,
      };

      dgvOrders.Columns.Add(pDgvColumnTotalPrice);
      dgvOrders.Columns.Add(pDgvColumnTotalAmount);

      pDgvColumnTotalPrice.Width = 118;
      pDgvColumnTotalAmount.Width = 80;
      pDgvColumnTotalPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
      pDgvColumnTotalAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

    }

    private void FormatAdditionalCells(DataGridViewCell xCell) {
      //funkcja formatująca komórki w dodatkowo dodanych kolumnach

      var pFormattedCellOrderIndex = dgvOrders.Rows[xCell.RowIndex].Cells["Index"];
      cOrder pOrder = mOrdersListUtils.OrdersList.FirstOrDefault(o => o.Index == (int)pFormattedCellOrderIndex.Value);

      if (xCell.RowIndex >= 0 && xCell.ColumnIndex == dgvOrders.Columns["TotalPrice"].Index) {

        xCell.Value = GetTotalProductsPrice(pOrder).ToString("C");

      } else if (xCell.RowIndex >= 0 && xCell.ColumnIndex == dgvOrders.Columns["TotalAmount"].Index) {

        xCell.Value = GetTotalProductsAmount(pOrder);
      }

    }

    private void UpdateAdditionalColumns() {
      //funkcja aktualizująca dodatkowo dodane kolumny

      foreach (DataGridViewRow pRow in dgvOrders.Rows) {
        FormatAdditionalCells(pRow.Cells["TotalPrice"]);
        FormatAdditionalCells(pRow.Cells["TotalAmount"]);
      }

    }

    private int GetTotalProductsAmount(cOrder xOrder) {

      int pSum = 0;
      foreach (cOrderedProduct pProduct in xOrder.OrderedProductsList) {
        pSum += pProduct.Quantity;
      }

      return pSum;

    }

    private double GetTotalProductsPrice(cOrder xOrder) {

      double pSum = 0;
      foreach (cOrderedProduct pProduct in xOrder.OrderedProductsList) {
        pSum += pProduct.Price_Total;
      }

      return pSum;

    }

    private void LoadOrders() {
      //funkcja wczytująca kolekcję produktów z pliku

      cOrder_DAO pOrder_DAO = new cOrder_DAO();
      List<cOrder>? pOrdersList = pOrder_DAO.GetOrdersList();

      if (pOrdersList != null)
        mOrdersListUtils.OrdersList = new BindingList<cOrder>(pOrdersList);

      BindDataGridView();

    }
  }
}
