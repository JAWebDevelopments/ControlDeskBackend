using ControlDesk.API.Configurations;
using ControlDesk.API.Endpoints;
using ControlDesk.API.Middleware;
using ControlDesk.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerDocumentation();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapTicketEndpoints();
app.MapSecurity();
app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
