using System.ComponentModel;

namespace ConBook {
  internal class cContactsListUtils {
    //klasa odpowiadająca za obsługę listy konktatków

    private BindingList<cContact> mContactsList;                  // lista przechowująca kontakty
    private int mLastContactIndex;                                // ostatnio wykorzystany indeks kontaktu

    #region Properties
    public BindingList<cContact> ContactsList { get { return mContactsList; } set { mContactsList = value; } }
    public int LastContactIndex { get { return mLastContactIndex; } set { mLastContactIndex = value; } }
    #endregion

    public cContactsListUtils() {

      mContactsList = new BindingList<cContact>();

      mLastContactIndex = cIndexTracker.GetIndexValue(cIndexTracker.IndexTypeEnum.Contact);

    }

    public void AddContact(cContact xContact) {
      //funkcja dodająca kontakt do listy
      //xContact - kontakt do dodania

      int pNewContactIndex = LastContactIndex + 1;
      LastContactIndex = pNewContactIndex;
      cIndexTracker.SetIndexValue(cIndexTracker.IndexTypeEnum.Contact, pNewContactIndex);

      xContact.Index = pNewContactIndex;
      ContactsList.Add(xContact);

    }

    public void DeleteContact(int xIndex) {
      //funkcja usuwająca kontakt z listy
      //xIndex - indeks kontaktu na liście

      BindingList<cOrder> pOrderList = cOrdersSerializer.GetOrdersList();
      cOrder pOrder = pOrderList.FirstOrDefault(o => o.IdxContact == ContactsList[xIndex].Index);

      if (pOrder != null) {
        MessageBox.Show($"Kontakt \"{ContactsList[xIndex].Name} {ContactsList[xIndex].Surname}\" jest związany z zamówieniem \"{pOrder.Number}\".\n\n" +
          $"Usuń lub zmodyfikuj to zamówienie, aby usunąć kontakt.", "Nie można usunąć", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else {
        DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
        $" \"{ContactsList[xIndex].Name} {ContactsList[xIndex].Surname}\" z listy?",
        "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (deletionQueryResult == DialogResult.Yes)
          ContactsList.RemoveAt(xIndex);
      }

    }
  }
}
