using System.Collections.Generic;
using System.Threading.Tasks;
using SoldierMovementTracking.Models;

namespace SoldierMovementTracking.Services
{
    public interface ISoldierService
    {
        Task<IEnumerable<Soldier>> GetAllSoldiersAsync();
        Task<Soldier> GetSoldierByIdAsync(int id);
        Task<Soldier> AddSoldierAsync(Soldier soldier);
        Task<Soldier> UpdateSoldierAsync(Soldier soldier);
        Task<bool> DeleteSoldierAsync(int id);
    }
}
