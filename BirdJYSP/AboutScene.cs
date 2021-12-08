using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdJYSP
{
    class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;

        public AboutScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g._spriteBatch;
        }
    }
}
