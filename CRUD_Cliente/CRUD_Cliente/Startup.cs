using CRUD_Cliente.src.context;
using CRUD_Cliente.src.repositories;
using CRUD_Cliente.src.repositories.implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;

namespace CRUD_Cliente
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
            // Config Banco de Dados
            services.AddDbContext<ClientContext>(opt => opt.UseSqlServer(Configuration["ConnectionStringsDev:DefaultConnection"]));

            // Repositorios
            services.AddScoped<IClient, ClientRepository>();

            // Controladores
            services.AddCors();
            services.AddControllers();

            // Config Swagger
            services.AddSwaggerGen(
                s =>
                {
                    s.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD Cliente", Version = "v1" });
                    s.AddSecurityDefinition(
                        "Bearer",
                        new OpenApiSecurityScheme()
                        {
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey,
                            Scheme = "Bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "JWT authorization header utiliza: Bearer + JWTToken",
                        });

                    s.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new List<string>()
                        }
                    });

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    s.IncludeXmlComments(xmlPath);
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ClientContext context)
        {
            // Ambiente de desenvolviemnto
            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD Cliente");
                    c.RoutePrefix = string.Empty;
                });
            }

            // Ambiente de produção
            context.Database.EnsureCreated();

            // Rotas
            app.UseRouting();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
