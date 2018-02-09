using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PE7
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        //create variables for the texture of the sprite, a rectangle for it and it's position
        Texture2D sprite;
        Rectangle rect;
        int originX;
        int originY;
        Point origin;
        //create spritefont for the text
        SpriteFont Font;

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

            base.Initialize();

            //change the window size to 960x540
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();

            rect = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - sprite.Width / 2,
                                 graphics.GraphicsDevice.Viewport.Height / 2 - sprite.Height / 2, 
                                  sprite.Width, 
                                  sprite.Height);
            
            Font = Content.Load<SpriteFont>("Arial20");




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
            //load the mew sprite
            sprite = Content.Load<Texture2D>("Mew");
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

            //add movement dependent on WASD keys in traditional directions
            //creates variable for the keyboard state
            KeyboardState CState = Keyboard.GetState();

            //call processInput
            processInput(CState);
            //updates the location of the rectangle's origin in it's X and Y coordinates
            originX = rect.X + sprite.Width / 2;
            originY = rect.Y + sprite.Height / 2;
            origin = rect.Center;
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.OldLace);

            //creates the string for name and coordinates
            string location = "Nick Valcour" +
                              "\n(X,Y) coordinates = " + originX.ToString() + ", " + originY.ToString();

            // TODO: Add your drawing code here
            //draw the sprite inside the rectanlge, then the text
            #region draw code
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, rect, Color.White);
            spriteBatch.DrawString(Font, location, new Vector2(10,10), Color.Black);
            spriteBatch.End();
            #endregion

            base.Draw(gameTime);
        }

        #region movement code        

        void processInput(KeyboardState CState)
        {
            //move up for W  
            if (CState.IsKeyDown(Keys.W))
                rect.Y -= 10;

            //move down for S
            if (CState.IsKeyDown(Keys.S))
                rect.Y += 10;

            //move left for A
            if (CState.IsKeyDown(Keys.A))
                rect.X -= 10;

            //move right for D
            if (CState.IsKeyDown(Keys.D))
                rect.X += 10;
        }
        #endregion
    }
}
