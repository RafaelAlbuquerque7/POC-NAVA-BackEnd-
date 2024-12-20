using Microsoft.EntityFrameworkCore;
using Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar CORS, serve para controlar quem pode acessar a api ou quais permissões tem o acesso
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Permite qualquer origem
              .AllowAnyMethod()   // Permite qualquer método (GET, POST, etc)
              .AllowAnyHeader();  // Permite qualquer cabeçalho
    });
});

// Adicionando o DbContext, é uma 'ponte' entre o codigo e o banco de dados, ele permite realizar as operações
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adicionando o Swagger, é uma interface que vai aparecer para interagir e testar a api
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  

// Adicionar suporte a controllers
builder.Services.AddControllers();

var app = builder.Build();

// Usar CORS
app.UseCors("AllowAll");  // Aplicando a política de CORS

// Usar Swagger se o ambiente for de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esta linha exibe a UI do Swagger
}

app.UseHttpsRedirection();

// Mapeia os controladores
app.MapControllers();  // Essa linha é importante para mapear os endpoints dos controllers

app.Run();
