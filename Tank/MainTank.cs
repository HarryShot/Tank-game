using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class MainTank: Irun, ITurn, ITransparent, ICurrentPicture
    {
        MainTankImg mainTankImg = new MainTankImg();
        Image[] img;
        Image currentImg;

        public Image CurrentImg
        {
            get { return currentImg; }
        }

        int x, y, direct_x, direct_y, nextDirectX, nextDirectY;

        public int NextDirectY
        {
            get { return nextDirectY; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    nextDirectY = value;
                else nextDirectY = 0;
            }
        }

        public int NextDirectX
        {
            get { return nextDirectX; }
            set {
                if (value == 0 || value == -1 || value == 1)
                    nextDirectX = value;
                else nextDirectX = 0;
            }
        }
        int sizeField;
        public int Direct_y
        {
            get { return direct_y; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else direct_y = 0;
            }
        }

        public int Direct_x
        {
            get { return direct_x; }
            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else direct_x = 0;
            }
        }

         public MainTank(int sizeField)
        {
            
            this.sizeField = sizeField;
              this.x= 120;
             this.y = 240;
             this.Direct_x = 0;
             this.Direct_y = -1;
             this.NextDirectX = 0;
             this.NextDirectY=-1;
            PutImg();

            PutCurrentImage();

             
           
        }
         public int Y
         {
             get { return y; }
         }

         public int X
         {
             get { return x; }
         }
         public void Run()
         {
             Transparent();
             x += direct_x;
             y += direct_y;
             if ((Math.IEEERemainder(x, 40) == 0) && (Math.IEEERemainder(y, 40) == 0))
                 Turn();
             PutCurrentImage();

         }

         int k;
         private void PutCurrentImage()
         {
             currentImg = img[k];
             k++;
             if (k == 3)
                 k = 0;
         }

         public void Turn()
         {
             Direct_x = NextDirectX;
             Direct_y = NextDirectY;
             PutImg();
         }

         public void Transparent()
         {
             if (x == -1)
                 x = sizeField - 21;
             if (x == (sizeField - 19))
                 x = 1;
             if (y == -1)
                 y = sizeField - 21;
             if (y == sizeField - 19)
                 y = 1;

         }
         void PutImg()
         {
             if (direct_x == 1)
             {
                 img = mainTankImg.Right;
             }
             if (direct_x == -1)
             {
                 img = mainTankImg.Left;
             }
             if (direct_y == 1)
             {
                 img = mainTankImg.Down;
             }
             if (direct_y == -1)
             {
                 img = mainTankImg.Up;
             }
         }

    }
}
