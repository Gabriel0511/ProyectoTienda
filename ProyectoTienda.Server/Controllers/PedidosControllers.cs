using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]

    public class PedidosControllers : ControllerBase
    {
        private readonly Context context;

        public PedidosControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> Get()
        {
            return await context.Pedidos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Pedido entidad)
        {
            try
            {
                context.Pedidos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Pedidos/2
        public async Task<ActionResult> Put(int id, [FromBody] Pedido entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var existe = await context.Pedidos.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existe == null)
            {
                return NotFound("No existe el tipo de producto buscado");
            }

            existe.Fecha = entidad.Fecha;
            existe.Total = entidad.Total;
            existe.EstadoDelPedido = entidad.EstadoDelPedido;

            try
            {
                context.Pedidos.Update(existe);
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
