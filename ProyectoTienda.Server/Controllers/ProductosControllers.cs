using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using ProyectoTienda.BD.Data;
using ProyectoTienda.BD.Data.Entity;
using System.Runtime.InteropServices;
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
        private readonly IOutputCacheStore outputCacheStore;

        private const string cacheKey = "Productos";

        public ProductosControllers(IProductoRepositorio repositorio, IMapper mapper, IOutputCacheStore outputCacheStore)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
        }

        // Método para obtener todos los productos
        [HttpGet]
        [OutputCache(Tags = [cacheKey])]
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
        public async Task<ActionResult<int>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {
                Producto entidad = mapper.Map<Producto>(entidadDTO);
                var nuevoId = await repositorio.Insert(entidad);

                await outputCacheStore.EvictByTagAsync(cacheKey, default);
                return nuevoId;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActualizarProductoDTO entidadDTO)
        {
            if (id != entidadDTO.Id)
            {
                return BadRequest("Datos Incorrectos");
            }

            var productoExistente = await repositorio.SelectById(id);
            if (productoExistente == null)
            {
                return NotFound("No existe el producto.");
            }

            mapper.Map(entidadDTO, productoExistente);

            try
            {
                await repositorio.Update(id, productoExistente);
                await outputCacheStore.EvictByTagAsync(cacheKey, default);
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
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El producto {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                await outputCacheStore.EvictByTagAsync(cacheKey, default);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
