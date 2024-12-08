using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Services;
using FitnessBeheerEFlayer;
using FitnessBeheerEFlayer.Repositories;
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
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        builder.Services.AddDbContext<FitnessContext>();
        builder.Services.AddScoped<IMemberRepository, MemberRepositoryEF>();
        builder.Services.AddScoped<MemberService>();
        builder.Services.AddScoped<IEquipmentRepository, EquipmentRepositoryEF>();
        builder.Services.AddScoped<EquipmentService>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepositoryEF>();
        builder.Services.AddScoped<ReservationService>();
        builder.Services.AddScoped<IFitnessProgramRepository, FitnessProgramRepositoryEF>();
        builder.Services.AddScoped<FitnessProgramService>();
        builder.Services.AddScoped<ICyclingSessionRepository, CyclingSessionRepositoryEF>();
        builder.Services.AddScoped<CyclingSessionService>();
        builder.Services.AddScoped<IRunningSessionRepository, RunningSessionRepositoryEF>();
        builder.Services.AddScoped<RunningSessionService>();
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
