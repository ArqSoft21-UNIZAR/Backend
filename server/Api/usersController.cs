using System;
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
                return BadRequest(new {message="Usuario no existe", code=2});
            default:
                return BadRequest(new {message="Error inesperado", code=-1});
        }
    }

    // EndPoint para registros
    [HttpPost("register")]
    public IActionResult register([FromBody] UserVO user)
    {
        if (usersLogic.register(user))
        {
            return Ok();
        }
        //TODO: Gestion del error Usuario ya existe como en login 
        return BadRequest();
    }

    // Borrar usuario
    [HttpPost("delete")]
    public IActionResult delete([FromBody] UserVO user)
    {
        if (usersLogic.delete(user.email, user.password))
        {
            return Ok();
        }
        return NotFound();
    }

    // Editar perfil
    [HttpPost("edit")]
    public IActionResult edit([FromBody] UserVO user)
    { 
        if (usersLogic.edit(user.email, user.nombre, user.apellidos, user.sexo, user.fNacimiento, user.localidad, user.meGusta1, user.meGusta2, user.meGusta3, user.noMeGusta1, user.noMeGusta2, user.noMeGusta3))
        {
            return Ok();
        }
        return BadRequest();
    }

    // Obtiene información de otro perfil
    [HttpPost("get")]
    public IActionResult get([FromBody] UserVO user)
    {
        try
        {
            return Ok(usersLogic.get(user.email));
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

}
