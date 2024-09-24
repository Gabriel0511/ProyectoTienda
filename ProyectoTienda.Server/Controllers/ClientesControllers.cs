using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]

    public class ClientesControllers : ControllerBase
    {
        private readonly Context context;

        public ClientesControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente entidad)
        {
            try
            {
                context.Clientes.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Clientes/2
        public async Task<ActionResult> Put(int id, [FromBody] Cliente entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var existe = await context.Clientes.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existe == null)
            {
                return NotFound("No existe el tipo de cliente buscado");
            }

            existe.NombreCliente = entidad.NombreCliente;
            existe.Apellido = entidad.Apellido;
            existe.Email = entidad.Email;
            existe.Direccion = entidad.Direccion;
            existe.CodigoPostal = entidad.CodigoPostal;

            try
            {
                context.Clientes.Update(existe);
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
