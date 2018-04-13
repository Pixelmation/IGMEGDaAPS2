using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DynamicTreeStarterCode
{
	/// <summary>
	/// Represents a tree-centric data structure
	/// that can have data dynamically inserted, 
	/// and can be drawn as a literal "tree" on the screen
	/// </summary>
	class Tree : DrawableTree
	{
		// Already has an inherited root node field called "root"

		/// <summary>
		/// Creates a tree that can be drawn
		/// </summary>
		/// <param name="sb">The sprite batch used to draw</param>
		/// <param name="treeColor">The color of this tree</param>
		public Tree(SpriteBatch sb, Color treeColor)
			: base(sb, treeColor)
		{ }

		/// <summary>
		/// Public facing Insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		public void Insert(int data)
		{
            // *** Fill in this method ****************************************
            if (root == null)
            {
                root = new TreeNode(data);

            }
            else
            {
                //TreeNode node = new TreeNode(data);
                Insert(data, root);
            }
		}

		/// <summary>
		/// Private recursive insert method
		/// </summary>
		/// <param name="data">The data to insert</param>
		/// <param name="node">The node to attempt to insert into</param>
		private void Insert(int data, TreeNode node)
		{
            // *** Fill in this method ****************************************
            //if the node.left is null, set the new data as the new node.left
            if (data < node.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new TreeNode(data);
                }
                else
                {
                    Insert(data, node.Left);
                }
            }

            //if the node.right is null, set the new data as the new node.right
            if (data >= node.Data)
            {
                if (node.Right == null)
                {
                    node.Right = new TreeNode(data);
                }
                else
                {
                    Insert(data, node.Right);
                }
            }
        }
	}
}
