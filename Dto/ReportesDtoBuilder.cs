using System;
using System.Collections.Generic;
using Backend.Models;

namespace Backend.DTO
{
  public class ReportesDtoBuilder
  {
    private ReportesDTO _reportesDto;

    public ReportesDtoBuilder Create(string id)
    {
      _reportesDto = new ReportesDTO();
      _reportesDto.Id = id;
      return this;
    }

    public ReportesDtoBuilder Fecha(DateTime fecha)
    {
      _reportesDto.fecha = fecha;
      return this;
    }

    public ReportesDtoBuilder Ubicacion(string ubicacion)
    {
      _reportesDto.ubicacion = ubicacion;
      return this;
    }

    public ReportesDtoBuilder Descripcion(string descripcion)
    {
      _reportesDto.descripcion = descripcion;
      return this;
    }

    public ReportesDtoBuilder Positivos(double postivos)
    {
      _reportesDto.postivos = postivos;
      return this;
    }

    public ReportesDtoBuilder Negativos(double negativos)
    {
      _reportesDto.negativos = negativos;
      return this;
    }

    public ReportesDtoBuilder TipoReporte(string tipo_reporte)
    {
      _reportesDto.tipo_reporte = tipo_reporte;
      return this;
    }

    public ReportesDtoBuilder Latitud(double latitud)
    {
      _reportesDto.latitud = latitud;
      return this;
    }

    public ReportesDtoBuilder Longitud(double longitud)
    {
      _reportesDto.longitud = longitud;
      return this;
    }

    public ReportesDtoBuilder Denuncias(double denuncias)
    {
      _reportesDto.denuncias = denuncias;
      return this;
    }

    public ReportesDtoBuilder Emergencia(bool emergencia)
    {
      _reportesDto.emergencia = emergencia;
      return this;
    }

    public ReportesDtoBuilder Usuario(UsuariosDto usuario)
    {
      _reportesDto.usuario = usuario;
      return this;
    }

    public ReportesDtoBuilder Imagenes(List<ReportesImagenes> imagenes)
    {
      _reportesDto.imagenes = imagenes;
      return this;
    }

    public ReportesDTO Build()
    {
      return _reportesDto;
    }
  }
}