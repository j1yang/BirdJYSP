using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    //action scene j here
    class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        public Pipe pipe1;
        public PipeDown pipe2;
        public Bird bird;
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            //-------------------------------------------------------------------------------
            SoundEffect pointUpSound = g.Content.Load<SoundEffect>("sounds/GetPoint");
            SoundEffect gunSound = g.Content.Load<SoundEffect>("sounds/gunSound2");
            SoundEffect losingSound = g.Content.Load<SoundEffect>("sounds/losing");
            //-------------------------------------------------------------------------------

            this.spriteBatch = g._spriteBatch;

            Texture2D birdTex = g.Content.Load<Texture2D>("images/enemyBird");
            Texture2D playerBirdTex = g.Content.Load<Texture2D>("images/playerBird");
            Texture2D bulletTex = g.Content.Load<Texture2D>("images/bullet");

            Bird bird = new Bird(game, spriteBatch, playerBirdTex, bulletTex, gunSound, losingSound);
            this.Components.Add(bird);

            Random rnd = new Random();
            

            //width of screen is 800
            Vector2 pipe1pos = new Vector2((Shared.stage.X), (Shared.stage.Y) - rnd.Next(20, 360));
            Vector2 pipe2pos = new Vector2((Shared.stage.X) + 800, rnd.Next(-400, -200));
            Texture2D pipeUpTex = g.Content.Load<Texture2D>("images/PipeUp");
            Texture2D pipeDownTex = g.Content.Load<Texture2D>("images/PipeDown");
            pipe1 = new Pipe(game, spriteBatch, pipeUpTex, pipe1pos);
            this.Components.Add(pipe1);
            pipe2 = new PipeDown(game, spriteBatch, pipeDownTex, pipe2pos);
            this.Components.Add(pipe2);

            Vector2 p2pos = new Vector2((Shared.stage.X) + 400, (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            Vector2 p3pos = new Vector2((Shared.stage.X) + 1200, (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            

            Enemy enemy2 = new Enemy(game, spriteBatch, birdTex, p2pos);
            this.Components.Add(enemy2);

            Enemy enemy3 = new Enemy(game, spriteBatch, birdTex, p3pos);
            this.Components.Add(enemy3);

            SpriteFont font = g.Content.Load<SpriteFont>("fonts/GameTitleFont");

            Score score = new Score(game, spriteBatch/*, bird, pipe1, pipe2, enemy2, enemy3*/, font);
            this.Components.Add(score);

            CollisionManager cm = new CollisionManager(game, bird,pipe1, pipe2, enemy2, enemy3, score, losingSound, pointUpSound);
            this.Components.Add(cm);
            


        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);

        }

    }
}
