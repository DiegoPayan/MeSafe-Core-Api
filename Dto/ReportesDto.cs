using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;

namespace Backend.DTO
{
  public class ReportesDTO
  {
    public string Id { get; set; }

    public DateTime fecha { get; set; }

    public string ubicacion { get; set; }

    public string descripcion { get; set; }

    public double postivos { get; set; }

    public double negativos { get; set; }

    public string tipo_reporte { get; set; }

    public double latitud { get; set; }

    public double longitud { get; set; }

    public double denuncias { get; set; }

    public bool emergencia { get; set; }

    public UsuariosDto usuario { get; set; }

    public List<ReportesImagenes> imagenes { get; set; }

    public override string ToString() =>
      new StringBuilder()
        .Append(Id)
        .Append(fecha)
        .Append(ubicacion)
        .Append(postivos)
        .Append(negativos)
        .Append(tipo_reporte)
        .Append(latitud)
        .Append(longitud)
        .Append(emergencia)
        .ToString();
  }
}