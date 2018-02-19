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

        public Collectible()
        {
            spriteWidth = 28;
            spriteHeight = 25;
            spriteSpeed = 10;

            position = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
            location = new Vector2(10, 10);
        }
    
        public void CMove()
        {
            Vector2 temp = location;
            temp.Y -= spriteSpeed;
            location = temp;
        }

        int XCoord()
        {
            int cord = RNG.Next(0, 935);
            return cord;
        }

        public void DrawBread(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, location, new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight), Color.White);
        }

    }
}
