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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

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

            if (helpScene.Enabled || actionScene.Enabled)
            {

                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();
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
