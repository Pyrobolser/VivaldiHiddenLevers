using AutoMapper;
using Flurl.Http;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Reflection;
using VivaldiHiddenLevers.Application.Apis.HLEntities;
using VivaldiHiddenLevers.Application.Clients.Queries.GetClientDetail;
using VivaldiHiddenLevers.Application.Infrastructure.AutoMapper;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Application.JsonConverters;
using VivaldiHiddenLevers.HLClient;
using VivaldiHiddenLevers.Persistence;
using VivaldiHiddenLevers.WebUI.Filters;

namespace VivaldiHiddenLevers.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            // MediatR
            services.AddMediatR(typeof(GetClientDetailQuery).GetTypeInfo().Assembly);

            // Flurl
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new FlattenNestedJSONConverter<HLClientResult>());

            FlurlHttp.ConfigureClient(Configuration["HiddenLeversServiceUri"], cli => cli
                .Configure(settings =>
                {
                    settings.JsonSerializer = new Flurl.Http.Configuration.NewtonsoftJsonSerializer(jsonSettings);
                })
                .WithHeaders(new
                {
                    Content_Type = "application/json"
                }));

            services.AddSingleton<IVivaldiHiddenLeversClient, HiddenLeversApiClient>();

            // DBContext
            string connection = Configuration.GetConnectionString("LocalConnection");
            services.AddDbContext<IVivaldiHiddenLeversDbContext, VivaldiHiddenLeversDbContext>
                (options => options.UseSqlServer(connection));

            // CORS
            services.AddCors();

            // WebAPI
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Swagger
            services.AddSwaggerDocument(config =>
            {
                config.DocumentName = "VivaldiHiddenLevers v1";
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Vivaldi - HiddenLevers API";
                    document.Info.Description = "Display Vivaldi clients with extra info powered by HiddenLevers.";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "François Blondel",
                        Email = "francois.blondel@outlook.com",
                    };
                };
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
