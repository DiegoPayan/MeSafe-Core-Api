using System;
using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Backend.utils;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly AuthService _authService;
    private readonly RolesService _rolesService;

    public AuthController(AuthService authService, RolesService rolesService)
    {
      _authService = authService;
      _rolesService = rolesService;
    }

    [HttpPost]
    public ActionResult<AuthDTo> Create([FromBody] LoginDto loginDto) {
      var userCredentials = _authService.Login(loginDto);
      var response = new AuthDTo();
      var usuario = new UsuariosDto();
      if(userCredentials != null) {
        
        usuario.Id = userCredentials.Id;
        usuario.nombres = userCredentials.nombres;
        usuario.apellidos = userCredentials.apellidos;
        usuario.email = userCredentials.email;
        usuario.estado = userCredentials.estado;
        usuario.municipio = userCredentials.municipio;
        usuario.colonia = userCredentials.colonia;
        usuario.genero = userCredentials.genero;
        usuario.edad = userCredentials.edad;
        usuario.ocupacion = userCredentials.ocupacion;
        usuario.celular = userCredentials.celular;
        usuario.imagen = userCredentials.imagen;
        usuario.registro_completo = userCredentials.registro_completo;
        usuario.censura_imagenes = userCredentials.censura_imagenes;
        usuario.estatus = userCredentials.estatus;

        var token = _authService.requestToken(loginDto);
        response.usuario = usuario;
        response.rol = _rolesService.Get(userCredentials.id_rol);
        response.token = response.extractToken(token.Result);
        return Ok(response);
      }
      return NotFound("Credenciales de usuario invalidas");
    }
  }
}