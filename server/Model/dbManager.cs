namespace Model;
using Npgsql;
using System.Drawing;


public class dbManager
{   
    static private string postgresConfig = "User ID=" + Environment.GetEnvironmentVariable("DATABASE_USER") +
                                           ";Password=" + Environment.GetEnvironmentVariable("DATABASE_PASSWORD") + 
                                           ";Host=" + Environment.GetEnvironmentVariable("DATABASE_HOST") + 
                                           ";Port=" + Environment.GetEnvironmentVariable("DATABASE_PORT") + 
                                           ";Database=" + Environment.GetEnvironmentVariable("DATABASE_ID") + 
                                           ";Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True";

    public static NpgsqlConnection getDBConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(postgresConfig);
        conn.Open();
        return conn;
    }

}
