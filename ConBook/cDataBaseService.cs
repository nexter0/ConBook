using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using Npgsql;

namespace ConBook {
  internal class cDataBaseService {

    private const string DATABASE_NAME = "conbook";
    public const string CONNECTION_DATA = $"Host=localhost;Port=5432;Username=postgres;Password=postgreSQL;Database={DATABASE_NAME};Include Error Detail=true";

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
      List<string> pExistingTablesList = new List<string>();


      using (NpgsqlCommand pCmd = new NpgsqlCommand()) {

        pCmd.Connection = xConnection;

        string pQuery = @"SELECT table_name 
                            FROM information_schema.tables 
                            WHERE table_type = 'BASE TABLE' 
                            AND table_schema NOT IN ('pg_catalog', 'information_schema')";

        using (var pCommand = new NpgsqlCommand(pQuery, xConnection)) {

          using (var pReader = pCommand.ExecuteReader()) {
            while (pReader.Read()) {
              pExistingTablesList.Add(pReader.GetString(0));
            }
          }

        }

        foreach (string pTable in pTablesList) {
          if (!pExistingTablesList.Contains(pTable))
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

    public void CreateMissingTables() {

      List<string> pTablesList = new List<string> { "contacts", "products", "orders", "ordered_products" };
      List<string> pTableNames = new List<string>();

      using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
        pConnection.Open();

        using (NpgsqlCommand pCmd = new NpgsqlCommand()) {

          string pQuery = @"SELECT table_name 
                            FROM information_schema.tables 
                            WHERE table_type = 'BASE TABLE' 
                            AND table_schema NOT IN ('pg_catalog', 'information_schema')";

          using (var pCommand = new NpgsqlCommand(pQuery, pConnection)) {

            using (var pReader = pCommand.ExecuteReader()) {
              while (pReader.Read()) {
                pTableNames.Add(pReader.GetString(0));
              }
            }

          }

          foreach (string pTable in pTablesList)
            if (!pTableNames.Contains(pTable)) {
              if (pTable == "orders") {

              }
            }
          
        }

        }


      }
    }
  }
}
