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
    class Enemy : GameObject
    {
        public List<Rectangle> EnemyBox = new List<Rectangle>();
        public List<Vector2> Enemyvelocity = new List<Vector2>();

        public Enemy()
        {
            spriteWidth = 32;
            spriteHeight = 32;

            location = new Vector2(XCoord(), 0 - YCoord());
            position = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
        }

        public void popEnemy(int level)
        {
            for (int i = 0; i < level; i++)
            {
                EnemyBox.Add(new Rectangle(XCoord(), 0 - YCoord(), 30, 30));
                Enemyvelocity.Add(new Vector2(0, 0 - speed()));
            }
        }

        public bool EnemyCollision(Player player, GameState Gstate)
        {
            for (int i = 0; i < EnemyBox.Count; i++)
            {
                if (player.position.Intersects(EnemyBox[i]))
                {
                    return true;
                }
            }
                return false;
        }

        public void MoveEnemy(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Vector2 temp = EnemyBox[i].Location.ToVector2();
                temp -= Enemyvelocity[i];
                EnemyBox[i] = new Rectangle((int)temp.X, (int)temp.Y, spriteWidth, spriteHeight);
                
            }
        }

        public void DrawEnemy(int level, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < level; i++)
            {
                spriteBatch.Draw(spriteTexture, EnemyBox[i], Color.White);

            }
        }
    }
}
