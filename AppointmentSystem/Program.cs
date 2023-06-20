using AppointmentSystem.Services;
using AppointmentSystem.Repositories;
using AppointmentSystem.Database;

var builder = WebApplication.CreateBuilder(args);

//add builder services
builder.Services.AddClinicDb(builder.Configuration);
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepo>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();

builder.Services.AddTransient<ISlotRepository,SlotRepo>();
builder.Services.AddTransient<ISlotService, SlotService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Clinic Module");
app.MapControllers();

app.Run();
