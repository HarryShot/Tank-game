using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tank
{
    partial class View : UserControl
    {

        Model model;
        public View(Model model)
        {
            InitializeComponent();

            this.model = model;
            
        }

        void Draw(PaintEventArgs e)
        {
            DrowDeadTank(e);
            DrowApple(e);
            DrawWall(e);
            DrawTank(e);
            DrowMainTank(e);
            DrowBullet(e);

            if (model.gameStatus != GameStatus.playing)
                return;
            Thread.Sleep(model.speedGame);
            Invalidate();
        }

        private void DrowDeadTank(PaintEventArgs e)
        {
            foreach (Dead_Tank dt in model.DeadTank)
                e.Graphics.DrawImage(dt.CurrentImg, new Point(dt.X, dt.Y));
        }

        private void DrowBullet(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.Bullet.Img,new Point(model.Bullet.X,model.Bullet.Y));
        }

        private void DrowMainTank(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.MainTank.CurrentImg, new Point(model.MainTank.X, model.MainTank.Y));
        }

        private void DrowApple(PaintEventArgs e)
        {
            for (int i = 0; i < model.Apples.Count;i++ )
                e.Graphics.DrawImage(model.Apples[i].Img, new Point(model.Apples[i].X, model.Apples[i].Y));
        }

        private void DrawTank(PaintEventArgs e)
        {
            for (int i = 0; i < model.Tanks.Count; i++)
                e.Graphics.DrawImage(model.Tanks[i].CurrentImg, new Point(model.Tanks[i].X, model.Tanks[i].Y));
           
        }


        private void DrawWall(PaintEventArgs e)
        {
            for(int y=20;y<260 ;y+=40)
                for (int x = 20; x < 260; x+=40 )
                    e.Graphics.DrawImage(model.wall.Img, new Point(x, y));
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e);
        }
    }
}
