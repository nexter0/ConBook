using System.ComponentModel;

namespace ConBook {
  internal class cOrdersListUtils {
    //klasa odpowiadająca za obsługę listy zamówień

    private int mLastOrderIndex;                                  // ostatnio wykorzystany indeks zamówienia
    private BindingList<cOrder> mOrdersList;                      // lista zamówień
    
    #region Properties
    public BindingList<cOrder> OrdersList { get { return mOrdersList; } set { mOrdersList = value; } }
    public int LastOrderIndex { get { return mLastOrderIndex; } set { mLastOrderIndex = value; } }
    #endregion

    public cOrdersListUtils() {
      
      OrdersList = new BindingList<cOrder>();

      mLastOrderIndex = cIndexTracker.GetIndexValue(cIndexTracker.IndexTypeEnum.Order);

    }

    public void AddOrder() {
      //funkcja dodająca zamówienie do listy zamówień

      cOrder pOrder = new cOrder();

      cContact_DAO pContact_DAO = new cContact_DAO();
      cProduct_DAO pProduct_DAO = new cProduct_DAO();
      cOrder_DAO pOrder_DAO = new cOrder_DAO();
      cOrderedProduct_DAO pOrderedProduct_DAO = new cOrderedProduct_DAO();

      frmOrderEditor pOrderEditor = new frmOrderEditor();

      BindingList<cContact> pContactsList = new BindingList<cContact>(pContact_DAO.GetContactsList());
      BindingList<cProduct> pProductsList = new BindingList<cProduct>(pProduct_DAO.GetProductsList());

      if (pOrderEditor.ShowMe(pOrder, pProductsList, pContactsList)) {

        if (pOrderedProduct_DAO.InsertOrderedProductsTransaction(pOrder.OrderedProductsList)) {
          MessageBox.Show("Wystąpił krytyczny błąd podczas tworzenia zamówienia.\nZamówienie nie zostało utworzone.", "Nie można utworzyć zamówienia", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
          

        if (pOrder_DAO.InsertOrder(pOrder) > 0)
          OrdersList.Add(pOrder);
      }


    }

    internal void EditOrder(int xIndex) {
      //funkcja edytująca kontakt
      //xIndex - indeks zamówienia na liście

      cContact_DAO pContact_DAO = new cContact_DAO();
      cProduct_DAO pProduct_DAO = new cProduct_DAO();
      cOrder_DAO pOrder_DAO = new cOrder_DAO();
      frmOrderEditor pOrderEditor = new frmOrderEditor();

      BindingList<cContact> pContactsList = new BindingList<cContact>(pContact_DAO.GetContactsList());
      BindingList<cProduct> pProductsList = new BindingList<cProduct>(pProduct_DAO.GetProductsList());

      if (pOrderEditor.ShowMe(OrdersList[xIndex], pProductsList, pContactsList))
        pOrder_DAO.UpdateOrder(OrdersList[xIndex]);



    }

    internal void DeleteOrder(int xIndex) {
      //funkcja usuwająca produkt z listy
      //xIndex - indeks zamówienia na liście

      cOrder_DAO pOrder_DAO = new cOrder_DAO();
      cOrder pOrder = OrdersList[xIndex];

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć zamówienie numer" +
          $" {OrdersList[xIndex].Number} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {
        if (pOrder_DAO.DropOrder(pOrder.Index) > 0)
          OrdersList.RemoveAt(xIndex);

      }

    }

  }
}
