using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class BulletImg
    {
        Image up = Properties.Resources.Bullet_Up;

        public Image Up
        {
            get { return up; }
        }
        Image down = Properties.Resources.Bullet_Down;

        public Image Down
        {
            get { return down; }
        }
        Image right = Properties.Resources.Bullet_Right;

        public Image Right
        {
            get { return right; }
        }
        Image left = Properties.Resources.Bullet_Left;

        public Image Left
        {
            get { return left; }
        }

    }
}
