using System.Collections.Generic;
using System.Threading.Tasks;
using SoldierMovementTracking.Models;

namespace SoldierMovementTracking.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetPositionsBySoldierIdAsync(int soldierId);
        Task<Position> AddPositionAsync(Position position);
        Task<Position> UpdatePositionAsync(Position position);
        Task<bool> DeletePositionAsync(int id);
    }
}
