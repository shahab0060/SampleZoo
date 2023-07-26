using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleZoo.Core.CQRS.User.Handlers.Commands;
using SampleZoo.Core.CQRS.User.Handlers.Queries;
using SampleZoo.DataLayer.Context;
using SampleZoo.Web.Modules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region Services

#region data protection

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + "\\wwwroot\\Auth\\"))
    .SetApplicationName("SampleZooProject")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/login-directly";
    options.LogoutPath = "/log-out";
    options.ExpireTimeSpan = TimeSpan.FromDays(180);
    options.SlidingExpiration = true;
});

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sample Zoo Web Api",
    });
});

#endregion

RegisterServices(builder.Services);

#region DbContext Config

builder.Services.AddDbContext<SampleZooDbContext>(options =>
{
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("SampleZooConnectionString"),
    sqlServerOptions => sqlServerOptions.CommandTimeout(6000));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

#endregion

#endregion

#region App


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");
else
    app.UseExceptionHandler("/Home/Error");

//The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
#endregion

#region AddIoC

void RegisterServices(IServiceCollection services)
{
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
         .ConfigureContainer<ContainerBuilder>(builder =>
         {
             builder.RegisterModule(new AutofacModule());
         });
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly));
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllUsersQueryHandler).GetTypeInfo().Assembly));
}

#endregion


app.Run();

#endregion