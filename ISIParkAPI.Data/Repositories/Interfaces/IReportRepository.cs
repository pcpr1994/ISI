using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISIParkAPI.Data.Repositories.Interfaces
{
    /// <summary>
    /// This interface it will be consumed by the class ReportRepository
    /// </summary>
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReport();
        Task<Report> GetReportDetails(int id);
        Task<bool> InsertReport(Report report);
        Task<bool> UpdateReport(Report report);
        Task<bool> DeleteReport(Report report);
    }
}
