using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private string[] scores = new string[100];


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
            int i = 0;
            using (StreamReader reader = new StreamReader("SavedScoreList.txt"))
            {
                while (!reader.EndOfStream)
                {
                    scores[i] = reader.ReadLine();
                }
                List<string> list = scores.ToList();
                list.Sort();

                i = 0;
                while (i < 10)
                {
                    savedScores[i] = list[i];
                    i++;
                }
                i = 0;
            }
            
        }


    }
}
