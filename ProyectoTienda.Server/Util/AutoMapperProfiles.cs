using AutoMapper;
using ProyectoTienda.BD.Data.Entity;
using ProyectoTienda.Shared.DTO;

namespace ProyectoTienda.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearProductoDTO, Producto>();
            CreateMap<CrearCategoriaDTO, Categoria>();
            CreateMap<CrearMarcaDTO, Marca>();
        }
    }
}
