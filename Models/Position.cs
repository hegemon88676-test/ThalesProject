using System;

namespace SoldierMovementTracking.Models
{
    public class Position
    {
        public int PositionID { get; set; }
        public int SoldierID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation property
        public Soldier Soldier { get; set; }
    }
}
