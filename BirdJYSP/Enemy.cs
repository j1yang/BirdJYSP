using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    public class Enemy : DrawableGameComponent
    {
        //Variables for an enemy
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 position;
        private Vector2 pipeSpeed;

        //origin of the object
        private Vector2 origin;
        private const int PIPE_OPENING = 100;
        private Vector2 originalPosition;
        private static Random rnd = new Random();
        //width is 800
        //height is 480
        private Vector2 startLocation = new Vector2((Shared.stage.X) + 800, (Shared.stage.Y) - rnd.Next(50, 420));

        //For the animation of enemy Bird
        private List<Rectangle> frames;
        private int frameIndex = 0;
        private int delay = 2;
        private int delayCounter;
        private const int COL = 3;

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 StartLocation { get => startLocation; set => startLocation = value; }

        public Enemy(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.Position = position;
            //this.stage = stage;
            this.pipeSpeed = new Vector2(5, 0);
            //set origin of pipe to 0,0 (top left)
            origin = new Vector2(0, 0);
            originalPosition = position;
            createFrames();
        }
        //used to create each frame of the sprite animation
        private void createFrames()
        {
            frames = new List<Rectangle>();
            int x = 0;
            int y = 0;
            for (int i = 0; i < COL; i++)
            {

                Rectangle r = new Rectangle(x, y, 120, 85);
                frames.Add(r);
                x += 134;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            spriteBatch.Draw(tex, Position, frames[frameIndex], Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            int bulletYPos = 40;

            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;
                if (frameIndex > COL - 1)
                {
                    frameIndex = 0;
                }
                delayCounter = 0;
            }

            Position -= pipeSpeed;
            
            //left
            if(Position.X < 0)
            {
                Random rnd = new Random();
                Vector2 tempLoc = new Vector2((Shared.stage.X) + 800, (Shared.stage.Y) - rnd.Next(50, 420));
                StartLocation = tempLoc;
                Position = StartLocation;
                Visible = true;
            }

            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, tex.Width, tex.Height);
        }

    }
}
