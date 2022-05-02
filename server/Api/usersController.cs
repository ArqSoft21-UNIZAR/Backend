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
    public async Task<IActionResult> login([FromBody] UserVO user)
    {
        Console.Write("Ejecutado login con user = "+user.ToString()+"\n");
        switch (await usersLogic.login(user.email, user.password))
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
    public async Task<IActionResult> register([FromBody] UserVO user)
    {
        Console.Write("Ejecutado register con user = "+user.ToString()+"\n");
        switch (await usersLogic.register(user))
        {
            case 0:
                return Ok();
            case 1:
                return BadRequest(new {message="Usuario ya existe", code=1});
            case 2:
                return BadRequest(new {message="Error registrando un nuevo usuario", code=2});
            default:
                return BadRequest(new {message="Error inesperado", code=-1});
        }
    }

    // Borrar usuario
    [HttpPost("delete")]
    public async Task<IActionResult> delete([FromBody] UserVO user)
    {
        Console.Write("Ejecutado delete con user = "+user.ToString()+"\n");
        if (await usersLogic.delete(user.email, user.password))
        {
            return Ok();
        }
        return NotFound();
    }

    // Editar perfil
    [HttpPost("edit")]
    public async Task<IActionResult> edit([FromBody] UserVO user)
    { 
        Console.Write("Ejecutado edit con user = "+user.ToString()+"\n");
        if (await usersLogic.edit(user.email, user.nombre, user.apellidos, user.sexo, user.fNacimiento, user.localidad, user.meGusta1, user.meGusta2, user.meGusta3, user.noMeGusta1, user.noMeGusta2, user.noMeGusta3,user.orientacion,user.capacidad))
        {
            return Ok();
        }
        return BadRequest();
    }

    // Obtiene información de otro perfil
    [HttpPost("get")]
    public async Task<IActionResult> get([FromBody] UserVO user)
    {
        Console.Write("Ejecutado get con user = "+user.ToString()+"\n");
        try
        {
            return Ok(await usersLogic.get(user.email));
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

}
