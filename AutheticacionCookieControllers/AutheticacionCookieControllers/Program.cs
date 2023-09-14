

//add the name to authentica using cookies 
using Microsoft.AspNetCore.Authentication.Cookies;
//add namespace to use JSON
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure servuces to authenticate using cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //set parameters for non-authorized users
        options.ReturnUrlParameter = "unauthorized";
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                //change the code to non-authorized 
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                var message = new
                {
                    error = "Unauthorized",
                    message = "Must be log in to access this resource."
                };
                //Serealize the object "message" in Json
                var jsonMessage = JsonSerializer.Serialize(message);
                // wrirte the message in the HTTP RESPONSE
                return context.Response.WriteAsync(jsonMessage);

            }
        };

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
