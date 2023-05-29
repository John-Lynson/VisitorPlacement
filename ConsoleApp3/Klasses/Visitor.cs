using System;

namespace VisitorPlacement.Klasses
{
    public enum VisitorType
    {
        Adult,
        Child
    }

    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GroupId { get; set; }

        public bool IsChild
        {
            get
            {
                // A visitor is considered a child if he/she is under 13 years old.
                return DateTime.Now.Year - DateOfBirth.Year < 13;
            }
        }

        public VisitorType Type
        {
            get
            {
                return IsChild ? VisitorType.Child : VisitorType.Adult;
            }
        }
    }
}
