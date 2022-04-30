using Model;
using System.Threading;
using System.Collections;

namespace AppLogic.matchesLogic;

public class matchesLogic
{
    // Acceso a datos
    static usersDAO service = new usersDAO();

    // Cola de espera
    static ArrayList<UserVO> listaEspera = new ArrayList<UserVO>();
    private static Semaphore nuevaSolicitud = new Semaphore(0, 5);

    // Gestion de threads
    private static bool working = false;


    public static async Task<bool> requestMatch(string email)
    {
        bool ok = true;
        try{
            // Lanza thread que empareja
            if (!working){
                Thread t = new Thread(new ThreadStart(matchMaker));
                t.Start();
                working = true;
            }
            
            UserVO user = service.getUser(email);
            listaEspera.add(user);
            nuevaSolicitud.Release();
        }
        catch(Exception e){
            Console.Write("Error al procesar la solicitud de match de " + email + " :\n" + e);
            ok = false;
        }
        return ok;
    }

    // Funcion que ejecuta en un thread paralelo  
    // para componer los matches
    private static async void matchMaker(){
        matchesDAO dao = new matchesDAO();
        while (true) {
            // logica MUY BASICA (Se puede mejorar)
            nuevaSolicitud.WaitOne();
            

            

        }
    }

    // llama a model para crear el nuevo match
    private static bool nuevoMatch(UserVO u1, UserVO u2){
        
    }

    //comprueba si dos usuarios pueden matchear
    private static bool canMatch(){
        
    }



}