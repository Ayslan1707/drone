using DroneMonitoramento.Data;
using DroneMonitoramento.Models;
using Microsoft.EntityFrameworkCore;

namespace DroneMonitoramento.Services
{
    public interface Interface
    {
    }
    public interface IDroneService
    {
        Task<IEnumerable<Drone>> GetDronesAsync();
        Task<Drone> GetDroneByIdAsync(int id);
        Task AddDroneAsync(Drone drone);
        Task UpdateDroneAsync(Drone drone);
        Task DeleteDroneAsync(int id);
    }

    public class DroneService : IDroneService
    {
        private readonly DroneContext _context;

        public DroneService(DroneContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Drone>> GetDronesAsync()
        {
            return await _context.Drones.ToListAsync();
        }

        public async Task<Drone> GetDroneByIdAsync(int id)
        {
            return await _context.Drones.FindAsync(id);
        }

        public async Task AddDroneAsync(Drone drone)
        {
            _context.Drones.Add(drone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDroneAsync(Drone drone)
        {
            _context.Entry(drone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDroneAsync(int id)
        {
            var drone = await _context.Drones.FindAsync(id);
            if (drone != null)
            {
                _context.Drones.Remove(drone);
                await _context.SaveChangesAsync();
            }
        }
    }

}
