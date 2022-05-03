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

    [HttpPost("request")]
    public async Task<IActionResult> requestMatch([FromBody] UserVO user)
    {
        if (await matchesLogic.requestNewMatch(user.email)){
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

    [HttpPost("delete")]
    public async Task<IActionResult> deleteMatch([FromBody] MatchVO match)
    {
        if (await matchesLogic.deleteMatch(match.email1, match.email2)){
            return Ok();
        }
        else{
            return BadRequest(new {message="Error inesperado", code=-1});
        }
    }
}



