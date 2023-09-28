using System.ComponentModel;
using System.Data.Common;
using Npgsql;

namespace ConBook {
  internal class cDataBaseService {

    private const string DATABASE_NAME = "conbook";
    public const string CONNECTION_DATA = $"Host=localhost;Port=5432;Username=postgres;Password=postgreSQL;Database={DATABASE_NAME}";

    public const int CONTACT_NAME_MAXLEN = 32;
    public const int CONTACT_SURNAME_MAXLEN = 64;
    public const int CONTACT_PHONE_MAXLEN = 20;
    public const int CONTACT_DESC_MAXLEN = 256;
    public const int CONTACT_NOTES_MAXLEN = 32;
    public const int PRODUCT_NAME_MAXLEN = 128;
    public const int PRODUCT_SYMBOL_MAXLEN = 32;

    public Exception? Test_DB_Connection() {

      try {

        var pConnection  = new NpgsqlConnection(CONNECTION_DATA);

        pConnection.Open();

        if (!Check_DB_TablesExist(pConnection))
          throw new Exception("Brak lub nieprawidłowa struktura bazy danych");

        pConnection.Close();

        //MessageBox.Show("Zakończono pomyślnie.");
        return null;

      }
      catch (Exception ex) {
        //MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return ex;
      }

    }

    private bool Check_DB_TablesExist(NpgsqlConnection xConnection) {

      List<string> pTablesList = new List<string> {"contacts", "products", "orders", "ordered_products"};

      using (NpgsqlCommand pCmd = new NpgsqlCommand()) {

        pCmd.Connection = xConnection;

        foreach (string pTable in pTablesList) {
          pCmd.CommandText = $"SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = '{pTable}') AS table_exists;";

          bool pTableExists = (bool)pCmd.ExecuteScalar();
          if (!pTableExists)
            return false;
        }
      }
      return true;

    }

    public bool Create_DB_Tables() {

      var pConnection = new NpgsqlConnection(CONNECTION_DATA);

      try {

        pConnection.Open();

        if (Check_DB_TablesExist(pConnection)) {

          MessageBox.Show("Wszystkie tabele w bazie danych istnieją.", "Baza danych istnieje", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return false;
        }

        string pQuery = $@"
            CREATE TABLE contacts (
              idx SERIAL NOT NULL PRIMARY KEY,
              name VARCHAR({CONTACT_NAME_MAXLEN}) NOT NULL,
              surname VARCHAR({CONTACT_SURNAME_MAXLEN}) NOT NULL,
              phone_number VARCHAR({CONTACT_PHONE_MAXLEN}) NOT NULL,
              description VARCHAR({CONTACT_DESC_MAXLEN}),
              notes VARCHAR({CONTACT_NOTES_MAXLEN})
             );

            CREATE TABLE products (
              idx SERIAL NOT NULL PRIMARY KEY,
              name VARCHAR({PRODUCT_NAME_MAXLEN}) NOT NULL,
              symbol VARCHAR({PRODUCT_SYMBOL_MAXLEN}) NOT NULL,
              price MONEY NOT NULL
             );

            CREATE TABLE orders (
              idx SERIAL NOT NULL PRIMARY KEY,
              number VARCHAR(16) NOT NULL,
              date_created DATE NOT NULL,
              contact_idx INTEGER NOT NULL REFERENCES contacts(idx) ON DELETE CASCADE
             );

            CREATE TABLE ordered_products (
              idx SERIAL NOT NULL PRIMARY KEY,
              order_idx INTEGER REFERENCES orders(idx) ON DELETE CASCADE,
              product_idx INTEGER REFERENCES products(idx),
              quantity INT NOT NULL DEFAULT 1,
              price_sold MONEY NOT NULL
             );";

        using (NpgsqlCommand pCmd = new NpgsqlCommand()) {

          pCmd.Connection = pConnection;
          pCmd.CommandText = pQuery;
          pCmd.ExecuteNonQuery();

        }

        pConnection.Close();

        return true;

      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return false;

    }

  }
}
