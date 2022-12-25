using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IAdminMessageRepository
    {
        Task<IEnumerable<AdminMessage>> GetAllAdminMessage();
        Task<AdminMessage> GetAdminMessageDetails(int id);
        Task<bool> InsertAdminMessage(AdminMessage adminMessage);
        Task<bool> UpdateAdminMessage(AdminMessage adminMessage);
        Task<bool> DeleteAdminMessage(AdminMessage adminMessage);
    }
}
