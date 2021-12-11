using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BirdJYSP
{
    public class CollisionManager : GameComponent
    {
        private string finalScore = "";
        public string playerName = "N/A";

        private Bird bird;
        private Bullet bullet;
        private Pipe pipe1;
        private PipeDown pipe2;
        private Enemy enemy1;
        private Enemy enemy2;
        private Score score;
        private GameOver gameOver;
        private SoundEffect losingSound, pointUpSound;


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
            gameOver.Visible = true;

            
            if (InputBox("Save Score", "New document name:", ref playerName) == DialogResult.OK)
            {
                finalScore = playerName;
                finalScore += " - " + score.CurrentScore;
                if (!File.Exists("SavedScoreList.txt"))
                {
                    File.Create("SavedScoreList.txt");
                }
                using (StreamWriter writer = new StreamWriter("SavedScoreList.txt", append: true))
                {
                    writer.WriteLine(finalScore);
                }
            }

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


            base.Update(gameTime);
        }
    }
}
