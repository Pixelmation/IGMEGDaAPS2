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
    class Player : GameObject
    {
        //create the playerstate
        public PlayerState PState = new PlayerState();

        public int level = 1;
        public int score = 0;
        public int scoreInLevel = 0;
        public Player()
        {
            spriteWidth = 106;
            spriteHeight = 120;
            spriteSpeed = 5;

            currentFrame = 0;
            frameCount = 9;

            timePerFrame = 100;
            timer = 0f;
            location = new Vector2(480 - spriteWidth/2, 305);
            position = new Rectangle((int)location.X, (int)location.Y, spriteWidth, spriteHeight);
        }

        public Player(Texture2D texture, int Width, int Height)
        {
            spriteTexture = texture;
            Width = spriteWidth;
            Height = spriteHeight;
        }

        //code for movement
        #region spriteMovement
        public void HandleSpriteMovement(GameTime gameTime, KeyboardState currentKBState)
        {

            //switch to change PState depending on currentKBstae
            #region Pstate
            switch (PState)
            {
                case PlayerState.FaceLeft:
                    //if A is held, change state to walkleft
                    if (currentKBState.IsKeyDown(Keys.A))
                    {
                        PState = PlayerState.WalkLeft;
                    }

                    //if D is held, change state to walkright
                    if (currentKBState.IsKeyDown(Keys.D))
                    {
                        PState = PlayerState.WalkRight;
                    }
                    break;
                case PlayerState.FaceRight:
                    //if A is held, change state to walkleft
                    if (currentKBState.IsKeyDown(Keys.A))
                    {
                        PState = PlayerState.WalkLeft;
                    }

                    //if D is held, change state to walkright
                    if (currentKBState.IsKeyDown(Keys.D))
                    {
                        PState = PlayerState.WalkRight;
                    }
                    break;
                case PlayerState.WalkLeft:
                    //if both A and D are up, change state to faceLeft
                    if (currentKBState.IsKeyUp(Keys.A) && currentKBState.IsKeyUp(Keys.D))
                    {
                        PState = PlayerState.FaceLeft;
                    }

                    //if A is up and D is down, change state to walkright
                    if (currentKBState.IsKeyUp(Keys.A) && currentKBState.IsKeyDown(Keys.D))
                    {
                        PState = PlayerState.WalkRight;
                    }
                    break;
                case PlayerState.WalkRight:
                    //if both A and D are up, chand gstate to faceRight
                    if (currentKBState.IsKeyUp(Keys.A) && currentKBState.IsKeyUp(Keys.D))
                    {
                        PState = PlayerState.FaceRight;
                    }

                    //if A is up and D is down, change state to walkright
                    if (currentKBState.IsKeyDown(Keys.A) && currentKBState.IsKeyUp(Keys.D))
                    {
                        PState = PlayerState.WalkLeft;
                    }

                    break;
                default:
                    break;

            }
            #endregion

            //sprint check
            if (currentKBState.IsKeyDown(Keys.LeftShift))
            {
                spriteSpeed = 10;
            }
            if (currentKBState.IsKeyUp(Keys.LeftShift))
            {
                spriteSpeed = 5;
            }

            //call movement animation and set speed to zero if sprite will move offscreen
            switch (PState)
            {
                case PlayerState.FaceLeft:
                    currentFrame = 0;
                    break;
                case PlayerState.FaceRight:
                    currentFrame = 0;
                    break;
                case PlayerState.WalkLeft:
                    Animate(gameTime);
                    break;
                case PlayerState.WalkRight:
                    Animate(gameTime);
                    break;
                default:
                    break;
            }

            switch (PState)
            {
                case PlayerState.WalkLeft:
                    Rectangle tempL = position;
                    tempL.X -= spriteSpeed;
                    position = tempL;
                    break;
                case PlayerState.WalkRight:
                    Rectangle tempR = position;
                    tempR.X += spriteSpeed;
                    position = tempR;
                    break;
                default:
                    break;
            }
        }
        #endregion


        //animate frames during movement
        #region animate code
        public void Animate(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer >= timePerFrame)
            {
                currentFrame += 1;
                if (currentFrame >= frameCount)
                {
                    currentFrame = 1;
                }
                timer -= timePerFrame;
            }
        }
        #endregion

        public void ScreenWrap()
        {
            if (position.Left >= 960)
            {
                //location = new Vector2(0 - position.Width, 305);
                position = new Rectangle(1-spriteWidth, (int)location.Y, spriteWidth, spriteHeight);
            }
            if (position.Right <= 0)
            {
                position = new Rectangle(959, (int)location.Y, spriteWidth, spriteHeight);

            }
        }

        public void DrawScottStanding(SpriteBatch spriteBatch, SpriteEffects flipsprite)
        {
            spriteBatch.Draw(spriteTexture, position, new Rectangle(0, 0, spriteWidth, spriteHeight), Color.White, 0f, Vector2.Zero, flipsprite, 0);
        }

        public void DrawScottWalking(SpriteBatch spriteBatch, SpriteEffects flipsprite)
        {
            spriteBatch.Draw(spriteTexture, position, new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight), Color.White, 0f, Vector2.Zero, flipsprite, 0);

        }
    }
}

