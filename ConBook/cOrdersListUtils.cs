using System.ComponentModel;

namespace ConBook {
  internal class cOrdersListUtils {

    private BindingList<cOrder> mOrdersList;

    public BindingList<cOrder> OrdersList { get { return mOrdersList; } set { mOrdersList = value; } }

    public cOrdersListUtils() {
      
      OrdersList = new BindingList<cOrder>();

    }

    public void AddOrder() {
      //funkcja dodająca zamówienie do listy zamówień

      cOrder pOrder = new cOrder();
      frmOrderEditor pOrderEditor = new frmOrderEditor();

      BindingList<cContact> pContactsList = cContactsSerializer.GetContactsList();
      BindingList<cProduct> pProductsList = cProductsSerializer.GetProductsList();

      if (pOrderEditor.ShowMe(pOrder, pProductsList, pContactsList))
        OrdersList.Add(pOrder);

    }

  }
}
