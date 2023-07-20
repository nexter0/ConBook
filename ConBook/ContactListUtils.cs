using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// Klasa odpowiadająca za funkcje typu CRUD konktatków do listy konktatków
namespace ConBook {
    internal class cContactListUtils {
        private IMainComponents mMainForm;

        public cContactListUtils(IMainComponents xMainForm) {
            mMainForm = xMainForm;
        }

        // funkcja usuwająca kontakt z listy
        public void DeleteContact() {
            DialogResult deletionQueryResult = MessageBox.Show($"Usunąć kontakt" +
                $" {mMainForm.mContacts[mMainForm.mSelectedRowIndex].Name} {mMainForm.mContacts[mMainForm.mSelectedRowIndex].Surname} z listy?",
                "Usuń kontakt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (deletionQueryResult == DialogResult.Yes) {
                mMainForm.mContacts.RemoveAt(mMainForm.mSelectedRowIndex);
                mMainForm.RefreshDataGridView();
            }
        }

        // funkcja dodająca kontakt do listy
        public void AddContact(string xName, string xSurname, string xPhone) {
            cContact pNewContact = new cContact(xName, xSurname, xPhone);
            mMainForm.mContacts.Add(pNewContact);
            mMainForm.RefreshDataGridView();
        }

        // funkcja edytująca istniejący kontakt
        public void EditContact(string xNewName, string xNewSurname, string xNewPhone) {
            cContact pEditedContact = new cContact(xNewName, xNewSurname, xNewPhone);
            mMainForm.mContacts[mMainForm.mSelectedRowIndex] = pEditedContact;
            mMainForm.RefreshDataGridView();
        }

    }
}
