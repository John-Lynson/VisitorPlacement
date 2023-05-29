using System;
using System.Linq;
using System.Collections.Generic;
using VisitorPlacement.Klasses;

namespace VisitorPlacement.Managers
{
    public class GroupManager
    {
        List<Group> Groups { get; set; }

        public GroupManager()
        {
            Groups = new List<Group>();
        }

        public Group CreateGroup(int id)
        {
            Group newGroup = new Group(id);
            Groups.Add(newGroup);
            return newGroup;
        }

        public Group GetGroupById(int groupId)
        {
            Group foundGroup = Groups.FirstOrDefault(g => g.Id == groupId);

            if (foundGroup == null)
            {
                return null;
            }

            return foundGroup;
        }

        public string AddVisitorToGroup(int groupId, Visitor visitor)
        {
            Group groupToModify = Groups.FirstOrDefault(g => g.Id == groupId);

            if (groupToModify == null)
            {
                return $"Group with ID {groupId} not found.";
            }

            bool success = groupToModify.AddMember(visitor);

            if (success)
            {
                return $"Visitor {visitor.Id} added to Group {groupId} successfully!";
            }
            else
            {
                return $"Failed to add Visitor {visitor.Id} to Group {groupId}. Maybe the visitor is a child and the group is empty.";
            }
        }
    }
}
