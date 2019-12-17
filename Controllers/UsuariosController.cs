using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Backend.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiController]
  public class UsuariosController : ControllerBase
  {

    private readonly UsuariosService _usuariosService;

    public UsuariosController(UsuariosService usuariosService)
    {
      _usuariosService = usuariosService;
    }

    [HttpGet]
    public ActionResult<List<Usuarios>> Get() =>
      _usuariosService.Get();

    [HttpGet("{id:length(24)}", Name = "GetUser")]
    public ActionResult<Usuarios> Get(string id)
    {
      var usuario = _usuariosService.Get(id);
      if (usuario == null)
      {
        return NotFound();
      }
      return usuario;
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

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var usuario = _usuariosService.Get(id);
      if (usuario == null)
      {
        return NotFound();
      }
      _usuariosService.Remove(usuario.Id);
      return NoContent();
    }
  }
}