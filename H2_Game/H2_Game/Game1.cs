using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace H2_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    enum PlayerState
    {
        FaceLeft,
        FaceRight,
        WalkLeft,
        WalkRight
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState currentKBState;
        Texture2D background;
        //PlayerState PState = new PlayerState();
        Player player = new Player();
        Collectible bread = new Collectible();
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
            bread.popLists(player.level);
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

            //loads the player spritesheet
            player.spriteTexture = Content.Load<Texture2D>("scottsprite");
            background = Content.Load<Texture2D>("1920x1080");
            bread.spriteTexture = Content.Load<Texture2D>("bread");
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
            currentKBState = Keyboard.GetState();
            player.HandleSpriteMovement(gameTime, currentKBState);
            player.Animate(gameTime);
            player.ScreenWrap();
            bread.MoveBread(player.level);
            bread.CheckCollectCollision(player);
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
            spriteBatch.Draw(background, new Rectangle(0,0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            switch (player.PState)
            {
                case PlayerState.FaceLeft:
                    player.DrawScottStanding(spriteBatch, SpriteEffects.FlipHorizontally);
                    break;
                case PlayerState.FaceRight:
                    player.DrawScottStanding(spriteBatch, SpriteEffects.None);
                    break;
                case PlayerState.WalkLeft:
                    player.DrawScottWalking(spriteBatch, SpriteEffects.FlipHorizontally);
                    break;
                case PlayerState.WalkRight:
                    player.DrawScottWalking(spriteBatch, SpriteEffects.None);
                    break;
                default:
                    break;
            }
            bread.drawcollectables(player.level, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }        
    }
}
