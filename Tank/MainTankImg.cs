using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class MainTankImg
    {
        Image[] up = new Image[] { 
            Properties.Resources.Main_Tank_up1,
            Properties.Resources.Main_Tank_up2,
            Properties.Resources.Main_Tank_up3};
        Image[] down = new Image[] {
            Properties.Resources.Main_Tank_down1,
            Properties.Resources.Main_Tank_down2,
            Properties.Resources.Main_Tank_down3};
        Image[] right = new Image[] { 
            Properties.Resources.Main_Tank_right1,
            Properties.Resources.Main_Tank_right2,
            Properties.Resources.Main_Tank_right3};
        Image[] left = new Image[] {
            Properties.Resources.Main_Tank_left1,
            Properties.Resources.Main_Tank_left2,
            Properties.Resources.Main_Tank_left3 };


        public Image[] Up
        {
            get { return up; }
        }

        public Image[] Down
        {
            get { return down; }
        }
        public Image[] Right
        {
            get { return right; }
        }
        public Image[] Left
        {
            get { return left; }
        }
    }
}
