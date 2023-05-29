using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacement.Managers;

namespace VisitorPlacement.Klasses
{
    public class Seat
    {
        public int Number { get; set; }
        public Visitor OccupiedBy { get; set; }
        public bool IsObstacle { get; set; } // New field

        public bool IsOccupied()
        {
            return OccupiedBy != null;
        }
    }
}