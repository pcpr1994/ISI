using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IUserHistoryRepository
    {
        Task<IEnumerable<UserHistory>> GetAllUserHistory();
        Task<UserHistory> GetUserHistoryID(int utilizadorid);
        Task<bool> InsertUserHistory(UserHistory userHistory);
        Task<bool> UpdateUserHistory(UserHistory userHistory);
        Task<bool> DeleteUserHistory(UserHistory userHistory);
    }
}
