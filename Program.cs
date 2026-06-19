using System.Security.Cryptography.X509Certificates;
namespace Api_Learn
{
    public class Program
    {
        public static void Main(string[] args, Microsoft.AspNetCore.Diagnostics.StatusCodeContext context1)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapControllers();
            app.Run();

            
        }
        
    }
}
