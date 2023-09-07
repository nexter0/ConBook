using System.ComponentModel;

namespace ConBook {
  internal class cProductListUtils {
    //klasa odpowiadająca za obsługę listy produktów

    private BindingList<cProduct> mProductsList;                    // lista produktów

    public BindingList<cProduct> ProductsList { get; set; }

    public cProductListUtils() {

      ProductsList = new BindingList<cProduct>();

    }

    internal void AddProduct() {
      //funkcja dodająca produkt do listy

      cProduct pProduct = new cProduct();
      frmProductEditor pProductEditor = new frmProductEditor();

      if (!pProductEditor.ShowMe(pProduct, ProductsList)) {
        return;
      }
      pProduct.Index = GetNewIndex();
      ProductsList.Add(pProduct);

    }

    internal void DeleteProduct(int xIndex) {
      //funkcja usuwająca produkt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {ProductsList[xIndex].Name} ({ProductsList[xIndex].Symbol}) z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {
        ProductsList.RemoveAt(xIndex);
      }

    }

    internal void EditProduct(int xIndex) {
      //funkcja edytująca kontakt

      frmProductEditor pProductEditor = new frmProductEditor();

      pProductEditor.ShowMe(ProductsList[xIndex], ProductsList);

    }

    private int GetNewIndex() {
      if (ProductsList.Count == 0) return 0;
      return ProductsList.Max(contact => contact.Index) + 1;
    }

  }
}
