using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;
using ProyectoTienda.Server.Repositorio;
using ProyectoTienda.Shared.DTO;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTienda.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;

        public ProductosControllers(IProductoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

       // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            var productos = await repositorio.Select();
            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos.");
            }
            return Ok(productos);

        }

        // Método para agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {
                Producto entidad = mapper.Map<Producto>(entidadDTO);
                var nuevoId = await repositorio.Insert(entidad);
                return CreatedAtAction(nameof(Get), new { id = nuevoId }, entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //// Método para modificar un producto existente
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Put(int id, [FromBody] CrearProductoDTO dto)
        //{
        //    var producto = await context.Productos.FindAsync(id);

        //    if (producto == null)
        //    {
        //        return NotFound("No existe el producto buscado");
        //    }

        //    producto.NombreProd = dto.NombreProd;
        //    producto.Descripcion = dto.Descripcion;
        //    producto.Equipo = dto.Equipo;
        //    producto.Liga = dto.Liga;
        //    producto.Precio = dto.Precio;
        //    producto.Talle = dto.Talle;
        //    producto.CantidadEnInventario = dto.CantidadEnInventario;
        //    producto.MarcaId = dto.MarcaId;
        //    producto.CategoriaId = dto.CategoriaId;

        //    try
        //    {
        //        context.Productos.Update(producto);
        //        await context.SaveChangesAsync();
        //        return Ok("Producto actualizado con éxito");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest($"Error en la actualización: {e.Message}");
        //    }
        //}


        //// Método para eliminar un producto
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var producto = await context.Productos.FindAsync(id);
        //    if (producto == null)
        //    {
        //        return NotFound($"El producto con ID {id} no existe");
        //    }

        //    context.Productos.Remove(producto);
        //    await context.SaveChangesAsync();
        //    return Ok("Producto eliminado con éxito");
        //}

    }
}
