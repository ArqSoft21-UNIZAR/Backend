using Model;
using System.Threading;
using System.Collections;
using sever.Controllers;

namespace AppLogic.matchesLogic;

public class matchesLogic
{
    // Acceso a datos
    static usersDAO userService = new usersDAO();
    static matchesDAO matchService = new matchesDAO();

    // Cola de espera
    static LinkedList<UserVO> listaEspera = new LinkedList<UserVO>();

    // Gestion de concurrencia
    private static Mutex matchMutex = new Mutex();



    // Devuelve la lista de usuarios con los que esta matcheado
    // el usuario con el email del parametro
    public static async Task<List<UserVO>> getMatches(string email){
        List<string> correos = await matchService.getMatches(email);

        List<UserVO> res = new List<UserVO>();
        foreach(string a in correos){
            UserVO user = await userService.getUser(a);
            res.Add(user);
        }

        return res;
    }

    public static async Task<bool> deleteMatch(string email1, string email2){
        if (await matchService.deleteMatch(email1, email2)){
            return true;
        }
        else{
            return false;
        }
    }

    // Sirve la solicitud de match del usuario con el email del parametro
    public static async Task<bool> requestNewMatch(string email)
    {
        bool ok = true;
        try{
            UserVO user = await userService.getUser(email);
            matchMaker(user);        
        }
        catch(Exception e){
            Console.Write("Error al procesar la solicitud de match de " + email + " :\n" + e);
            ok = false;
        }
        return ok;
    }

    // -------------------
    // |   MATCHMAKING   |
    // -------------------
    // El sistema de matchmaking funciona de la siguiente forma: 
        // Cuando un nuevo usuario solicita match se intenta matchear con
        // todos los de la lista de espera, si no se puede con ninguno se 
        // anade a ella y se espera a que se pueda matchear con alguien
        // de esta formala lista de espera siempre tiene usuarios que no 
        // se pueden matchear entre si. 
        // Utiliza mutex para que la concurrencia rompa este principio
    
    // Intenta emparejar al Usuario con los 
    // de la lista, si no lo anade a esta
    private static async void matchMaker(UserVO newUser){
        bool matched = false;

        // Intenta emparejar con los que esperan
        matchMutex.WaitOne();
        foreach(UserVO oldUser in listaEspera){
            if( await attemptMatch(newUser, oldUser) ){
                // se ha conseguido hacer el match
                listaEspera.Remove(oldUser);
                matched = true;
                break;
            }
        }

        if (!matched){
            // No ha podido emparejar, anade al final de la lista
            listaEspera.AddLast(newUser);
        }

        matchMutex.ReleaseMutex();
    }

    // Verifica que se pueda crear el nuevo match, si es asi lo crea
    // y devuelve true. Si no devuelve false.
    private static async Task<bool> attemptMatch(UserVO u1, UserVO u2){
        bool res = false;
        if (await canMatch (u1, u2)){
            res = await matchService.addMatch(u1.email, u2.email);
            //MatchesHub.NewMatch(u1, u2);
        }
        return res;
    }

    // Comprueba si dos usuarios pueden matchear
    private static async Task<bool> canMatch(UserVO u1, UserVO u2){
        // Mismo usuario
        if(u1.email == u2.email){
            return false;
        }

        // Usuarios matcheados entre si
        if(await matchService.findMatch(u1.email, u2.email) ){
            return false;
        }

        return true;
    }

}