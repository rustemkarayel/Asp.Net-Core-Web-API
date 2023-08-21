
using Microsoft.EntityFrameworkCore;
using WebApi.Repository;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //dbContext'i kullanabilmek için. appsettings'deki veriyi configure etmek gerekir.Direkt elle buraya yazmak yerine appsettings kullanırız.
            builder.Services.AddDbContext<RepositoryContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}