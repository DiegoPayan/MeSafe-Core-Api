using System.Collections.Generic;
using Backend.Models;
using Backend.utils;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;
using Backend.DTO;

namespace Backend.Services
{
  public class ReportesService
  {
    private readonly IMongoCollection<Reportes> _reportes;
    private readonly IMongoCollection<ReportesImagenes> _reportesImages;
    private readonly IMongoCollection<Usuarios> _usuarios;

    public ReportesService(IMeSafeDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _reportes = database.GetCollection<Reportes>(settings.ReportsCollectionName);
      _reportesImages = database.GetCollection<ReportesImagenes>(settings.ReportsImagesCollectionName);
      _usuarios = database.GetCollection<Usuarios>(settings.UsersCollectionName);
    }

    public List<ReportesDTO> Get()
    {
      var response = new List<ReportesDTO>();
      var reporte = _reportes.Find(reportes => true && reportes.emergencia == false).ToList();
      reporte.ForEach(delegate (Reportes repo)
      {
        var userCredentials = _usuarios.Find<Usuarios>(usuarioCon => usuarioCon.Id == repo.id_usuario).FirstOrDefault();
        var usuario = new UsuariosDto();
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

        var reportesDTO = new ReportesDtoBuilder()
          .Create(repo.Id)
          .Fecha(repo.fecha)
          .Ubicacion(repo.ubicacion)
          .Descripcion(repo.descripcion)
          .Positivos(repo.postivos)
          .Negativos(repo.negativos)
          .TipoReporte(repo.tipo_reporte)
          .Latitud(repo.latitud)
          .Longitud(repo.longitud)
          .Denuncias(repo.denuncias)
          .Emergencia(repo.emergencia)
          .Usuario(usuario)
          .Imagenes(_reportesImages.Find<ReportesImagenes>(imagenes => imagenes.id_reporte == repo.Id).ToList())
          .Build();
        response.Add(reportesDTO);
      });
      return response;
    }

    public ReportesDTO Get(string id)
    {
      var response = new ReportesDTO();
      var repo = _reportes.Find<Reportes>(reporte => reporte.Id == id && reporte.emergencia == false).FirstOrDefault();
      var userCredentials = _usuarios.Find<Usuarios>(usuarioCon => usuarioCon.Id == repo.id_usuario).FirstOrDefault();
      var usuario = new UsuariosDto();
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
      var reportesDTO = new ReportesDtoBuilder()
          .Create(repo.Id)
          .Fecha(repo.fecha)
          .Ubicacion(repo.ubicacion)
          .Descripcion(repo.descripcion)
          .Positivos(repo.postivos)
          .Negativos(repo.negativos)
          .TipoReporte(repo.tipo_reporte)
          .Latitud(repo.latitud)
          .Longitud(repo.longitud)
          .Denuncias(repo.denuncias)
          .Emergencia(repo.emergencia)
          .Usuario(usuario)
          .Imagenes(_reportesImages.Find<ReportesImagenes>(imagenes => imagenes.id_reporte == repo.Id).ToList())
          .Build();
      return reportesDTO;
    }

    public List<ReportesDTO> GetByTipo(string tipo)
    {
      var response = new List<ReportesDTO>();
      var reporte = _reportes.Find(reportes => reportes.tipo_reporte == tipo && reportes.emergencia == false).ToList();
      reporte.ForEach(delegate (Reportes repo)
      {
        var userCredentials = _usuarios.Find<Usuarios>(usuarioCon => usuarioCon.Id == repo.id_usuario).FirstOrDefault();
        var usuario = new UsuariosDto();
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

        var reportesDTO = new ReportesDtoBuilder()
          .Create(repo.Id)
          .Fecha(repo.fecha)
          .Ubicacion(repo.ubicacion)
          .Descripcion(repo.descripcion)
          .Positivos(repo.postivos)
          .Negativos(repo.negativos)
          .TipoReporte(repo.tipo_reporte)
          .Latitud(repo.latitud)
          .Longitud(repo.longitud)
          .Denuncias(repo.denuncias)
          .Emergencia(repo.emergencia)
          .Usuario(usuario)
          .Imagenes(_reportesImages.Find<ReportesImagenes>(imagenes => imagenes.id_reporte == repo.Id).ToList())
          .Build();
        response.Add(reportesDTO);
      });
      return response;
    }

    public List<Reportes> GetAlertas()
    {
      var reporte = _reportes.Find(reportes => reportes.emergencia == true).Limit(3).SortByDescending(reportes => reportes.Id).ToList();
      return reporte;
    }

    public Reportes Create(Reportes reporte)
    {
      _reportes.InsertOne(reporte);
      var file = new UploadFiles();
      if (reporte.imagenes != null)
      {
        //var imagenes = file.saveImagesAsync("reporte-" + reporte.Id.ToString(), reporte.imagenes);
        reporte.imagenes.ForEach(delegate (string image)
        {
          var reporteImages = new ReportesImagenes()
          {
            id_reporte = reporte.Id,
            imagen = image,
            reportes_censura = 0,
            estatus = "A"
          };
          _reportesImages.InsertOne(reporteImages);
        });
      }
      return reporte;
    }

    public void RateReport(string id, float rate)
    {
      var varReporte = _reportes.Find(reporte => reporte.Id == id).FirstOrDefault();
      if (varReporte != null)
      {
        if (rate == -1)
        {
          varReporte.negativos = varReporte.negativos + 1;
        }
        else
        {
          varReporte.postivos = varReporte.postivos + 1;
        }
      }
      _reportes.ReplaceOne(reporte => reporte.Id == varReporte.Id, varReporte);
    }

    public void CensureReportImage(string id, int usuario)
    {
      var varReporteImagen = _reportesImages.Find(reporteImagen => reporteImagen.Id == id).FirstOrDefault();
      if (varReporteImagen != null)
      {
        if( usuario == 0) {
          varReporteImagen.reportes_censura = varReporteImagen.reportes_censura + 1;
        } else if (usuario == 1) {
          varReporteImagen.reportes_censura = varReporteImagen.reportes_censura + 10;
        }
        _reportesImages.ReplaceOne(reporteImagen => reporteImagen.Id == varReporteImagen.Id, varReporteImagen);
      }
    }

    public void ReportReport(string id) {
      var reporte = _reportes.Find(reporte1 => reporte1.Id == id).FirstOrDefault();
      if (reporte != null) {
        reporte.denuncias = reporte.denuncias + 1;
      }
      _reportes.ReplaceOne(reporte2 => reporte2.Id == reporte.Id, reporte);
    }

    public void Remove(string id) =>
      _reportes.DeleteOne(reporte => reporte.Id == id);
  }
}