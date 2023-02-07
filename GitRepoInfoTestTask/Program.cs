using GitRepoInfoTestTask;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Установка пути к локальному Git-репозиторию 
RepositoryConnection.ConnectionPath = "";

if (RepositoryConnection.ConnectionPath == "" || RepositoryConnection.ConnectionPath == null)
{
    throw new NullReferenceException("Пустой путь к локальному Git-репозиторию. ");
}

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
