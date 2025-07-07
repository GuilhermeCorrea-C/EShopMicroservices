var builder = WebApplication.CreateBuilder(args);

// Adicionar serivos ao container de DI

var app = builder.Build();

// Configurar o pipeline da requisicao HTTP

app.Run();
