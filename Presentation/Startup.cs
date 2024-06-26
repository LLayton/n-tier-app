using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Persist;
using Services;
using Repositories;

namespace Presentation
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
            services.AddAutoMapper(typeof (MappingProfile));
            
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IServiceBook,ServiceBook>();

            services.AddScoped<IEntryRepository,EntryRepository>();
            services.AddScoped<IEntryService,EntryService>();

            services.AddScoped<ISpotterRepository,SpotterRepository>();
            services.AddScoped<ISpotterService,SpotterService>();

            services.AddScoped<IEntrySpotterService,EntrySpotterService>();
            services.AddScoped<IEntrySpotterRepository,EntrySpotterRepository>();
            
            services.AddScoped<IDataRecognition,DataRecognition>();
            services.AddOpenApiDocument();
            // Configuration de la chaîne de connexion
            //string connectionString = "Server=localhost;Port=8081;User=root;Password=;Database=testntier" ;
            string connectionString = "Server=localhost;Port=3306;User=root;Password=;Database=testntier;Charset=utf8";

            // Ajout du contexte de base de données
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
