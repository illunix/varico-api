var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApp();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

app.MapTransactionsEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();