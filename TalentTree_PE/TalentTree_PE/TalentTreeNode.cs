using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTree_PE
{
    class TalentTreeNode
    {
        //Name and it's property
        string name;
        public string Name { get => name; set => name = value; }

        //Learned and it's property
        bool learned;
        public bool Learned { get => learned; set => learned = value; }

        //LeftNode and it's property
        TalentTreeNode leftNode;
        public TalentTreeNode LeftNode { get => leftNode; set => leftNode = value; }

        //RightNode and it's property
        TalentTreeNode rightNode;
        public TalentTreeNode RightNode { get => rightNode; set => rightNode = value; }

        public TalentTreeNode(string name, bool learned, TalentTreeNode leftNode, TalentTreeNode rightNode)
        {
            Name = name;
            Learned = learned;
            LeftNode = leftNode;
            RightNode = rightNode;
        }


        public void ListAllAbilities()
        {
            Console.WriteLine("All possible classes:");

        }

        public void ListKnownAbilities()
        {

        }

        public void ListPossibleAbilities()
        {

        }
    }
}
