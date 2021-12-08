using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, highlightFont;
        private string[] menuItems;

        public int SelectedIndex { get; set; }
        private Vector2 pos;
        private Color regularColor = Color.Black;
        private Color highlightColor = Color.Red;


        private KeyboardState oldState;

        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont hilightFont,
            string[] menuItem) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = hilightFont;
            this.menuItems = menuItem;
            pos = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = pos;

            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (SelectedIndex == i)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[i], tempPos, highlightColor);
                    tempPos.Y += highlightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i], tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Length)
                {
                    SelectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Length - 1;
                }
            }
            oldState = ks;

            base.Update(gameTime);
        }
    }
}
