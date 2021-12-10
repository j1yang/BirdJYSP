using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    public class Bullet : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D bulletTex;
        private SoundEffect gunSound;
        private Bird bird;

        private Vector2 bulletPos;
        private Vector2 bulletSpeed;

        private float rotation = 0;
        private float bulletScale = .3f;

        private Vector2 origin;
        private Rectangle bulletSrcRect;
        public Bullet(Game game,
            SpriteBatch spriteBatch,
            Bird bird,
            Texture2D bulletTex,
            SoundEffect gunSound) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.bird = bird;

            this.bulletTex = bulletTex;
            this.gunSound = gunSound;

            origin = new Vector2(0, 0);
            bulletSrcRect = new Rectangle(0, 0, bulletTex.Width, bulletTex.Height);

            bulletPos = new Vector2(3000, 0);
            bulletSpeed = new Vector2(0, 0);

            this.gunSound = gunSound;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bulletTex, bulletPos, bulletSrcRect, Color.White, rotation, origin, bulletScale, SpriteEffects.None, 0.1f);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            //Bullet moving
            bulletPos += bulletSpeed;

            KeyboardState ks = Keyboard.GetState();


            if (ks.IsKeyDown(Keys.LeftControl))
            {
                //bullet passed right border
                if (bulletPos.X >= Shared.stage.X)
                {
                    Vector2 tempLoc = new Vector2(bird.BirdPos.X + bird.BirdTex.Width, bird.BirdPos.Y + 40);

                    //set starting point
                    bulletPos = tempLoc;
                    var instance = gunSound.CreateInstance();
                    instance.Volume = 0.3f;
                    instance.Play();
                    bulletSpeed = new Vector2(22, 0);
                    Visible = true;
                }
            }
            base.Update(gameTime);
        }

        public Rectangle getBulletBounds()
        {
            return new Rectangle((int)bulletPos.X, (int)bulletPos.Y, bulletTex.Width, bulletTex.Height);
        }
    }
}
