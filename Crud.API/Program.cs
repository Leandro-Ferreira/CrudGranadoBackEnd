using Crud.Core.Repository;
using Crud.Infraestrutura.Data;
using Crud.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Crud.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            ConexaoModelReservaPostgres(builder);
            ConfiguracaoMediatr(builder);
            Cors(builder);
            RepositoryBind(builder);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                .Union(new AssemblyName[] { currentAssembly.GetName() })
                .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                .Where(f => File.Exists(f)).ToArray();

                Array.ForEach(xmlDocs, (d) =>
                {
                    c.IncludeXmlComments(d);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }


        private static void ConexaoModelReservaPostgres(WebApplicationBuilder builder)
        {
            try
            {
                builder.Services
                       .AddEntityFrameworkNpgsql()
                       .AddDbContext<CrudGranadoContext>(options => options.UseInMemoryDatabase("CRUD"));
                       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void ConfiguracaoMediatr(WebApplicationBuilder builder)
        {
            var assembly = AppDomain.CurrentDomain.Load("Crud.Application");

            builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(assembly); });
        }

        private static void RepositoryBind(WebApplicationBuilder builder)=>
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
        
        private static void Cors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }
}