using System.ComponentModel;
using System.Xml.Linq;

namespace ConBook {
  internal class cContactListUtils {
    // Klasa odpowiadająca za funkcje typu CRUD konktatków


    public void DeleteContact(BindingList<cContact> xContactList, int xIndex) {
      // funkcja usuwająca kontakt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {xContactList[xIndex].Name} {xContactList[xIndex].Surname} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        xContactList.RemoveAt(xIndex);

      }

    }

    public void AddContact(cContact xContact, BindingList<cContact> xContactList) {
      // funkcja dodająca kontakt do listy

      xContactList.Add(xContact);

    }

    public void AddContact(string xName, string xSurname, string xPhone, BindingList<cContact> xContactList) {
      // funkcja dodająca kontakt do listy

      cContact pNewContact = new cContact(xName, xSurname, xPhone);
      xContactList.Add(pNewContact);

    }

    public void EditContact(cContact xEditedContact, BindingList<cContact> xContactList, int xIndex) {
      // funkcja edytująca istniejący kontakt

      xContactList[xIndex] = xEditedContact;

    }

    public void EditContact(string xNewName, string xNewSurname, string xNewPhone, BindingList<cContact> xContactList, int xIndex) {
      // funkcja edytująca istniejący kontakt

      cContact pEditedContact = new cContact(xNewName, xNewSurname, xNewPhone);
      xContactList[xIndex] = pEditedContact;

    }

  }
}
