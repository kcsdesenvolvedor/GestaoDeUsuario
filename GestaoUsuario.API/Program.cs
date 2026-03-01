using GestaoUsuario.API;
using GestaoUsuario.Application;
using GestaoUsuario.Persistence;
using GestaoUsuario.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServicesPersistence(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.ConfigureServicesApplication();
builder.Services.ConfigureServicesApi();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Permitir requisições de qualquer origem (CORS)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

CreateDatabase(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

//No cenário de produção o correto seria utilizar migrations para criar o banco de dados, mas para esse cenário de teste
//podemos utilizar o EnsureCreated para criar o banco de dados automaticamente caso ele não exista.
static void CreateDatabase(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GestaoUsuarioContext>();
    dbContext.Database.EnsureCreated();
}