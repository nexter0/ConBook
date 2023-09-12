using System.ComponentModel;

namespace ConBook {
  public partial class frmOrderEditor : Form {

    bool mIsCanceled;

    public frmOrderEditor() {
      InitializeComponent();
    }

    internal bool ShowMe(cOrder xOrder, BindingList<cProduct>? xProductsList, BindingList<cContact>? xContactList) {
      //funkcja wywołująca formularz

      List<int> pSelectedProductsIndexes = new List<int>();
      bool pIsOrderEmpty = xOrder.IdxContact == -1;

      clbProductsSelection.DataSource = xProductsList;
      clbProductsSelection.DisplayMember = "Name";
      //clbProductsSelection.ValueMember = "Index";

      clbContactsSelection.DataSource = xContactList;
      //clbContactsSelection.ValueMember = "Index";
      clbContactsSelection.DisplayMember = "ToString";


      InitializeTextBoxes(xOrder);
      CustomizeWidow(pIsOrderEmpty);

      this.ShowDialog();

      if (mIsCanceled)
        return false;

      if (!ValidateCheckedListBox()) {
        MessageBox.Show("Error.");
        return false;
      }

      xOrder.Number = txtOrderNumber.Text;
      xOrder.CreationDate = dtpCreationDate.Value;
      xOrder.IdxContact = clbContactsSelection.CheckedItems.Cast<cContact>().FirstOrDefault().Index;

      foreach (var pItem in clbProductsSelection.CheckedItems) {
        if (pItem is cProduct pProduct) {
          pSelectedProductsIndexes.Add(pProduct.Index);
        }
      }

      xOrder.IdxsProducts = pSelectedProductsIndexes;

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
        clbContactsSelection.SetItemChecked(xOrder.IdxContact - 1, true);
        foreach (int pIndex in xOrder.IdxsProducts) {
          clbProductsSelection.SetItemChecked(pIndex - 1, true);
        }
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

    private void btnCancel_Click(object sender, EventArgs e) {
      mIsCanceled = true;
      this.Close();
    }
  }
}
