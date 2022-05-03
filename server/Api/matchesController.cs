using System;
using Microsoft.AspNetCore.Mvc;
using AppLogic.matchesLogic;

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
        if (await matchesLogic.requestMatch(user.email)){
            return Ok();
        }
        else{
            return BadRequest(new {message="Error inesperado", code=-1});
        }
    }


    [HttpPost("get")]
    public async Task<IEnumerable<UserVO>> getMatches([FromBody] UserVO user)
    {
        return await matchesLogic.getMatches(user.email);
    }
}



