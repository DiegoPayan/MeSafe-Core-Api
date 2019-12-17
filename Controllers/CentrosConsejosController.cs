using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace Backend.Controllers
{
  [Route("api/consejos")]
  [Authorize]
  [ApiController]
  public class CentrosConsejosController : ControllerBase
  {

    private readonly CentrosConsejosService _centrosConsejos;

    public CentrosConsejosController(CentrosConsejosService centrosConsejos)
    {
      _centrosConsejos = centrosConsejos;
    }

    [HttpGet]
    public ActionResult<List<Consejos>> GetConsejos() =>
      _centrosConsejos.GetConsejos();

    [HttpGet("centros")]
    public ActionResult<List<CentrosAyuda>> GetCentros() =>
      _centrosConsejos.GetCentros();

  }
}