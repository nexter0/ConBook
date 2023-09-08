using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ConBook {
  public partial class frmProductEditor : Form {

    bool mIsCanceled;
    private enum mValidationResultEnum { OK, FIELD_EMPTY, VALUE_ERROR, MARKERS_ERROR, SYMBOL_ERROR }
    private BindingList<cProduct> mProductsList;


    public frmProductEditor() {
      InitializeComponent();
    }
    private void btnSubmit_Click(object sender, EventArgs e) {

      Submit();

    }

    private void btnCancel_Click(object sender, EventArgs e) {

      mIsCanceled = true;
      this.Close();

    }

    internal bool ShowMe(cProduct xProduct, BindingList<cProduct> xProductsList) {
      //funkcja wywołująca formularz 

      mIsCanceled = false;
      mProductsList = xProductsList;

      InitializeTextBoxes(xProduct);
      CustomizeWidow(xProduct.IsEmpty());

      this.ShowDialog();

      if (mIsCanceled)
        return false;

      xProduct.Name = txtName.Text;
      xProduct.Symbol = txtSymbol.Text;
      try {
        xProduct.Price = Math.Truncate(100 * double.Parse(txtPrice.Text)) / 100;
      } catch (Exception ex) {
        MessageBox.Show($"Podczas edycji kontaktu wystąpił błąd:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

        if (xProduct.IsEmpty())
          return false;

        return true;
      
    }



    private void CustomizeWidow(bool xIsEmptyProduct) {
      //funkcja ustawiająca właściwości okna w zależności od trybu edycji / dodawania

      if (!xIsEmptyProduct) {

        btnSubmit.Text = "Edytuj";
        this.Text = "Edytuj produkt";
        this.Icon = Properties.Resources.editIcon;

      } else {

        btnSubmit.Text = "Dodaj";
        this.Text = "Dodaj produkt";
        this.Icon = Properties.Resources.plusIcon;

      }

    }

    private void InitializeTextBoxes(cProduct xProduct) {
      //funkcja czyszcząca lub uzupełniająca pola tekstowa

      if (xProduct != null) {
        txtName.Text = xProduct.Name;
        txtSymbol.Text = xProduct.Symbol;
        txtPrice.Text = xProduct.Price.ToString();
      } else {
        txtName.Text = string.Empty;
        txtSymbol.Text = string.Empty;
        txtPrice.Text = "0";
      }

    }

    private mValidationResultEnum ValidateTextBoxes() {
      //funkcja weryfikująca poprawność wpisanych danych w pola tekstowe      

      string pPatternMarkers = @"(::|\$<|\>\$)";
      string pPatternPrice = @"[^0-9,.]+";

      if (txtPrice.Text.Contains('.')) {
        string pPriceFormatted = txtPrice.Text.Replace('.', ',');
        txtPrice.Text = pPriceFormatted;
      }

      if (string.IsNullOrEmpty(txtName.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtSymbol.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (Regex.IsMatch(txtPrice.Text, pPatternPrice)) { return mValidationResultEnum.VALUE_ERROR; }
      try {
        if (double.Parse(txtPrice.Text) < 0) { return mValidationResultEnum.VALUE_ERROR; }
      } catch (Exception ex) {
        return mValidationResultEnum.VALUE_ERROR;
      }
      if (Regex.IsMatch(txtName.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(txtSymbol.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(txtPrice.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };

      if (cProduct.CheckIfSymbolExists(mProductsList, txtSymbol.Text)) { return mValidationResultEnum.SYMBOL_ERROR; };

      return mValidationResultEnum.OK;

    }

    private void Submit() {

      mValidationResultEnum pCntValidation = ValidateTextBoxes();

      if (pCntValidation == mValidationResultEnum.OK) {
        this.Close();
      } else {
        string pCaption = "Błąd";
        string pMessage = "Nieprawdiłowe dane!\n\n";

        switch (pCntValidation) {
          case mValidationResultEnum.FIELD_EMPTY: { pMessage += "Pola Nazwa, Symbol, Cena są wymagane."; break; }
          case mValidationResultEnum.VALUE_ERROR: { pMessage += "Nieprawidłowa wartość w polu Cena."; break; }
          case mValidationResultEnum.MARKERS_ERROR: { pMessage += "Niedozwolona kombinacja znaków ('::', '$<', '>$')."; break; }
          case mValidationResultEnum.SYMBOL_ERROR: { pMessage += $"Produkt o symbolu: {txtSymbol.Text} istnieje."; break; }

        }

        MessageBox.Show(pMessage, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      }

    }
  }
}
