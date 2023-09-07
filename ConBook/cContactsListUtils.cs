using System.ComponentModel;

namespace ConBook {
  internal class cContactsListUtils {
    //Klasa odpowiadająca za obsługę listy konktatków

    private BindingList<cContact> mContactsList;                  // lista przechowująca kontakty
    private int mLastContactIndex;                                // ostatnio przypisany indeks do kontaktu

    public BindingList<cContact> ContactsList { get { return mContactsList; } set { mContactsList = value; } }
    public int LastContactIndex { get { return mLastContactIndex; } set { mLastContactIndex = value; } }

    public cContactsListUtils() {

      mContactsList = new BindingList<cContact>();

      mLastContactIndex = cIndexTracker.GetIndexValue("Contact");

    }
    
    public void DeleteContact(int xIndex) {
      //funkcja usuwająca kontakt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {ContactsList[xIndex].Name} {ContactsList[xIndex].Surname} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        ContactsList.RemoveAt(xIndex);

      }

    }

    public void AddContact(cContact xContact) {
      //funkcja dodająca kontakt do listy

      int pNewContactIndex = LastContactIndex + 1;
      LastContactIndex = pNewContactIndex;
      cIndexTracker.SetIndexValue("Contact", pNewContactIndex);

      xContact.Index = pNewContactIndex;
      ContactsList.Add(xContact);

    }

    public void EditContact(cContact xEditedContact, int xIndex) {
      //funkcja edytująca istniejący kontakt

      ContactsList[xIndex] = xEditedContact;

    }

    public void EditContact(string xNewName, string xNewSurname, string xNewPhone, int xIndex) {
      // unkcja edytująca istniejący kontakt

      cContact pEditedContact = new cContact(xNewName, xNewSurname, xNewPhone);

      ContactsList[xIndex] = pEditedContact;

    }
  }
}
