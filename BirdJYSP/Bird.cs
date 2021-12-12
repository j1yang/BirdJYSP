using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BirdJYSP
{
    public class Bird : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        public Texture2D birdTex;

        private Vector2 birdPos;
        private Vector2 birdGravity;
        private Vector2 birdSpeed;

        private float rotation = 0;
        private float bulletScale = .3f;

        private Vector2 origin;
        private Rectangle birdSrcRect;

        private KeyboardState oldState;
        //added for animation of bird
        private List<Rectangle> frames;
        private int frameIndex = 0;
        private int delay = 2;
        private int delayCounter;
        private const int ROW = 3;

        private SoundEffect losingSound;

        public Vector2 BirdPos { get => birdPos; set => birdPos = value; }
        public Texture2D BirdTex { get => birdTex; set => birdTex = value; }

        public Bird(Game game,
           SpriteBatch spriteBatch,
           Texture2D birdTex,
           SoundEffect losingSound
           ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.BirdTex = birdTex;
            this.BirdPos = new Vector2((Shared.stage.X- birdTex.Width)/5,(Shared.stage.Y - birdTex.Height)/2);
            this.birdGravity = new Vector2(0, (float)3.3);
            this.birdSpeed = new Vector2(0, -11);

            origin = new Vector2(0, 0);
            birdSrcRect = new Rectangle(0, 0, birdTex.Width, birdTex.Height);
            //createFrames called to instantiate the list of frames in one animation cycle
            createFrames();

            this.losingSound = losingSound;
        }
        //used to create each frame of the sprite animation
        private void createFrames()
        {
            frames = new List<Rectangle>();
            int x = 0;
            int y = 0;
            for (int i = 0; i < ROW; i++)
            {
                
                Rectangle r = new Rectangle(x, y, 100, 80);
                frames.Add(r);
                y += 124;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            //Draw bird
            //spriteBatch.Begin();
            //spriteBatch.Draw(birdTex, birdPos, birdSrcRect, Color.White, rotation, origin , birdScale, SpriteEffects.None, 0.1f);
            //spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.Draw(BirdTex, BirdPos, frames[frameIndex], Color.White);
            spriteBatch.End();

            //Draw bullet
            //spriteBatch.Begin();
            //spriteBatch.Draw(bulletTex, bulletPos, bulletSrcRect, Color.White, rotation, origin, bulletScale, SpriteEffects.None, 0.1f);
            //spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            int bulletYPos = 40;
            delayCounter++;
            if (delayCounter> delay)
            {
                frameIndex++;
                if (frameIndex > ROW - 1)
                {
                    frameIndex = 0;
                    bulletYPos = 40;
                }
                delayCounter = 0;
            }

            //Gravity down
            BirdPos += birdGravity;

            //Bullet moving
            //bulletPos += bulletSpeed;

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                //if space bar clicked then bird go up
                BirdPos += birdSpeed;
            }

            //bird go under bottom border
            //if (BirdPos.Y >= Shared.stage.Y)
            //{
            //    if (BirdPos.Y == Shared.stage.Y - BirdTex.Height * 2)
            //    {
            //        this.BirdPos = new Vector2(-10000, -10000);
            //    }
            //}

            //bird go over top border
            if (BirdPos.Y <= 0)
            {//bounce bird back
                Vector2 hit = new Vector2(0, 9);
                BirdPos += hit;
            }
            base.Update(gameTime);
        }

        public Rectangle getBounds()
        {
            
            return new Rectangle((int)BirdPos.X, (int)BirdPos.Y, 100, 80);
            //tex x = 100
            //tex y = 80

        }

        
    }
}
