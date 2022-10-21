using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Infrastructure;
using SubscriptionMAN.API.Infrastructure.Data;
using SubscriptionMAN.API.Infrastructure.Identity;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using SubscriptionMAN.API.Presentation.Validators;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(c =>
{
    string connetion_string = builder.Configuration.GetConnectionString("MysqlAppConnection");
    c.UseMySql(connetion_string, ServerVersion.AutoDetect(connetion_string));
});

builder.Services.AddDbContext<IdentityUserDbContext>(c =>
{
    string connetion_string = builder.Configuration.GetConnectionString("MysqlIdentityConnection");
    c.UseMySql(connetion_string, ServerVersion.AutoDetect(connetion_string));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<IdentityUserDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddInfrastructure();



builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = AuthorizationConstants.Issuer,
        ValidAudience = AuthorizationConstants.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(AuthorizationConstants.JWT_SECRET_KEY))
    };
});


builder.Services.AddAuthorization();

builder.Services.AddMemoryCache();


builder.Services.AddValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.MapControllers();

app.Run();
