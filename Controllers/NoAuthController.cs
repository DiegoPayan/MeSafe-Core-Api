using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Backend.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class NoAuthController : ControllerBase
  {

    private readonly UsuariosService _usuariosService;

    public NoAuthController(UsuariosService usuariosService)
    {
      _usuariosService = usuariosService;
    }

  

    [HttpPost]
    public ActionResult<Usuarios> Create(Usuarios usuario)
    {
      _usuariosService.Create(usuario);
      return CreatedAtRoute("GetUser", new { id = usuario.Id.ToString() }, usuario);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Usuarios usuarioIn)
    {
      var usuario = _usuariosService.Get(id);
      if (usuario == null)
      {
        return NotFound();
      }
      _usuariosService.Update(id, usuarioIn);
      return NoContent();
    }

  }
}
