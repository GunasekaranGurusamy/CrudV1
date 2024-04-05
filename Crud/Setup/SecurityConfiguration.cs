using Crud.Handler;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Crud.Setup;

public static class SecurityConfiguration
{
    public static WebApplicationBuilder ConfigureAuthentication(this  WebApplicationBuilder builder)
    {
        var _jwtSettings = builder.Configuration.GetSection("JWTConfig");
        builder.Services.Configure<JWTSettings>(_jwtSettings);
        builder.Services.AddAuthentication(item =>
        {
            item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(item =>
        {
            item.RequireHttpsMetadata = true;
            item.SaveToken = false;
            item.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JWTConfig:KEY"))),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew=TimeSpan.Zero
            };
        });

        return builder; 
    }
}
