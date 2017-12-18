using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class Wall:Ipicture
    {
        WallImg wallImg = new WallImg();
        Image img;

        public Image Img
        {
            get { return img; }
        }

        public Wall()
        {
            img = wallImg.Img;
        }
    }
}
