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
        KeyboardState currentKBState;
        PlayerState PState = new PlayerState();

        public Player()
        {
            spriteWidth = 106;
            spriteHeight = 120;
            spriteSpeed = 5;
            
            currentFrame = 0;
            frameCount = 9;
            
            timePerFrame = 100;
            timer = 0f;
            position = new Rectangle((int)location.X,(int)location.Y, spriteWidth, spriteHeight);
            location = new Vector2(200,305);
        }

        public Player(Texture2D texture, int Width, int Height)
        {
            spriteTexture = texture;
            Width = spriteWidth;
            Height = spriteHeight;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            currentKBState = Keyboard.GetState();

            //switch to change PState depending on currentKBstae
            #region Pstate
            switch (PState)
            {
                case PlayerState.FaceLeft:
                    //if left arrow is held, change state to walkleft
                    if (currentKBState.IsKeyDown(Keys.A))
                    {
                        PState = PlayerState.WalkLeft;
                    }

                    //if right arrow is held, change state to walkright
                    if (currentKBState.IsKeyDown(Keys.D))
                    {
                        PState = PlayerState.WalkRight;
                    }
                    break;
                case PlayerState.FaceRight:
                    //if left arrow is held, change state to walkleft
                    if (currentKBState.IsKeyDown(Keys.A))
                    {
                        PState = PlayerState.WalkLeft;
                    }

                    //if right arrow is held, change state to walkright
                    if (currentKBState.IsKeyDown(Keys.D))
                    {
                        PState = PlayerState.WalkRight;
                    }
                    break;
                case PlayerState.WalkLeft:
                    if (currentKBState.IsKeyUp(Keys.A) && currentKBState.IsKeyUp(Keys.D))
                    {
                        PState = PlayerState.FaceLeft;
                    }

                    //if left arrow is up and right arrow is down, change state to walkright
                    if (currentKBState.IsKeyUp(Keys.A) && currentKBState.IsKeyDown(Keys.D))
                    {
                        PState = PlayerState.WalkRight;
                    }
                    break;
                case PlayerState.WalkRight:
                    if (currentKBState.IsKeyUp(Keys.A) && currentKBState.IsKeyUp(Keys.D))
                    {
                        PState = PlayerState.FaceRight;
                    }

                    //if left arrow is up and right arrow is down, change state to walkright
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
                    Vector2 tempL = location;
                    tempL.X -= spriteSpeed;
                    location = tempL; 
                    break;
                case PlayerState.WalkRight:
                    Vector2 tempR = location;
                    tempR.X += spriteSpeed;
                    location = tempR;
                    break;
                default:
                    break;
            }
        }

        //animate frames during movement
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

        public void ScreenWrap()
        {
            if (position.Left >= 960)
            {
                location = new Vector2(0-position.Width, 305);
            }
            if (position.Right <= 0)
            {
                location = new Vector2(960,305);
            }
        }

        public void DrawScottStanding(SpriteBatch spriteBatch, SpriteEffects flipsprite)
        {
            spriteBatch.Draw(spriteTexture, location, new Rectangle(0, 0, spriteWidth, spriteHeight), Color.White, 0, Vector2.Zero, 1.0f, flipsprite, 0);
        }

        public void DrawScottWalking(SpriteBatch spriteBatch, SpriteEffects flipsprite)
        {
            spriteBatch.Draw(spriteTexture, location, new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight), Color.White, 0, Vector2.Zero, 1.0f, flipsprite, 0);
        }
    }
}

