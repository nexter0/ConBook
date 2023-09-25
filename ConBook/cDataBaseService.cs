using System.ComponentModel;
using System.Data.Common;
using Npgsql;

namespace ConBook {
  internal class cDataBaseService {

    private const string DATABASE_NAME = "conbook";
    public const string CONNECTION_DATA = $"Host=localhost;Port=5432;Username=postgres;Password=postgreSQL;Database={DATABASE_NAME}";
    

    public Exception? TestConnection() {

      try {

        var pConnection  = new NpgsqlConnection(CONNECTION_DATA);

        pConnection.Open();

        if (!DBTablesExist(pConnection))
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

    private bool DBTablesExist(NpgsqlConnection xConnection) {

      List<string> pTablesList = new List<string> {"contact", "product", "order", "ordered_product"};

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

    public bool CreateDBTables() {

      var pConnection = new NpgsqlConnection(CONNECTION_DATA);

      try {

        pConnection.Open();

        if (DBTablesExist(pConnection)) {

          MessageBox.Show("Wszystkie tabele w bazie danych istnieją.", "Baza danych istnieje", MessageBoxButtons.OK, MessageBoxIcon.Information);
          return false;
        }

        string pQuery = @"
            CREATE TABLE contact (
              idx SERIAL NOT NULL PRIMARY KEY,
              name VARCHAR(32) NOT NULL,
              surname VARCHAR(64) NOT NULL,
              phone_number VARCHAR(20) NOT NULL,
              description VARCHAR(256),
              notes VARCHAR(256)
             );

            CREATE TABLE product (
              idx SERIAL NOT NULL PRIMARY KEY,
              name VARCHAR(128) NOT NULL,
              symbol VARCHAR(32) NOT NULL,
              price MONEY NOT NULL
             );

            CREATE TABLE ""order"" (
              idx SERIAL NOT NULL PRIMARY KEY,
              number VARCHAR(16),
              date_created DATE,
              contact_idx INTEGER NOT NULL REFERENCES contact(idx)
             );

            CREATE TABLE ordered_product (
              order_idx INTEGER REFERENCES ""order""(idx),
              product_idx INTEGER REFERENCES product(idx),
              quantity INT NOT NULL DEFAULT 1,
              price_sold MONEY NOT NULL,
              PRIMARY KEY (order_idx, product_idx)
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
