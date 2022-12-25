using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IPlaceTypeRepository
    {
        Task<IEnumerable<PlaceType>> GetAllPlaceType();
        Task<PlaceType> GetPlaceTypeDetails(int id);
        Task<bool> InsertPlaceType(PlaceType placeType);
        Task<bool> UpdatePlaceType(PlaceType placeType);
        Task<bool> DeletePlaceType(PlaceType placeType);
    }
}
