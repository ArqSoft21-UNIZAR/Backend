namespace AppLogic.usersLogic;

public class usersLogic
{
    public static string login(string email, string hashContrasena)
    {
        Model.user realUser = new Model.user(email);
        Console.Write(realUser.fNacimiento);
        
        if(realUser != null){
            // Usuario existe
            if(realUser.hashContrasena == hashContrasena){
                // Contrasenas coinciden
                return "Ok";
            }
            else{
                // Contrasenas no coinciden
                return "Contrasena incorrecta";
            }
        }
        else{
            return "Usuario no existe";
        }
    }

    
}