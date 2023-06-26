using CodeBridgeTest.Data;
using CodeBridgeTest.Data.Factory.Impliment;
using CodeBridgeTest.Data.Factory.Interfaces;
using CodeBridgeTest.Data.Repository.Implement;
using CodeBridgeTest.Data.Repository.Interfaces;
using CodeBridgeTest.Middlewares;
using CodeBridgeTest.Model;
using CodeBridgeTest.Services.Impliment;
using CodeBridgeTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeBridgeTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson();

            //Initionilize Database
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddTransient<IDogRepository, DogRepository>();

            //Factory
            builder.Services.AddScoped<ISortStrategyFactory<Dog>, SortStrategyFactory>();
            builder.Services.AddScoped<ISortStrategy<Dog>, DogTailLengthDescendingSortStrategy>();
            builder.Services.AddScoped<ISortStrategy<Dog>, DogTailLengthAscendingSortStrategy>();
            builder.Services.AddScoped<ISortStrategy<Dog>, DogWeightDescendingSortStrategy>();
            builder.Services.AddScoped<ISortStrategy<Dog>, DogWeightAscendingSortStrategy>();

            //Services
            builder.Services.AddScoped<IDogsServices, DogServices>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseMiddleware<RateLimitMiddleware>();
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