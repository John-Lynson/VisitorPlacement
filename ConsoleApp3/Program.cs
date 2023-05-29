using System;
using VisitorPlacement.Klasses;
using VisitorPlacement.Managers;
using VisitorPlacement.UI;

namespace VisitorPlacement
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            EventManager eventManager = new EventManager();
            GroupManager groupManager = new GroupManager();

            // Start the user interface
            userInterface.Start();

            // Create an event
            string createEventResult = eventManager.CreateEvent("My Event");
            Console.WriteLine(createEventResult); // Output the result

            // Create a group
            Group group = groupManager.CreateGroup(1);
            // Add a visitor to the group
            string addVisitorResult = groupManager.AddVisitorToGroup(1, new Visitor());
            Console.WriteLine(addVisitorResult); // Output the result

            // Register the group to the event
            string registerGroupResult = eventManager.RegisterGroupToEvent("My Event", group);
            Console.WriteLine(registerGroupResult); // Output the result

            // Assign seats for the event
            string assignSeatsResult = eventManager.AssignSeatsForEvent("My Event");
            Console.WriteLine(assignSeatsResult); // Output the result

            // Print the event status
            string eventStatus = eventManager.PrintEventStatus("My Event");
            Console.WriteLine(eventStatus); // Output the event status
        }
    }
}