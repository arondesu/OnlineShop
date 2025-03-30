using MySql.Data.MySqlClient;

public class DBConn {

    private string connectionString;
    private MySqlConnection conn;

    public MySqlConnection connectSql() {

        try {
            connectionString = $"server=localhost; database=applianceDB; uid=root; pwd=root;";
            conn = new MySqlConnection(connectionString);

            //MessageBox.Show(conn == null ? "❌ Database connection failed!" : "✅ Database Connection successful", "Connection Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine(conn == null ? "❌ Database connection failed!" : "✅ Database Connection successful");
            return conn;

        } catch(Exception e) {
            //MessageBox.Show("Error connecting to database: " + e.Message, "Connection Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine("Error connecting to database: " + e.Message);
            return null;
        }

    }
}