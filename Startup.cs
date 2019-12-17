using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvcCore().AddAuthorization().AddJsonFormatters().AddApiExplorer();

      services.AddAuthentication("Bearer")
        .AddIdentityServerAuthentication(options =>
        {
          options.Authority = "http://cancerberus";
          options.RequireHttpsMetadata = false;
          options.ApiName = "meSafeApi";
        });
      services.Configure<MeSafeDatabaseSettings>(Configuration.GetSection(nameof(MeSafeDatabaseSettings)));
      services.AddSingleton<IMeSafeDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MeSafeDatabaseSettings>>().Value);

      services.AddSingleton<UsuariosService>();
      services.AddSingleton<AuthService>();
      services.AddSingleton<ReportesService>();
      services.AddSingleton<RolesService>();
      services.AddSingleton<CentrosConsejosService>();
      services.AddSingleton<ConocidosService>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
      });

      services.AddSignalR();

    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseAuthentication();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      app.UseSignalR(routes =>
      {
        routes.MapHub<ReportesHub>("/reportesHub");
      });

      app.UseMvc();
    }
  }
}
