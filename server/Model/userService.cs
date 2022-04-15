using Npgsql;

namespace Model;

public class userService
{
    public NpgsqlConnection conn;
    public userService()
    {
        conn = dbManager.getDBConnection();
    }


    public UserVO getUser(string email)
    {
        try {
            String query = "SELECT * FROM Usuario WHERE email = '" + email + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            UserVO output = new UserVO(dr.GetString(0),dr.GetString(7),dr.GetString(1),dr.GetString(2),dr.GetString(4),18,dr.GetString(6),dr.GetString(8),"","",dr.GetString(11),"","");

            dr.Close();

            return output;
        }
        catch (System.Exception) {
            throw;
        }
    }


    public bool createUser(UserVO usuario)
    {
        try
        {
            String query = "INSERT INTO Usuario VALUES ('"+usuario.email+"','"+usuario.nombre+"','"+usuario.apellidos+"',"+
            " '"+usuario.edad+"','"+usuario.sexo+"','"+usuario.foto+"','"+usuario.localidad+"','"+usuario.password+"', "+
            " '"+usuario.meGusta1+"','"+usuario.meGusta2+"','"+usuario.meGusta3+"','"+usuario.noMeGusta1+"','"+usuario.noMeGusta2+"','"+usuario.noMeGusta3+"')";
            
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            cmd.ExecuteNonQuery(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }


    public bool deleteUser(string email, string password)
    {
        try
        {
            String query = "DELETE FROM Usuario WHERE email = '" + email + "' AND hashContrasena = '" + password + "'";
            
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

            cmd.ExecuteNonQuery(); // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}