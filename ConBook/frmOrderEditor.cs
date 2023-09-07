using System.ComponentModel;
using System.Xml.Linq;

namespace ConBook {
  public partial class frmOrderEditor : Form {

    bool mIsCanceled;

    public frmOrderEditor() {
      InitializeComponent();
    }

    internal bool ShowMe(cOrder xOrder, BindingList<cProduct>? xProductsList, BindingList<cContact>? xContactList) {
      //funkcja wywołująca formularz

      List<int> pSelectedProductsIndexes = new List<int>();

      clbProductsSelection.DataSource = xProductsList;
      clbProductsSelection.DisplayMember = "Name";
      //clbProductsSelection.ValueMember = "Index";

      clbContactsSelection.DataSource = xContactList;
      //clbContactsSelection.ValueMember = "Index";
      clbContactsSelection.DisplayMember = "ToString";


      InitializeTextBoxes(xOrder);

      this.ShowDialog();

      if (mIsCanceled)
        return false;

      if (!ValidateCheckedListBox()) {
        MessageBox.Show("Error.");
        return false;
      }

      xOrder.OrderNumber = txtOrderNumber.Text;
      xOrder.CreationDate = dtpCreationDate.Value;
      xOrder.IdxContact = clbContactsSelection.CheckedItems.Cast<cContact>().FirstOrDefault().Index;

      foreach (var pItem in clbProductsSelection.CheckedItems) {
        if (pItem is cProduct pProduct) {
          pSelectedProductsIndexes.Add(pProduct.Index);
        }
      }

      return true;

    }

    private void InitializeTextBoxes(cOrder? xOrder) {
      //funkcja czyszcząca lub uzupełniająca pola tekstowa

      if (xOrder != null) {
        txtOrderNumber.Text = xOrder.OrderNumber;
        dtpCreationDate.Value = xOrder.CreationDate;
      } else {
        txtOrderNumber.Text = string.Empty;
        dtpCreationDate.Value = DateTime.Now;
      }

    }

    private bool ValidateCheckedListBox() {
      //funkcja weryfikująca CheckedListBox

      if (clbContactsSelection.CheckedItems.Count != 1)
        return false;

      return true;

    }

    private void frmOrderEditor_Load(object sender, EventArgs e) {

    }

    private void btnSubmit_Click(object sender, EventArgs e) {

      this.Close();

    }
  }
}
