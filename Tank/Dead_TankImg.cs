using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    class Dead_TankImg
    {
        Image[] dead = new Image[] { 
            Properties.Resources.Dead_Tank1,
            Properties.Resources.Dead_Tank2,
            Properties.Resources.Dead_Tank3};

        public Image[] Dead
        {
            get { return dead; }
        }
        

       
    }
}
