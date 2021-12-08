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
            Vector2 p2pos = new Vector2((Shared.stage.X) + 300 , (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            Vector2 p3pos = new Vector2((Shared.stage.X) + 600, (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y));
            Pipe pipe1 = new Pipe(game, spriteBatch, birdTex, p1pos);
            this.Components.Add(pipe1);

            Pipe pipe2 = new Pipe(game, spriteBatch, birdTex, p2pos);
            this.Components.Add(pipe2);

            Pipe pipe3 = new Pipe(game, spriteBatch, birdTex, p3pos);
            this.Components.Add(pipe3);

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
