namespace Model;
using Npgsql;
using System.Drawing;


public class dbManager
{   
    static private string postgresConfig = "User ID=" + Environment.GetEnvironmentVariable("DATABASE_USER") +
                                           ";Password=" + Environment.GetEnvironmentVariable("DATABASE_PASSWORD") + 
                                           ";Host=" + Environment.GetEnvironmentVariable("DATABASE_HOST") + 
                                           ";Database=" + Environment.GetEnvironmentVariable("DATABASE_ID") + 
                                           ";Pooling=true;TrustServerCertificate=True";

    public static NpgsqlConnection getDBConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(postgresConfig);
        conn.Open();
        return conn;
    }

}
