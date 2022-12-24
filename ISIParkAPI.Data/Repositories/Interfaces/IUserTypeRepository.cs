using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserType();
        Task<UserType> GetUserTypeDetails(int id);
        Task<bool> InsertUserType(UserType userType);
        Task<bool> UpdateUserType(UserType userType);
        Task<bool> DeleteUserType(UserType userType);
    }
}
