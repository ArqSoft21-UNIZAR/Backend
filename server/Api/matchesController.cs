using System;
using Microsoft.AspNetCore.Mvc;
using AppLogic.chatsLogic;

namespace sever.Controllers;

[ApiController]
[Route("[controller]")]
public class matchesController : ControllerBase
{
    public matchesController(){
        
    }

    [HttpPost("get")]
    public async Task<IActionResult> requestMatch([FromBody] UserVO user)
    {
        if (await matchesController.requestMatch(user.email)){
            return Ok();
        }
        else{
            return BadRequest(new {message="Error inesperado", code=-1});
        }
    }
}



