using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    //action scene j here
    class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;

        

        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g._spriteBatch;

            Texture2D birdTex = g.Content.Load<Texture2D>("images/test");
            Texture2D bulletTex = g.Content.Load<Texture2D>("images/bullet");
            Bird bird = new Bird(game, spriteBatch, birdTex, bulletTex);
            this.Components.Add(bird);

            Random rnd = new Random();
            Vector2 p1pos = new Vector2((Shared.stage.X), (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            Vector2 p2pos = new Vector2((Shared.stage.X) + 296 , (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            Vector2 p3pos = new Vector2((Shared.stage.X) + 593, (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            Enemy enemy1 = new Enemy(game, spriteBatch, birdTex, p1pos);
            this.Components.Add(enemy1);

            Enemy enemy2 = new Enemy(game, spriteBatch, birdTex, p2pos);
            this.Components.Add(enemy2);

            Enemy enemy3 = new Enemy(game, spriteBatch, birdTex, p3pos);
            this.Components.Add(enemy3);

            //width of screen is 800
            Vector2 pipe1pos = new Vector2((Shared.stage.X), (Shared.stage.Y) - rnd.Next(20, 420));
            Vector2 pipe2pos = new Vector2((Shared.stage.X) + 400, rnd.Next(-400, -100));
            Texture2D pipeUpTex = g.Content.Load<Texture2D>("images/PipeUp");
            Texture2D pipeDownTex = g.Content.Load<Texture2D>("images/PipeDown");
            Pipe pipe1 = new Pipe(game, spriteBatch, pipeUpTex, pipe1pos);
            this.Components.Add(pipe1);
            PipeDown pipe2 = new PipeDown(game, spriteBatch, pipeDownTex, pipe2pos);
            this.Components.Add(pipe2);


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
