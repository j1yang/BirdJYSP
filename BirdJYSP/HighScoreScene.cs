using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdJYSP
{
    class HighScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;

        public HighScoreScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g._spriteBatch;

            SpriteFont font = g.Content.Load<SpriteFont>("fonts/GameTitleFont");

            HighScore highSCore = new HighScore(game, spriteBatch, font);
            this.Components.Add(highSCore);
        }
    }
}
