using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Application.Mapping;
using SocialNetwork.Application.Services;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Infrastructure.Context;
using SocialNetwork.Infrastructure.Repositories;
using System.Text;
using System.Text.Json.Serialization;
using Profile = SocialNetwork.Domain.Entites.Profile;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseIISIntegration();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddIdentity<Profile, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
   

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
        ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
    });

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions
    .ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IProfileService, ProfileService>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DomainToDTOMappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Animes_API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Header de autorização JWT usando o esquema Bearer.\r\n\r\nInforme 'Bearer'[espaço] e o seu token.\r\n\r\nExemplo:\'Bearer 12345abasdr\'",
    });


    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
              {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                  {
                          Type=ReferenceType.SecurityScheme,
                          Id="Bearer"
                  }
                },
                new string[]{}
            }
        });

});


builder.Services.AddCors();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(builder =>
{
    builder.AllowAnyHeader()
           .AllowAnyOrigin()
           .AllowAnyMethod();
});


app.MapControllers();

app.Run();
