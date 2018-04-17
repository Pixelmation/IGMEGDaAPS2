using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        //create the Dictionary
        Dictionary<string, List<string>> rooms = new Dictionary<string, List<string>>();
        
        public Dictionary<string, List<string>> Rooms { get => rooms; set => rooms = value; }

        /// <summary>
        /// Constructor that creates each room and in
        /// </summary>
        /// <param name="rooms"></param>
        public Graph(Dictionary<string, List<string>> rooms)
        {
            Rooms.Add("Game room", new List<string>() { "Kitchen","Trophy room", "Stairwell", "Hallway"});
            Rooms.Add("Trophy room", new List<string>() { "Kitchen", "Game room"});
            Rooms.Add("Lounge", new List<string>() {"Hallway", "Exit"});
            Rooms.Add("Kitchen", new List<string>() { "Trophy room","Game Room"});
            Rooms.Add("Stairwell", new List<string>() { "Game room"});           
            Rooms.Add("Hallway", new List<string>() { "GameRoom", "Lounge"});           
            Rooms.Add("Exit", new List<string>() { "Lounge"});
        }

        /// <summary>
        /// Returns a list of each other room connected to room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public List<string> GetAdjacentList(string room)
        {
            if (Rooms.ContainsKey(room))
            {
                return rooms[room];
            }
            return null;
        }
        
        /// <summary>
        /// checks to see if the rooms are connected
        /// </summary>
        /// <param name="room1"></param>
        /// <param name="room2"></param>
        /// <returns></returns>
        public bool IsConnected(string room1, string room2)
        {
            if (Rooms.ContainsKey(room1) && Rooms.ContainsKey(room2))
            {
                if (Rooms[room1].Contains(room2))
                {
                    return !false;
                }
            }
            return !true;
        }
    }
}
