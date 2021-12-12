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
        public string score = "Score: \n";
        private SpriteFont font;
        private Vector2 pos;
        private string[] savedScores = new string[10];
        private string[] scores = new string[100];
        private List<string> scoreList = new List<string>();
        private List<Tuple<int, string>> list = new List<Tuple<int, string>>();

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
            spriteBatch.DrawString(font, score, new Vector2(100, 60), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            score = GenerateList();
            base.Update(gameTime);
        }

        public string GenerateList()
        {

            if (!File.Exists("SavedScoreList.txt"))
            {
                File.Create("SavedScoreList.txt");
            }

            int index = 0;
            using (StreamReader reader = new StreamReader("SavedScoreList.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] tempLine = line.Split('-');
                    scoreList.Add(line);
                    list.Add(new Tuple<int, string>(int.Parse(tempLine[0].Trim(' ')), tempLine[1].Trim(' ')));
                }
            }

            list.Sort((x, y) => y.Item1.CompareTo(x.Item1));

            if (list.Count() >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    string line = "#" + (i + 1) + ": " + list[i].Item1 + " - " + list[i].Item2 + "\n";
                    score += line;
                }

            }
            else
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    string line = "#" + (i + 1) + ": " + list[i].Item1 + " - " + list[i].Item2 + "\n";
                    score += line;

                }
            }

            return score;
        }


    }
}
