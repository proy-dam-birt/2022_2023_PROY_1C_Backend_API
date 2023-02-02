using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;


namespace DAM.Proyecto.WebAPI.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            var basepath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basepath, "DAM.Proyecyo.WebAPI.xml");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DAM.Proyecto.WebAPI", Version = "v1" });
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {
            app.UseSwagger();


            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DAM.Proyecto.WebAPI"));
            return app;
        }
    }
}
