using System.Data;
using System.Diagnostics.Contracts;
using Npgsql;

namespace ConBook {
  internal class cContactDAO {

    private const string TABLE_NAME = "contact";
    private const string COLUMN_INDEX = "idx";
    private const string COLUMN_NAME = "name";
    private const string COLUMN_SURNAME = "surname";
    private const string COLUMN_PHONE = "phone_number";
    private const string COLUMN_DESCRIPTION = "description";
    private const string COLUMN_NOTES = "notes";

    public List<cContact>? GetContactList() {
      //funkcja pobierająca kontakty z bazy danych i zwracająca ich kolekcję

      List<cContact> pContactsList = new List<cContact>();

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using (NpgsqlCommand pCommand = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME} ORDER BY {COLUMN_INDEX}", pConnection)) {

            using (NpgsqlDataReader pReader = pCommand.ExecuteReader()) {
              if (pReader.HasRows) {
                while (pReader.Read()) {
                  cContact pContact = new cContact();

                  pContact.Index = pReader.GetInt32(COLUMN_INDEX);
                  pContact.Name = pReader.GetString(COLUMN_NAME);
                  pContact.Surname = pReader.GetString(COLUMN_SURNAME);
                  pContact.Phone = pReader.GetString(COLUMN_PHONE);
                  if (!pReader.IsDBNull(COLUMN_DESCRIPTION))
                    pContact.Description = pReader.GetString(COLUMN_DESCRIPTION);
                  if (!pReader.IsDBNull(COLUMN_NOTES))
                    pContact.Notes = pReader.GetString(COLUMN_NOTES);

                  pContactsList.Add(pContact);

                }
              }
            }
          }
        }
          return pContactsList;

      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return null;

    }

    public int InsertContact(cContact xContact) {
      //funkcja dodająca kontakt do bazy danych
      //xContact - indeks kontaktu do dodania

      string pInsertCommand = $"INSERT INTO {TABLE_NAME} ({COLUMN_NAME}, {COLUMN_SURNAME}, {COLUMN_PHONE}, {COLUMN_DESCRIPTION}, {COLUMN_NOTES}) " +
        "VALUES (@paramName, @paramSurname, @paramPhone, @paramDesc, @paramNotes);";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pInsertCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramName", xContact.Name);
          pCommand.Parameters.AddWithValue("@paramSurname", xContact.Surname);
          pCommand.Parameters.AddWithValue("@paramPhone", xContact.Phone);
          pCommand.Parameters.AddWithValue("@paramDesc", xContact.Description);
          pCommand.Parameters.AddWithValue("@paramNotes", xContact.Notes);

          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;

    }

    public int DropContact(int xContactIndex) {
      //funkcja usuwająca kontakt z bazy danych
      //xContactIndex - indeks kontaktu do usunięcia

      string pDropCommand = $"DELETE FROM {TABLE_NAME} WHERE {COLUMN_INDEX}={xContactIndex}";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pDropCommand, pConnection);

          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;
    }

    public int UpdateContact(cContact xEditedContact) {
      //funkcja edytująca kontakt w bazie danych
      //xEditedContact - edytowany kontakt

      string pUpdateCommand = $"UPDATE {TABLE_NAME} SET {COLUMN_NAME} = @paramName, {COLUMN_SURNAME} = @paramSurname, {COLUMN_PHONE} = @paramPhone, {COLUMN_DESCRIPTION} = @paramDesc, {COLUMN_NOTES} = @paramNotes WHERE {COLUMN_INDEX} = {xEditedContact.Index};";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pUpdateCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramName", xEditedContact.Name);
          pCommand.Parameters.AddWithValue("@paramSurname", xEditedContact.Surname);
          pCommand.Parameters.AddWithValue("@paramPhone", xEditedContact.Phone);
          pCommand.Parameters.AddWithValue("@paramDesc", xEditedContact.Description);
          pCommand.Parameters.AddWithValue("@paramNotes", xEditedContact.Notes);

          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;


    }

  }
}
