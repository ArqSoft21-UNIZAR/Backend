using Npgsql;

namespace Model;

public class matchesDAO
{

    public NpgsqlConnection conn;
    public matchesDAO()
    {
        conn = dbManager.getDBConnection();
    }

    public void Dispose() => conn.Close();


    public async Task<bool> addMatch(string email1, string email2)
    {
        if( email1 == email2){
            return false;
        }

        try {
            
            String query;
            if(email1 < email2){
                query = "INSERT INTO Match VALUES ('" + email1 + "','" + email2 + "')";
            } 
            else{
                query = "INSERT INTO Match VALUES ('" + email2 + "','" + email1 + "')";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            await cmd.ExecuteNonQueryAsync(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            
            return true;
        }
        catch (System.Exception) {
            throw;
        }
    }

    public async Task<bool> findMatch(string email1, string email2){
        try {
            
            String query;
            if(email1 < email2){
                query = "SELECT FROM Match WHERE usuario1 = '" + email1 + "' and usuario2 = '" + email2 + "'";
            } 
            else{
                query = "SELECT FROM Match WHERE usuario1 = '" + email2 + "' and usuario2 = '" + email1 + "'";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            await cmd.ExecuteNonQueryAsync(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            
            return true;
        }
        catch (System.Exception) {
            throw;
        }
    }
}