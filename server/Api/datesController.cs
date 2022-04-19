using Microsoft.AspNetCore.Mvc;
using AppLogic.datesLogic;

namespace sever.Controllers;

[ApiController]
[Route("[controller]")]
public class datesController : ControllerBase
{
    public datesController(){

    }


    [HttpPost("acceptCita")]
    public void acceptCita(string email_send, string email_recieve)
    { 
        datesLogic.acceptCita(email_send, email_recieve);
        return;
    }


    [HttpPost("suggestPlan")]
    public void suggestPlan(string email_send, string email_recieve)
    { 
        datesLogic.suggestPlan(email_send, email_recieve);
        return;
    }


    [HttpPost("acceptPlan")]
    public void acceptPlan(string email_send, string email_recieve)
    { 
        datesLogic.acceptPlan(email_send, email_recieve);
        return;
    }


    [HttpPost("sendPlan")]
    public void sendPlan(string email_send, string email_recieve)
    { 
        datesLogic.sendPlan(email_send, email_recieve);
        return;
    }


    [HttpPost("acceptFecha")]
    public void acceptFecha(string email_send, string email_recieve)
    { 
        datesLogic.acceptFecha(email_send, email_recieve);
        return;
    }


    [HttpPost("sendFecha")]
    public void sendFecha(string email_send, string email_recieve, string moment)
    { 
        datesLogic.sendFecha(email_send, email_recieve, moment);
        return;
    }


    [HttpPost("checkStatus")]
    public void checkStatus(string email1, string email2)
    { 
        datesLogic.checkStatus(email1, email2);
        return;
    }

}