using Microsoft.AspNetCore.Mvc;
using AppLogic.usersLogic;
using AppLogic.datesLogic;
using AppLogic.chatsLogic;

namespace sever.Controllers;

[ApiController]
[Route("[controller]")]
public class usersController : ControllerBase
{

    public usersController(){

    }

    // EndPoint para inicios de sesión
    [HttpPost("login")]
    public string login(string email, string hashContrasena)
    { 

        return usersLogic.login(email, hashContrasena);
    }

    // EndPoint para registros
    [HttpPost("register")]
    public string register(string email, string hashContrasena)
    { 

        return usersLogic.register(email, hashContrasena);
    }

    // Borrar usuario
    [HttpPost("deleteUser")]
    public string deleteUser(string email, string hashContrasena)
    { 

        return usersLogic.deleteUser(email, hashContrasena);
    }

    // Editar perfil
    [HttpPost("edit")]
    public string edit(string nombre, int edad, int sexo, string localidad)
    { 

        return usersLogic.edit(nombre, edad, sexo, localidad);
    }

    // Obtiene información de otro perfil
    [HttpPost("getProfile")]
    public string getProfile(string email)
    { 

        return usersLogic.getProfile(email);
    }

}

[ApiController]
[Route("[controller]")]
public class datesController : ControllerBase
{
    public datesController(){

    }


    [HttpPost("acceptCita")]
    public string acceptCita(string email_send, string email_recieve)
    { 

        return datesLogic.acceptCita(email_send, email_recieve);
    }


    [HttpPost("suggestPlan")]
    public string suggestPlan(string email_send, string email_recieve)
    { 

        return datesLogic.suggestPlan(email_send, email_recieve);
    }


    [HttpPost("acceptPlan")]
    public string acceptPlan(string email_send, string email_recieve)
    { 

        return datesLogic.acceptPlan(email_send, email_recieve);
    }


    [HttpPost("sendPlan")]
    public string sendPlan(string email_send, string email_recieve)
    { 

        return datesLogic.sendPlan(email_send, email_recieve);
    }


    [HttpPost("sendFecha")]
    public string sendFecha(string email_send, string email_recieve, string moment)
    { 

        return datesLogic.sendFecha(email_send, email_recieve, moment);
    }


    [HttpPost("acceptFecha")]
    public string acceptFecha(string email_send, string email_recieve)
    { 

        return datesLogic.acceptFecha(email_send, email_recieve);
    }


    [HttpPost("checkStatus")]
    public string checkStatus(string email1, string email2)
    { 

        return datesLogic.acceptFecha(email1, email2);
    }

}

[ApiController]
[Route("[controller]")]
public class chatController : ControllerBase
{
    public chatController(){

    }

    [HttpPost("getChats")]
    public string checkStatus(string email)
    { 

        return chatLogic.getChats(email);
    }

    [HttpPost("sendMessage")]
    public string sendMessage(string email_send, string email_recieve, string message)
    { 

        return chatLogic.sendMessage(email_send, email_recieve, message);
    }
}



