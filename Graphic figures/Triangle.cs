using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_dom_2
{
    public class Triangle : Shape
    {
        Point[] points = new Point[3];
        public override int Area
        {
            get
            {
                return Width * Height;
            }
        }
        public override int Surface
        {
            get
            {
                return (Width * Height) / 2;
            }
            set { }
        }
        public override void Paint(Graphics graphics)
        {
            points[0] = new Point() { X = Location.X, Y = Location.Y + Height };
            points[1] = new Point() { X = Location.X + (Width / 2), Y = Location.Y };
            points[2] = new Point() { X = Location.X + Width, Y = Location.Y + Height };

            var colourBorder = Selected
               ? Color.Red
               : Colour;
            var colourFill = Color.FromArgb(100, Colour);
            using (var brush = new SolidBrush(colourFill))
                graphics.FillPolygon(brush, points);

            using (var pen = new Pen(colourBorder))
                graphics.DrawPolygon(pen, points);
        }
        public override bool InShape(Point point)
        {
            return Location.X <= point.X && point.X <= Location.X + Width &&
                Location.Y <= point.Y && point.Y <= Location.Y + Height;
        }
        public override bool Crossed(Shape triangle)
        {
            return this.Location.X <= triangle.Location.X + triangle.Width &&
                triangle.Location.X <= this.Location.X + this.Width &&
                this.Location.Y <= triangle.Location.Y + triangle.Height &&
                triangle.Location.Y <= this.Location.Y + this.Height;
        }
    }
}
