using DesafioFullStack.Data;
using DesafioFullStack.Integration.Refit;
using DesafioFullStack.Repository;
using DesafioFullStack.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Full Stack", Version = "v1" });
    var xmlFile = "DesafioFullStack.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<SystemDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<ICompany, CompanyRepository>();
builder.Services.AddScoped<ISupplier, SupplierRepository>();

builder.Services.AddRefitClient<IApiCepIntegrationRefit>().ConfigureHttpClient(
    c =>
    {
        c.BaseAddress = new Uri("https://h-apigateway.conectagov.estaleiro.serpro.gov.br/api-cep/v1");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Full Stack V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
