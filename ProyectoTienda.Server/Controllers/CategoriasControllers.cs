using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/Categorias")]

    public class CategoriasControllers : ControllerBase
    {
        private readonly Context context;

        public CategoriasControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Categoria entidad)
        {
            try
            {
                context.Categorias.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Categorias/2
        public async Task<ActionResult> Put(int id, [FromBody] Categoria entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var existe = await context.Categorias.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existe == null)
            {
                return NotFound("No existe el tipo de cliente buscado");
            }

            existe.NombreCat = entidad.NombreCat;

            try
            {
                context.Categorias.Update(existe);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
