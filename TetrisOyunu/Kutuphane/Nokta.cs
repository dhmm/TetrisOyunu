using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisOyunu.Kutuphane
{
    public class Nokta
    {
        public int X { set; get; }
        public int Y { set; get; }

        public Nokta (int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        

    }
}
