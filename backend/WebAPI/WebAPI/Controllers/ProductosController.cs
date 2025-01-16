using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using WebAPI.Custom;
using WebAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbPruebaContext _context;

        public ProductosController(DbPruebaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult>Listar() 
        {
            var lista = await _context.Productos.ToListAsync();

            if (lista == null) 
                return NotFound();

            return StatusCode(StatusCodes.Status200OK, new {value = lista});
        }
    }
}
