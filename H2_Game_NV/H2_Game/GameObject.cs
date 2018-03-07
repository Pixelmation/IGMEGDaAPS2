using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace H2_Game
{
    class GameObject
    {
        Random RNG = new Random();

        //generic texture for the sprites, vector for location and rectangle for the position
        public Texture2D spriteTexture { get; set; }
        public Vector2 location { get; set; }
        public Rectangle position { get; set; }

        //generic ints for the sprites width and height
        public int spriteWidth { get; set; }
        public int spriteHeight { get; set; }

        //current frame and frame count variables
        public int currentFrame { get; set; }
        public int frameCount { get; set; }

        //a time for each frame, a timer that it uses, and a spritespeed
        public int timePerFrame { get; set; }
        public float timer { get; set; }
        public int spriteSpeed { get; set; }

        /// <summary>
        /// generic draw method
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, position, Color.White);
        }

        /// <summary>
        /// random X coordinate between 0 and 935
        /// </summary>
        /// <returns></returns>
        protected int XCoord()
        {
            int cord = RNG.Next(0, 935);
            return cord;
        }

        /// <summary>
        /// random Y coordinate between 0 and 400
        /// </summary>
        /// <returns></returns>
        protected int YCoord()
        {
            int cord = RNG.Next(0, 400);
            return cord;
        }

        /// <summary>
        /// random int between 1 and 2 for velocities
        /// </summary>
        /// <returns></returns>
        protected int speed()
        {
            int num = RNG.Next(1, 3);
            return num;
        }
    }
}
