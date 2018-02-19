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
        public Texture2D spriteTexture { get; set; }
        public Rectangle position { get; set; }

        public int spriteWidth { get; set; }
        public int spriteHeight { get; set; }

        public int currentFrame { get; set; }
        public int frameCount { get; set; }

        public int timePerFrame { get; set; }
        public float timer { get; set; }
        public int spriteSpeed { get; set; }
        public Vector2 location { get; set; }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, position, Color.White);
        }


    }

}
