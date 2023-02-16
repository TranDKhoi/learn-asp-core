using LearnASP.Core.Contracts;
using LearnASP.Core.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace LearnASP.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            policy.SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader().AllowCredentials());
        });

        public static void ConfigureRepository(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };

                //For hubs chat
                //o.Events = new JwtBearerEvents
                //{
                //    OnMessageReceived = context =>
                //    {
                //        var accessToken = context.Request.Query["access_token"];

                //        // If the request is for our hub...
                //        var path = context.HttpContext.Request.Path;
                //        if (!string.IsNullOrEmpty(accessToken) &&
                //            path.StartsWithSegments("/hubs/noti"))
                //        {
                //            // Read the token out of the query string
                //            context.Token = accessToken;
                //        }
                //        return Task.CompletedTask;
                //    }
                //};
            });
        }

        public static void ConfigureSwaggerOptions(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer",
            new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Place to add JWT with Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
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

        }

    }
}
