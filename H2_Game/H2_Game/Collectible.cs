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
        Random RNG = new Random();
        List<Rectangle> collectBox = new List<Rectangle>();
        List<Vector2> velocity = new List<Vector2>();
        List<bool> active = new List<bool>();

        public Collectible()
        {
            spriteWidth = 28;
            spriteHeight = 25;
            spriteSpeed = 10;

            location = new Vector2(XCoord(), 0-YCoord());
            position = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
        }
    
        public void popLists(int level)
        {
            for (int i = 0; i < level * 30; i++)
            {
                collectBox.Add(new Rectangle(XCoord(), 0-YCoord(), 30, 30));
                velocity.Add(new Vector2(0, 0-speed()));
                active.Add(true);
            }

        }

        int XCoord()
        {
            int cord = RNG.Next(0, 935);
            return cord;
        }

        int YCoord()
        {
            int cord = RNG.Next(0, 200);
            return cord;
        }

        int speed()
        {
            int num = RNG.Next(1,3);
            return num;
        }

        public bool CheckCollision(int num, Player player)
        {
                if (player.position.Intersects(collectBox[num]))
                {
                    active[num] = false;
                    return true;
                }
            
                return false;
        }

        public void CheckCollectCollision(Player player)
        {
            for (int i = 0; i < player.level * 30; i++)
            {
                int num = i;
                CheckCollision(num, player);
            }
        }
        public void drawcollectables(int level, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < level*30; i++)
            {

                if (active[i] == true)
                {
                    spriteBatch.Draw(spriteTexture, collectBox[i], Color.White);
                }
            }
        }

        public void MoveBread(int level)
        {
                for (int i = 0; i < level * 30; i++)
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
