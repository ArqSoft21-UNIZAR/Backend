namespace Model;
using Npgsql;
using System.Drawing;


public class dbManager
{   
    static private string user_bd = Environment.GetEnvironmentVariable("DATABASE_USER");
    static private string password_bd = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
    static private string host_bd = Environment.GetEnvironmentVariable("DATABASE_HOST");

    static private string port_bd = Environment.GetEnvironmentVariable("DATABASE_PORT");

    static private string id_bd = Environment.GetEnvironmentVariable("DATABASE_ID");
    static private string postgresConfig = "User ID=" + user_bd + ";Password=" + password_bd + 
                                           ";Host=" + host_bd + ";Port=" + port_bd + ";Database=" + id_bd + ";Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True";

    public static NpgsqlConnection getDBConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(postgresConfig);
        conn.Open();
        return conn;
    }

}
