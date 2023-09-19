using System.ComponentModel;

namespace ConBook {
  internal class cProductListUtils {
    //klasa odpowiadająca za obsługę listy produktów

    private BindingList<cProduct> mProductsList;                    // lista produktów
    private int mLastProductIndex;                                  // ostatnio wykorzystany indeks produktu

    #region Properties
    public BindingList<cProduct> ProductsList { get { return mProductsList; } set { mProductsList = value; } }
    public int LastProductIndex { get { return mLastProductIndex; } set { mLastProductIndex = value; } }

    public cProductListUtils() {

      ProductsList = new BindingList<cProduct>();

      mLastProductIndex = cIndexTracker.GetIndexValue(cIndexTracker.IndexTypeEnum.Product);

    }
    #endregion

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
      //xIndex - indeks produktu w liście produktów

      BindingList<cOrder> pOrderList = cOrdersSerializer.GetOrdersList();
      cOrder pOrder = pOrderList.FirstOrDefault(o => o.OrderedProductsList.Any(p => p.Index == ProductsList[xIndex].Index));

      if (pOrder != null) {
        MessageBox.Show($"Produkt \"{ProductsList[xIndex].Name}\" jest związany z zamówieniem \"{pOrder.Number}\".\n\n" +
          $"Usuń lub zmodyfikuj to zamówienie, aby usunąć produkt.", "Nie można usunąć", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else {

        DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
        $" {ProductsList[xIndex].Name} ({ProductsList[xIndex].Symbol}) z listy?",
        "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (deletionQueryResult == DialogResult.Yes) {
          ProductsList.RemoveAt(xIndex);
        }

      }

    }

    internal void EditProduct(int xIndex) {
      //funkcja edytująca produkt
      //xIndex - indeks produktu w liście produktów

      frmProductEditor pProductEditor = new frmProductEditor();

      pProductEditor.ShowMe(ProductsList[xIndex], ProductsList);

    }
  }
}
