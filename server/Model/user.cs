namespace Model;
using Npgsql;
using System.Drawing;

public class user
{
    public string email { get; set; }
    public string nombre { get; set; }
    public string apellidos { get; set; }
    public DateTime fNacimiento { get; set; }
    public string genero { get; set; }
    public Byte[] foto { get; set; }
    public string localidad { get; set; }
    public string hashContrasena { get; set; }
    public string meGusta1 { get; set; }
    public string meGusta2 { get; set; }
    public string meGusta3 { get; set; }
    public string noMeGusta1 { get; set; }
    public string noMeGusta2 { get; set; }
    public string noMeGusta3 { get; set; }

    public user(string email)
    {  
        // Consulta BD
        NpgsqlConnection conn = dbManager.getDBConnection();

        String query = "SELECT * FROM Usuario WHERE email = '" + email + "'";
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

        NpgsqlDataReader dr = cmd.ExecuteReader();

        dr.Read();

        // Asigna valores
        this.email = dr.GetString(0);
        this.nombre = dr.GetString(1);
        this.apellidos = dr.GetString(2);
        this.fNacimiento = dr.GetDateTime(3);
        this.genero = dr.GetString(4);
        if (!dr.IsDBNull(5)){
            //this.foto = dr.getBytes(5); // NO ESTOY SEGURO DE QUE SEA GETBYTES!!!!!!!!!!!!
        }
        this.localidad = dr.GetString(6);
        this.hashContrasena = dr.GetString(7);

        this.meGusta1 = dr.GetString(8);
        if (!dr.IsDBNull(9)){
            this.meGusta2 = dr.GetString(9);
        }
        if (!dr.IsDBNull(12)){
            this.meGusta3 = dr.GetString(10);
        }

        this.noMeGusta1 = dr.GetString(11);
        if (!dr.IsDBNull(12)){
            this.noMeGusta2 = dr.GetString(12);
        }
        
        if (!dr.IsDBNull(13)){
            this.noMeGusta3 = dr.GetString(13);
        }

        dr.Close();
        conn.Close();
    }
   
    public void login(string email,string hashContrasena)
    {  
        // Consulta BD
        NpgsqlConnection conn = dbManager.getDBConnection();

        String query = "SELECT * FROM Usuario WHERE email = '" + email + "' AND hashContrasena = '" + hashContrasena + "'";
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

        NpgsqlDataReader dr = cmd.ExecuteReader();

        dr.Read();

        // Asigna valores
        this.email = dr.GetString(0);
        this.hashContrasena = dr.GetString(7);
        dr.Close();
        conn.Close();
    }

    public void createUser(user usuario)
    {
       // Consulta BD
        NpgsqlConnection conn = dbManager.getDBConnection();

        String query = "INSERT INTO Usuario VALUES ('"+usuario.email+"','"+usuario.nombre+"','"+usuario.apellidos+"', "+
        " '"+usuario.fNacimiento+"','"+usuario.genero+"','"+usuario.foto+"','"+usuario.localidad+"','"+usuario.hashContrasena+"', "+
        " '"+usuario.meGusta1+"','"+usuario.meGusta2+"','"+usuario.meGusta3+"','"+usuario.noMeGusta1+"','"+usuario.noMeGusta2+"','"+usuario.noMeGusta3+"')";
        
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

        // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
        cmd.ExecuteNonQuery();

        conn.Close();
    }


    public void deleteUser(string email, string hashContrasena)
    {
       // Consulta BD
        NpgsqlConnection conn = dbManager.getDBConnection();

        String query = "DELETE FROM Usuario WHERE email = '" + email + "' AND hashContrasena = '" + hashContrasena + "'";
        
        NpgsqlCommand cmd = new NpgsqlCommand(query, conn); 

        // instrucciones de SQL que ejecutan algo en la base de datos, pero que no devuelven un valor.
        cmd.ExecuteNonQuery();

        conn.Close();
    }
}