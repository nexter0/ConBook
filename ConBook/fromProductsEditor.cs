using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ConBook {
  public partial class frmProductsEditor : Form {

    bool mIsCanceled;
    private enum mValidationResultEnum { OK, FIELD_EMPTY, VALUE_ERROR, MARKERS_ERROR }


    public frmProductsEditor() {
      InitializeComponent();
    }
    private void btnSubmit_Click(object sender, EventArgs e) {
      Submit();
    }

    internal bool ShowMe(cProduct xProduct) {
      //funkcja wywołująca formularz 

      mIsCanceled = false;

      InitializeTextBoxes(xProduct);
      CustomizeWidow(xProduct.IsEmpty());
      this.ShowDialog();
      if (mIsCanceled)
        return false;

      xProduct.Name = txtName.Text;
      xProduct.Symbol = txtSymbol.Text;
      xProduct.Price = double.Parse(txtPrice.Text);
      if (xProduct.IsEmpty())
        return false;

      return true;

    }

    private void CustomizeWidow(bool xIsEmptyContact) {
      //funkcja ustawiająca właściwości okna w zależności od trybu edycji / dodawania

      if (!xIsEmptyContact) {

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
      string pPatternPrice = @"[\d,.]+";

      if (txtPrice.Text.Contains('.')) {
        string pPriceFormatted = txtPrice.Text.Replace('.', ',');
        txtPrice.Text = pPriceFormatted;
      }
        
      if (string.IsNullOrEmpty(txtName.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (string.IsNullOrEmpty(txtSymbol.Text)) { return mValidationResultEnum.FIELD_EMPTY; }
      if (!Regex.IsMatch(txtPrice.Text, pPatternPrice)) { return mValidationResultEnum.VALUE_ERROR; }
      if (double.Parse(txtPrice.Text) < 0) { return mValidationResultEnum.VALUE_ERROR; }
      if (Regex.IsMatch(txtName.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(txtSymbol.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };
      if (Regex.IsMatch(txtPrice.Text, pPatternMarkers)) { return mValidationResultEnum.MARKERS_ERROR; };

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

        }

        MessageBox.Show(pMessage, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      }

    }


  }
}
