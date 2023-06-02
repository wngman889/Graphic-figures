using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOp_dom_2
{
    public partial class FormRectangle : Form
    {
        private Rectangle rectangle;
        public Rectangle Rectangle 
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
                textBox1.Text = rectangle.Width.ToString();
                textBox2.Text = rectangle.Height.ToString();
                textBoxSurface.Text = rectangle.Surface.ToString();
                buttonColour.BackColor = rectangle.Colour;
            } 
        }
        public FormRectangle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle.Width = int.Parse(textBox1.Text);
            Rectangle.Height = int.Parse(textBox2.Text);
            Rectangle.Surface = int.Parse(textBoxSurface.Text);
            Rectangle.Colour = buttonColour.BackColor;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColour_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonColour.BackColor = cd.Color;
            }
        }
    }
}
