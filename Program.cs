using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Entities.Context;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using SuperHeroApi.Services.Interface;
using SuperHeroApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });
builder.Services.AddDbContext<SuperHeroContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ISuperHero, SuperHeroService>();
builder.Services.AddAuthorization();


builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<SuperHeroContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
