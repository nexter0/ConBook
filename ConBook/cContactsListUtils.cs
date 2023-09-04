using System.ComponentModel;

namespace ConBook {
  internal class cContactsListUtils {
    //Klasa odpowiadająca za obsługę listy konktatków

    private BindingList<cContact> mContacts;                  // Lista przechowująca kontakty
    private cContactSerializer mSerializer;                   // klasa do zapisu i wczytywania listy kontaktów

    public BindingList<cContact> Contacts { get { return mContacts; } set { mContacts = value; } }
    public cContactSerializer Serializer { get { return mSerializer; } }

    public cContactsListUtils() {

      mContacts = new BindingList<cContact>();
      mSerializer = new cContactSerializer();

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

      Contacts.Add(xContact);

    }

    public void AddContact(string xName, string xSurname, string xPhone) {
      //funkcja dodająca kontakt do listy

      cContact pNewContact = new cContact(xName, xSurname, xPhone);

      Contacts.Add(pNewContact);

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

  }
}
