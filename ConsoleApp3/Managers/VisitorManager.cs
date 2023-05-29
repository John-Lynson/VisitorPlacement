using System;
using System.Linq;
using System.Collections.Generic;
using VisitorPlacement.Klasses;

namespace VisitorPlacement.Managers
{
    public class VisitorManager
    {
        List<Visitor> Visitors { get; set; }

        public VisitorManager()
        {
            Visitors = new List<Visitor>();
        }

        public Visitor CreateVisitor(int id, string name, DateTime dob, int groupId)
        {
            Visitor newVisitor = new Visitor
            {
                Id = id,
                Name = name,
                DateOfBirth = dob,
                GroupId = groupId
            };

            Visitors.Add(newVisitor);
            return newVisitor;
        }
    }
}
