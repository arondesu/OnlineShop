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

        public int ID { get; set; } //index 0
        public string? ItemID { get; set; } // Nullable to avoid CS8618
        public string? ItemName { get; set; } // Nullable to avoid CS8618
        public string? Type { get; set; } // Nullable to avoid CS8618
        public string? Stock { get; set; } // Nullable to avoid CS8618
        public string? Price { get; set; } // Nullable to avoid CS8618
        public string? Status { get; set; } // Nullable to avoid CS8618
        public string? Image { get; set; } // Nullable to avoid CS8618
        public string? DateInsert { get; set; } // Nullable to avoid CS8618
        public string? DateUpdate { get; set; } // Nullable to avoid CS8618

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
                                    LEFT JOIN Inventory inv ON i.item_name = inv.ProductName 
                                    WHERE i.date_delete IS NULL";

                using (SqlCommand cmd = new SqlCommand(SelectItem, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AddItemData aid = new AddItemData();

                        aid.ID = reader["id"] != DBNull.Value ? (int)reader["id"] : 0;
                        aid.ItemID = reader["item_id"]?.ToString();
                        aid.ItemName = reader["item_name"]?.ToString();
                        aid.Type = reader["item_type"]?.ToString();
                        aid.Stock = reader["item_stock"]?.ToString();
                        // Use PurchasePrice from Inventory if available, otherwise fallback to items price
                        aid.Price = reader["inv_price"]?.ToString() ?? reader["item_price"]?.ToString();
                        aid.Status = reader["item_status"]?.ToString();
                        aid.Image = reader["item_image"]?.ToString();
                        aid.DateInsert = reader["date_insert"]?.ToString();
                        aid.DateUpdate = reader["date_update"]?.ToString();

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
