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
        PlayerState PState = new PlayerState();
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
            HandleSpriteMovement(gameTime);
            player.Animate(gameTime);
            player.ScreenWrap();
            bread.CMove();
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

            switch (PState)
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
            bread.DrawBread(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
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
                player.spriteSpeed = 10;
            }
            if (currentKBState.IsKeyUp(Keys.LeftShift))
            {
                player.spriteSpeed = 5;
            }

            //call movement animation and set speed to zero if sprite will move offscreen
            switch (PState)
            {
                case PlayerState.FaceLeft:
                    player.currentFrame = 0;
                    break;
                case PlayerState.FaceRight:
                    player.currentFrame = 0;
                    break;
                case PlayerState.WalkLeft:
                    player.Animate(gameTime);
                    break;
                case PlayerState.WalkRight:
                    player.Animate(gameTime);
                    break;
                default:
                    break;
            }

            switch (PState)
            {
                case PlayerState.WalkLeft:
                    Vector2 tempL = player.location;
                    tempL.X -= player.spriteSpeed;
                    player.location = tempL;
                    break;
                case PlayerState.WalkRight:
                    Vector2 tempR = player.location;
                    tempR.X += player.spriteSpeed;
                    player.location = tempR;
                    break;
                default:
                    break;
            }
        }
        
    }
}
