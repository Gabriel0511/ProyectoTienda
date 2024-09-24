using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/Marcas")]

    public class MarcasControllers : ControllerBase
    {
        private readonly Context context;

        public MarcasControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get()
        {
            return await context.Marcas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Marca entidad)
        {
            try
            {
                context.Marcas.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Marcas/2
        public async Task<ActionResult> Put(int id, [FromBody] Marca entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var existe = await context.Marcas.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existe == null)
            {
                return NotFound("No existe el tipo de marca buscado");
            }

            existe.NombreMarca = entidad.NombreMarca;

            try
            {
                context.Marcas.Update(existe);
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
