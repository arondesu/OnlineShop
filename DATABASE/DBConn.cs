﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShop.DATABASE
{
    internal class DBConn
    {
        private SqlConnection conn; // Change MySqlConnection to SqlConnection
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ADMIN\source\repos\OnlineShop\DATABASE\appliance_db.mdf"";Integrated Security=True";

        public SqlConnection GetConnection() // Change return type to SqlConnection
        {
            try
            {
                conn = new SqlConnection(connectionString); // Initialize SqlConnection
                conn.Open();
                Console.WriteLine("Database connected successfully!");//changed to write to console
                return conn; // Return the SqlConnection object
            }
            catch (Exception)
            {
                Console.WriteLine($"Database connection failed!");
                throw;
            }
            finally//added this to close the conenction after each connect
            {
                conn.Close();
            }
        }
    }
}
