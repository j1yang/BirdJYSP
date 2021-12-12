using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    public class GameOver : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private int currentScore = 0;
        private string gameOver = "Game Over";
        private string direction = "Press Space to restart the game.\nESC or Enter key to go menu.";
        private SpriteFont font, directionFont;
        private Vector2 pos1, pos2;

        //private SoundEffect hitSound;
        public GameOver(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            SpriteFont directionFont) : base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = spriteBatch;

            this.font = font;
            this.directionFont = directionFont;
            pos1 = new Vector2(Shared.stage.X / 2 - 80, Shared.stage.Y / 2 - 50);
            pos2 = new Vector2(Shared.stage.X / 2 - 80, Shared.stage.Y / 2);
            //this.Visible = false;
        }

        public int CurrentScore { get => currentScore; set => currentScore = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, gameOver, pos1, Color.Red);
            spriteBatch.DrawString(directionFont, direction, pos2, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
