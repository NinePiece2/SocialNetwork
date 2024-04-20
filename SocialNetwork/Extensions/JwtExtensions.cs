using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Microsoft.Owin.Security.Jwt;
using System.Web.Http;

public static class JwtExtensions
{
    public static void GenerateJwtToken(this OAuthGrantResourceOwnerCredentialsContext context, ApplicationUser user, ApplicationUserManager userManager)
    {
        var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ExternalBearer);
        // Add custom claims if needed

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String("YourBase64EncodedSecretKey"); // Use a secure key
        var securityToken = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddHours(1), // Set token expiration as needed
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        var token = tokenHandler.WriteToken(securityToken);
        context.Validated(new AuthenticationTicket(identity, new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) })); // Match expiration
        context.Response.Headers.Add("Authorization", new[] { $"Bearer {token}" });
    }

    public static void ConfigureJwtAuthentication(this IAppBuilder app, HttpConfiguration config)
    {
        var issuer = "YourIssuer"; // Adjust as needed
        var audience = "YourAudience"; // Adjust as needed
        var key = Convert.FromBase64String("YourBase64EncodedSecretKey"); // Use a secure key

        app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
        {
            AuthenticationMode = AuthenticationMode.Active,
            TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }
        });
    }
}
