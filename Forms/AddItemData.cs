using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using OnlineShop.DATABASE;

namespace OnlineShop.Forms
{
    internal class AddItemData
    {
        private DBConn dbConn = new DBConn(); //calling DBConn class

        public int ID { get; set; }
        public int? ItemID { get; set; }
        public string? ItemName { get; set; }
        public string? Type { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public string? Image { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }

        public List<AddItemData> itemListData()
        {
            List<AddItemData> listDatas = new List<AddItemData>();

            try
            {
                using SqlConnection conn = dbConn.GetConnection();
                conn.Open();

                // Modified query to correctly join with Inventory table
                string SelectItem = @"SELECT i.*, 
                                    inv.ProductName as inv_productname,
                                    inv.Description as inv_description, 
                                    inv.PurchasePrice as inv_price 
                                    FROM items i 
                                    INNER JOIN Inventory inv ON i.item_name = inv.ProductName 
                                    WHERE i.date_delete IS NULL";

                using (SqlCommand cmd = new SqlCommand(SelectItem, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AddItemData aid = new AddItemData();

                        aid.ID = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
                        aid.ItemID = reader["item_id"] != DBNull.Value ? Convert.ToInt32(reader["item_id"]) : (int?)null;
                        aid.ItemName = reader["item_name"]?.ToString();
                        aid.Type = reader["item_type"]?.ToString();
                        aid.Stock = reader["item_stock"] != DBNull.Value ? Convert.ToInt32(reader["item_stock"]) : (int?)null;
                        aid.Price = reader["inv_price"] != DBNull.Value ? Convert.ToDecimal(reader["inv_price"]) :
                                    (reader["item_price"] != DBNull.Value ? Convert.ToDecimal(reader["item_price"]) : (decimal?)null);
                        aid.Status = reader["item_status"]?.ToString();
                        aid.Image = reader["item_image"]?.ToString();
                        aid.DateInsert = reader["date_insert"] != DBNull.Value ? Convert.ToDateTime(reader["date_insert"]) : (DateTime?)null;
                        aid.DateUpdate = reader["date_update"] != DBNull.Value ? Convert.ToDateTime(reader["date_update"]) : (DateTime?)null;

                        listDatas.Add(aid);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                using SqlConnection conn = dbConn.GetConnection();
                conn.Close();
            }

            return listDatas;
        }
    }
}
