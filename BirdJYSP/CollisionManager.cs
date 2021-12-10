using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdJYSP
{
    public class CollisionManager : GameComponent
    {

        private Ball ball;
        private Bat bat;
        private SoundEffect hitSound;
        public CollisionManager(Game game,
            Ball ball,
            Bat bat,
            SoundEffect hitSound) : base(game)
        {
            this.ball = ball;
            this.bat = bat;
            this.hitSound = hitSound;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle ballRect = ball.getBounds();
            Rectangle batRect = bat.getBounds();

            if (ballRect.Intersects(batRect))
            {
                //ball.Speed.Y = -ball.Speed.Y;
                ball.Speed = new Vector2(ball.Speed.X, -Math.Abs(-ball.Speed.Y));
                hitSound.Play();
            }

            base.Update(gameTime);
        }
    }
}
