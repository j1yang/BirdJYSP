using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    class StartScene : GameScene
    {
        //comment test
        private MenuComponent menu;
        public MenuComponent Menu { get => menu; set => menu = value; }

        private SpriteBatch spriteBatch;
        string[] menuItems = { "Start Game", "High Scores", "Help", "About", "Exit" };
        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g._spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("fonts/regF");
            SpriteFont highlightFont = g.Content.Load<SpriteFont>("fonts/highlightF");

            menu = new MenuComponent(g, spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(menu);
        }
    }
}
