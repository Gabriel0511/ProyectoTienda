using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]

    public class ProductosControllers : ControllerBase
    {
        private readonly Context context;

        public ProductosControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet] //api/Productos
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/Productos/2
        public async Task<ActionResult<Producto>> Get(int id)
        {
            Producto? existe = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (existe == null)
            {
                return NotFound();
            }
            return existe;
        }

        [HttpGet("GetByCod/{cod}")]  //api/Productos/GetByCod/NombreProd
        public async Task<ActionResult<Producto>> GetByCod(string cod)
        {
            Producto? inter = await context.Productos.FirstOrDefaultAsync(x => x.NombreProd == cod);
            if (inter == null)
            {
                return NotFound(); 
            }
            return inter;
        }

        [HttpGet("existe/{id:int}")] //api/Productos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto entidad)
        {
            try
            {
                context.Productos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Productos/2
        public async Task<ActionResult> Put(int id, [FromBody] Producto entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var verif = await context.Productos.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (verif == null)
            {
                return NotFound("No existe el tipo de producto buscado");
            }

            verif.NombreProd = entidad.NombreProd;
            verif.Descripcion = entidad.Descripcion;
            verif.Equipo = entidad.Equipo;
            verif.Liga = entidad.Liga;
            verif.Precio = entidad.Precio;
            verif.Talle = entidad.Talle;
            verif.CantidadEnInventario = entidad.CantidadEnInventario;

            try
            {
                context.Productos.Update(verif);
                await context.SaveChangesAsync();
                return Ok();
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.Id==id);
            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe");
            }
            Producto EntidadABorrar = new Producto();
            EntidadABorrar.Id = id;
            context.Remove( EntidadABorrar );
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
