using System;
using Microsoft.AspNetCore.Mvc;
using AppLogic.chatsLogic;

namespace sever.Controllers;

[ApiController]
[Route("[controller]")]
public class chatsController : ControllerBase
{
    public chatsController(){

    }

    [HttpPost("get")]
    public async Task<ChatVO> getChat([FromBody] ChatVO chat)
    {
        return await chatsLogic.getChat(chat.emisor, chat.receptor);
    }
}



