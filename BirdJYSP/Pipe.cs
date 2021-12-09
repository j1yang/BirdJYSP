using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    class Pipe : DrawableGameComponent
    {
        //Variables for an enemy
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 stage;
        private Vector2 pipeSpeed;

        //origin of the object
        private Vector2 origin;
        private const int PIPE_OPENING = 100;
        private Vector2 originalPosition;
        private static Random rnd = new Random();
        //width is 800
        //height is 480
        private Vector2 startLocation = new Vector2((Shared.stage.X), (Shared.stage.Y) - rnd.Next(40, 420));
        private Vector2 respawn = new Vector2(((Shared.stage.X)), rnd.Next(40, 420));

        public Pipe(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            //this.stage = stage;
            this.pipeSpeed = new Vector2(5, 0);
            //set origin of pipe to 0,0 (top left)
            origin = new Vector2(0, 0);
            originalPosition = position;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            position -= pipeSpeed;

            //left
            if (position.X < 0)
            {
                Random rnd = new Random();
                position.X = Shared.stage.X + 800;
                position.Y = rnd.Next(40, 360);
            }

            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

    }
}
