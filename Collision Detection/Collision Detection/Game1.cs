using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Collision_Detection
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random RNG = new Random();

        //texture and rectangle for player
        Texture2D player;
        Rectangle playerRect;

        //create a list for collecting object
        List<Rectangle> collect = new List<Rectangle>();

        //texture and rectangle for collectable, as well as positions for them
        Texture2D collectable;
        Rectangle collectableRect1;
        Rectangle collectableRect2;
        Rectangle collectableRect3;
        Rectangle collectableRect4;
        Rectangle collectableRect5;

        Vector2 position1;
        Vector2 position2;
        Vector2 position3;
        Vector2 position4;
        Vector2 position5;

        //velocity for the rectangles to move at
        Vector2 velocity1;
        Vector2 velocity2;
        Vector2 velocity3;
        Vector2 velocity4;
        Vector2 velocity5;

        bool collected1 = false;
        bool collected2 = false;
        bool collected3 = false;
        bool collected4 = false;
        bool collected5 = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();


            //add collectble rectangles to the collect list
            collect.Add(collectableRect1);
            collect.Add(collectableRect2);
            collect.Add(collectableRect3);
            collect.Add(collectableRect4);
            collect.Add(collectableRect5);

            velocity1 = new Vector2(VelocityX(), VelocityY());
            velocity2 = new Vector2(VelocityX(), VelocityY());
            velocity3 = new Vector2(VelocityX(), VelocityY());
            velocity4 = new Vector2(VelocityX(), VelocityY());
            velocity5 = new Vector2(VelocityX(), VelocityY());
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //load the player texture and rectangle
            player = Content.Load<Texture2D>("bug");
            playerRect = new Rectangle((GraphicsDevice.Viewport.Width / 2) - (player.Width / 2),
                                            (GraphicsDevice.Viewport.Height / 2) - (player.Height / 2),
                                            player.Width,
                                            player.Height);


            //load the collectable and create locations for the collectable rectangles
            collectable = Content.Load<Texture2D>("bread");
            collectableRect1 = new Rectangle(CordX(), CordY(), collectable.Width, collectable.Height);
            collectableRect2 = new Rectangle(CordX(), CordY(), collectable.Width, collectable.Height);
            collectableRect3 = new Rectangle(CordX(), CordY(), collectable.Width, collectable.Height);
            collectableRect4 = new Rectangle(CordX(), CordY(), collectable.Width, collectable.Height);
            collectableRect5 = new Rectangle(CordX(), CordY(), collectable.Width, collectable.Height);

            position1 = new Vector2(collectableRect1.X, collectableRect1.Y);
            position2 = new Vector2(collectableRect2.X, collectableRect2.Y);
            position3 = new Vector2(collectableRect3.X, collectableRect3.Y);
            position4 = new Vector2(collectableRect4.X, collectableRect4.Y);
            position5 = new Vector2(collectableRect5.X, collectableRect5.Y);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //changes each position by whatever it's velocity is every second
            position1 += velocity1 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position2 += velocity2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position3 += velocity3 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position4 += velocity4 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position5 += velocity5 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //set the X and Y for each collectable rect
            #region changing coords
            collectableRect1.X = (int)position1.X;
            collectableRect1.Y = (int)position1.Y;

            collectableRect2.X = (int)position2.X;
            collectableRect2.Y = (int)position2.Y;

            collectableRect3.X = (int)position3.X;
            collectableRect3.Y = (int)position3.Y;

            collectableRect4.X = (int)position4.X;
            collectableRect4.Y = (int)position4.Y;

            collectableRect5.X = (int)position5.X;
            collectableRect5.Y = (int)position5.Y;
            #endregion

            #region bounds check for collectableRect1
            if (collectableRect1.Left <= 0 && velocity1.X < 0)
            {
                velocity1.X *= -1;
            }
            if (collectableRect1.Right >= GraphicsDevice.Viewport.Width && velocity1.X > 0)
            {
                velocity1.X *= -1;
            }
            if (collectableRect1.Top <= 0 && velocity1.Y < 0)
            {
                velocity1.Y *= -1;
            }
            if (collectableRect1.Bottom >= GraphicsDevice.Viewport.Height && velocity1.Y > 0)
            {
                velocity1.Y *= -1;
            }
            #endregion

            #region bounds check for collectableRect2
            if (collectableRect2.Left <= 0 && velocity2.X < 0)
            {
                velocity2.X *= -1;
            }
            if (collectableRect2.Right >= GraphicsDevice.Viewport.Width && velocity2.X > 0)
            {
                velocity2.X *= -1;
            }
            if (collectableRect2.Top <= 0 && velocity2.Y < 0)
            {
                velocity2.Y *= -1;
            }
            if (collectableRect2.Bottom >= GraphicsDevice.Viewport.Height && velocity2.Y > 0)
            {
                velocity2.Y *= -1;
            }
            #endregion

            #region bounds check for collectableRect3
            if (collectableRect3.Left <= 0 && velocity3.X < 0)
            {
                velocity3.X *= -1;
            }
            if (collectableRect3.Right >= GraphicsDevice.Viewport.Width && velocity3.X > 0)
            {
                velocity3.X *= -1;
            }
            if (collectableRect3.Top <= 0 && velocity3.Y < 0)
            {
                velocity3.Y *= -1;
            }
            if (collectableRect3.Bottom >= GraphicsDevice.Viewport.Height && velocity3.Y > 0)
            {
                velocity3.Y *= -1;
            }
            #endregion

            #region bounds check for collectableRect4
            if (collectableRect4.Left <= 0 && velocity4.X < 0)
            {
                velocity4.X *= -1;
            }
            if (collectableRect4.Right >= GraphicsDevice.Viewport.Width && velocity4.X > 0)
            {
                velocity4.X *= -1;
            }
            if (collectableRect4.Top <= 0 && velocity4.Y < 0)
            {
                velocity4.Y *= -1;
            }
            if (collectableRect4.Bottom >= GraphicsDevice.Viewport.Height && velocity4.Y > 0)
            {
                velocity4.Y *= -1;
            }
            #endregion

            #region bounds check for collectableRect5
            if (collectableRect5.Left <= 0 && velocity5.X < 0)
            {
                velocity5.X *= -1;
            }
            if (collectableRect5.Right >= GraphicsDevice.Viewport.Width && velocity5.X > 0)
            {
                velocity5.X *= -1;
            }
            if (collectableRect5.Top <= 0 && velocity5.Y < 0)
            {
                velocity5.Y *= -1;
            }
            if (collectableRect5.Bottom >= GraphicsDevice.Viewport.Height && velocity5.Y > 0)
            {
                velocity5.Y *= -1;
            }
            #endregion

            //checks for collision. if collision, sets the appropriate collected bool to true
            #region collision
            if ((playerRect.Intersects(collectableRect1)) && (collected1 == false))
            {
                collected1 = true;
            }

            if ((playerRect.Intersects(collectableRect2)) && (collected2 == false))
            {
                collected2 = true;
            }

            if ((playerRect.Intersects(collectableRect3)) && (collected3 == false))
            {
                collected3 = true;
            }

            if ((playerRect.Intersects(collectableRect4)) && (collected4 == false))
            {
                collected4 = true;
            }

            if ((playerRect.Intersects(collectableRect5)) && (collected5 == false))
            {
                collected5 = true;
            }
            #endregion

            //movement with WASD
            #region movevment
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.W))
            {
                playerRect.Y -= 5;
            }
            if (state.IsKeyDown(Keys.S))
            {
                playerRect.Y += 5;
            }
            if (state.IsKeyDown(Keys.A))
            {
                playerRect.X -= 5;
            }
            if (state.IsKeyDown(Keys.D))
            {
                playerRect.X += 5;
            }
            #endregion

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(player, playerRect, Color.White);

            //draw each bread if their respective collected bool is false
            if (collected1 == false)
                spriteBatch.Draw(collectable, collectableRect1, Color.White);

            if (collected2 == false)
                spriteBatch.Draw(collectable, collectableRect2, Color.White);

            if (collected3 == false)
                spriteBatch.Draw(collectable, collectableRect3, Color.White);

            if (collected4 == false)
                spriteBatch.Draw(collectable, collectableRect4, Color.White);

            if (collected5 == false)
                spriteBatch.Draw(collectable, collectableRect5, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #region random coords
        /// <summary>
        /// method for getting a random x cord
        /// </summary>
        /// <returns></returns>
        int CordX()
        {
            int width = RNG.Next(20,GraphicsDevice.Viewport.Width - collectable.Width - 20);
            return width;
        }

        /// <summary>
        /// method for getting a random y cord
        /// </summary>
        /// <returns></returns>
        int CordY()
        {
            int height = RNG.Next(20, GraphicsDevice.Viewport.Height - collectable.Height -20);
            return height;
        }
        #endregion

        #region random velocity
        /// <summary>
        /// get a random x value between 100 and 200 for velocity
        /// </summary>
        /// <returns></returns>
        int VelocityX()
        {
            int VX = RNG.Next(100,201);
            int negativeX = RNG.Next(1, 3);
            if (negativeX == 2)
            {
                VX *= -1;
            }
            return VX;
        }

        /// <summary>
        /// get a random Y value between 100 and 200 for velocity
        /// </summary>
        /// <returns></returns>
        int VelocityY()
        {
            int VY = RNG.Next(100, 201);
            int negativeY = RNG.Next(1, 3);
            if (negativeY == 2)
            {
                VY *= -1;
            }
            return VY;
        }
        #endregion


    }
}
