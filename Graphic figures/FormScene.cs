using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOp_dom_2
{
    public partial class FormScene : Form
    {
        private List<Shape> shapes = new List<Shape>();
        //variable by which I know if mousedown was active
        private Rectangle frameRectangle;
        private Circle frameCircle;
        private Triangle frameTriangle;
        //initial mouse click point
        private Point mouseDownLocation;
        private Point mouseDownLocationC;
        private Point mouseDownLocationT;
        private int index;
        protected bool indexRec = false;
        protected bool indexCir = false;
        protected bool indexTrian = false;
        //private Point pointMoving;
        private bool shapeMoving = false;
        public FormScene()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }
        private int CalculateArea()
        {
            var area = 0;
            for (int i = 0; i < shapes.Count(); i++)
                area += shapes[i].Area;
            return area;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Redraws the figures
            foreach (var shape in shapes)
                shape.Paint(e.Graphics);
            if (frameRectangle != null)
                frameRectangle.Paint(e.Graphics);
            if (frameCircle != null)
                frameCircle.Paint(e.Graphics);
            if (frameTriangle != null)
                frameTriangle.Paint(e.Graphics);
            var centerPoint = new Point
            {
                X = Width / 2,
                Y = Height / 2
            };
            using(var pen=new Pen(Color.Gray))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                e.Graphics.DrawLine(pen, centerPoint.X, 0, centerPoint.X, Height);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                pen.Width = 2;
                e.Graphics.DrawEllipse(pen, centerPoint.X - 2, centerPoint.Y - 2, 4, 4);
            }
        }

        private void FormScene_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = e.Location;
            frameRectangle = new Rectangle
            {
                Colour = Color.Gray
            };
            mouseDownLocationC = e.Location;
            frameCircle = new Circle
            {
                Colour = Color.Gray
            };
            mouseDownLocationT = e.Location;
            frameTriangle = new Triangle
            {
                Colour = Color.Gray
            };
            //for (int i = 0; i < shapes.Count(); i++)
            //    shapes[i].Selected = false;

            //else 
            //if (e.Button == MouseButtons.Left)
            // s = new Circle()
            // {
            //    Location = e.Location,
            //    Radius=100
            // };
            //for (int i = shapes.Count() - 1; i >= 0; i--)
            //{
            //    if (shapes[i].InShape(e.Location))
            //    {
            //        shapes[i].Selected = true;
            //        break;
            //    }
            //}
            foreach (var selectedShape in shapes)
            {
                //Selects the shape if it is clicked on
                selectedShape.Selected = selectedShape.InShape(e.Location);
                shapeMoving = true;
            }

            Invalidate();
        }
        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            if (index == 1)
            {
                if (frameRectangle == null)
                    return;
                frameRectangle.Location = new Point
                {
                    X = Math.Min(mouseDownLocation.X, e.Location.X),
                    Y = Math.Min(mouseDownLocation.Y, e.Location.Y)
                };
                frameRectangle.Width = Math.Abs(mouseDownLocation.X - e.Location.X);
                frameRectangle.Height = Math.Abs(mouseDownLocation.Y - e.Location.Y);
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < shapes.Count(); i++)
                        shapes[i].Selected = shapes[i].Crossed(frameRectangle);
                }
                indexRec = true;
                //Invalidate();
            }
            if (index == 2)
            {
                if (frameCircle == null)
                    return;
                frameCircle.Location = new Point
                {
                    X = Math.Min(mouseDownLocation.X, e.Location.X),
                    Y = Math.Min(mouseDownLocation.Y, e.Location.Y)
                };
                frameCircle.Radius = Math.Abs(mouseDownLocation.X - e.Location.X);
                frameCircle.Radius = Math.Abs(mouseDownLocation.Y - e.Location.Y);
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < shapes.Count(); i++)
                        shapes[i].Selected = shapes[i].Crossed(frameCircle);
                }
                indexCir = true;
                //Invalidate();
            }
            if (index == 3)
            {
                if (frameTriangle == null)
                    return;
                frameTriangle.Location = new Point
                {
                    X = Math.Min(mouseDownLocationT.X, e.Location.X),
                    Y = Math.Min(mouseDownLocationT.Y, e.Location.Y)
                };
                frameTriangle.Width = Math.Abs(mouseDownLocationT.X - e.Location.X);
                frameTriangle.Height = Math.Abs(mouseDownLocationT.Y - e.Location.Y);
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < shapes.Count(); i++)
                        shapes[i].Selected = shapes[i].Crossed(frameTriangle);
                }
                indexTrian = true;
                //Invalidate();
            }
            if (index == 4)
            {
                if (shapeMoving == true)
                {
                    foreach (var selectedShape in shapes)
                        if (selectedShape.Selected)
                        {
                            selectedShape.Location = e.Location;
                            selectedShape.CoordinatesStart = e.Location;
                        }
                }
            }
            Invalidate();
        }

        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {
            if (frameRectangle == null)
                return;
            if (frameCircle == null)
                return;
            if (frameTriangle == null)
                return;
            if (e.Button == MouseButtons.Right) 
            {
                var r = new Random();
                //frameRectangle.Colour = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));

                var c = new Random();
                //frameCircle.Colour = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                var t = new Random();
                //frameTriangle.Colour = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                for (int i = 0; i < shapes.Count(); i++)
                    shapes[i].Selected = false;

                shapes.Add(frameRectangle);
                shapes.Add(frameCircle);
                shapes.Add(frameTriangle);
                frameRectangle.Selected = true;
                frameCircle.Selected = true;
                frameTriangle.Selected = true;
                toolStripStatusLabelArea.Text = CalculateArea().ToString();
            }
            frameRectangle = null;
            frameCircle = null;
            frameTriangle = null;
                if (shapeMoving == true)
                    shapeMoving = false;
            Invalidate();
        }
        private void FormScene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;
            for (int i = shapes.Count() - 1; i >= 0; i--)
            {
                if (shapes[i].Selected)
                    shapes.RemoveAt(i);
            }
            toolStripStatusLabelArea.Text = CalculateArea().ToString();

            Invalidate();
        }

        private void FormScene_DoubleClick(object sender, EventArgs e)
        {
            foreach(var shape in shapes)
            {
                if (shape.Selected && indexRec == true)
                {
                    var formRectangle = new FormRectangle();
                    formRectangle.Rectangle = (Rectangle)shape;
                    formRectangle.ShowDialog();
                    indexRec = false;
                    break;
                }
                if (shape.Selected && indexCir == true)
                {
                    var formCircle = new FormCircle();
                    formCircle.Circle = (Circle)shape;
                    formCircle.ShowDialog();
                    indexCir=false;
                    break;
                }
                if (shape.Selected && indexTrian == true)
                {
                    var formTriangle = new FormTriangle();
                    formTriangle.Triangle = (Triangle)shape;
                    formTriangle.ShowDialog();
                    indexTrian = false;
                    break;
                }
                Invalidate();
            }
        }
        private void SelectShapes(IEnumerable<Shape> _shapes) 
        {
            foreach (var shape in _shapes)
            {
                shape.Selected = true;
            }
            Invalidate();
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var centerPoint = new Point
            {
                X = Width / 2,
                Y = Height / 2
            };
            var centerShapes = shapes.Where(s => s.InShape(centerPoint));
            SelectShapes(centerShapes);
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var centerX = Width / 2;
            var rightShapes = shapes
                .Where(s => s.Location.X + s.Width >= centerX)
                .ToList();
            SelectShapes(rightShapes);
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var centerX = Width / 2;
            var leftShapes = shapes.Where(s => s.Location.X <= centerX);
            SelectShapes(leftShapes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            index = 3;
        }
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    pointMoving = e.Location;
        //    base.OnMouseDown(e);
        //}
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left) //&& shapes[i].InShape(e.Location))
        //    {
        //        this.Left += e.X - pointMoving.X;
        //        this.Top += e.Y - pointMoving.Y;
        //    }
        //    base.OnMouseMove(e);
        //}

        private void buttonClear_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            //for (int i = shapes.Count - 1; i >= 0; i--)
            //    shapes.RemoveAt(i);
        }
        //private void buttonSave_Click(object sender, EventArgs e)
        //{
        //    img = (Bitmap)Image.FromFile(@"E:\kr.bmp");
        //    SaveFileDialog sf = new SaveFileDialog();
        //    sf.Filter = "JPG(*.JPG)|*.jpg";
        //    if (sf.ShowDialog() == DialogResult.OK)
        //        img.Save(sf.FileName);
        //}

        private void buttonMoving_Click(object sender, EventArgs e)
        {
            index = 4;
        }
    }
}
