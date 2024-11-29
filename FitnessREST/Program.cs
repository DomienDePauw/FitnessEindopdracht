using FitnessBL;
using FitnessDL;
namespace FitnessREST;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Configure CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp", policy =>
            {
                policy.AllowAnyOrigin() // Gebruik de juiste URL (http of https)
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });


        // Add services to the container.
        builder.Services.AddDbContext<FitnessContext>();
        builder.Services.AddScoped<MemberRepository>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SupportNonNullableReferenceTypes();
            c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}/{e.ActionDescriptor.RouteValues["action"]}");

        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowReactApp");
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
