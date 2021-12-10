
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private StartScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private HighScoreScene highScoreScene;
        private AboutScene aboutScene;
        public const int QUIT = 4;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Vector2 stage = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            //cloud background (2 layers to fix a bug
            Texture2D texClouds = this.Content.Load<Texture2D>("images/clouds");
            Rectangle srcRectClouds = new Rectangle(0, 100, texClouds.Width, (int)stage.Y);
            Vector2 posClouds = new Vector2(1194, stage.Y - srcRectClouds.Height);
            Vector2 speedClouds = new Vector2(1, 0);
            ScrollingBackground cloud = new ScrollingBackground(this, _spriteBatch, texClouds, posClouds, srcRectClouds, speedClouds);
            Vector2 posClouds2 = new Vector2(0, stage.Y - srcRectClouds.Height);
            Vector2 speedClouds2 = new Vector2(1, 0);
            ScrollingBackground cloud2 = new ScrollingBackground(this, _spriteBatch, texClouds, posClouds2, srcRectClouds, speedClouds2);
            this.Components.Add(cloud);
            this.Components.Add(cloud2);

            //Changing background (should carry over to all screens) for city

            Texture2D tex = this.Content.Load<Texture2D>("images/background");
            Rectangle srcRect = new Rectangle(0, -300, tex.Width, (int)stage.Y);
            Vector2 pos = new Vector2(0, stage.Y - srcRect.Height);
            Vector2 speed = new Vector2(2, 0);
            ScrollingBackground sb = new ScrollingBackground(this, _spriteBatch, tex, pos, srcRect, speed);


            Vector2 pos2 = new Vector2(0, stage.Y - srcRect.Height - 10);
            Vector2 speed2 = new Vector2(1, 0);
            ScrollingBackground sb2 = new ScrollingBackground(this, _spriteBatch, tex, pos2, srcRect, speed2);
            this.Components.Add(sb2);
            this.Components.Add(sb);

            // TODO: use this.Content to load your game content here
            startScene = new StartScene(this);
            this.Components.Add(startScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            highScoreScene = new HighScoreScene(this);
            this.Components.Add(highScoreScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);

            startScene.show();
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            KeyboardState ks = Keyboard.GetState();

            if (helpScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    helpScene.hide();
                    startScene.show();
                }
            }
            if (highScoreScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    highScoreScene.hide();
                    startScene.show();
                }
            }
            if (aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    aboutScene.hide();
                    startScene.show();
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();


            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    actionScene.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    highScoreScene.show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    helpScene.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    startScene.hide();
                    aboutScene.show();
                }
                else if (selectedIndex == QUIT && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            

            base.Draw(gameTime);
        }

        private void hideAllScenes()
        {
            foreach (GameScene item in Components)
            {
                item.hide();
            }
        }
    }
}
