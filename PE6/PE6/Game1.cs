using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE6
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //create variables for position and the image
        Vector2 position;
        Texture2D image;

        //sets the speed of the image as it moves around
        Vector2 velocity = new Vector2(100, 100);

    
        /// <summary>
        /// constructor
        /// </summary>
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
            //changes position of image to the center of the window
            position = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - (image.Width / 2),
                                   (graphics.GraphicsDevice.Viewport.Height / 2) - (image.Height / 2));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            image = this.Content.Load<Texture2D>("Pixelmation_Logo_Transparent");


            // TODO: use this.Content to load your game content here
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
            //moves the image 100 pixels in both the x and y direction every second, bouncing off of the boundaries by negating the velocity
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            #region boudary checks
            //if image reaches the left boundry, negate x velocity
            if (position.X <= 0 && velocity.X <=0)
            {
                velocity.X *= -1;
            }

            //if image reaches the top boundary, negate y velocity
            if (position.Y <= 0 && velocity.Y <= 0)
            {
                velocity.Y *= -1;
            }

            //if image reaches the right boundry, negate x velocity
            if (position.X >= graphics.GraphicsDevice.Viewport.Width - image.Width && velocity.X >= 0)
            {
                velocity.X *= -1;
            }

            //if image reaches the bottom boundary, negate y velocity
            if (position.Y >= graphics.GraphicsDevice.Viewport.Height - image.Height && velocity.Y >= 0)
            {
                velocity.Y *= -1;
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
            //changes backcolor to FireBrick
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            //Draw the image
            spriteBatch.Begin();
            spriteBatch.Draw(image, position, null, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
