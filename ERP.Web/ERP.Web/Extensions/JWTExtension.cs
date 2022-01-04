using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace ERP.Web.Extensions
{
    public static class JWTExtension
    {
        public static void ConfigureJWT(this IServiceCollection services, string Jwtkey)
        {
            var key = Encoding.ASCII.GetBytes(Jwtkey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    x.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Response.ContentType = "application/json";
                            string msg = "Authentication token is invalid";

                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                msg = "Token expired";
                            }
                            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
                            {
                                statusCode = (int)HttpStatusCode.Unauthorized,
                                message = msg
                            }));
                        }
                    };
                });


        }
    }
}
