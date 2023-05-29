using System;
using VisitorPlacement.Managers;
using VisitorPlacement.Klasses;

namespace VisitorPlacement.UI
{
    public class UserInterface
    {
        private EventManager eventManager;
        private GroupManager groupManager;
        private VisitorManager visitorManager;


        public UserInterface()
        {
            eventManager = new EventManager();
            groupManager = new GroupManager();
            visitorManager = new VisitorManager();
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Create event");
                Console.WriteLine("2. Add sector to event");
                Console.WriteLine("3. Register group to event");
                Console.WriteLine("4. Create group");
                Console.WriteLine("5. Add visitor to group");
                Console.WriteLine("6. Assign seats for event");
                Console.WriteLine("7. Print event status");
                Console.WriteLine("8. Exit");

                string userInput = Console.ReadLine();
                string eventName;
                int groupId;
                Group group;

                switch (userInput)
                {
                    case "1":
                        Console.Write("Enter event name: ");
                        eventName = Console.ReadLine();
                        string createResult = eventManager.CreateEvent(eventName);
                        Console.WriteLine(createResult);
                        break;

                    case "2":
                        Console.Write("Enter event name: ");
                        eventName = Console.ReadLine();
                        Console.Write("Enter sector letter: ");
                        char letter = char.Parse(Console.ReadLine());
                        Console.Write("Enter number of rows: ");
                        int rows = int.Parse(Console.ReadLine());
                        Console.Write("Enter row length: ");
                        int rowLength = int.Parse(Console.ReadLine());
                        Console.Write("Enter number of obstacle seats: ");
                        int obstacleSeats = int.Parse(Console.ReadLine());
                        string addSectorResult = eventManager.AddSectorToEvent(eventName, letter, rows, rowLength, obstacleSeats);
                        Console.WriteLine(addSectorResult);
                        break;

                    case "3":
                        Console.Write("Enter event name: ");
                        eventName = Console.ReadLine();
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        group = groupManager.GetGroupById(groupId);
                        if (group == null)
                        {
                            Console.WriteLine($"Group with ID {groupId} not found.");
                            break;
                        }
                        string registerGroupResult = eventManager.RegisterGroupToEvent(eventName, group);
                        Console.WriteLine(registerGroupResult);
                        break;

                    case "4":
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        Group newGroup = groupManager.CreateGroup(groupId);
                        Console.WriteLine($"Group {newGroup.Id} created successfully!");
                        break;

                    case "5":
                        Console.Write("Enter group ID: ");
                        groupId = int.Parse(Console.ReadLine());
                        Console.Write("Enter visitor ID: ");
                        int visitorId = int.Parse(Console.ReadLine());
                        Console.Write("Enter visitor name: ");
                        string visitorName = Console.ReadLine();
                        Visitor newVisitor = visitorManager.CreateVisitor(visitorId, visitorName, DateTime.Now, groupId);
                        string addVisitorResult = groupManager.AddVisitorToGroup(groupId, newVisitor);
                        Console.WriteLine(addVisitorResult);
                        break;


                    case "6":
                        Console.Write("Enter event name: ");
                        eventName = Console.ReadLine();
                        string assignSeatsResult = eventManager.AssignSeatsForEvent(eventName);
                        Console.WriteLine(assignSeatsResult);
                        break;

                    case "7":
                        Console.Write("Enter event name: ");
                        eventName = Console.ReadLine();
                        string eventStatus = eventManager.PrintEventStatus(eventName);
                        Console.WriteLine(eventStatus);
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
