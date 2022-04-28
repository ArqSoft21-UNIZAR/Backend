using System.Collections.Generic;
using Npgsql;

namespace Model;

public class chatsDAO
{
    public NpgsqlConnection conn;
    public chatsDAO()
    {
        conn = dbManager.getDBConnection();
    }

    public void Dispose() => conn.Close();

    public async Task<bool> saveMessage(string sender, string reciever, string content, DateTime date)
    {
        try
        {
            String query = "INSERT INTO Mensaje VALUES(DEFAULT,'"+sender+"','"+reciever+"','"+content+"','"+
            date.ToString()+"')";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            await cmd.ExecuteNonQueryAsync(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<List<Message>> GetMessages(string sender, string reciever)
    {
        List<Message> output = new List<Message>();

        String query =  "SELECT * FROM Mensaje WHERE ("+
                        "((emisor_id = '"+sender+"') AND (receptor_id = '"+reciever+"')) OR"+
                        "((emisor_id = '"+reciever+"') AND (receptor_id = '"+sender+"')));";

        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
        
        NpgsqlDataReader dr = await cmd.ExecuteReaderAsync();
        while(dr.Read()){
            Message temp = new Message(dr.GetString(1),dr.GetString(2),dr.GetString(3), dr.GetDateTime(4));
            if (temp.sender == sender) { temp.isSent = true; }
            output.Add(temp);
        }

        dr.Close();

        return output;
    }
}
