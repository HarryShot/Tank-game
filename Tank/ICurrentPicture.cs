using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tank
{
    interface ICurrentPicture
    {
        Image CurrentImg
        {
            get;
        }
    }
}
