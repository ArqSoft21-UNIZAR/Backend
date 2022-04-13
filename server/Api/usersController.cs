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
    public IActionResult login([FromBody] UserVO user)
    {
        switch (usersLogic.login(user.email, user.password))
        {
            case 0:
                return Ok();
            case 1:
                return BadRequest(new {message="Contraseña incorrecta", code=1});
            case 2:
                return NotFound();
            default:
                return BadRequest(new {message="Error inesperado", code=-1});
        }
    }

    // EndPoint para registros
    [HttpPost("register")]
    public void register(string email, string hashContrasena)
    {
        usersLogic.register(email, hashContrasena);
        return;
    }

    // Borrar usuario
    [HttpPost("deleteUser")]
    public void deleteUser(string email, string hashContrasena)
    { 
        usersLogic.deleteUser(email, hashContrasena);
        return;
    }

    // Editar perfil
    [HttpPost("edit")]
    public void edit(string nombre, int edad, int sexo, string localidad)
    { 
        usersLogic.edit(nombre, edad, sexo, localidad);
        return;
    }

    // Obtiene información de otro perfil
    [HttpPost("getProfile")]
    public void getProfile(string email)
    { 
        usersLogic.getProfile(email);
        return;
    }

}
