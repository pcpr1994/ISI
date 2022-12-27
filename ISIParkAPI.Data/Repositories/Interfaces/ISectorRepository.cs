using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class SectorRepository
    /// </summary>
    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> GetAllSector();
        Task<Sector> GetSectorDetails(int id);
        Task<bool> InsertSector(Sector sector);
        Task<bool> UpdateSector(Sector sector);
        Task<bool> DeleteSector(Sector sector);
    }
}
