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

        //texture and rectangle for collectable
        Texture2D collectable;
        Rectangle collectableRect1;
        Rectangle collectableRect2;
        Rectangle collectableRect3;
        Rectangle collectableRect4;
        Rectangle collectableRect5;


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

            //create locations for the collectable rectangles
            collectableRect1 = new Rectangle(RandomWidth(), RandomHeight(), collectable.Width, collectable.Height);
            collectableRect2 = new Rectangle(RandomWidth(), RandomHeight(), collectable.Width, collectable.Height);
            collectableRect3 = new Rectangle(RandomWidth(), RandomHeight(), collectable.Width, collectable.Height);
            collectableRect4 = new Rectangle(RandomWidth(), RandomHeight(), collectable.Width, collectable.Height);
            collectableRect5 = new Rectangle(RandomWidth(), RandomHeight(), collectable.Width, collectable.Height);

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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(player, playerRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        int RandomWidth()
        {
            int width = RNG.Next(0,GraphicsDevice.Viewport.Width - collectable.Width);
            return width;
        }

        int RandomHeight()
        {
            int height = RNG.Next(0, GraphicsDevice.Viewport.Height - collectable.Height);
            return height;
        }

    }
}
