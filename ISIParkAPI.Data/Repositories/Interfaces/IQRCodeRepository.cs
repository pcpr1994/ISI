using ISIParkAPI.Model;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IQRCodeRepository
    {
        Task<UserDTO> GetQRCode(int id);
    }
}
