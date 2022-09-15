using SuaSaude.Core.Interface;
using SuaSaude.Core.Service;
using SuaSaude.Infra.Client.Advice;
using SuaSaude.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IControleDePeso, ControleDePesoService>(); // 1 instancia por requisicao
builder.Services.AddScoped<IClassificacaoIMCRepository, ClassificacaoIMCRepository>();
builder.Services.AddScoped<IComunicaAdviceClient, ComunicaAdviceClient>();

//builder.Services.AddTransient(); // para cada injecao uma instancia!
//builder.Services.AddSingleton(); // 1 instancia todas as requisicoes!

builder.Services.AddHttpClient("APIAdvice", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["APIAdviceAddress"]);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
