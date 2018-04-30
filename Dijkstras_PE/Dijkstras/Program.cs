using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstras
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            //call Shortest path and pass in lounge
            graph.ShortestPath("lounge");
        }
    }
}
