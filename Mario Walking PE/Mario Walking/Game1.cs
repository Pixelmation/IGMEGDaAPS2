using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Mario_Walking
{
    // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
    // PRACTICE EXERCISE:  Enums are typically declared here!

    //create enum for mario
    enum MarioState
    {
        FaceLeft,
        FaceRight,
        WalkLeft,
        WalkRight
    }
    // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MarioState MState = new MarioState();

        // Texture and drawing
        Texture2D spriteSheet;  // The single image with all of the animation frames
        Vector2 marioLoc;       // Mario's location on the screen

        // Animation
        int frame;              // The current animation frame
        double timeCounter;     // The amount of time that has passed
        double fps;             // The speed of the animation
        double timePerFrame;    // The amount of time (in fractional seconds) per frame

        // Constants for "source" rectangle (inside the image)
        const int WalkFrameCount = 3;       // The number of frames in the animation
        const int MarioRectOffsetY = 116;   // How far down in the image are the frames?
        const int MarioRectHeight = 72;     // The height of a single frame
        const int MarioRectWidth = 44;      // The width of a single frame

        // Constructor
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
            // Sets up the mario location
            marioLoc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Initialize
            fps = 10.0;
            timePerFrame = 1.0 / fps;

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

            // Load the single spritesheet
            spriteSheet = Content.Load<Texture2D>("Mario");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState state = Keyboard.GetState();

            // Handles animation for you
            UpdateAnimation(gameTime);

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Add your finite state machine code (switch statement) here!
            // - Be sure to check the finite state machine's state first
            // - Then check for specific transitions inside each state (may require keyboard input)

            //switch statement for checking each state
            #region the switch statement for changing state
            switch (MState)
            {
                //if mario is facing left
                case MarioState.FaceLeft:
                    //if left arrow is held, change state to walkleft
                    if (state.IsKeyDown(Keys.Left))
                    {
                        MState = MarioState.WalkLeft;

                    }

                    //if right arrow is held, change state to walkright
                    if (state.IsKeyDown(Keys.Right))
                    {
                        MState = MarioState.WalkRight;
                    }
                    break;

                //if mario is facing right
                case MarioState.FaceRight:
                    //if left arrow is held, change state to walkleft
                    if (state.IsKeyDown(Keys.Left))
                    {
                        MState = MarioState.WalkLeft;
                    }

                    //if right arrow is held, change state to walkright
                    if (state.IsKeyDown(Keys.Right))
                    {
                        MState = MarioState.WalkRight;
                    }
                    break;

                //if mario is walking left
                case MarioState.WalkLeft:

                    //if neither key is held, change state to faceleft
                    if (state.IsKeyUp(Keys.Left) && state.IsKeyUp(Keys.Right))
                    {
                        MState = MarioState.FaceLeft;
                    }

                    //if left arrow is up and right arrow is down, change state to walkright
                    if (state.IsKeyUp(Keys.Left) && state.IsKeyDown(Keys.Right))
                    {
                        MState = MarioState.WalkRight;
                    }
                    break;


                case MarioState.WalkRight:
                    //if neither key is held, change state to faceright
                    if (state.IsKeyUp(Keys.Left) && state.IsKeyUp(Keys.Right))
                    {
                        MState = MarioState.FaceRight;
                    }

                    //if right arrow is up and left arrow is down, change state to walkleft
                    if (state.IsKeyUp(Keys.Right) && state.IsKeyDown(Keys.Left))
                    {
                        MState = MarioState.WalkLeft;
                    }
                    break;
                default:
                    break;
            }
            #endregion

            //if MState is WalkLeft, move left 5 pixels. if it's WalkRight, then move right 2 pixels. 
            //If LeftShift is held, add/subtract another 4 pixels(sprint check)
            #region the switch statements for moving
            switch (MState)
            {
                case MarioState.WalkLeft:
                    marioLoc.X -= 2;
                    if (state.IsKeyDown(Keys.LeftShift))
                    {
                        marioLoc.X -= 4;
                    }
                    break;
                case MarioState.WalkRight:
                    marioLoc.X += 2;
                    if (state.IsKeyDown(Keys.LeftShift))
                    {
                        marioLoc.X += 4;
                    }
                    break;
                default:
                    break;
            }
            #endregion

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch
            spriteBatch.Begin();

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Check the finite state machine state here to
            // determine how exactly to draw Mario

            //Draws mario depending on his state
            #region draw switch
            switch (MState)
            {
                case MarioState.FaceLeft:
                    DrawMarioStanding(SpriteEffects.FlipHorizontally);
                    break;
                case MarioState.FaceRight:
                    DrawMarioStanding(SpriteEffects.None);
                    break;
                case MarioState.WalkLeft:
                    DrawMarioWalking(SpriteEffects.FlipHorizontally);
                    break;
                case MarioState.WalkRight:
                    DrawMarioWalking(SpriteEffects.None);
                    break;
                default:
                    break;
            }
            #endregion

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            // End the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Updates mario's animation as necessary
        /// </summary>
        /// <param name="gameTime">Time information</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            // Handle animation timing
            // - Add to the time counter
            // - Check if we have enough "time" to advance the frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;                     // Adjust the frame

                if (frame > WalkFrameCount)     // Check the bounds
                    frame = 1;                  // Back to 1 (since 0 is the "standing" frame)

                timeCounter -= timePerFrame;    // Remove the time we "used"

            }
        }

        /// <summary>
        /// Draws only the left-most frame of mario, which is him standing
        /// </summary>
        /// <param name="flipSprite">
        /// Enum values for flipping the sprite horizontally
        /// and or vertically
        /// </param>
        private void DrawMarioStanding(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                spriteSheet,                    // - The texture to draw
                marioLoc,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    0,                          //   - This rectangle specifies
                    MarioRectOffsetY,        //	   where "inside" the texture
                    MarioRectWidth,           //     to get pixels (We don't want to
                    MarioRectHeight),         //     draw the whole thing)
                Color.White,                    // - The color
                0,                              // - Rotation (none currently)
                Vector2.Zero,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }

        /// <summary>
        /// Draws mario running, based on the current FRAME field
        /// which is changed by the code in Update
        /// </summary>
        /// <param name="flipSprite">
        /// Enum values for flipping the sprite horizontally
        /// and or vertically
        /// </param>
        private void DrawMarioWalking(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                spriteSheet,                    // - The texture to draw
                marioLoc,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    frame * MarioRectWidth,     //   - This rectangle specifies
                    MarioRectOffsetY,           //	   where "inside" the texture
                    MarioRectWidth,             //     to get pixels (We don't want to
                    MarioRectHeight),           //     draw the whole thing)
                Color.White,                    // - The color
                0,                              // - Rotation (none currently)
                Vector2.Zero,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }
    }
}
