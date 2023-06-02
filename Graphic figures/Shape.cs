using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_dom_2
{
    public abstract class Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Radius { get; set; }
        public Point Location { get; set; }
        public Point CoordinatesStart { get; set; }
        public Color Colour { get; set; }
        public bool Selected { get; set; }
        public abstract int Area { get; }
        public abstract int Surface { get; set; }
        public abstract void Paint(Graphics graphics);
        public abstract bool InShape(Point point);
        public abstract bool Crossed(Shape shapes);
    }
}
