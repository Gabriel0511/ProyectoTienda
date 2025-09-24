using ProyectoTienda.Shared.DTO;

namespace ProyectoTienda.Client.Autorizacion
{
    public interface ILoginService
    {
        Task Login(UserTokenDTO tokenDTO);
        Task Logout();
    }
}
