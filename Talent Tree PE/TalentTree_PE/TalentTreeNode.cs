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
            LeftNode = null;
            RightNode = null;
        }


        public void ListAllClasses()
        {
            Console.WriteLine(this.Name);

            if (LeftNode != null)
            {
                LeftNode.ListKnownClasses();
            }

            if (RightNode != null)
            {
                RightNode.ListKnownClasses();
            }

        }

        public void ListKnownClasses()
        {
            if (this.Learned)
            {

                Console.WriteLine(this.Name);

                if (LeftNode != null)
                {
                    LeftNode.ListKnownClasses();
                }

                if (RightNode != null)
                {
                    RightNode.ListKnownClasses();
                }
            }
            else
            {

            }
        }

        public void ListPossibleClasses()
        {
            if (LeftNode != null && LeftNode.Learned)
            {
                LeftNode.ListPossibleClasses();
            }
            if (RightNode != null && RightNode.Learned)
            {
                RightNode.ListPossibleClasses();
            }

            if (LeftNode != null && LeftNode.Learned != true)
            {
                Console.WriteLine(LeftNode.Name);
                LeftNode.ListPossibleClasses();
            }
            if (RightNode != null && RightNode.Learned != true)
            {
                Console.WriteLine(RightNode.Name);
                RightNode.ListPossibleClasses();
            }
        }
    }
}
