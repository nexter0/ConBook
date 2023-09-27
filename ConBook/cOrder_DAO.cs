using System.Data;
using Npgsql;

namespace ConBook {
  internal class cOrder_DAO {

    private const string TABLE_NAME = "orders";
    private const string COLUMN_NAME_INDEX = "idx";
    private const string COLUMN_NAME_NUMBER = "number";
    private const string COLUMN_NAME_DATE = "date_created";
    private const string COLUMN_NAME_CONTACT = "contact_idx";

    public List<cOrder>? GetOrdersList() {
      //funkcja pobierająca kontakty z bazy danych i zwracająca ich kolekcję

      List<cOrder> pOrdersList = new List<cOrder>();

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using (NpgsqlCommand pCommand = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME} ORDER BY {COLUMN_NAME_INDEX}", pConnection)) {

            using (NpgsqlDataReader pReader = pCommand.ExecuteReader()) {
              if (pReader.HasRows) {
                while (pReader.Read()) {
                  cOrder pOrder = new cOrder();

                  pOrder.Index = pReader.GetInt32(COLUMN_NAME_INDEX);
                  pOrder.Number = pReader.GetString(COLUMN_NAME_NUMBER);
                  pOrder.CreationDate = DateTime.Parse(pReader.GetString(COLUMN_NAME_DATE));
                  pOrder.IdxContact = pReader.GetInt32(COLUMN_NAME_CONTACT);

                  pOrdersList.Add(pOrder);

                }
              }
            }
          }
        }
          return pOrdersList;

      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return null;

    }

    public int InsertOrder(cOrder xOrder) {
      //funkcja dodająca zamówienie do bazy danych
      //xOrder - zamówienie do dodania

      string pInsertCommand = $"INSERT INTO {TABLE_NAME} ({COLUMN_NAME_NUMBER}, {COLUMN_NAME_DATE}, {COLUMN_NAME_CONTACT}) " +
        "VALUES (@paramNumber, @paramDate, @paramContact);";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pInsertCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramNumber", xOrder.Number);
          pCommand.Parameters.AddWithValue("@paramDate", xOrder.CreationDate);
          pCommand.Parameters.AddWithValue("@paramContact", xOrder.IdxContact);

          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;

    }

    public int DropOrder(int xOrderIndex) {
      //funkcja usuwająca kontakt z bazy danych
      //xContactIndex - indeks kontaktu do usunięcia

      string pDropCommand = $"DELETE FROM {TABLE_NAME} WHERE {COLUMN_NAME_INDEX}={xOrderIndex}";

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

    public int UpdateOrder(cOrder xEditedOrder) {
      //funkcja edytująca kontakt w bazie danych
      //xEditedContact - edytowany kontakt

      string pUpdateCommand = $"UPDATE {TABLE_NAME} SET {COLUMN_NAME_NUMBER} = @paramNumber, {COLUMN_NAME_DATE} = @paramDate, {COLUMN_NAME_CONTACT} = @paramContact WHERE {COLUMN_NAME_INDEX} = {xEditedOrder.Index};";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pUpdateCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramNumber", xEditedOrder.Number);
          pCommand.Parameters.AddWithValue("@paramDate", xEditedOrder.CreationDate);
          pCommand.Parameters.AddWithValue("@paramContact", xEditedOrder.IdxContact);


          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;


    }

  }
}
