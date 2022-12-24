using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetAllHistory();
        Task<History> GetHistoryDetails(int id);
        Task<bool> InsertHistory(History history);
        Task<bool> UpdateHistory(History history);
        Task<bool> DeleteHistory(History history);
    }
}
