using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    public class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private int currentScore = 0;
        private string score = "Score: ";
        private SpriteFont font;
        private Vector2 pos;

        //private SoundEffect hitSound;
        public Score(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;

            this.font = font;
            this.pos = pos;

        }

        public int CurrentScore { get => currentScore; set => currentScore = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, score, pos, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            score = "Score: " + currentScore;

            Debug.WriteLine(CurrentScore);

            base.Update(gameTime);
        }

    }
}
