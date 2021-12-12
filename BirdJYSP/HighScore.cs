using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BirdJYSP
{
    class HighScore : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        private int currentScore = 0;
        private string score = "Score: ";
        private SpriteFont font;
        private Vector2 pos;
        private string[] savedScores = new string[10];
        


        //private SoundEffect hitSound;
        public HighScore(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font) : base(game)
        {
            this.spriteBatch = spriteBatch;

            this.font = font;

        }

        //public int CurrentScore { get => currentScore; set => currentScore = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "HighScores", new Vector2(300, 20), Color.Red);
            spriteBatch.End();
            GenerateList();
            for (int i = 0; i < 10; i++)
            {
                score = "#" + (i + 1) + ": " + savedScores[i];
                spriteBatch.Begin();
                spriteBatch.DrawString(font, score, new Vector2(100, (100 + (i*30))), Color.Black);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        public void GenerateList()
        {
            if(!File.Exists("SavedScoreList.txt"))
            {
                File.Create("SavedScoreList.txt");
            }
            int i = 1;
            using (StreamReader reader = new StreamReader("SavedScoreList.txt"))
            {
                while (i < 10)
                {
                    savedScores[i] = reader.ReadLine();
                    i++;
                }
                i = 1;
            }
            
        }


    }
}
