using Npgsql;

namespace Model;

public class chatsDAO
{
    public NpgsqlConnection conn;
    public chatsDAO()
    {
        conn = dbManager.getDBConnection();
    }

    public bool saveMessage(string sender, string reciever, string content, DateTime date)
    {
        try
        {
            Console.Write(date.ToString());
            String query = "INSERT INTO Mensaje VALUES(DEFAULT,'"+sender+"','"+reciever+"','"+content+"','"+
            date.ToString()+"')";

            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            cmd.ExecuteNonQuery(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public ChatVO getChat(string sender, string reciever)
    {
        //TODO
        return new ChatVO();
    }
}
