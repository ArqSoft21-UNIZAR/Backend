using Microsoft.AspNetCore.Mvc;

namespace AppLogic.usersLogic;

public class usersLogic
{
    public static int login(string email, string hashContrasena)
    {
        Model.user realUser = new Model.user(email);
        
        if(realUser != null){
            // Usuario existe
            if(realUser.hashContrasena == hashContrasena){
                // Contrasenas coinciden
                return 0;
            }
            else{
                // Contrasenas no coinciden
                return 1;
            }
        }
        else{
            return 2;
        }
    }

    public static void register(string email, string hashContrasena)
    {

    }

    public static void deleteUser(string email, string hashContrasena)
    {
        
    }

    public static void edit(string nombre, int edad, int sexo, string localidad)
    {
        
    }

    public static void getProfile(string email)
    {
        
    }

    
}