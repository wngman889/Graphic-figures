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
    public partial class FormTriangle : Form
    {
        private Triangle triangle;
        public Triangle Triangle
        {
            get
            {
                return triangle;
            }
            set
            {
                triangle = value;
                textBox1.Text = triangle.Width.ToString();
                textBox2.Text = triangle.Height.ToString();
                textBoxSurface.Text = triangle.Surface.ToString();
                buttonColour.BackColor = triangle.Colour;
            }
        }
        public FormTriangle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangle.Width = int.Parse(textBox1.Text);
            Triangle.Height = int.Parse(textBox2.Text);
            Triangle.Surface = int.Parse(textBoxSurface.Text);
            Triangle.Colour = buttonColour.BackColor;
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
