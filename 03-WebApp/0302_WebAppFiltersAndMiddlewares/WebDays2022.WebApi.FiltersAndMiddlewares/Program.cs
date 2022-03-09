var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatureManagement();    // <=
builder.Services.AddControllers(options => {
        options.Filters.AddForFeature<SimulateSlowServerActionFilter>(nameof(FeatureFlags.SimulateSlowServer)); // <= Registo il feature flag a livello di filtro
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

app.UseMiddlewareForFeature<LogRequestsMiddleware>(nameof(FeatureFlags.LogRequests));  // <= Registo il feature flag a livello di middleware

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
