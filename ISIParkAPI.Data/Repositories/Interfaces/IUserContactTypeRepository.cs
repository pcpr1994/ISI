using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IUserContactTypeRepository
    {
        Task<IEnumerable<UserContactType>> GetAllUserContactType();
        Task<UserContactType> GetUserContactTypeID(int utilizadorid);
        Task<bool> InsertUserContactType(UserContactType userContactType);
        Task<bool> UpdateUserContactType(UserContactType userContactType);
        Task<bool> DeleteUserContactType(UserContactType userContactType);
    }
}
