using Microsoft.Xna.Framework;
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
        private Texture2D birdTex;
        private Texture2D bulletTex;

        private Vector2 birdPos;
        private Vector2 birdGravity;
        private Vector2 birdSpeed;

        private Vector2 bulletPos;
        private Vector2 bulletGravity;
        private Vector2 bulletSpeed;

        private float rotation = 0;
        private float birdScale = 3.1f;
        private float bulletScale = .3f;

        private Vector2 origin;
        private Rectangle birdSrcRect;
        private Rectangle bulletSrcRect;

        private KeyboardState oldState;
        //added for animation of bird
        private Vector2 dimesion;
        private List<Rectangle> frames;
        private int frameIndex = 0;
        private int delay = 2;
        private int delayCounter;
        private const int ROW = 3;
        

        public Bird(Game game,
           SpriteBatch spriteBatch,
           Texture2D birdTex,
           Texture2D bulletTex
           ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.birdTex = birdTex;
            this.birdPos = new Vector2((Shared.stage.X- birdTex.Width)/5,(Shared.stage.Y - birdTex.Height)/2);
            this.birdGravity = new Vector2(0, (float)3.3);
            this.birdSpeed = new Vector2(0, -11);

            origin = new Vector2(0, 0);
            birdSrcRect = new Rectangle(0, 0, birdTex.Width, birdTex.Height);
            bulletSrcRect = new Rectangle(0, 0, bulletTex.Width, bulletTex.Height);

            bulletPos = new Vector2(3000, 0);
            bulletSpeed = new Vector2(0,0);
            this.bulletTex = bulletTex;
            //createFrames called to instantiate the list of frames in one animation cycle
            createFrames();
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
            spriteBatch.Draw(birdTex, birdPos, frames[frameIndex], Color.White);
            spriteBatch.End();

            //Draw bullet
            spriteBatch.Begin();
            spriteBatch.Draw(bulletTex, bulletPos, bulletSrcRect, Color.White, rotation, origin, bulletScale, SpriteEffects.None, 0.1f);
            spriteBatch.End();
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
                //}
                //if (frameIndex == 0)
                //{
                //    bulletYPos = 40;
                //}
                //if (frameIndex == 1)
                //{
                //    bulletYPos = 164;
                //}
                //if (frameIndex == 2)
                //{
                //    bulletYPos = 288;
                //}
                
                delayCounter = 0;
            }

            //Gravity down
            birdPos += birdGravity;

            //Bullet moving
            bulletPos += bulletSpeed;

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                //if space bar clicked then bird go up
                birdPos += birdSpeed;
            }

            if (ks.IsKeyDown(Keys.LeftControl))
            {
                //bullet passed right border
                if (bulletPos.X >= Shared.stage.X)
                {
                    //bullet starting point
                    //Vector2 tempLoc = new Vector2(birdPos.X + birdTex.Width * birdScale, birdPos.Y + birdTex.Height + 10);
                    //

                    Vector2 tempLoc = new Vector2(birdPos.X + birdTex.Width, birdPos.Y +  bulletYPos);

                    //set starting point
                    bulletPos = tempLoc;
                    bulletSpeed = new Vector2(22, 0);
                }
            }
            //bird go under bottom border
            if (birdPos.Y >= Shared.stage.Y)
            {
                birdPos += new Vector2(0, -80);
                if (birdPos.Y == Shared.stage.Y-birdTex.Height*2)
                {
                    this.Enabled = false;
                    this.Visible = false;

                    this.birdPos = new Vector2(-10000, -10000);
                }
            }

            //bird go over top border
            if (birdPos.Y <= 0)
            {//bounce bird back
                Vector2 hit = new Vector2(0, 9);
                birdPos += hit;
            }

            base.Update(gameTime);
        }

        public Rectangle getBirdBounds()
        {
            
            return new Rectangle((int)birdPos.X, (int)birdPos.Y, birdTex.Width, birdTex.Height);
            //tex x = 100
            //tex y = 80

        }

        public Rectangle getBulletBounds()
        {
            return new Rectangle((int)bulletPos.X, (int)bulletPos.Y, bulletTex.Width, bulletTex.Height);
        }
    }
}
