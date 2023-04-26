using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Net.Http;


public class WebApiConfig
{

    public static void Register(HttpConfiguration config)
    {
        // Configure JSON serialization
        config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

        // Configure Bearer Authorization
        var issuer = System.Configuration.ConfigurationManager.AppSettings["JwtIssuer"];
        var audience = System.Configuration.ConfigurationManager.AppSettings["JwtAudience"];
        var secret = System.Configuration.ConfigurationManager.AppSettings["JwtSecret"];

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secret)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        var app = new AppBuilder();

        app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
        {
            AuthenticationMode = AuthenticationMode.Active,
            TokenValidationParameters = tokenValidationParameters
        });

        config.Filters.Add(new System.Web.Http.AuthorizeAttribute());

        // Configure endpoints
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
       name: "CreatePersona",
       routeTemplate: "api/personas/create",
       defaults: new { controller = "Personas", action = "Create" },
      constraints: new { httpMethod = new HttpMethod("POST") }
   );

        config.Routes.MapHttpRoute(
            name: "GetPersonaWithCitas",
            routeTemplate: "api/personas",
            defaults: new { controller = "Personas", action = "GetWithCitas" }
        );

        config.Routes.MapHttpRoute(
            name: "GetCitasWithMotivoCitaByFecha",
            routeTemplate: "api/citas/{fecha}",
            defaults: new { controller = "Citas", action = "GetWithMotivoCitaByFecha" }
        );
    }
}