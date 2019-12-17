using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Backend.DTO;

namespace Backend.Controllers
{
  [Route("api/conocidos")]
  [Authorize]
  [ApiController]
  public class ConocidosController : ControllerBase
  {

    private readonly ConocidosService _conocidos;

    public ConocidosController(ConocidosService conocidos)
    {
      _conocidos = conocidos;
    }

    [HttpGet("{id:length(24)}", Name = "GetSolicitudes")]
    public ActionResult<List<Conocidos>> GetSolicitudes(string id) =>
      _conocidos.getSolicitudes(id);

    [HttpPost]
    public ActionResult<Conocidos> postConocidos (Conocidos conocidos) {
      _conocidos.Create(conocidos);
       return CreatedAtRoute("GetSolicitudes", new { id = conocidos.Id.ToString() }, conocidos);
    }

  }
}