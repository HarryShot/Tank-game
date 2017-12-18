using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class Apple:Ipicture
    {
        AppleImg appleImg = new AppleImg();
        Image img;

        int x, y;

        public int Y
        {
            get { return y; }
        }

        public int X
        {
            get { return x; }
        }

        public Image Img
        {
            get { return img; }
        }

        public Apple(int x,int y)
        {
            img = appleImg.Img;
            this.x = x;
            this.y = y;
        }
    }
}
