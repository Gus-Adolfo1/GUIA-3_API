using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutheticacionCookieControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
     
            // POST api/<AccountController>
            [HttpPost("login")]
            public IActionResult Login(string login, string password)
            {
                if (login == "admin" && password == "12345")
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login)
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {

                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    return Ok("Inicio de Sesion Correcto");
                }
                else
                {
                    return Unauthorized("Credenciales Incorrectas");
                }
            }

            // POST api/<AccountController>
            [HttpPost("logout")]
            public IActionResult Logout()
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return Ok("Cerro Sesion Correctamente");
            }

        }
    }

