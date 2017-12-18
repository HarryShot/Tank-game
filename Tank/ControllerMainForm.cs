using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

[assembly: CLSCompliant(true)]
namespace Tank
{
    delegate void Invoker();
    public partial class ControllerMainForm : Form
    {

        public ControllerMainForm() : this(260) { }
        public ControllerMainForm(int sizeField) : this(sizeField, 5) { }
        public ControllerMainForm(int sizeField, int amountTank) : this(sizeField, amountTank, 5) { }
        public ControllerMainForm(int sizeField, int amountTank, int amountApples) : this(sizeField, amountTank, amountApples, 40) { }
        public ControllerMainForm(int sizeField, int amountTank, int amountApples, int speedGame)
        {
            InitializeComponent();

            model = new Model(sizeField, amountTank, amountApples, speedGame);
            model.changeStreep += new Streep(ChangerStatusStripLbl);
            view = new View(model);
            this.Controls.Add(view);

            isSound = true;

            SP = new SoundPlayer(Properties.Resources.Tank_Move);
        }

        private void StartPause_btn_Click(object sender, EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stoping;
                Start_stop_pbx.Image = Properties.Resources.Button_play;
                ChangerStatusStripLbl();
            }
            else
            {
                Start_stop_pbx.Focus();
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.Play);
                modelPlay.Start();
                Start_stop_pbx.Image = Properties.Resources.Button_pause;
                ChangerStatusStripLbl();
                view.Invalidate();
            }
        }

        private void Controller_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
            {
                model.gameStatus = GameStatus.stoping;
                modelPlay.Abort();
            }
            DialogResult dr = MessageBox.Show("Do you want exit?", "Tanks", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk,
                 MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }


        private void Start_pause_pbx_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "A":
                    {
                        model.MainTank.NextDirectX = -1;
                        model.MainTank.NextDirectY = 0;
                    } break;
                case "D":
                    {
                        model.MainTank.NextDirectX = 1;
                        model.MainTank.NextDirectY = 0;
                    } break;
                case "W":
                    {
                        model.MainTank.NextDirectX = 0;
                        model.MainTank.NextDirectY = -1;
                    } break;
                case "S":
                    {
                        model.MainTank.NextDirectX = 0;
                        model.MainTank.NextDirectY = 1;
                    } break;
                case "E":
                    {
                        SetBulletStartPoint();
                    } break;
            }
        }

        private void SetBulletStartPoint()
        {
            if (model.MainTank.Direct_x == 1)
            {
                model.Bullet.X = model.MainTank.X + 20;
                model.Bullet.Y = model.MainTank.Y + 8;
            }
            if (model.MainTank.Direct_x == -1)
            {
                model.Bullet.X = model.MainTank.X - 10;
                model.Bullet.Y = model.MainTank.Y + 8;
            }
            if (model.MainTank.Direct_y == 1)
            {
                model.Bullet.X = model.MainTank.X + 8;
                model.Bullet.Y = model.MainTank.Y + 20;
            }
            if (model.MainTank.Direct_y == -1)
            {
                model.Bullet.X = model.MainTank.X + 8;
                model.Bullet.Y = model.MainTank.Y - 10;
            }
            model.Bullet.Direct_x = model.MainTank.Direct_x;
            model.Bullet.Direct_y = model.MainTank.Direct_y;
            model.Bullet.Km = 0;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.NewGame();
            Start_stop_pbx.Image = Properties.Resources.Button_play;
            view.Refresh();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
                                 Tanks version 1.0
            For move use key 'w'-Up,'s'-Down,'a'-Left,'d'-Right
                                           Fire - 'e'", "Tanks", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                 MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void SoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSound = !isSound;
            if (isSound)
            {
                soundToolStripMenuItem.Image = global::Tank.Properties.Resources.Sound_On;
            }
            else
            {
                soundToolStripMenuItem.Image = global::Tank.Properties.Resources.SoundOff;

            }
        }

        void ChangerStatusStripLbl()
        {
            Invoke(new Invoker(SetValueToStrLbl));
        }

        private void SetValueToStrLbl()
        {
            GameStatus_lbl_ststrp.Text = model.gameStatus.ToString();
            if (isSound)
            {
                if (model.gameStatus == GameStatus.playing)
                    SP.PlayLooping();
                else
                    SP.Stop();
            }
        }


        View view;
        Model model;
        Thread modelPlay;
        bool isSound;
        SoundPlayer SP;
    }
}
