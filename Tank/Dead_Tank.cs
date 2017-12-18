using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class Dead_Tank
    {
        Dead_TankImg deadImg = new Dead_TankImg();
        Image currentImg;

        public Image CurrentImg
        {
            get { return currentImg; }
        }
        Image[] img;
        int x, y;

        public int Y
        {
            get { return y; }
        }

            public int X
            {
          get { return x; }
        }
            public Dead_Tank(int x, int y)
            {
                this.x = x;
                this.y = y;
                img = deadImg.Dead;
                PutCurrentImage();
            }

        public void Fire()
        {
        PutCurrentImage();
        }
            int k;
            protected void PutCurrentImage()
            {
                currentImg = img[k];
                k++;
                if (k == 3)
                    k = 0;
            }


    }
}
