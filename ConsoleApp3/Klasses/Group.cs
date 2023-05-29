using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacement.Managers;

namespace VisitorPlacement.Klasses
{
    public class Group
    {
        public int Id { get; set; }
        public List<Visitor> Members { get; set; } // This will be your 'Visitors' list

        public Group(int id)
        {
            Id = id;
            Members = new List<Visitor>();
        }


        public bool AddMember(Visitor visitor)
        {
            if (!Members.Any() && visitor.IsChild)
            {
                return false; // Cannot add a child as the first member of the group.
            }

            Members.Add(visitor);
            return true; // Member added successfully
        }
    }
}