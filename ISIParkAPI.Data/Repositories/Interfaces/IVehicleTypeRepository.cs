using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IVehicleTypeRepository
    {
        Task<IEnumerable<VehicleType>> GetAllVehicleType();
        Task<VehicleType> GetVehicleTypeDetails(int id);
        Task<bool> InsertVehicleType(VehicleType vehicleType);
        Task<bool> UpdateVehicleType(VehicleType vehicleType);
        Task<bool> DeleteVehicleType(VehicleType vehicleType);
    }
}
