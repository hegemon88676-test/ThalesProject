using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoldierMovementTracking.Data;
using SoldierMovementTracking.Models;

namespace SoldierMovementTracking.Services
{
    public class SoldierService : ISoldierService
    {
        private readonly MilitaryContext _context;

        public SoldierService(MilitaryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Soldier>> GetAllSoldiersAsync()
        {
            return await _context.Soldiers.ToListAsync();
        }

        public async Task<Soldier> GetSoldierByIdAsync(int id)
        {
            return await _context.Soldiers.FindAsync(id);
        }

        public async Task<Soldier> AddSoldierAsync(Soldier soldier)
        {
            _context.Soldiers.Add(soldier);
            await _context.SaveChangesAsync();
            return soldier;
        }

        public async Task<Soldier> UpdateSoldierAsync(Soldier soldier)
        {
            _context.Entry(soldier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return soldier;
        }

        public async Task<bool> DeleteSoldierAsync(int id)
        {
            var soldier = await _context.Soldiers.FindAsync(id);
            if (soldier == null)
            {
                return false;
            }

            _context.Soldiers.Remove(soldier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
