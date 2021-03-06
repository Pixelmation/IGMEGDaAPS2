﻿using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace QuadTreeStarter
{
    class QuadTreeNode
    {
        #region Constants
        // The maximum number of objects in a quad
        // before a subdivision occurs
        private const int MAX_OBJECTS_BEFORE_SUBDIVIDE = 3;
        #endregion

        #region Variables
        // The game objects held at this level of the tree
        private List<GameObject> _objects;

        // This quad's rectangle area
        private Rectangle _rect;

        // This quad's divisions
        private QuadTreeNode[] _divisions;
        #endregion

        #region Properties
        /// <summary>
        /// The divisions of this quad
        /// </summary>
        public QuadTreeNode[] Divisions { get { return _divisions; } }

        /// <summary>
        /// This quad's rectangle
        /// </summary>
        public Rectangle Rectangle { get { return _rect; } }

        /// <summary>
        /// The game objects inside this quad
        /// </summary>
        public List<GameObject> GameObjects { get { return _objects; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Quad Tree
        /// </summary>
        /// <param name="x">This quad's x position</param>
        /// <param name="y">This quad's y position</param>
        /// <param name="width">This quad's width</param>
        /// <param name="height">This quad's height</param>
        public QuadTreeNode(int x, int y, int width, int height)
        {
            // Save the rectangle
            _rect = new Rectangle(x, y, width, height);

            // Create the object list
            _objects = new List<GameObject>();

            // No divisions yet
            _divisions = null;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a game object to the quad.  If the quad has too many
        /// objects in it, and hasn't been divided already, it should
        /// be divided
        /// </summary>
        /// <param name="gameObj">The object to add</param>
        public void AddObject(GameObject gameObj)
        {
            // ACTIVITY: Complete this method

            //check to see if there are more object than the max
            if (_objects.Count >= MAX_OBJECTS_BEFORE_SUBDIVIDE && _divisions == null)
            {
                Divide();
            }

            //otherwise just add it to objects
            else if (_divisions == null)
            {
                _objects.Add(gameObj);
                return;
            }

            //check to see if any of the rectangles contains a square
            if (_rect.Contains(gameObj.Rectangle))
            {
                //if it fits in a subdivision, move that square to the smaller subdivision
                for (int i = 0; i < 4; i++)
                {
                    if (_divisions[i]._rect.Contains(gameObj.Rectangle))
                    {
                        _divisions[i].AddObject(gameObj);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Divides this quad into 4 smaller quads.  Moves any game objects
        /// that are completely contained within the new smaller quads into
        /// those quads and removes them from this one.
        /// </summary>
        public void Divide()
        {
            // ACTIVITY: Complete this method
            _divisions = new QuadTreeNode[4];

            //create the upper left, upper right, bottom left, and bottom right rectangles respectively
            QuadTreeNode node1 = new QuadTreeNode(_rect.X, _rect.Y, _rect.Width / 2, _rect.Height / 2);
            QuadTreeNode node2 = new QuadTreeNode(_rect.X + _rect.Width / 2, _rect.Y, _rect.Width / 2, _rect.Height / 2);
            QuadTreeNode node3 = new QuadTreeNode(_rect.X, _rect.Y + _rect.Height / 2, _rect.Width / 2, _rect.Height / 2);
            QuadTreeNode node4 = new QuadTreeNode(_rect.X + _rect.Width / 2, _rect.Y + _rect.Height / 2, _rect.Width / 2, _rect.Height / 2);

            //set each of the nodes above to be the divisions
            _divisions[0] = node1;
            _divisions[1] = node2;
            _divisions[2] = node3;
            _divisions[3] = node4;

            //adds each square in objects to a temp list then moves them to their new leaf nodes
            //temporary save objects in a list to transfer
            List<GameObject> tempObjects = new List<GameObject>();
            tempObjects.AddRange(_objects);

            //clear the objects list for this division

            //recurse to finish transfering objects from parent rectangle
            foreach (GameObject gameObj in tempObjects)
            {
                AddObject(gameObj);
            }
            _objects.Clear();
        }

        /// <summary>
        /// Recursively populates a list with all of the rectangles in this
        /// quad and any subdivision quads.  Use the "AddRange" method of
        /// the list class to add the elements from one list to another.
        /// </summary>
        /// <returns>A list of rectangles</returns>
        public List<Rectangle> GetAllRectangles()
        {
            List<Rectangle> rects = new List<Rectangle>();

            //if there are subdivisions, add each of them then check each of them for more subdivions recursively
            if (_divisions != null)
            {
                for (int i = 0; i < _divisions.Length; i++)
                {
                    rects.Add(_divisions[i].Rectangle);
                    rects.AddRange(_divisions[i].GetAllRectangles());
                }

            }
            // ACTIVITY: Complete this method

            return rects;
        }

        /// <summary>
        /// A possibly recursive method that returns the
        /// smallest quad that contains the specified rectangle
        /// </summary>
        /// <param name="rect">The rectangle to check</param>
        /// <returns>The smallest quad that contains the rectangle</returns>
        public QuadTreeNode GetContainingQuad(Rectangle rect)
        {
            // ACTIVITY: Complete this method

            if (_rect.Contains(rect))
            {
                //for (int i = 0; i < _divisions.Length; i++)
                //{
                    if (_divisions != null)
                    {
                        //iterate to find the division that contains the specified rectangle
                        for (int i = 0; i < 4; i++)
                        {
                            //recursively go through each division if they exist
                            if (_divisions[i]._rect.Contains(rect))
                            {
                                return _divisions[i].GetContainingQuad(rect);
                            }
                        }
                    }
                    //returns current rectangle
                    return this;
                //}
            }
            // Return null if this quad doesn't completely contain
            // the rectangle that was passed in
            return null;
        }
        #endregion
    }
}
