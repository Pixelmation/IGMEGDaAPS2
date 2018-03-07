using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace H2_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    //enum for the player state
    enum PlayerState
    {
        FaceLeft,
        FaceRight,
        WalkLeft,
        WalkRight
    }

    //enum for gamestate
    enum GameState
    {
        Menu,
        Game,
        GameOver

    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region variables
        //keyboard states
        KeyboardState currentKBState;
        KeyboardState previousKBState;

        //initialize gamestate
        GameState Gstate;
        
        //initialize each other relevant class
        Player player = new Player();
        Collectible bread = new Collectible();
        Enemy enemy = new Enemy();

        //load the spritefont, background, and create a timer
        SpriteFont spriteFont;
        Texture2D background;
        float timer = 10.00f;
        #endregion

        /// <summary>
        /// cunstructor
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
            //change the window size to 960x540
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

            #region image and font loading
            //loads the player spritesheet
            player.spriteTexture = Content.Load<Texture2D>("scottsprite");

            //load the background texture
            background = Content.Load<Texture2D>("1920x1080");

            //load the collectible texture
            bread.spriteTexture = Content.Load<Texture2D>("bread");

            //Load the enemy texture
            enemy.spriteTexture = Content.Load<Texture2D>("Bug");

            //load the spriteFont
            spriteFont = Content.Load<SpriteFont>("Ariel24");
            #endregion

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
            //set currentKBState
            currentKBState = Keyboard.GetState();

            //if gamestate is Menu, look for SingleKeyPress to equal true. once it does, enter the game and reset everything
            #region Menu
            if (Gstate == GameState.Menu)
            {
                SingleKeyPress(Keys.Enter);
                if (SingleKeyPress(Keys.Enter) == true)
                {
                    Gstate = GameState.Game;
                    ResetGame();
                }
            }
            #endregion

            //if gamestate is Game, load everything. 
            #region GState Game
            if (Gstate == GameState.Game)
            {
                player.HandleSpriteMovement(gameTime, currentKBState);
                player.Animate(gameTime);
                player.ScreenWrap();
                bread.MoveBread(player.level);
                bread.CheckCollectCollision(player);
                enemy.MoveEnemy(player.level);
                timer -= 1 / 60f;

                //if the player collects half of the bread onscreen, call next level
                if (player.scoreInLevel == (bread.collectBox.Count / 2))
                {
                    player.scoreInLevel = 0;
                    NextLevel();
                }

                //if timer = 0 or player intersects an enemy, change gamestate to gameover                
                if (timer <= 0.00 || enemy.EnemyCollision(player, Gstate) == true)
                {
                    Gstate = GameState.GameOver;
                }
            }
            #endregion

            //if gamestate is gameover look for SingleKeyPress to equal true. once it does, return to Menu
            #region Gstate GameOver
            if (Gstate == GameState.GameOver)
            {
                SingleKeyPress(Keys.Enter);
                if (SingleKeyPress(Keys.Enter) == true)
                {
                    ResetGame();
                    Gstate = GameState.Menu;
                }
            }
            #endregion

            //set previousKBState to currentKBState
            previousKBState = currentKBState;
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

            //draw the background
            spriteBatch.Draw(background, new Rectangle(0,0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            //strings and their sizes
            #region string variables
            //strings and their sizes for the menu screen
            string welcome1 = "Welcome to breadcollector 2018!";
            string welcome2 = "Please press Enter to begin.";
            Vector2 welcome1Length = spriteFont.MeasureString(welcome1);
            Vector2 welcome2Length = spriteFont.MeasureString(welcome2);

            //strings and their sizes for the game over screen
            string endString1 = "You lost! final score is:";
            string endString2 = player.score.ToString();
            Vector2 endString1Length = spriteFont.MeasureString(endString1);
            Vector2 endString2Length = spriteFont.MeasureString(endString2);

            //formats the timer into a nicer format
            string.Format("{0:0.00}", timer);
            #endregion

            //if gamestate is menu, draw the welcome and await statechange
            #region draw menu
            if (Gstate == GameState.Menu)
            {
                spriteBatch.DrawString(spriteFont, welcome1, new Vector2(GraphicsDevice.Viewport.Width / 2- welcome1Length.X / 2 , GraphicsDevice.Viewport.Height / 2- welcome1Length.Y), Color.Black);
                spriteBatch.DrawString(spriteFont, welcome2, new Vector2(GraphicsDevice.Viewport.Width / 2 - welcome2Length.X / 2, GraphicsDevice.Viewport.Height / 2+ welcome2Length.Y), Color.Black);
            }
            #endregion

            //if gamestate is game, draw the GUI and the game itself. player, collectables, and bugs
            #region draw game
            if (Gstate == GameState.Game)
            {
                spriteBatch.DrawString(spriteFont, player.level.ToString(), new Vector2(GraphicsDevice.Viewport.Width / 2, 10), Color.Black);
                spriteBatch.DrawString(spriteFont, "current Score: " + player.score.ToString(), new Vector2(10, 10), Color.Black);
                spriteBatch.DrawString(spriteFont, "Time Left: " + string.Format("{0:0.00}", timer), new Vector2(10, 40), Color.Black);
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
                enemy.DrawEnemy(player.level, spriteBatch);
            }
            #endregion

            //if gamestate is gameover, show the lost message and show their final score
            #region draw gameover
            if (Gstate == GameState.GameOver)
            {
                spriteBatch.DrawString(spriteFont, endString1, new Vector2(GraphicsDevice.Viewport.Width / 2 - endString1Length.X / 2, GraphicsDevice.Viewport.Height / 2 - endString1Length.Y), Color.Black);
                spriteBatch.DrawString(spriteFont, endString2, new Vector2(GraphicsDevice.Viewport.Width / 2 - endString2Length.X / 2, GraphicsDevice.Viewport.Height / 2 + endString2Length.Y), Color.Black);
            }
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //helper methods
        #region helper methods
        /// <summary>
        /// check for enter to be pressed, and return true once it is
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool SingleKeyPress(Keys key)
        {
            if (currentKBState.IsKeyDown(Keys.Enter) == true && previousKBState.IsKeyDown(Keys.Enter) == false)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// resets all of the variables and calls next level
        /// </summary>
        void ResetGame()
        {
            player.level = 0;
            player.score = 0;
            player.scoreInLevel = 0;
            NextLevel();
        }

        /// <summary>
        /// adds to player level, resets timer, and resets the collectable and enemy lists as well as player location
        /// </summary>
        void NextLevel()
        {
            player.level++;
            timer = 10.00f;
            bread.collectBox.Clear();
            bread.velocity.Clear();
            bread.active.Clear();
            enemy.EnemyBox.Clear();
            enemy.Enemyvelocity.Clear();
            bread.popLists(player.level);
            enemy.popEnemy(player.level);
            player.location = new Vector2(480 - player.spriteWidth / 2, 305);
        }
        #endregion
    }
}
