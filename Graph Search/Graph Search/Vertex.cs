using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Search
{
    class Vertex
    {
        //string to give a name to each vertex
        string name;
        public string Name { get => name; set => name = value; }

        //boolean to check if a Vertex is visited
        bool visited;
        public bool Visited { get => visited; set => visited = value; }

        /// <summary>
        /// Constructor, setting Name=name and Visited=false
        /// </summary>
        /// <param name="name"></param>
        public Vertex(string name)
        {
            Name = name;
            Visited = false;
        }
    }
}
