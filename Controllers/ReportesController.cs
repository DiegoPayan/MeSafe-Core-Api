using System.Collections.Generic;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.DTO;

namespace Backend.Controllers
{
  [Route("api/[controller]")]
  [Authorize]
  [ApiController]
  public class ReportesController : ControllerBase
  {
    private readonly ReportesService _reportesService;

    public ReportesController(ReportesService reporteService)
    {
      _reportesService = reporteService;
    }

    [HttpGet]
    public ActionResult<List<ReportesDTO>> get() =>
      _reportesService.Get();

    [HttpGet("{id:length(24)}", Name = "GetReportes")]
    public ActionResult<ReportesDTO> Get(string id)
    {
      var reporte = _reportesService.Get(id);
      if (reporte == null)
      {
        return NotFound();
      }
      return reporte;
    }

    [HttpGet("tipo/{tipo:length(24)}", Name = "GetReportesByType")]
    public ActionResult<List<ReportesDTO>> GetByTipo(string tipo)
    {
      var reporte = _reportesService.GetByTipo(tipo);
      if (reporte == null)
      {
        return NotFound();
      }
      return reporte;
    }

    [HttpGet("alertas")]
    public ActionResult<List<Reportes>> GetAlertas()
    {
      var reporte = _reportesService.GetAlertas();
      if (reporte == null)
      {
        return NotFound();
      }
      return reporte;
    }

    [HttpPost]
    public ActionResult<Reportes> Create(Reportes reporte)
    {
      _reportesService.Create(reporte);
      return CreatedAtRoute("GetReportes", new { id = reporte.Id.ToString() }, reporte);
    }

    [HttpPut("calificar")]
    public IActionResult Rate(ReportesRateDto reporteRateDto)
    {
      _reportesService.RateReport(reporteRateDto.id, reporteRateDto.rate);
      return NoContent();
    }

    [HttpPut("censurar")]
    public IActionResult Censure(CensureImagesDto censureImages)
    {
      _reportesService.CensureReportImage(censureImages.id, censureImages.usuario);
      return NoContent();
    }

    [HttpPut("denuncia/{id:length(24)}")]
    public IActionResult Denunce(string id)
    {
      _reportesService.ReportReport(id);
      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var reporte = _reportesService.Get(id);
      if (reporte == null)
      {
        return NotFound();
      }
      _reportesService.Remove(reporte.Id);
      return NoContent();
    }
  }
}