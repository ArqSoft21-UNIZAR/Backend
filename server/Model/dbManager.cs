namespace Model;
using Npgsql;
using System.Drawing;


public class dbManager
{   
    private const string postgresConfig = "Server=127.0.0.1;User Id=postgres;Password=postgres;Database=postgres;";

    public static NpgsqlConnection getDBConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(postgresConfig);
        conn.Open();
        return conn;
    }

}
