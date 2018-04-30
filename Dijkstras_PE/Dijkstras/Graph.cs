using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras
{
    class Graph
    {
        //adkacency matrix
        int[,] adjMatrix = new int[7, 7]
        {
            //A   B   C  D  E  F  G
            { 0, 15, 20, 0, 0, 0, 0},  //A
            { 15, 0, 10, 0, 20, 0, 0}, //B
            { 20, 10, 0, 5, 0, 0, 0},  //C
            { 0,  0,  5, 0, 5, 0, 0},  //D
            { 0, 20, 0, 5, 0, 20, 15}, //E
            { 0,  0, 0, 0, 20, 0, 10}, //F
            { 0,  0, 0, 0, 15, 10, 0}  //G
        };

        //dictionary for vertices
        Dictionary<string, Vertex> dictvertices = new Dictionary<string, Vertex>();
        public Dictionary<string, Vertex> DictVertices { get => dictvertices; set => dictvertices = value; }

        //list for vertices
        List<Vertex> listvertices = new List<Vertex>();
        public List<Vertex> ListVertices { get => listvertices; set => listvertices = value; }

        /// <summary>
        /// Constructor, adds rooms
        /// </summary>
        public Graph()
        {
            Vertex lounge = new Vertex("lounge");
            ListVertices.Add(lounge);

            Vertex library = new Vertex("library");
            ListVertices.Add(library);

            Vertex kitchen = new Vertex("kitchen");
            ListVertices.Add(kitchen);

            Vertex hallway = new Vertex("hallway");
            ListVertices.Add(hallway);

            Vertex stairs = new Vertex("stairs");
            ListVertices.Add(stairs);

            Vertex bedroom = new Vertex("bedroom");
            ListVertices.Add(bedroom);

            Vertex restroom = new Vertex("restroom");
            ListVertices.Add(restroom);

            foreach (Vertex item in ListVertices)
            {
                DictVertices.Add(item.Name, item);
            }
        }

        /// <summary>
        /// Resets all fields to default
        /// </summary>
        public void Reset()
        {
            foreach (Vertex item in ListVertices)
            {
                item.Visited = false;
                item.TotalDistance = int.MaxValue;
                item.Permanent = false;
                item.NearestVertex = null;
            }
        }

        /// <summary>
        /// Finds the next closest vertex to name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Vertex GetUnvisitedNeighbor(string name)
        {
            //if the Key exists, cycle through each other room for one that's connected
            if (DictVertices.ContainsKey(name))
            {
                for (int i = 0; i < ListVertices.Count; i++)
                {
                    if (adjMatrix[ListVertices.IndexOf(DictVertices[name]), i] != 0)
                    {
                        //if it finds one, set it's visited to true and return it
                        if (DictVertices.ContainsValue(ListVertices[i]) && ListVertices[i].Visited == false)
                        {
                            ListVertices[i].Visited = true;
                            return ListVertices[i];
                        }
                    }
                }
            }

            //if the name doesn't exist, give an error
            else
            {
                Console.WriteLine("Invalid Room");
                return null;
            }

            //if it doesn't have a connected and unvisited room
            return null;
        }

        private int PathTraveled(Vertex vertex1, Vertex vertex2)
        {
            if (DictVertices.ContainsKey(vertex1.Name) == false || DictVertices.ContainsKey(vertex2.Name) == false)
            {
                Console.WriteLine("Vertex not found");
                return -1;
            }

            return adjMatrix[ListVertices.IndexOf(DictVertices[vertex1.Name]), ListVertices.IndexOf(DictVertices[vertex2.Name])];
        }

        /// <summary>
        /// gets the shortest path for each vertice
        /// </summary>
        /// <param name="start"></param>
        public void ShortestPath(string start)
        {
            if (DictVertices.ContainsKey(start) == false)
            {
                Console.WriteLine("Invalid Name");
                return;
            }
            //saves the origin as teh original room
            string save = start;

            Reset();

            //request user input and set it to lowercase
            Console.WriteLine("You are in the lounge.");
            Console.WriteLine("Input the room where you want to go: ");
            string destination = Console.ReadLine();
            destination = destination.ToLower();

            //adjust value of the starting node
            DictVertices[start].Permanent = true;
            DictVertices[start].TotalDistance = 0;

            //sets currentVertex to the origin
            Vertex currentVertex = DictVertices[start];

            //while there are nodes not set to permanent, set them to permanent
            bool allPermanent = false;

            while (allPermanent == false)
            {
                allPermanent = true;

                foreach (Vertex item in ListVertices)
                {
                    if (item.Permanent == false)
                    {
                        allPermanent = false;
                        break;
                    }
                }

                //if they're all permanent, exit the loop
                if (allPermanent == true)
                {
                    break;
                }

                //sets current to the next closest neighbor
                currentVertex = GetUnvisitedNeighbor(start);

                //loops until there are no more unvisited Vertices
                while (currentVertex != null)
                {
                    //sets distance to the origin's total distance and the path travelled from the origin to the current working vertex
                    int distance = DictVertices[start].TotalDistance + PathTraveled(DictVertices[start], currentVertex);

                    //check to see if the new distance is lower than the previous
                    if (distance < currentVertex.TotalDistance)
                    {
                        //set the total distance to the possible distance
                        currentVertex.TotalDistance = distance;
                        currentVertex.NearestVertex = DictVertices[start];
                    }

                    //move to next neighbor that hasn't been visited
                    currentVertex = GetUnvisitedNeighbor(start);
                }

                //sets the shortest distance
                Vertex newVertex = new Vertex("name");
                newVertex.TotalDistance = int.MaxValue;
                foreach (Vertex item in ListVertices)
                {
                    if (item.Permanent == false)
                    {
                        if (item.TotalDistance <= newVertex.TotalDistance)
                        {
                            newVertex = item;
                            
                        }
                    }

                }

                newVertex.Permanent = true;
                start = newVertex.Name;
                
            }

            //print out each vertex then it's nearest neighbor
            currentVertex = DictVertices[destination];
            Console.WriteLine("\nThe shortest path from " + save + " to " + destination + " is:");
            while (currentVertex != null)
            {
                Console.WriteLine(currentVertex.Name);
                currentVertex = currentVertex.NearestVertex;
            }
            Console.ReadLine();
        }
    }
}
