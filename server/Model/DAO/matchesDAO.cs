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
            if(string.Compare(email1,email2)>=0){
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

    public async Task<bool> deleteMatch(string email1,string email2){
        try {
            
            String query;
            if(string.Compare(email1,email2)>=0){
                query = "DELETE FROM Match WHERE usuario1 = '" + email1 + "' AND usuario2 = '" + email2 + "')";
            } 
            else{
                query = "DELETE FROM Match WHERE usuario1 = '" + email2 + "' AND usuario2 = '" + email1 + "')";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            await cmd.ExecuteNonQueryAsync(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            
            return true;
        }
        catch (System.Exception) {
            throw;
        }
    }

    // Devuelve true si existe un match entre los dos usuarios
    // false si no
    public async Task<bool> findMatch(string email1, string email2){
        try {
            
            String query;
            if(string.Compare(email1,email2)>=0){
                query = "SELECT FROM Match WHERE usuario1 = '" + email1 + "' and usuario2 = '" + email2 + "'";
            } 
            else{
                query = "SELECT FROM Match WHERE usuario1 = '" + email2 + "' and usuario2 = '" + email1 + "'";
            }

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 
            NpgsqlDataReader dr = await cmd.ExecuteReaderAsync();

            bool res = dr.HasRows;

            dr.Close();

            return res;
        }
        catch (System.Exception) {
            throw;
        }
    }

    public async Task<List<string>> getMatches(string email){
        try{
            
            List<string> matchesList = new List<string>(); 

            string query1 = "SELECT usuario2 FROM Match WHERE usuario1 = '" + email + "'";
            string query2 = "SELECT usuario1 FROM Match WHERE usuario2 = '" + email + "'";

            NpgsqlCommand cmd = new NpgsqlCommand(query1, conn);
            NpgsqlDataReader dr = await cmd.ExecuteReaderAsync();
            while (dr.Read()){
                string match = dr.GetString(0);
                matchesList.Add(match);
            }
            dr.Close();

            cmd = new NpgsqlCommand(query2, conn);
            dr = await cmd.ExecuteReaderAsync();
            while (dr.Read()){
                string match = dr.GetString(0);
                matchesList.Add(match);
                
            }
            dr.Close();

            return matchesList;
        }
        catch (System.Exception) {
            throw;
        }
    }
}