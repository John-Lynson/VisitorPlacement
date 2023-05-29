using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacement.Managers;

namespace VisitorPlacement.Klasses
{
    public class Row
    {
        public int Number { get; set; }
        public List<Seat> Seats { get; set; }
        public int ObstacleSeats { get; set; }

        public Row(int number, int length, int obstacleSeats)
        {
            Number = number;
            ObstacleSeats = obstacleSeats;
            Seats = new List<Seat>();
            for (int i = 0; i < length; i++)
            {
                Seats.Add(new Seat { Number = i + 1, IsObstacle = i >= length - obstacleSeats });
            }
        }
    }
}