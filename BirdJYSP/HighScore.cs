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
        private string score = "Score: \n";
        private SpriteFont font;
        private Vector2 pos;
        private string[] savedScores = new string[10];
        private string[] scores = new string[100];
        private List<string> scoreList = new List<string>();


        //private SoundEffect hitSound;
        public HighScore(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font) : base(game)
        {
            this.spriteBatch = spriteBatch;

            this.font = font;
            this.score = GenerateList();

        }

        //public int CurrentScore { get => currentScore; set => currentScore = value; }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "HighScores", new Vector2(300, 20), Color.Red);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.DrawString(font, score, new Vector2(100, 80), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }

        public string GenerateList()
        {
            //if(!File.Exists("SavedScoreList.txt"))
            //{
            //    File.Create("SavedScoreList.txt");
            //}
            //int i = 0;
            //using (StreamReader reader = new StreamReader("SavedScoreList.txt"))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        scores[i] = reader.ReadLine();
            //    }
            //    List<string> list = scores.ToList();
            //    list.Sort();

            //    i = 0;
            //    while (i < 10)
            //    {
            //        savedScores[i] = list[i];
            //        i++;
            //    }
            //    i = 0;
            //}

            if (!File.Exists("SavedScoreList.txt"))
            {
                File.Create("SavedScoreList.txt");
            }

            using (StreamReader reader = new StreamReader("SavedScoreList.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    scoreList.Add(line);
                }
            }

            scoreList.Sort();
            scoreList.Reverse();

            if (scoreList.Count() >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    string line = "#" + (i + 1) + ": " + scoreList[i] + "\n";
                    score += line;
                }
                
            }
            else
            {
                for (int i = 0; i < scoreList.Count(); i++)
                {
                    string line = "#" + (i + 1) + ": " + scoreList[i] + "\n";
                    score += line;

                }
            }

            return score;
        }


    }
}
