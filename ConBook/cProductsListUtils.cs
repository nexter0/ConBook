using System.ComponentModel;

namespace ConBook {
  internal class cProductListUtils {
    //klasa odpowiadająca za obsługę listy produktów

    private BindingList<cProduct> mProductsList;                    // lista produktów
    private int mLastProductIndex;                                  // ostatnio wykorzystany indeks produktu

    public BindingList<cProduct> ProductsList { get; set; }
    public int LastProductIndex { get { return mLastProductIndex; } set { mLastProductIndex = value; } }

    public cProductListUtils() {

      ProductsList = new BindingList<cProduct>();

      mLastProductIndex = cIndexTracker.GetIndexValue(cIndexTracker.IndexTypeEnum.Product);

    }

    internal void AddProduct() {
      //funkcja dodająca produkt do listy

      cProduct pProduct = new cProduct();
      frmProductEditor pProductEditor = new frmProductEditor();

      if (!pProductEditor.ShowMe(pProduct, ProductsList)) {
        return;
      }

      int pNewProductIndex = LastProductIndex + 1;
      LastProductIndex = pNewProductIndex;
      cIndexTracker.SetIndexValue(cIndexTracker.IndexTypeEnum.Product, pNewProductIndex);

      pProduct.Index = pNewProductIndex;
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
  }
}
