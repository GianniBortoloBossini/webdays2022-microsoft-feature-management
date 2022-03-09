using Microsoft.Extensions.DependencyInjection.Extensions;                      // <==
using Microsoft.FeatureManagement;                                              // <==
using Microsoft.FeatureManagement.FeatureFilters;                               // <==

var builder = WebApplication.CreateBuilder(args);

var appConfigCnnStr = builder.Configuration["ConnectionStrings:AppConfig"];                      // <==
builder.Configuration.AddAzureAppConfiguration(                                                  // <==
    config =>                                                                                    // <==
        config.Connect(appConfigCnnStr)                                                          // <==
               .UseFeatureFlags(                                                                 // <==
                   featureFlagOptions =>                                                         // <==
                        featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(10))); // <==

builder.Services.AddAzureAppConfiguration();

builder.Services.AddControllersWithViews();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();  // <==
builder.Services.AddFeatureManagement()                                         // <==
        .AddFeatureFilter<BrowsersFeatureFilter>()                              // <==
        .AddFeatureFilter<TimeWindowFilter>();                                  // <==

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseAzureAppConfiguration();         // <==

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
