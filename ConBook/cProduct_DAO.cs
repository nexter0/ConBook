using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace ConBook {
  internal class cProduct_DAO {

    private const string TABLE_NAME = "products";
    private const string COLUMN_NAME_INDEX = "idx";
    private const string COLUMN_NAME_NAME = "name";
    private const string COLUMN_NAME_SYMBOL = "symbol";
    private const string COLUMN_NAME_PRICE = "price";

    public List<cProduct>? GetProductsList() {
      //funkcja pobierająca produkty z bazy danych i zwracająca ich kolekcję

      List<cProduct> pProductsList = new List<cProduct>();

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using (NpgsqlCommand pCommand = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME} ORDER BY {COLUMN_NAME_INDEX}", pConnection)) {

            using (NpgsqlDataReader pReader = pCommand.ExecuteReader()) {
              if (pReader.HasRows) {
                while (pReader.Read()) {
                  cProduct pProduct = new cProduct();

                  pProduct.Index = pReader.GetInt32(COLUMN_NAME_INDEX);
                  pProduct.Name = pReader.GetString(COLUMN_NAME_NAME);
                  pProduct.Symbol = pReader.GetString(COLUMN_NAME_SYMBOL);
                  pProduct.Price = (double)pReader.GetDecimal(COLUMN_NAME_PRICE);


                  pProductsList.Add(pProduct);

                }
              }
            }
          }
        }
        return pProductsList;

      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return null;

    }

    public int InsertProduct (cProduct xProduct) {
      //funkcja dodająca produkt do bazy danych
      //xProduct - indeks produktu do dodania

      string pInsertCommand = $"INSERT INTO {TABLE_NAME} ({COLUMN_NAME_NAME}, {COLUMN_NAME_SYMBOL}, {COLUMN_NAME_PRICE}) " +
        "VALUES (@paramName, @paramSymbol, @paramPrice);";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pInsertCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramName", xProduct.Name);
          pCommand.Parameters.AddWithValue("@paramSymbol", xProduct.Symbol);

          NpgsqlParameter pParamPrice = new NpgsqlParameter("@paramPrice", NpgsqlDbType.Money);
          pParamPrice.Value = (decimal)xProduct.Price;
          pCommand.Parameters.Add(pParamPrice);



          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;

    }

    public int DropProduct(int xProductIndex) {
      //funkcja usuwająca produkt z bazy danych
      //xProductIndex - indeks produktu do usunięcia

      string pDropCommand = $"DELETE FROM {TABLE_NAME} WHERE {COLUMN_NAME_INDEX}={xProductIndex}";

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

    public int UpdateProduct(cProduct xEditedProduct) {
      //funkcja edytująca kontakt w bazie danych
      //xEditedContact - edytowany produkt

      string pUpdateCommand = $"UPDATE {TABLE_NAME} SET {COLUMN_NAME_NAME} = @paramName, {COLUMN_NAME_SYMBOL} = @paramSymbol, {COLUMN_NAME_PRICE} = @paramPrice WHERE {COLUMN_NAME_INDEX} = {xEditedProduct.Index};";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pUpdateCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramName", xEditedProduct.Name);
          pCommand.Parameters.AddWithValue("@paramSymbol", xEditedProduct.Symbol);

          NpgsqlParameter pParamPrice = new NpgsqlParameter("@paramPrice", NpgsqlDbType.Money);
          pParamPrice.Value = (decimal)xEditedProduct.Price;
          pCommand.Parameters.Add(pParamPrice);


          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;

    }

  }
}
