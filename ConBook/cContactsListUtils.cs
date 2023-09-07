using System.ComponentModel;

namespace ConBook {
  internal class cContactsListUtils {
    //Klasa odpowiadająca za obsługę listy konktatków

    private BindingList<cContact> mContacts;                  // lista przechowująca kontakty

    public BindingList<cContact> Contacts { get { return mContacts; } set { mContacts = value; } }

    public cContactsListUtils() {

      mContacts = new BindingList<cContact>();

    }
    
    public void DeleteContact(int xIndex) {
      //funkcja usuwająca kontakt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {Contacts[xIndex].Name} {Contacts[xIndex].Surname} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        Contacts.RemoveAt(xIndex);

      }

    }

    public void AddContact(cContact xContact) {
      //funkcja dodająca kontakt do listy

      xContact.Index = GetNewIndex();
      Contacts.Add(xContact);

    }

    public void EditContact(cContact xEditedContact, int xIndex) {
      //funkcja edytująca istniejący kontakt

      Contacts[xIndex] = xEditedContact;

    }

    public void EditContact(string xNewName, string xNewSurname, string xNewPhone, int xIndex) {
      // unkcja edytująca istniejący kontakt

      cContact pEditedContact = new cContact(xNewName, xNewSurname, xNewPhone);

      Contacts[xIndex] = pEditedContact;

    }

    private int GetNewIndex() {
      if (Contacts.Count == 0) return 0;
      return Contacts.Max(contact => contact.Index) + 1;
    }

  }
}
