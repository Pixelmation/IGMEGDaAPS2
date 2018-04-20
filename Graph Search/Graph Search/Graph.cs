using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Search
{
    class Graph
    {
        int[,] adjMatrix = new int[5, 5]
        {
            //A  B  C  D  E
            { 0, 1, 1, 0, 0}, //A
            { 1, 0, 1, 1, 0}, //B
            { 1, 1, 0, 0, 0}, //C
            { 0, 1, 0, 0, 1}, //D
            { 0, 0, 0, 1, 0}  //E
        };

        Dictionary<String, Vertex> DictNodes = new Dictionary<string, Vertex>();

        List<Vertex> ListNodes = new List<Vertex>();

        public Graph()
        {
            Vertex vertexA = new Vertex("Kitchen");
            ListNodes.Add(vertexA);

            Vertex vertexB = new Vertex("Trophy room");
            ListNodes.Add(vertexB);

            Vertex vertexC = new Vertex("Game room");
            ListNodes.Add(vertexC);

            Vertex vertexD = new Vertex("Lounge");
            ListNodes.Add(vertexD);

            Vertex vertexE = new Vertex("Exit");
            ListNodes.Add(vertexE);

            foreach (Vertex item in ListNodes)
            {
                DictNodes.Add(item.Name, item);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < ListNodes.Count - 1; i++)
            {
                ListNodes[i].Visited = false;
            }
        }

        public Vertex GetUnvisitedneighbor(String name)
        {
            bool foundVisited;

            int column = 0;

            int currentIndex = 0;

            if (DictNodes.ContainsKey(name))
            {
                currentIndex = ListNodes.IndexOf(DictNodes[name]);

                while (foundVisited = false && (column < adjMatrix.GetLength(1)))
                {

                }
            }
        }

        public void DepthFirst(String name)
        {

        }
    }
}
