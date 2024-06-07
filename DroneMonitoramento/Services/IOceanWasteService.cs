using DroneMonitoramento.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMonitoramento.Interfaces
{
    public interface IOceanWasteService
    {
        Task<IEnumerable<OceanWaste>> GetOceanWastes();
        Task<OceanWaste> GetOceanWaste(int id);
        Task<OceanWaste> AddOceanWaste(OceanWaste oceanWaste);
        Task<bool> UpdateOceanWaste(int id, OceanWaste oceanWaste);
        Task<bool> DeleteOceanWaste(int id);
        bool OceanWasteExists(int id);
    }
}
