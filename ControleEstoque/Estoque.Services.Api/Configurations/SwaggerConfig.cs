using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Estoque.Services.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EVenda Controle de Estoque",
                    Description = "Estoque API Swagger surface",
                    Contact = new OpenApiContact { Name = "Luiz carlos", Email = "luizcarlostn@outlook.com.br", Url = new Uri("https://www.endcreation.com.br") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/luizelanna/Acelera_EVenda") }
                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}