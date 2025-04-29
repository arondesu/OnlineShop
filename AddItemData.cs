using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using OnlineShop.DATABASE;

namespace OnlineShop
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

                string SelectItem = "SELECT * FROM items WHERE date_delete IS NULL";

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
                        aid.Price = reader["item_price"]?.ToString();
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
