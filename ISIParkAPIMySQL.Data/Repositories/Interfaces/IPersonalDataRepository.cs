using ISIParkAPIMySQL.Model;

namespace ISIParkAPIMySQL.Data.Repositories.Interfaces
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
