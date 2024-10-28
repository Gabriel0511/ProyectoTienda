using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.DTOs;
using ProyectoTienda.BD.Data.Entity;
using System.ComponentModel.DataAnnotations;

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

        // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        // Método para obtener un producto por su ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            Producto? existe = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (existe == null)
            {
                return NotFound("Producto no encontrado");
            }
            return existe;
        }

        // Método para agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<int>> Post( [FromBody] CrearProductoDTO dto)
        {
            // Validación de datos
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Error de Validación
            }

            var producto = new Producto
            {
                NombreProd = dto.NombreProd,
                Descripcion = dto.Descripcion,
                Equipo = dto.Equipo,
                Liga = dto.Liga,
                Precio = dto.Precio,
                Talle = dto.Talle,
                CantidadEnInventario = dto.CantidadEnInventario,
                MarcaId = dto.MarcaId,
                CategoriaId = dto.CategoriaId
            };

            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return producto.Id;
        }

        // Método para modificar un producto existente
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CrearProductoDTO dto)
        {
            var producto = await context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound("No existe el producto buscado");
            }

            producto.NombreProd = dto.NombreProd;
            producto.Descripcion = dto.Descripcion;
            producto.Equipo = dto.Equipo;
            producto.Liga = dto.Liga;
            producto.Precio = dto.Precio;
            producto.Talle = dto.Talle;
            producto.CantidadEnInventario = dto.CantidadEnInventario;
            producto.MarcaId = dto.MarcaId;
            producto.CategoriaId = dto.CategoriaId;

            try
            {
                context.Productos.Update(producto);
                await context.SaveChangesAsync();
                return Ok("Producto actualizado con éxito");
            }
            catch (Exception e)
            {
                return BadRequest($"Error en la actualización: {e.Message}");
            }
        }


        // Método para eliminar un producto
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound($"El producto con ID {id} no existe");
            }

            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
            return Ok("Producto eliminado con éxito");
        }

    }
}
