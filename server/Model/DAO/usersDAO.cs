using Npgsql;

namespace Model;

public class usersDAO
{
    public NpgsqlConnection conn;
    public usersDAO()
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
            UserVO output = new UserVO(dr.GetString(0),dr.GetDateTime(3),dr.GetString(7),dr.GetString(1),dr.GetString(2),dr.GetString(4),dr.GetString(6),dr.GetString(8),"","",dr.GetString(11),"","");

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
            String query = "INSERT INTO Usuario VALUES ('"+usuario.email+"','"+usuario.nombre+"','"+usuario.apellidos+"','"+
            usuario.fNacimiento.ToString("yyyy-MM-dd")+"','"+usuario.sexo+"','"+usuario.foto+"','"+usuario.localidad+"','"+usuario.password+"','"+
            usuario.meGusta1+"','"+usuario.meGusta2+"','"+usuario.meGusta3+"','"+usuario.noMeGusta1+"','"+usuario.noMeGusta2+"','"+usuario.noMeGusta3+"')";

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

    public bool editUser(UserVO usuario) {
        try
        {
            String query = "UPDATE Usuario SET foto = '"+usuario.foto+"',"+
                                              "localidad = '"+usuario.localidad+"',"+
                                              "meGusta1 = '"+usuario.meGusta1+"',"+
                                              "meGusta2 = '"+usuario.meGusta2+"',"+
                                              "meGusta3 = '"+usuario.meGusta3+"',"+
                                              "noMeGusta1 = '"+usuario.noMeGusta1+"',"+
                                              "noMeGusta2 = '"+usuario.noMeGusta2+"',"+
                                              "noMeGusta3 = '"+usuario.noMeGusta3+"';";
            
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