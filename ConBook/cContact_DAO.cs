using System.Data;
using Npgsql;

namespace ConBook {
  internal class cContact_DAO {

    private const string TABLE_NAME = "contact";
    private const string COLUMN_NAME_INDEX = "idx";
    private const string COLUMN_NAME_NAME = "name";
    private const string COLUMN_NAME_SURNAME = "surname";
    private const string COLUMN_NAME_PHONE = "phone_number";
    private const string COLUMN_NAME_DESCRIPTION = "description";
    private const string COLUMN_NAME_NOTES = "notes";

    public List<cContact>? GetContactsList() {
      //funkcja pobierająca kontakty z bazy danych i zwracająca ich kolekcję

      List<cContact> pContactsList = new List<cContact>();

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using (NpgsqlCommand pCommand = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME} ORDER BY {COLUMN_NAME_INDEX}", pConnection)) {

            using (NpgsqlDataReader pReader = pCommand.ExecuteReader()) {
              if (pReader.HasRows) {
                while (pReader.Read()) {
                  cContact pContact = new cContact();

                  pContact.Index = pReader.GetInt32(COLUMN_NAME_INDEX);
                  pContact.Name = pReader.GetString(COLUMN_NAME_NAME);
                  pContact.Surname = pReader.GetString(COLUMN_NAME_SURNAME);
                  pContact.Phone = pReader.GetString(COLUMN_NAME_PHONE);
                  if (!pReader.IsDBNull(COLUMN_NAME_DESCRIPTION))
                    pContact.Description = pReader.GetString(COLUMN_NAME_DESCRIPTION);
                  if (!pReader.IsDBNull(COLUMN_NAME_NOTES))
                    pContact.Notes = pReader.GetString(COLUMN_NAME_NOTES);

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
      //xContact - kontakt do dodania

      string pInsertCommand = $"INSERT INTO {TABLE_NAME} ({COLUMN_NAME_NAME}, {COLUMN_NAME_SURNAME}, {COLUMN_NAME_PHONE}, {COLUMN_NAME_DESCRIPTION}, {COLUMN_NAME_NOTES}) " +
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

      string pDropCommand = $"DELETE FROM {TABLE_NAME} WHERE {COLUMN_NAME_INDEX}={xContactIndex}";

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

      string pUpdateCommand = $"UPDATE {TABLE_NAME} SET {COLUMN_NAME_NAME} = @paramName, {COLUMN_NAME_SURNAME} = @paramSurname, {COLUMN_NAME_PHONE} = @paramPhone," +
        $" {COLUMN_NAME_DESCRIPTION} = @paramDesc, {COLUMN_NAME_NOTES} = @paramNotes WHERE {COLUMN_NAME_INDEX} = {xEditedContact.Index};";

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
