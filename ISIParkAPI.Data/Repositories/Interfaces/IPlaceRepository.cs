using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAllPlace();
        Task<Place> GetPlaceById(int id);
        Task<bool> InsertPlace(Place place);
        Task<bool> UpdatePlace(Place place);
        Task<bool> DeletePlace(Place place);
    }
}
