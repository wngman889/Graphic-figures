using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_dom_2
{
    public class Rectangle:Shape
    {
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
                return Width * Height;
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
                graphics.FillRectangle(brush, Location.X, Location.Y, Height, Width);

            using (var pen = new Pen(colorBorder))
                graphics.DrawRectangle(pen, Location.X, Location.Y, Height, Width);
        }
        public override bool InShape(Point point)
        {
            //check if the mouse is in shape
            return Location.X <= point.X && point.X <= Location.X + Width &&
                Location.Y <= point.Y && point.Y <= Location.Y + Height;
        }
        public override bool Crossed(Shape rectangle)
        {
            return this.Location.X <= rectangle.Location.X + rectangle.Width &&
                rectangle.Location.X <= this.Location.X + this.Width &&
                this.Location.Y <= rectangle.Location.Y + rectangle.Height &&
                rectangle.Location.Y <= this.Location.Y + this.Height;
        }
    }
}
