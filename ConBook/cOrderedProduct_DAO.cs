using System.Data;
using System.Transactions;
using Npgsql;
using NpgsqlTypes;

namespace ConBook {
  internal class cOrderedProduct_DAO {

    private const string TABLE_NAME = "ordered_products";
    private const string COLUMN_NAME_INDEX = "idx";
    private const string COLUMN_NAME_PRODUCT = "product_idx";
    private const string COLUMN_NAME_ORDER = "order_idx";
    private const string COLUMN_NAME_QUANTITY = "quantity";
    private const string COLUMN_NAME_PRICE_SOLD = "price_sold";

    public List<cOrderedProduct>? GetOrderedProductsList() {
      //funkcja pobierająca "zamówione produkty" z bazy danych i zwracająca ich kolekcję

      List<cOrderedProduct> pOrderedProductsList = new List<cOrderedProduct>();

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using (NpgsqlCommand pCommand = new NpgsqlCommand($"SELECT * FROM {TABLE_NAME} ORDER BY {COLUMN_NAME_INDEX}", pConnection)) {

            using (NpgsqlDataReader pReader = pCommand.ExecuteReader()) {
              if (pReader.HasRows) {
                while (pReader.Read()) {
                  cOrderedProduct pOrderedProduct = new cOrderedProduct();

                  pOrderedProduct.Index = pReader.GetInt32(COLUMN_NAME_INDEX);
                  pOrderedProduct.IdxProduct = pReader.GetInt32(COLUMN_NAME_PRODUCT);
                  pOrderedProduct.IdxOrder = pReader.GetInt32(COLUMN_NAME_ORDER);
                  pOrderedProduct.Price_Sold = (double)pReader.GetDecimal(COLUMN_NAME_PRICE_SOLD);


                  pOrderedProductsList.Add(pOrderedProduct);

                }
              }
            }
          }
        }
        return pOrderedProductsList;

      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return null;

    }

    public int InsertOrderedProduct (cOrderedProduct xOrderedProduct) {
      //funkcja dodająca "zamówiony produkt" do bazy danych
      //xOrderedProduct - "zamówiony produkt do dodania

      string pInsertCommand = $"INSERT INTO {TABLE_NAME} ({COLUMN_NAME_ORDER}, {COLUMN_NAME_PRODUCT}, {COLUMN_NAME_QUANTITY}, {COLUMN_NAME_PRICE_SOLD}) " +
        "VALUES (@paramIdxOrder, @paramIdxProduct, @paramQuantity, @paramPriceSold);";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pInsertCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramIdxOrder", xOrderedProduct.IdxOrder);
          pCommand.Parameters.AddWithValue("@paramIdxProduct", xOrderedProduct.IdxProduct);
          pCommand.Parameters.AddWithValue("@paramQuantity", xOrderedProduct.Quantity);

          NpgsqlParameter pParamPrice = new NpgsqlParameter("@paramPriceSold", NpgsqlDbType.Money);
          pParamPrice.Value = (decimal)xOrderedProduct.Price_Sold;
          pCommand.Parameters.Add(pParamPrice);



          return pCommand.ExecuteNonQuery();

        }
      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;

    }

    public int InsertOrderedProduct(cOrderedProduct xOrderedProduct, NpgsqlConnection xConnection) {
      //funkcja dodająca "zamówiony produkt" do bazy danych
      //xOrderedProduct - "zamówiony produkt do dodania

      string pInsertCommand = $"INSERT INTO {TABLE_NAME} ({COLUMN_NAME_ORDER}, {COLUMN_NAME_PRODUCT}, {COLUMN_NAME_QUANTITY}, {COLUMN_NAME_PRICE_SOLD}) " +
        "VALUES (@paramIdxOrder, @paramIdxProduct, @paramQuantity, @paramPriceSold);";

      try {

          using NpgsqlCommand pCommand = new NpgsqlCommand(pInsertCommand, xConnection);

          pCommand.Parameters.AddWithValue("@paramIdxOrder", xOrderedProduct.IdxOrder);
          pCommand.Parameters.AddWithValue("@paramIdxProduct", xOrderedProduct.IdxProduct);
          pCommand.Parameters.AddWithValue("@paramQuantity", xOrderedProduct.Quantity);

          NpgsqlParameter pParamPrice = new NpgsqlParameter("@paramPriceSold", NpgsqlDbType.Money);
          pParamPrice.Value = (decimal)xOrderedProduct.Price_Sold;
          pCommand.Parameters.Add(pParamPrice);

          return pCommand.ExecuteNonQuery();

      } catch (Exception ex) {
        MessageBox.Show(ex.Message, "Błąd bazy danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return -1;

    }

    public int DropOrderedProduct(int xOrderedProductIndex) {
      //funkcja usuwająca produkt z bazy danych
      //xProductIndex - indeks produktu do usunięcia

      string pDropCommand = $"DELETE FROM {TABLE_NAME} WHERE {COLUMN_NAME_INDEX}={xOrderedProductIndex}";

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

    public int UpdateProduct(cOrderedProduct xEditedOrderedProduct) {
      //funkcja edytująca kontakt w bazie danych
      //xEditedContact - edytowany produkt

      string pUpdateCommand = $"UPDATE {TABLE_NAME} SET {COLUMN_NAME_ORDER} = @paramIdxOrder, {COLUMN_NAME_PRODUCT} = @paramIdxProduct, {COLUMN_NAME_QUANTITY} = @paramQuantity, {COLUMN_NAME_PRICE_SOLD} = @paramPriceSold WHERE {COLUMN_NAME_INDEX} = {xEditedOrderedProduct.Index};";

      try {

        using (NpgsqlConnection pConnection = new NpgsqlConnection(cDataBaseService.CONNECTION_DATA)) {
          pConnection.Open();

          using NpgsqlCommand pCommand = new NpgsqlCommand(pUpdateCommand, pConnection);

          pCommand.Parameters.AddWithValue("@paramIdxOrder", xEditedOrderedProduct.IdxOrder);
          pCommand.Parameters.AddWithValue("@paramIdxProduct", xEditedOrderedProduct.IdxProduct);
          pCommand.Parameters.AddWithValue("@paramQuantity", xEditedOrderedProduct.Quantity);

          NpgsqlParameter pParamPrice = new NpgsqlParameter("@paramPriceSold", NpgsqlDbType.Money);
          pParamPrice.Value = (decimal)xEditedOrderedProduct.Price_Sold;
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
