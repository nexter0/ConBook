using System.ComponentModel;

namespace ConBook {
  internal class cProductListUtils {
    //klasa odpowiadająca za obsługę listy produktów

    private BindingList<cProduct> mProducts;                   // lista produktów
    private frmProductsEditor mEditor;                  // formularz dodawania / edycji produktów

    public  BindingList<cProduct> Products { get; set; }

    public cProductListUtils() {

       Products = new BindingList<cProduct>();

       mEditor = new frmProductsEditor();

    }

    internal void AddProduct() {
      //funkcja dodająca produkt do listy

      cProduct pProduct = new cProduct();

      if (!mEditor.ShowMe(pProduct))
        return;

      Products.Add(pProduct);

    }

    internal void DeleteProduct(int xIndex) {
      //funkcja usuwająca produkt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {Products[xIndex].Name} ({Products[xIndex].Symbol}) z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {
        Products.RemoveAt(xIndex);
      }

    }

    internal void EditProduct(int xIndex) {
      //funkcja edytująca kontakt

      mEditor.ShowMe(Products[xIndex]);

    }

  }
}
