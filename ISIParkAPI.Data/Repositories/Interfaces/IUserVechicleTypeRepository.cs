using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IUserVechicleTypeRepository
    {
        Task<IEnumerable<UserVechicleType>> GetAllUserVechicleTypey();
        Task<UserVechicleType> GetUserVechicleTypeID(int utilizadorid);
        Task<bool> InsertUserVechicleType(UserVechicleType userVechicleType);
        Task<bool> UpdateUserVechicleType(UserVechicleType userVechicleType);
        Task<bool> DeleteUserVechicleType(UserVechicleType userVechicleType);
    }
}
