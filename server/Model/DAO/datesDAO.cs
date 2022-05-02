using Npgsql;

namespace Model;

public class datesDAO
{
    public NpgsqlConnection conn;
    public datesDAO()
    {
        conn = dbManager.getDBConnection();
    }

    public void Dispose() => conn.Close();

    public void suggestPlan(string email_send, string email_recieve)
    {
        //TODO
        return;
    }

    public void acceptPlan(string email_send, string email_recieve)
    {
        //TODO
        return;
    }

    public async Task<PlanVO> getDefaultPlan()
    {
        try {
            
            String query = "SELECT * FROM Plan WHERE predefinido = 'true' ORDER BY random() LIMIT 1;";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = await cmd.ExecuteReaderAsync();
            dr.Read();
            
            PlanVO output = new PlanVO(dr.GetString(1),dr.GetString(2),dr.GetDouble(3),dr.GetDouble(4));

            dr.Close();

            return output;
        }
        catch (System.Exception) {
            throw;
        }
    }

    public void acceptFecha(string email_send, string email_recieve)
    {
        //TODO
        return;
    }

    public void suggestFecha(string email_send, string email_recieve, string moment)
    {
        //TODO
        return;
    }

    public void checkStatus(string email1, string email2)
    {
        //TODO
        return;
    }
}