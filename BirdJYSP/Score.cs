using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    public class Score : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private Bird bird;
        private Pipe pipe1;
        private PipeDown pipe2;
        private Enemy enemy1;
        private Enemy enemy2;
        private int currentScore = 0;
        private string score = "Score: ";
        private SpriteFont font;
        private Vector2 pos;

        //private SoundEffect hitSound;
        public Score(Game game,
            SpriteBatch spriteBatch,
            //Bird bird,
            //Pipe pipe1,
            //PipeDown pipe2,
            //Enemy enemy1,
            //Enemy enemy2,
            SpriteFont font) : base(game)
        {
            this.spriteBatch = spriteBatch;

            //this.bird = bird;
            //this.pipe1 = pipe1;
            //this.pipe2 = pipe2;
            //this.enemy1 = enemy1;
            //this.enemy2 = enemy2;

            this.font = font;
            pos = new Vector2(Shared.stage.X / 2, Shared.stage.Y / 2);

        }

        public int CurrentScore { get => currentScore; set => currentScore = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, score, pos, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            score = "Score: " + currentScore;
            //Rectangle birdRec = bird.getBirdBounds();
            //Rectangle bulletRec = bird.getBulletBounds();
            //Rectangle pipe1Rec = pipe1.getBounds();
            //Rectangle pipe2Rec = pipe2.getBounds();
            //Rectangle enemy1Rec = enemy1.getBounds();
            //Rectangle enemy2Rec = enemy2.getBounds();



            ////bullet collides with enemy bird
            //if (bulletRec.Intersects(enemy1Rec) && enemy1.Visible)
            //{
            //    CurrentScore++;
            //}
            ////bullet collides with enemy bird
            //if (bulletRec.Intersects(enemy2Rec) && enemy2.Visible)
            //{
            //    CurrentScore++;
            //}




            //if (pipe1Rec.X <= 0)
            //{
            //    CurrentScore++;
            //}
            //if (pipe2Rec.X <= 0)
            //{
            //    CurrentScore++;
            //}



            Debug.WriteLine(CurrentScore);

            base.Update(gameTime);
        }

    }
}
