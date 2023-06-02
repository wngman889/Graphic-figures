using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_dom_2
{
    public class Circle:Shape
    {
        public override int Area
        {
            get
            {
                return Radius * Radius;
            }
        }
        public override int Surface
        {
            get
            {
                return (int)(3.14 * Radius * Radius);
            }
            set { }
        }
        public override void Paint(Graphics graphics)
        {
            var colorBorder = Selected
               ? Color.Red
               : Colour;
            var colourFill = Color.FromArgb(100, Colour);
            using (var brush = new SolidBrush(colourFill))
                graphics.FillEllipse(brush, Location.X, Location.Y, 2 * Radius, 2 * Radius);

            using (var pen = new Pen(colorBorder))
                graphics.DrawEllipse(pen, Location.X, Location.Y, 2 * Radius, 2 * Radius);
        }
        public override bool InShape(Point point)
        {
            return Location.X <= point.X && point.X <= Location.X + Radius &&
                Location.Y <= point.Y && point.Y <= Location.Y + Radius;
        }
        public override bool Crossed(Shape circle)
        {
            return this.Location.X <= circle.Location.X + circle.Radius &&
                circle.Location.X <= this.Location.X + this.Radius &&
                this.Location.Y <= circle.Location.Y + circle.Radius &&
                circle.Location.Y <= this.Location.Y + this.Radius;
        }
    }
}
