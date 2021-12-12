using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BirdJYSP
{
    public class CollisionManager : GameComponent
    {
        private int finalScore = 0;
        public string playerName = "N/A";
        string savedName;
        int savedScore;
        List<(int, string)> list = new List<(int Index, string Name)> { };
        string currentLine;

        private Bird bird;
        private Bullet bullet;
        private Pipe pipe1;
        private PipeDown pipe2;
        private Enemy enemy1;
        private Enemy enemy2;
        private Score score;
        public GameOver gameOver;
        private SoundEffect losingSound, pointUpSound;
        public bool isScoreUpdated = false;

        //private SoundEffect hitSound;
        public CollisionManager(Game game,
            Bird bird,
            Bullet bullet,
            Pipe pipe1,
            PipeDown pipe2,
            Enemy enemy1,
            Enemy enemy2,
            Score score,
            GameOver gameOver,
           SoundEffect losingSound,
           SoundEffect pointUpSound) : base(game)
        {
            this.bird = bird;
            this.bullet = bullet;
            this.pipe1 = pipe1;
            this.pipe2 = pipe2;
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.score = score;
            this.gameOver = gameOver;
            this.gameOver.Visible = false;
            this.losingSound = losingSound;
            this.pointUpSound = pointUpSound;

        }
        public void GenerateGameOver()
        {
            var instance = losingSound.CreateInstance();
            instance.Volume = 0.8f;
            instance.Play();
            bird.Enabled = false;
            bird.Visible = false;
            bullet.Enabled = false;
            bullet.Visible = false;
            pipe1.Enabled = false;
            pipe1.Visible = false;
            pipe2.Enabled = false;
            pipe2.Visible = false;
            enemy1.Enabled = false;
            enemy1.Visible = false;
            enemy2.Enabled = false;
            enemy2.Visible = false;
            gameOver.Visible = true;
            score.Visible = false;
            //gameOver.Visible = true;

            #region Save score in descending order
            if (InputBox("Save Score", "New document name:", ref playerName) == DialogResult.OK)
            {
                isScoreUpdated = true;
                finalScore = score.CurrentScore;
                if (!File.Exists("SavedScoreList.txt"))
                {
                    File.Create("SavedScoreList.txt");
                }
                using (StreamReader reader = new StreamReader("SavedScoreList.txt"))
                {
                    #region Trial 1
                    //int i = 0;
                    ////get length of file
                    //while (!reader.EndOfStream)
                    //{
                    //    reader.ReadLine();
                    //    i++;
                    //}
                    //string[] savedScores = new string[i];
                    //bool endRead = false;
                    //bool recordSaved = false;
                    //bool oddLine = true;
                    ////records number of iterations gone trhough
                    //int j = 0;
                    ////records placement of the new record
                    //int k = 0;
                    //while (!reader.EndOfStream || endRead)
                    //{
                    //    currentLine = reader.ReadLine();
                    //    savedScores[j] = currentLine;
                    //    if (oddLine)
                    //    {
                    //        if (int.Parse(currentLine) < finalScore)
                    //        {
                    //            k = j;
                    //        }
                    //        oddLine = false;

                    //    }
                    //    else
                    //    {
                    //        oddLine = true;
                    //    }
                    //    j++;
                    //}
                    ////Now, savedRecords will be array A
                    ////Next, create an array that is the same size of Array A + 2 (for the new entries)
                    //string[] updatedSavedScores = new string[i + 2];
                    //for (int m = 0; m < k; m++)
                    //{
                    //    updatedSavedScores[m] = savedScores[m];
                    //}
                    //updatedSavedScores[k] = finalScore.ToString();
                    //updatedSavedScores[k + 1] = playerName;
                    //j = i - k;
                    //for (int n = 0; n < j; n++)
                    //{
                    //    updatedSavedScores[k + 1 + n] = finalScore.ToString();
                    //}
                    //list = updatedSavedScores.ToList();
                    #endregion
                    while(!reader.EndOfStream)
                    {
                        currentLine = reader.ReadLine();
                        string[] fields = currentLine.Split(" - ");
                        savedScore = int.Parse(fields[0]);
                        savedName = fields[1];
                        list.Add((savedScore, savedName));
                    }
                    
                }

                using (StreamWriter writer = new StreamWriter("SavedScoreList.txt", append: true))
                {
                    //foreach (var item in list)
                    //{
                    //    writer.WriteLine(item);
                    //}
                    //First line will print player name, second will print Score

                }
            }
            #endregion

        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle birdRec = bird.getBounds();
            Rectangle bulletRec = bullet.getBulletBounds();
            Rectangle pipe1Rec = pipe1.getBounds();
            Rectangle pipe2Rec = pipe2.getBounds();
            Rectangle enemy1Rec = enemy1.getBounds();
            Rectangle enemy2Rec = enemy2.getBounds();

            //palyer bird collides  with enemy bird
            if (birdRec.Intersects(enemy1Rec) && enemy1.Visible || birdRec.Intersects(enemy2Rec) && enemy2.Visible)
            {
                GenerateGameOver();
            }

            //palyer bird collides  with pipe1
            if (birdRec.Intersects(pipe1Rec) && pipe1.Visible)
            {
                GenerateGameOver();
            }
            //palyer bird collides  with pipe2
            if (birdRec.Intersects(pipe2Rec) && pipe2.Visible)
            {
                GenerateGameOver();
            }

            //bullet collides with enemy bird
            if (bulletRec.Intersects(enemy1Rec) && enemy1.Visible && bullet.Visible)
            {
                var instance = pointUpSound.CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
                score.CurrentScore++;
                gameOver.CurrentScore++;
                enemy1.Visible = false;
                bullet.Visible = false;
            }
            //bullet collides with enemy bird
            if (bulletRec.Intersects(enemy2Rec) && enemy2.Visible && bullet.Visible)
            {
                var instance = pointUpSound.CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
                score.CurrentScore++;
                gameOver.CurrentScore++;
                enemy2.Visible = false;
                bullet.Visible = false;
            }

            if (pipe1Rec.X <= 0)
            {
                score.CurrentScore++;
                gameOver.CurrentScore++;
            }
            if (pipe2Rec.X <= 0)
            {
                score.CurrentScore++;
                gameOver.CurrentScore++;
            }
            KeyboardState ks = Keyboard.GetState();

            if (gameOver.Visible)
            {//if game is over
                if (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space) && isScoreUpdated == true)
                {//space key pushed, play game again
                    ResetGame();

                }
            }

            base.Update(gameTime);
        }

        public void ResetGame()
        {
            //game over message disable
            gameOver.Visible = false;

            //reset score
            score.CurrentScore = 0;

            //enable player bird, enemy bird, bullet, and pipe
            bird.Enabled = true;
            bird.Visible = true;
            bird.BirdPos = new Vector2((Shared.stage.X - bird.birdTex.Width) / 5, (Shared.stage.Y - bird.birdTex.Height) / 2);
            bullet.Enabled = true;
            bullet.Visible = true;
            pipe1.Enabled = true;
            pipe1.Visible = true;
            Random rnd = new Random();

            pipe1.position = new Vector2((Shared.stage.X), (Shared.stage.Y) - rnd.Next(100, 380));;

            pipe2.Enabled = true;
            pipe2.Visible = true;
            pipe2.position = new Vector2((Shared.stage.X) + 800, rnd.Next(-400, -200));

            enemy1.Enabled = true;
            enemy1.Visible = true;
            enemy1.position= new Vector2((Shared.stage.X) + 400, (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y)); ;

            enemy2.Enabled = true;
            enemy2.Visible = true;
            enemy2.position = new Vector2((Shared.stage.X) + 1200, (Shared.stage.Y) - rnd.Next(2, (int)Shared.stage.Y)); ;

            score.Visible = true;

            isScoreUpdated = false;
        }
    }
}
