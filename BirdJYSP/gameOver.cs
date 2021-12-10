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
        private SpriteFont font;
        private Vector2 pos;

        //private SoundEffect hitSound;
        public GameOver(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font) : base(game)
        {
            this.spriteBatch = spriteBatch;

            this.font = font;
            pos = new Vector2(Shared.stage.X / 2 - 80, Shared.stage.Y / 2 - 50);

        }

        public int CurrentScore { get => currentScore; set => currentScore = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, gameOver, pos, Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
    }
}
