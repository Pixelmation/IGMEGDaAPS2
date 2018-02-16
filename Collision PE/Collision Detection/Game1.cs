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

        //create a list for the collectable rectangles and a parallel list of velocities as vector2s
        List<Rectangle> collectRect = new List<Rectangle>();
        List<Vector2> velocity = new List<Vector2>();
       

        //texture for the collectable and the number of them
        Texture2D collectable;
        int numcollect = 5;

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

            //change window size
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();

            //populate the list of collectable rectangles
            for (int i = 0; i < numcollect; i++)
            {
                collectRect.Add(new Rectangle(CordX(), CordY(), 28, 25));
            }

            //poplulate the list of velocities
            for (int i = 0; i < numcollect; i++)
            {
                velocity.Add(new Vector2(1,1));
            }

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

            //load the collectable
            collectable = Content.Load<Texture2D>("bread");

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

            //create a new rectangle every frame that changes direction depending on it's velocity
            for (int i = 0; i < numcollect; i++)
            {
                collectRect[i] = new Rectangle(collectRect[i].X + (int)velocity[i].X, collectRect[i].Y + (int)velocity[i].Y, collectable.Width, collectable.Height);

                //bounds check for each bread rect
                #region bounds check
                if ((collectRect[i].Right >= GraphicsDevice.Viewport.Width) && (velocity[i].X == 1))
                {
                    Vector2 temp = velocity[i];
                    temp.X *= -1;
                    velocity[i] = temp;
                }
                if ((collectRect[i].Left <= 0) && (velocity[i].X == -1))
                {
                    Vector2 temp = velocity[i];
                    temp.X *= -1;
                    velocity[i] = temp;
                }
                if ((collectRect[i].Bottom >= GraphicsDevice.Viewport.Height) && (velocity[i].Y == 1))
                {
                    Vector2 temp = velocity[i];
                    temp.Y *= -1;
                    velocity[i] = temp;
                }
                if ((collectRect[i].Top <= 0) && (velocity[i].Y == -1))
                {
                    Vector2 temp = velocity[i];
                    temp.Y *= -1;
                    velocity[i] = temp;
                }
                #endregion

            }

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

            //draw the player
            spriteBatch.Draw(player, playerRect, Color.White);

            //draw each rectangle. if it intersects the player, give it a red color
            #region draw rects
            for (int i = 0; i < numcollect; i++)
            {
                if (collectRect[i].Intersects(playerRect))
                    spriteBatch.Draw(collectable, collectRect[i], Color.Red);
                else
                {
                    spriteBatch.Draw(collectable, collectRect[i], Color.White);
                }
            }
            #endregion

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
            int width = RNG.Next(20,GraphicsDevice.Viewport.Width - 50);
            return width;
        }

        /// <summary>
        /// method for getting a random y cord
        /// </summary>
        /// <returns></returns>
        int CordY()
        {
            int height = RNG.Next(20, GraphicsDevice.Viewport.Height - 50);
            return height;
        }
        #endregion


    }
}
