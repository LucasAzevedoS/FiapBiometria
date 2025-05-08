

using BiometriaValidacaoApi;
using BiometriaValidacaoAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro do serviço Fake
builder.Services.AddScoped<IMongoRepository, FakeMongoRepository>(); // <= Aqui!
builder.Services.AddScoped<IBiometriaService, BiometriaService>();   // <= (caso ainda não tenha adicionado)

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
