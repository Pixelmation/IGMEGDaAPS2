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
        //lists for the enemy rectangles and velocities for them
        #region lists
        public List<Rectangle> EnemyBox = new List<Rectangle>();
        public List<Vector2> Enemyvelocity = new List<Vector2>();
        #endregion

        /// <summary>
        /// constructor for Enemy that sets sprite width, height, location, and position
        /// </summary>
        public Enemy()
        {
            spriteWidth = 32;
            spriteHeight = 32;

            location = new Vector2(XCoord(), 0 - YCoord());
            position = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
        }

        /// <summary>
        /// populates the relevant lists x times, where x is whatever player.level is
        /// </summary>
        /// <param name="level"></param>
        public void popEnemy(int level)
        {
            for (int i = 0; i < level; i++)
            {
                EnemyBox.Add(new Rectangle(XCoord(), 0 - YCoord(), 30, 30));
                Enemyvelocity.Add(new Vector2(0, 0 - speed()));
            }
        }

        /// <summary>
        /// checks for collision between player and enemy
        /// </summary>
        /// <param name="player"></param>
        /// <param name="Gstate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// moves each enemy down in respect to their relative velocity
        /// </summary>
        /// <param name="level"></param>
        public void MoveEnemy(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Vector2 temp = EnemyBox[i].Location.ToVector2();
                temp -= Enemyvelocity[i];
                EnemyBox[i] = new Rectangle((int)temp.X, (int)temp.Y, spriteWidth, spriteHeight);
                
            }
        }

        /// <summary>
        /// draws each enemy x times, where x is the player.level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="spriteBatch"></param>
        public void DrawEnemy(int level, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < level; i++)
            {
                spriteBatch.Draw(spriteTexture, EnemyBox[i], Color.White);

            }
        }
    }
}
