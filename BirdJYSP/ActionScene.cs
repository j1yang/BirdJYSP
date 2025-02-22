﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BirdJYSP
{
    //action scene j here
    class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        public Pipe pipe1;
        public PipeDown pipe2;
        public Bird bird;
        private Song backgroundMusic;
        public CollisionManager cm;
        public ActionScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            //-------------------------------------------------------------------------------
            SoundEffect pointUpSound = g.Content.Load<SoundEffect>("sounds/GetPoint");
            SoundEffect gunSound = g.Content.Load<SoundEffect>("sounds/gunSound2");
            SoundEffect losingSound = g.Content.Load<SoundEffect>("sounds/losing");

            //background Music Added
            backgroundMusic = g.Content.Load<Song>("sounds/gameBackgroundSound");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.Volume = 0.3f;
            MediaPlayer.IsRepeating = true;

            //-------------------------------------------------------------------------------

            this.spriteBatch = g._spriteBatch;

            Texture2D birdTex = g.Content.Load<Texture2D>("images/enemyBird");
            Texture2D playerBirdTex = g.Content.Load<Texture2D>("images/playerBird");
            Texture2D bulletTex = g.Content.Load<Texture2D>("images/bullet");

            Bird bird = new Bird(game, spriteBatch, playerBirdTex, losingSound);
            this.Components.Add(bird);

            Bullet bullet = new Bullet(game, spriteBatch, bird, bulletTex, gunSound);
            this.Components.Add(bullet);

            Random rnd = new Random();
            

            //width of screen is 800
            Vector2 pipe1pos = new Vector2((Shared.stage.X), (Shared.stage.Y) - rnd.Next(100, 380));
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

            Score score = new Score(game, spriteBatch/*, bird, pipe1, pipe2, enemy2, enemy3*/, font, new Vector2(Shared.stage.X - 180, 10));
            this.Components.Add(score);

            SpriteFont regularFont = g.Content.Load<SpriteFont>("fonts/regF");
            GameOver gameOver = new GameOver(game, spriteBatch, font, regularFont,score);
            gameOver.Visible = false;
            //Make invisible, when player loses, make visibile
            this.Components.Add(gameOver);

              cm = new CollisionManager(game, bird, bullet, pipe1, pipe2, enemy2, enemy3, score, gameOver, losingSound, pointUpSound);
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
