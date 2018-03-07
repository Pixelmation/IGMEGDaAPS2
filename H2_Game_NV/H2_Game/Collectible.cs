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
    class Collectible : GameObject
    {
        //lists for creating all of the collectibles and a number variable
        #region lists and a number
        public List<Rectangle> collectBox = new List<Rectangle>();
        public List<Vector2> velocity = new List<Vector2>();
        public List<bool> active = new List<bool>();

        public int num;
        #endregion

        /// <summary>
        /// constructor for collectable that sets sprite width, height, location, and position
        /// </summary>
        public Collectible()
        {
            spriteWidth = 28;
            spriteHeight = 25;

            location = new Vector2(XCoord(), 0 - YCoord());
            position = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
        }
        
        /// <summary>
        /// creates x items in each list, where x is the level number*10
        /// </summary>
        /// <param name="level"></param>
        public void popLists(int level)
        {
            for (int i = 0; i < level * 10; i++)
            {
                collectBox.Add(new Rectangle(XCoord(), 0 - YCoord(), 30, 30));
                velocity.Add(new Vector2(0, 0 - speed()));
                active.Add(true);
            }
        }

        /// <summary>
        /// checks collision and adds to score if an intersect occures
        /// </summary>
        /// <param name="num"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CheckCollision(int num, Player player)
        {
            if (player.position.Intersects(collectBox[num]))
            {
                if (active[num] == true)
                {
                player.score++;
                player.scoreInLevel++;
                }
                active[num] = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// calls check collision so that the return wont stop it from working
        /// </summary>
        /// <param name="player"></param>
        public void CheckCollectCollision(Player player)
        {
            for (int i = 0; i < player.level * 10; i++)
            {
                num = i;
                CheckCollision(num, player);
            }
        }

        /// <summary>
        /// draws the bread x times, where x is however many times it's in the collectBox list
        /// </summary>
        /// <param name="level"></param>
        /// <param name="spriteBatch"></param>
        public void drawcollectables(int level, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < level * 10; i++)
            {

                if (active[i] == true)
                {
                    spriteBatch.Draw(spriteTexture, collectBox[i], Color.White);
                }
            }
        }

        /// <summary>
        /// moves the rectangles down by their resprective velocity vector2 every time
        /// </summary>
        /// <param name="level"></param>
        public void MoveBread(int level)
        {
            for (int i = 0; i < level * 10; i++)
            {
                if (active[i] == true)
                {
                    Vector2 temp = collectBox[i].Location.ToVector2();
                    temp -= velocity[i];
                    collectBox[i] = new Rectangle((int)temp.X, (int)temp.Y, spriteWidth, spriteHeight);
                }
            }
        }
    }
}
