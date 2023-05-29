using System;
using System.Linq;
using System.Collections.Generic;
using VisitorPlacement.Klasses;
using VisitorPlacement.Managers;

namespace VisitorPlacement.Managers
{
    public class EventManager
    {
        List<Event> Events { get; set; }

        public EventManager()
        {
            Events = new List<Event>();
        }

        public string CreateEvent(string eventName)
        {
            Event newEvent = new Event(eventName);
            Events.Add(newEvent);

            return $"Event {eventName} created successfully!";
        }

        public string AddSectorToEvent(string eventName, char letter, int rows, int rowLength, int obstacleSeats)
        {
            Event eventToModify = GetEventByName(eventName);

            if (eventToModify == null)
            {
                return $"Event {eventName} not found.";
            }

            eventToModify.AddSector(letter, rows, rowLength, obstacleSeats);

            return $"Sector {letter} added to Event {eventName} successfully!";
        }

        public string RegisterGroupToEvent(string eventName, Group group)
        {
            Event eventToModify = GetEventByName(eventName);

            if (eventToModify == null)
            {
                return $"Event {eventName} not found.";
            }

            return eventToModify.RegisterGroup(group);
        }

        public string AssignSeatsForEvent(string eventName)
        {
            Event eventToModify = GetEventByName(eventName);

            if (eventToModify == null)
            {
                return $"Event {eventName} not found.";
            }

            return eventToModify.AssignSeats();
        }

        public string PrintEventStatus(string eventName)
        {
            Event eventToView = GetEventByName(eventName);

            if (eventToView == null)
            {
                return $"Event {eventName} not found.";
            }

            return eventToView.PrintStatus();
        }

        private Event GetEventByName(string eventName)
        {
            return Events.FirstOrDefault(e => e.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
