using System;
using System.Collections.Generic;
using System.Text;
using VisitorPlacement.Managers;

namespace VisitorPlacement.Klasses
{
    public class Event
    {
        public string Name { get; set; }
        public List<Sector> Sectors { get; set; }
        public List<Group> RegisteredGroups { get; set; }

        public Event(string name)
        {
            Name = name;
            Sectors = new List<Sector>();
            RegisteredGroups = new List<Group>();
        }

        public int TotalSeats()
        {
            int totalSeats = 0;

            foreach (var sector in Sectors)
            {
                foreach (var row in sector.Rows)
                {
                    totalSeats += row.Seats.Count;
                }
            }

            return totalSeats;
        }

        public int TotalVisitors()
        {
            int totalVisitors = 0;

            foreach (var group in RegisteredGroups)
            {
                totalVisitors += group.Members.Count;
            }

            return totalVisitors;
        }

        public string RegisterGroup(Group group)
        {
            if (TotalVisitors() + group.Members.Count > TotalSeats())
            {
                return "Registration failed. The event is full.";
            }

            RegisteredGroups.Add(group);
            return $"Registration successful. Welcome Group {group.Id}!";
        }

        public void AddSector(char letter, int rows, int rowLength, int obstacleSeats) // Added obstacleSeats parameter
        {
            Sectors.Add(new Sector(letter, rows, rowLength, obstacleSeats)); // Added obstacleSeats argument
        }

        public string AssignSeats()
        {
            int assignedVisitors = 0;

            foreach (var group in RegisteredGroups)
            {
                foreach (var sector in Sectors)
                {
                    foreach (var row in sector.Rows)
                    {
                        // Skip rows with obstacles for children.
                        if (group.Members.Any(member => member.IsChild) && row.ObstacleSeats > 0) continue;

                        // Find the first unoccupied seat in the row.
                        int startIndex = -1;
                        for (int i = 0; i < row.Seats.Count; i++)
                        {
                            if (row.Seats[i].OccupiedBy == null)
                            {
                                startIndex = i;
                                break;
                            }
                        }

                        // Check if there are enough consecutive seats for the entire group.
                        if (startIndex >= 0 && startIndex + group.Members.Count <= row.Seats.Count &&
                            !row.Seats.Skip(startIndex).Take(group.Members.Count).Any(seat => seat.OccupiedBy != null))
                        {
                            for (int i = 0; i < group.Members.Count; i++)
                            {
                                // If the member is a child and the seat is next to an obstacle, skip to the next seat.
                                if (group.Members[i].IsChild && i < row.ObstacleSeats)
                                {
                                    i++;
                                }
                                row.Seats[startIndex + i].OccupiedBy = group.Members[i];
                                assignedVisitors++;
                            }
                            goto GroupAssigned;
                        }
                    }
                }

                // If we've gotten here, then the group could not be assigned seats. We return with an error message.
                return $"Not all visitors could be assigned a seat. {assignedVisitors} out of {TotalVisitors()} visitors have been assigned a seat.";

            GroupAssigned:; // Empty statement for the "goto" to target.
            }

            return "All visitors have been assigned a seat.";
        }

                public string PrintStatus()
                {
                    StringBuilder status = new StringBuilder();

                    status.AppendLine($"Event Name: {Name}");

                    foreach (var sector in Sectors)
                    {
                        status.AppendLine($"Sector: {sector.Letter}");

                        foreach (var row in sector.Rows)
                        {
                            status.AppendLine($"Row: {row.Number}");

                            foreach (var seat in row.Seats)
                            {
                                string visitor = seat.OccupiedBy == null ? "Empty" : $"Occupied by {seat.OccupiedBy.Id}";
                                status.AppendLine($"Seat: {seat.Number} - {visitor}");
                            }
                        }
                    }

                    return status.ToString();
                }
            }
        }
