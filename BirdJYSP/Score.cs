using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    class Score : GameComponent
    {

        private Bird bird;
        private Pipe pipe1;
        private PipeDown pipe2;
        private Enemy enemy1;
        private Enemy enemy2;
        public int currentScore = 0;
        //private SoundEffect hitSound;
        public Score(Game game,
            Bird bird,
            Pipe pipe1,
            PipeDown pipe2,
            Enemy enemy1,
            Enemy enemy2) : base(game)
        {
            this.bird = bird;
            this.pipe1 = pipe1;
            this.pipe2 = pipe2;
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle birdRec = bird.getBirdBounds();
            Rectangle bulletRec = bird.getBulletBounds();
            Rectangle pipe1Rec = pipe1.getBounds();
            Rectangle pipe2Rec = pipe2.getBounds();
            Rectangle enemy1Rec = enemy1.getBounds();
            Rectangle enemy2Rec = enemy2.getBounds();

            

            //bullet collides with enemy bird
            if (bulletRec.Intersects(enemy1Rec) && enemy1.Visible)
            {
                currentScore++;
            }
            //bullet collides with enemy bird
            if (bulletRec.Intersects(enemy2Rec) && enemy2.Visible)
            {
                currentScore++;
            }



                 
            if (pipe1Rec.X <= 0)
            {
                currentScore++;
            }
            if (pipe2Rec.X <= 0)
            {
                currentScore++;
            }



            Debug.WriteLine(currentScore);

            base.Update(gameTime);
        }

    }
}
