using System.Collections.Generic;

namespace SoldierMovementTracking.Models
{
    public class Soldier
    {
        public int SoldierID { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Country { get; set; }
        public string TrainingInfo { get; set; }

        // Navigation property
        public ICollection<Position> Positions { get; set; }
    }
}
