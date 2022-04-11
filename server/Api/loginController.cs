using Microsoft.AspNetCore.Mvc;
using AppLogic.usersLogic;

namespace sever.Controllers;

[ApiController]
[Route("[controller]")]
public class usersController : ControllerBase
{

    public usersController(){

    }

    // EndPoint para inicios de sesión
    [HttpPost("login")]
    public string login([FromBody] UserDTO user)
    {
        return usersLogic.login(user.email, user.password);
    }


    // EndPoint para registros
    [HttpPost("register")]
    public string register(string email, string hashContrasena)
    { 

        return usersLogic.login(email, hashContrasena);
    }



}