
using FastEndpoint.dbContext;
using FastEndpoint.Interface;
using FastEndpoint.Service;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace FastEndpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //for fastendpoint for two line 
            builder.Services.AddFastEndpoints();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();


            // Add services to the container.
            builder.Services.AddDbContext<ProjectContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("FastEndpoint")));
           // builder.Services.AddControllers();
            builder.Services.AddScoped<IProductService,ProductService>();  
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           // builder.Services.AddEndpointsApiExplorer();


           // builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


           // app.MapControllers();
           app.UseFastEndpoints();

            app.Run();
        }
    }
}
