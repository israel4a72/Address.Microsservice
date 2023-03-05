using Address.Application.Repositories.External;
using Address.Application.UseCases.Handlers;
using Address.Infrastructure.Repositories.External;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<IViaCepRepository, ViaCepRepository>();
builder.Services.AddTransient<ProccessAddressHandler>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
