using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace ConBook {
  public partial class frmOrderDetails : Form {

    BindingList<cContact>? mFullContactsList;
    BindingList<cProduct>? mFullProductsList;

    public frmOrderDetails() {
      InitializeComponent();
    }

    private void frmOrderDetails_KeyUp(object sender, KeyEventArgs e) {

      if (e.KeyCode == Keys.Escape) {
        this.Close();
      }

    }

    internal bool ShowMe(cOrder xOrder) {

      //mFullContactsList = cContactsSerializer.GetContactsList();
      //mFullProductsList = cProductsSerializer.GetProductsList();

      ResetLabels();
      SetLabels(xOrder);

      ConfigureDataGridView();


      this.ShowDialog();

      return true;
    }

    private void SetLabels(cOrder xOrder) {

      cContact? pContact = mFullContactsList.FirstOrDefault(c => c.Index == xOrder.IdxContact);

      double pTotalPrice = xOrder.OrderedProductsList.Sum(p => p.Price_Total);

      dgvProducts.DataSource = xOrder.OrderedProductsList;

      lbOrderNumber.Text = xOrder.Number;
      lbDateCreated.Text = xOrder.CreationDate.ToString();
      lbClientName.Text = pContact.Name;
      lbClientSurname.Text = pContact.Surname;
      lbClientPhone.Text = pContact.Phone;
      lbTotal.Text = "PLN " + Math.Round(pTotalPrice, 2).ToString();

    }

    private void ResetLabels() {

      lbOrderNumber.Text = "<ORDER_NUMBER>";
      lbDateCreated.Text = "<DATE_CREATED>";
      lbClientName.Text = "<NAME>";
      lbClientSurname.Text = "<SURNAME>";
      lbClientPhone.Text = "<PHONE>";

    }

    private void ConfigureDataGridView() {
      //funkcja kofigurująca DataGridView

      DataGridViewColumn pDgvColumnIndex = dgvProducts.Columns["Index"];
      DataGridViewColumn pDgvColumnAmount = dgvProducts.Columns["Amount"];
      DataGridViewColumn pDgvColumnSellPrice = dgvProducts.Columns["Price_Sold"];
      DataGridViewColumn pDgvColumnTotalPrice = dgvProducts.Columns["Price_Total"];

      pDgvColumnIndex.HeaderText = "Nazwa";
      pDgvColumnAmount.HeaderText = "Ilość";
      pDgvColumnSellPrice.HeaderText = "Cena sprzedaży (za szt.)";
      pDgvColumnTotalPrice.HeaderText = "Cena łączna";

      pDgvColumnIndex.Width = 263;
      pDgvColumnAmount.Width = 50;
      pDgvColumnSellPrice.Width = 100;
      pDgvColumnTotalPrice.Width = 120;

    }

    private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {

      if (e.RowIndex >= 0 && e.ColumnIndex == dgvProducts.Columns["Index"].Index) {
        int productIndex = (int)e.Value;

        cProduct pProduct = mFullProductsList.FirstOrDefault(p => p.Index == productIndex);


        if (pProduct != null) {
          e.Value = pProduct.Name;
        }
      }
      if (e.RowIndex >= 0 && e.ColumnIndex == dgvProducts.Columns["Price_Total"].Index) {
        string pTotalPriceCellValue = e.Value.ToString();
        if (!pTotalPriceCellValue.Contains(","))
          e.Value = e.Value + ",00";
      }

    }
  }
}
