using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> GetAllContactType();
        Task<ContactType> GetContactTypeDetails(int id);
        Task<bool> InsertContactType(ContactType contactType);
        Task<bool> UpdateContactType(ContactType contactType);
        Task<bool> DeleteContactType(ContactType contactType);
    }
}
