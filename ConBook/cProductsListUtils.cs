using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace ConBook {
  internal class cProductListUtils {
    //klasa odpowiadająca za obsługę listy produktów
    private int mLastProductIndex;                                  // ostatnio wykorzystany indeks produktu

    private BindingList<cProduct>? mProductsList;                    // lista przechowująca kontakty

    #region Properties
    public BindingList<cProduct>? ProductsList { get { return mProductsList; } set { mProductsList = value; } }
    public int LastProductIndex { get { return mLastProductIndex; } set { mLastProductIndex = value; } }

    public cProductListUtils() {

      ProductsList = new BindingList<cProduct>();

    }
    #endregion

    internal void AddProduct() {
      //funkcja dodająca produkt do listy

      cProduct pProduct = new cProduct();
      cProduct_DAO pProduct_DAO = new cProduct_DAO();
      frmProductEditor pProductEditor = new frmProductEditor();


      if (!pProductEditor.ShowMe(pProduct, ProductsList)) {
        return;
      }

      if (pProduct_DAO.InsertProduct(pProduct) > 0)
        ProductsList.Add(pProduct);

    }

    internal void DeleteProduct(int xIndex) {
      //funkcja usuwająca produkt z listy
      //xIndex - indeks produktu w liście produktów

      //BindingList<cOrder> pOrderList = cOrdersSerializer.GetOrdersList();
      cProduct_DAO pProduct_DAO = new cProduct_DAO();
      cProduct pProduct = ProductsList[xIndex];
      //cOrder pOrder = pOrderList.FirstOrDefault(o => o.OrderedProductsList.Any(p => p.Index == ProductsList[xIndex].Index));

      //if (pOrder != null) {
      //  MessageBox.Show($"Produkt \"{ProductsList[xIndex].Name}\" jest związany z zamówieniem \"{pOrder.Number}\".\n\n" +
      //    $"Usuń lub zmodyfikuj to zamówienie, aby usunąć produkt.", "Nie można usunąć", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //}
      //else {

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
      $" {ProductsList[xIndex].Name} ({ProductsList[xIndex].Symbol}) z listy?",
      "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (deletionQueryResult == DialogResult.Yes) {
          if (pProduct_DAO.DropContact(pProduct.Index) > 0)
            ProductsList.RemoveAt(xIndex);
        }

      //}

    }

    internal void EditProduct(int xIndex) {
      //funkcja edytująca produkt
      //xIndex - indeks produktu w liście produktów

      frmProductEditor pProductEditor = new frmProductEditor();
      cProduct_DAO pProduct_DAO = new cProduct_DAO();


      if (pProductEditor.ShowMe(ProductsList[xIndex], ProductsList))
        pProduct_DAO.UpdateProduct(ProductsList[xIndex]);

    }


    public void UpdateProductsList() {
      //funkcja odświeżająca listę kontaktów (pobiera ją ponownie z bazy danych)

      cProduct_DAO pProduct_DAO = new cProduct_DAO();

      ProductsList = new BindingList<cProduct>(pProduct_DAO.GetProductsList());

    }

  }
}
