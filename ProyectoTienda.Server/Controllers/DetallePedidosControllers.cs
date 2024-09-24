using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/DetallePedidos")]

    public class DetallePedidosControllers : ControllerBase
    {
        private readonly Context context;

        public DetallePedidosControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<DetallePedido>>> Get()
        {
            return await context.DetallePedidos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DetallePedido entidad)
        {
            try
            {
                context.DetallePedidos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/DetallePedidos/2
        public async Task<ActionResult> Put(int id, [FromBody] DetallePedido entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var existe = await context.DetallePedidos.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (existe == null)
            {
                return NotFound("No existe el tipo de detalle de pedido buscado");
            }

            existe.Cantidad = entidad.Cantidad;
            existe.PrecioUnitario = entidad.PrecioUnitario;

            try
            {
                context.DetallePedidos.Update(existe);
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
