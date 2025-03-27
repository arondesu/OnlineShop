using MySql.Data.MySqlClient;

public class DBFunc {
    private DBConn conn = new DBConn();

    public bool additem() {

        try{
            using MySqlConnection connection = conn.connectSql();

            connection.Open();

            string query = "INSERT INTO item (name) VALUES ('value1')";
        }
    }
}