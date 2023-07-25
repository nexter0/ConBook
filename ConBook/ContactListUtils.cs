// Klasa odpowiadająca za funkcje typu CRUD konktatków do listy konktatków
namespace ConBook {
  internal class cContactListUtils {
    private IMainComponents mMainForm;

    public cContactListUtils(IMainComponents xMainForm) {

      mMainForm = xMainForm;

    }


    public void DeleteContact() {
      // funkcja usuwająca kontakt z listy

      DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
          $" {mMainForm.mContacts[mMainForm.mSelectedRowIndex].Name} {mMainForm.mContacts[mMainForm.mSelectedRowIndex].Surname} z listy?",
          "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (deletionQueryResult == DialogResult.Yes) {

        mMainForm.mContacts.RemoveAt(mMainForm.mSelectedRowIndex);
        mMainForm.RefreshDataGridView();

      }

    }

    public void AddContact(string xName, string xSurname, string xPhone) {
      // funkcja dodająca kontakt do listy

      cContact pNewContact = new cContact(xName, xSurname, xPhone);
      mMainForm.mContacts.Add(pNewContact);

      mMainForm.RefreshDataGridView();
    }

    public void EditContact(string xNewName, string xNewSurname, string xNewPhone) {
      // funkcja edytująca istniejący kontakt

      cContact pEditedContact = new cContact(xNewName, xNewSurname, xNewPhone);
      mMainForm.mContacts[mMainForm.mSelectedRowIndex] = pEditedContact;

      mMainForm.RefreshDataGridView();

    }

  }
}
