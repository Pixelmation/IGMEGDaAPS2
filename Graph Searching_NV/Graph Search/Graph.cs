using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Search
{
    class Graph
    {
        //create a 5x5 matrix
        int[,] adjMatrix = new int[5, 5]
        {
            //A  B  C  D  E
            { 0, 1, 1, 0, 0}, //A
            { 1, 0, 1, 1, 0}, //B
            { 1, 1, 0, 0, 0}, //C
            { 0, 1, 0, 0, 1}, //D
            { 0, 0, 0, 1, 0}  //E
        };

        //new dictionary of nodes
        Dictionary<String, Vertex> DictNodes = new Dictionary<string, Vertex>();

        //new List of of nodes
        List<Vertex> ListNodes = new List<Vertex>();

        /// <summary>
        /// Constructor that creates the vertecies, adding them to the list and dictionary
        /// </summary>
        public Graph()
        {
            Vertex vertexA = new Vertex("Kitchen");
            ListNodes.Add(vertexA);

            Vertex vertexC = new Vertex("Game room");
            ListNodes.Add(vertexC);

            Vertex vertexB = new Vertex("Trophy room");
            ListNodes.Add(vertexB);

            Vertex vertexD = new Vertex("Lounge");
            ListNodes.Add(vertexD);

            Vertex vertexE = new Vertex("Exit");
            ListNodes.Add(vertexE);

            foreach (Vertex item in ListNodes)
            {
                DictNodes.Add(item.Name, item);
            }
        }

        /// <summary>
        /// sets each node's visited property back to false
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < ListNodes.Count; i++)
            {
                ListNodes[i].Visited = false;
            }
        }

        /// <summary>
        /// Checks to see what the next connected room is with the matrix
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Vertex GetUnvisitedneighbor(String name)
        {
            //create a column and row to check
            int column = 0;
            int row = 0;

            //checks if the name exists
            if (DictNodes.ContainsKey(name))
            {
                //sets row to the index of the name
                row = ListNodes.IndexOf(DictNodes[name]);

                //checks every column of the matrix for a connection
                while (column < adjMatrix.GetLength(1))
                {
                    if ((adjMatrix[row, column] == 1) && (ListNodes[column].Visited == false))
                    {
                        //sets the Node to visited and returns it
                        ListNodes[column].Visited = true;
                        return ListNodes[column];
                    }
                    //add 1 to column
                    column++;
                }
            }
            //return null if a connection or the key can't be found
            return null;
        }

        /// <summary>
        /// Goes through each row of the matrix, only advancing after finding the connection
        /// </summary>
        /// <param name="name"></param>
        public void DepthFirst(String name)
        {
            if (DictNodes.ContainsKey(name))
            {
                //sets a current vertex
                Vertex currentVertex = DictNodes[name];

                //resets everything to visited = false
                Reset();

                //creates a stack of vertices
                Stack<Vertex> stack = new Stack<Vertex>();

                //print the vertex
                Console.WriteLine("Found vertex: " + DictNodes[name].Name);

                //set it to true and add it to the stack
                DictNodes[name].Visited = true;
                stack.Push(DictNodes[name]);

                //cycles through each room
                while (stack.Count > 0)
                {
                    //make the nearest neighbor the currentvertex
                    currentVertex = GetUnvisitedneighbor(stack.Peek().Name);

                    //checks to see if there's a current vertex
                    if (currentVertex != null)
                    {
                        //print it
                        Console.WriteLine("Found vertex: " + currentVertex.Name);

                        //set visited to true
                        currentVertex.Visited = true;

                        //push it to the stack
                        stack.Push(currentVertex);

                    }
                    //remove it from the stack
                    else
                    {
                        stack.Pop();
                    }
                }
                return;
            }
            //if name isn't found, just return
            Console.WriteLine("invalid name");
            return;
        }
    }
}
