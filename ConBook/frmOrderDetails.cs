using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace ConBook {
  public partial class frmOrderDetails : Form {
    public frmOrderDetails() {
      InitializeComponent();
    }

    internal bool ShowMe(cOrder xOrder) {

      ResetLabels();
      SetLabels(xOrder);

      ConfigureDataGridView();


      this.ShowDialog();

      return true;
    }

    private void SetLabels(cOrder xOrder) {

      BindingList<cContact> pFullContactsList = cContactsSerializer.GetContactsList();
      BindingList<cProduct> pFullProductsList = cProductsSerializer.GetProductsList();

      cContact pContact = pFullContactsList.FirstOrDefault(c => c.Index == xOrder.IdxContact);
      BindingList<cProduct> pProductsList = new BindingList<cProduct>();

      //foreach (int pProductIndex in xOrder.OrderedProductsList) {
      //  cProduct pProduct = pFullProductsList.FirstOrDefault(p => p.Index == pProductIndex);
      //  pProductsList.Add(pProduct);
      //}

      double pTotalPrice = pProductsList.Sum(p => p.Price);

      dgvProducts.DataSource = pProductsList;

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
      DataGridViewColumn pDgvColumnName = dgvProducts.Columns["Name"];
      DataGridViewColumn pDgvColumnSymbol = dgvProducts.Columns["Symbol"];
      DataGridViewColumn pDgvColumnPrice = dgvProducts.Columns["Price"];

      pDgvColumnIndex.HeaderText = "Indeks";
      pDgvColumnName.HeaderText = "Nazwa";
      pDgvColumnSymbol.HeaderText = "Symbol";
      pDgvColumnPrice.HeaderText = "Cena";

      pDgvColumnIndex.Width = 50;
      pDgvColumnName.Width = 263;
      pDgvColumnSymbol.Width = 100;
      pDgvColumnPrice.Width = 120;

    }

  }
}
