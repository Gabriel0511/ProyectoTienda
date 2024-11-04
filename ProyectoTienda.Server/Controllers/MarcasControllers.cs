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
    [Route("api/Marcas")]
    public class MarcasControllers : ControllerBase
    {
        private readonly IMarcaRepositorio repositorio;
        private readonly IMapper mapper;

        public MarcasControllers(IMarcaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        // Método para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<List<Marca>>> Get()
        {
            return await repositorio.Select();
        }

        // Método para agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearMarcaDTO entidadDTO)
        {
            try
            {
                Marca entidad = mapper.Map<Marca>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
