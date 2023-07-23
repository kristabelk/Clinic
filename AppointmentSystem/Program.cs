using AppointmentSystem.Services;
using AppointmentSystem.Repositories;
using AppointmentSystem.Database;
using AppointmentSystem.Security;

var builder = WebApplication.CreateBuilder(args);

//add builder services
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));
builder.Services.AddClinicAuthentication(builder.Configuration);   
builder.Services.AddClinicDb(builder.Configuration);
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepo>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddTransient<ISlotRepository,SlotRepo>();
builder.Services.AddTransient<ISlotService, SlotService>();

builder.Services.AddTransient<IUserRepository,UserRepo>();
builder.Services.AddTransient<IUserManagementService, UserManagementService>();

builder.Services.AddTransient<JwtCreator>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Clinic Module");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
