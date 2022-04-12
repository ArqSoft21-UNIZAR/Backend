using Microsoft.AspNetCore.Mvc;
using AppLogic.chatsLogic;

namespace sever.Controllers;

[ApiController]
[Route("[controller]")]
public class chatsController : ControllerBase
{
    public chatsController(){

    }

    [HttpPost("getChats")]
    public void checkStatus(string email)
    { 
        chatsLogic.getChats(email);
        return;
    }

    [HttpPost("sendMessage")]
    public void sendMessage(string email_send, string email_recieve, string message)
    { 
        chatsLogic.sendMessage(email_send, email_recieve, message);
        return;
    }
}



