﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace BirdJYSP
{
    //Samuel  was here, Jay was here too
    class GameScene : DrawableGameComponent
    {
        public List<GameComponent> Components { get; set; }

        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }

        public virtual void hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }


        public GameScene(Game game) : base(game)
        {
            Components = new List<GameComponent>();
            hide();
        }


        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in Components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            foreach (GameComponent item in Components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
    }
}
