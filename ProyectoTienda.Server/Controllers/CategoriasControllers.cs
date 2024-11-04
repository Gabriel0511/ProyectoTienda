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
    [Route("api/Categorias")]
    public class CategoriasControllers : ControllerBase
    {
        private readonly ICategoriaRepositorio repositorio;
        private readonly IMapper mapper;

        public CategoriasControllers(ICategoriaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await repositorio.Select();
        }

        // Método para agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCategoriaDTO entidadDTO)
        {
            try
            {
                Categoria entidad = mapper.Map<Categoria>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
