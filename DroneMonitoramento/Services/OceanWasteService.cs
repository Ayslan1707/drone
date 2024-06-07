using DroneMonitoramento.Data;
using DroneMonitoramento.Interfaces;
using DroneMonitoramento.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMonitoramento.Services
{
    public class OceanWasteService : IOceanWasteService
    {
        private readonly DroneContext _context;

        public OceanWasteService(DroneContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OceanWaste>> GetOceanWastes()
        {
            return await _context.OceanWastes.ToListAsync();
        }

        public async Task<OceanWaste> GetOceanWaste(int id)
        {
            return await _context.OceanWastes.FindAsync(id);
        }

        public async Task<OceanWaste> AddOceanWaste(OceanWaste oceanWaste)
        {
            _context.OceanWastes.Add(oceanWaste);
            await _context.SaveChangesAsync();
            return oceanWaste;
        }

        public async Task<bool> UpdateOceanWaste(int id, OceanWaste oceanWaste)
        {
            if (id != oceanWaste.Id)
                return false;

            _context.Entry(oceanWaste).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOceanWaste(int id)
        {
            var oceanWaste = await _context.OceanWastes.FindAsync(id);
            if (oceanWaste == null)
                return false;

            _context.OceanWastes.Remove(oceanWaste);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool OceanWasteExists(int id)
        {
            return _context.OceanWastes.Any(e => e.Id == id);
        }
    }
}
