using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdJYSP
{
    class Bird : DrawableGameComponent
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

        public Bird(Game game,
           SpriteBatch spriteBatch,
           Texture2D birdTex,
           Texture2D bulletTex
           ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.birdTex = birdTex;
            this.birdPos = new Vector2((Shared.stage.X- birdTex.Width)/5,(Shared.stage.Y - birdTex.Height)/2);
            this.birdGravity = new Vector2(0, (float)1.9);
            this.birdSpeed = new Vector2(0, -6);

            origin = new Vector2(0, 0);
            birdSrcRect = new Rectangle(0, 0, birdTex.Width, birdTex.Height);
            bulletSrcRect = new Rectangle(0, 0, bulletTex.Width, bulletTex.Height);

            bulletPos = new Vector2(3000, 0);
            bulletSpeed = new Vector2(0,0);
            this.bulletTex = bulletTex;
        }

        public override void Draw(GameTime gameTime)
        {
            //Draw bird
            spriteBatch.Begin();
            spriteBatch.Draw(birdTex, birdPos, birdSrcRect, Color.White, rotation, origin , birdScale, SpriteEffects.None, 0.1f);
            spriteBatch.End();

            //Draw bullet
            spriteBatch.Begin();
            spriteBatch.Draw(bulletTex, bulletPos, bulletSrcRect, Color.White, rotation, origin, bulletScale, SpriteEffects.None, 0.1f);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
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
                    Vector2 tempLoc = new Vector2(birdPos.X + birdTex.Width * birdScale, birdPos.Y + birdTex.Height + 10);
                    //set starting point
                    bulletPos = tempLoc;
                    bulletSpeed = new Vector2(16, 0);
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
                Vector2 hit = new Vector2(0, 6);
                birdPos += hit;
            }

            base.Update(gameTime);
        }

        
    }
}
