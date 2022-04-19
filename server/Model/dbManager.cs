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
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=postgres;Database=postgres;");
        //PARA PRUEBAS LOCALES: "Server=127.0.0.1;User Id=postgres;Password=postgres;Database=postgres;"
        conn.Open();
        return conn;
    }

}
