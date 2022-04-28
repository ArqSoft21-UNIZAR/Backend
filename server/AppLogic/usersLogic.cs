using Microsoft.AspNetCore.Mvc;
using Model;

namespace AppLogic.usersLogic;

public class usersLogic
{
    static usersDAO service = new usersDAO();


    public static async Task<int> login(string email, string password)
    {
        try
        {
            UserVO data = await service.getUser(email);
            if (data.password==password) {
                // Contrasenas coinciden
                return 0;
            }
            else {
                // Contrasenas no coinciden
                return 1;
            }
        }
        catch (System.Exception)
        {
            //Usuario no existe
            return 2;
        }
    }


    public static async Task<int> register(UserVO user)
    {
        if (await service.createUser(user)) {
            return 0;
        }
        else {
            try {
                await service.getUser(user.email);
                return 1; //Ya existe un usuario
            }
            catch (System.Exception e) {
                Console.Write(e);
                return 2; //No se pudo crear el usuario
            }
        }
    }


    public static async Task<bool> delete(string email, string password)
    {
        return await service.deleteUser(email,password);
    }


    public static async Task<bool> edit(string email, string nombre, string apellidos, string sexo, DateTime fNacimiento, string localidad, string meGusta1, string meGusta2, string meGusta3, string noMeGusta1, string noMeGusta2, string noMeGusta3)
    {
        try
        {
            UserVO user = await service.getUser(email);

            user.nombre = nombre;
            user.apellidos = apellidos;
            user.localidad = localidad;
            user.meGusta1 = meGusta1;
            user.meGusta2 = meGusta2;
            user.meGusta3 = meGusta3;
            user.noMeGusta1 = noMeGusta1;
            user.noMeGusta2 = noMeGusta2;
            user.noMeGusta3 = noMeGusta3;

            // service.editUser(user);
            await service.deleteUser(user.email, user.password); //TODO: esto es una chapuza ¿metodo update en usersDAO?
            await service.createUser(user);

            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public static async Task<UserVO> get(string email)
    {
        return await service.getUser(email);
    }
}