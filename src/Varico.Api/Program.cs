var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApp()
    .AddApi();

var app = builder.Build();

app.UseApi();

app.Run();