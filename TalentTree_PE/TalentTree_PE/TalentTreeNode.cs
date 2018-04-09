using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTree_PE
{
    class TalentTreeNode
    {
        #region Properties
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
        #endregion

        #region constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="learned"></param>
        /// <param name="leftNode"></param>
        /// <param name="rightNode"></param>
        public TalentTreeNode(string name, bool learned, TalentTreeNode leftNode, TalentTreeNode rightNode)
        {
            Name = name;
            Learned = learned;
            LeftNode = null;
            RightNode = null;
        }
        #endregion

        #region Methods

        #region all classes
        /// <summary>
        /// prints every node
        /// </summary>
        public void ListAllClasses()
        {
            Console.WriteLine(this.Name);

            //recursively goes through each node
            if (LeftNode != null)
            {
                LeftNode.ListAllClasses();
            }

            if (RightNode != null)
            {
                RightNode.ListAllClasses();
            }

        }
        #endregion

        #region Known classes
        /// <summary>
        /// prints each node that is set to true
        /// </summary>
        public void ListKnownClasses()
        {
                //recursive case
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

            //base case
            else
            {

            }
        }
        #endregion

        #region possible classes
        /// <summary>
        /// Searches each node, if the left or Right node is not learned and current is, then print the left or right node
        /// </summary>
        public void ListPossibleClasses()
        {
            //if learned, go to the next node
            if (LeftNode != null && LeftNode.Learned)
            {
                LeftNode.ListPossibleClasses();
            }
            if (RightNode != null && RightNode.Learned)
            {
                RightNode.ListPossibleClasses();
            }

            //if next nodes aren't known, print them
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
        #endregion

        #endregion
    }
}
