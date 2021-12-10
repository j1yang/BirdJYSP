using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdJYSP
{
    public class CollisionManager : GameComponent
    {

        private Bird bird;
        private Pipe pipe1;
        private PipeDown pipe2;
        private Enemy enemy1;
        private Enemy enemy2;

        //private SoundEffect hitSound;
        public CollisionManager(Game game,
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

            //palyer bird collides  with enemy bird
            if (birdRec.Intersects(enemy1Rec) || birdRec.Intersects(enemy2Rec))
            {
                //ball.Speed.Y = -ball.Speed.Y;
                //ball.Speed = new Vector2(ball.Speed.X, -Math.Abs(-ball.Speed.Y));
                //hitSound.Play();
                bird.Enabled = false;
                bird.Visible = false;
            }

            //palyer bird collides  with pipe
            if (birdRec.Intersects(pipe1Rec) || birdRec.Intersects(pipe2Rec))
            {
                bird.Enabled = false;
                bird.Visible = false;
            }

            //bullet collides with enemy bird
            if (birdRec.Intersects(enemy1Rec) || birdRec.Intersects(enemy2Rec))
            {

            }



            base.Update(gameTime);
        }
    }
}
