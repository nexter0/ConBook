using System.ComponentModel;

namespace ConBook {
  internal class cOrdersListUtils {

    private BindingList<cOrder> mOrdersList;                      // lista zamówień
    private int mLastOrderIndex;                                  // ostatnio wykorzystany indeks zamówienia

    public BindingList<cOrder> OrdersList { get { return mOrdersList; } set { mOrdersList = value; } }
    public int LastOrderIndex { get { return mLastOrderIndex; } set { mLastOrderIndex = value; } }

    public cOrdersListUtils() {
      
      OrdersList = new BindingList<cOrder>();
      mLastOrderIndex = cIndexTracker.GetIndexValue(cIndexTracker.IndexTypeEnum.Order);

    }

    public void AddOrder() {
      //funkcja dodająca zamówienie do listy zamówień

      cOrder pOrder = new cOrder();
      frmOrderEditor pOrderEditor = new frmOrderEditor();

      BindingList<cContact> pContactsList = cContactsSerializer.GetContactsList();
      BindingList<cProduct> pProductsList = cProductsSerializer.GetProductsList();

      if (pOrderEditor.ShowMe(pOrder, pProductsList, pContactsList)) {
        int pNewOrderIndex = LastOrderIndex + 1;
        LastOrderIndex = pNewOrderIndex;
        cIndexTracker.SetIndexValue(cIndexTracker.IndexTypeEnum.Order, pNewOrderIndex);

        pOrder.Index = pNewOrderIndex;
        OrdersList.Add(pOrder);
      }


    }

    internal void EditOrder(int xIndex) {
      //funkcja edytująca kontakt

      frmOrderEditor pOrderEditor = new frmOrderEditor();

      BindingList<cContact> pContactsList = cContactsSerializer.GetContactsList();
      BindingList<cProduct> pProductsList = cProductsSerializer.GetProductsList();

      pOrderEditor.ShowMe(OrdersList[xIndex], pProductsList, pContactsList);

    }

    internal void DeleteOrder(int xIndex) {
      //funkcja usuwająca produkt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć zamówienie numer" +
          $" {OrdersList[xIndex].Number} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {
        OrdersList.RemoveAt(xIndex);
      }

    }

  }
}
