namespace Model;
using Npgsql;
using System.Drawing;


public class dbManager
{   
    private const string postgresConfig = "Server=127.0.0.1;User Id=postgres;Password=postgres;Database=postgres;";

    public static NpgsqlConnection getDBConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection("User ID="+Environment.GetEnvironmentVariable("DATABASE_USER")+";Password="+Environment.GetEnvironmentVariable("DATABASE_PASSWORD")+";Host="+Environment.GetEnvironmentVariable("DATABASE_HOST")+";Port="+Environment.GetEnvironmentVariable("DATABASE_PORT")+";Database="+Environment.GetEnvironmentVariable("DATABASE_ID")+";Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;");
        conn.Open();
        return conn;
    }

}
