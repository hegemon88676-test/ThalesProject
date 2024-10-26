using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoldierMovementTracking.Data;
using SoldierMovementTracking.Models;

namespace SoldierMovementTracking.Services
{
    public class PositionService : IPositionService
    {
        private readonly MilitaryContext _context;

        public PositionService(MilitaryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetPositionsBySoldierIdAsync(int soldierId)
        {
            return await _context.Positions
                .Where(p => p.SoldierID == soldierId)
                .ToListAsync();
        }

        public async Task<Position> AddPositionAsync(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position;
        }

        public async Task<Position> UpdatePositionAsync(Position position)
        {
            _context.Entry(position).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return position;
        }

        public async Task<bool> DeletePositionAsync(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return false;
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
