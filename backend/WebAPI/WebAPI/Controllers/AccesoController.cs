using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using WebAPI.Custom;
using WebAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]//permite el acceso sin auntenticar
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly DbPruebaContext _context;
        private readonly Utilidades _utilidades;

        public AccesoController(DbPruebaContext context, Utilidades utilidades)
        {
            _context = context;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult>Registrar(UsuarioDTO objeto) 
        {
            var modeloUsuario = new Usuario
            {
                Nombre = objeto.Nombre,

                Correo = objeto.Correo,

                Clave = _utilidades.encriptarSha256(objeto.Clave)
            };

            await _context.Usuarios.AddAsync(modeloUsuario);
            await _context.SaveChangesAsync();

            if(modeloUsuario.IdUsuario!= 0)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto) 
        { 
            var usuarioEncontrado = await _context.Usuarios.Where(p=> p.Correo  == objeto.Correo &&
                                                                  p.Clave== _utilidades.encriptarSha256(objeto.Password)).FirstOrDefaultAsync();

            if(usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = false, token = " "});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.GenereateJWT(usuarioEncontrado) });


        }

        [HttpGet]
        [Route("ValidarToken")]
        public IActionResult ValidarToken([FromQuery]string token)
        {
                bool respuesta = _utilidades.ValidarToken(token);
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta});
            


        }
    }
}
