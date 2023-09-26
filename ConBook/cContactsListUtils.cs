using System.ComponentModel;
using System.Diagnostics.Contracts;

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

      cContact_DAO pContactDAO = new cContact_DAO();

      if (pContactDAO.InsertContact(xContact) > 0)
        ContactsList.Add(xContact);

    }

    public void DeleteContact(int xIndex) {
      //funkcja usuwająca kontakt z listy
      //xIndex - indeks kontaktu na liście

      cContact_DAO pContactDAO = new cContact_DAO();
      cContact pContact = ContactsList[xIndex];
      //BindingList<cOrder> pOrderList = cOrdersSerializer.GetOrdersList();
      //cOrder pOrder = pOrderList.FirstOrDefault(o => o.IdxContact == pContact.Index);


      //if (pOrder != null) {
      //  MessageBox.Show($"Kontakt \"{pContact.Name} {pContact.Surname}\" jest związany z zamówieniem \"{pOrder.Number}\".\n\n" +
      //    $"Usuń lub zmodyfikuj to zamówienie, aby usunąć kontakt.", "Nie można usunąć", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //}
      //else {
        DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
        $" \"{pContact.Name} {pContact.Surname}\" z listy?",
        "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (deletionQueryResult == DialogResult.Yes)
          if (pContactDAO.DropContact(pContact.Index) > 0)
            ContactsList.RemoveAt(xIndex);
      // }

    }

    public void EditContact(cContact xEditedContact) {
      //funkcja wywołująca funkcję aktualizującą wpis w bazie danych
      //xEditedContact - edytowany kontakt

      cContact_DAO pContactDAO = new cContact_DAO();

      pContactDAO.UpdateContact(xEditedContact);

    }

    public void UpdateContactsList() {
      //funkcja odświeżająca listę kontaktów (pobiera ją ponownie z bazy danych)

      cContact_DAO pContactDAO = new cContact_DAO();

      ContactsList = new BindingList<cContact>(pContactDAO.GetContactsList());

    }

  }
}
