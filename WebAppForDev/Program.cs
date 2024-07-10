using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebAppForDev;
using WebAppForDev.Authentication;
using WebAppForDev.Models.DataContext;
using WebAppForDev.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

// Adiciona serviços de autenticação e autorização
builder.Services.AddAuthentication("BasicAuthentication") // Configuração mínima de autenticação
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

// Configura o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Adiciona autenticação ao pipeline
app.UseAuthorization(); // Adiciona autorização ao pipeline
app.MapControllers();

app.Run();
