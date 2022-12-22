using ISIParkAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPIMySQL.Data.Repositories
{
    public interface IPersonalDataRepository
    {
        Task<IEnumerable<PersonalData>> GetAllPersonalData();
        Task<PersonalData> GetPersonalDataDetails(int numero);
        Task<bool> InsertPersonalData(PersonalData personalData);
        Task<bool> UpdatePersonalData(PersonalData personalData);
        Task<bool> DeletePersonalData(PersonalData personalData);
    }
}
