using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras
{
    class Vertex
    {
        //string to give a name to each vertex
        string name;
        public string Name { get => name; set => name = value; }

        //boolean to check if a Vertex is visited
        bool visited;
        public bool Visited { get => visited; set => visited = value; }

        //int for total distance from established node to this one
        int totalDistance;
        public int TotalDistance { get => totalDistance; set => totalDistance = value; }

        //contains whatever the nearest vertex is
        Vertex nearestVertex;
        public Vertex NearestVertex { get => nearestVertex; set => nearestVertex = value; }

        /// <summary>
        /// Constructor, passing in name and distance
        /// </summary>
        /// <param name="name"></param>
        public Vertex(string name, int distance)
        {
            Name = name;
            TotalDistance = distance;
            NearestVertex = null;
            Visited = false;
        }
    }
}
