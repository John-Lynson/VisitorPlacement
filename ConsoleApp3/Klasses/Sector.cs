using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacement.Managers;

namespace VisitorPlacement.Klasses
{
    public class Sector
    {
        public char Letter { get; set; }
        public List<Row> Rows { get; set; }

        public Sector(char letter, int numberOfRows, int rowLength, int obstacleSeats)
        {
            Letter = letter;
            Rows = new List<Row>();

            for (int i = 1; i <= numberOfRows; i++)
            {
                Rows.Add(new Row(i, rowLength, obstacleSeats));
            }
        }
    }
}
