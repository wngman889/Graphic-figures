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
    public partial class FormCircle : Form
    {
        private Circle circle;
        public Circle Circle
        {
            get
            {
                return circle;
            }
            set
            {
                circle = value;
                textBox1.Text = circle.Radius.ToString();
                textBoxSurface.Text = circle.Surface.ToString();
                buttonColour.BackColor = circle.Colour;
            }
        }
        public FormCircle()
        {
            InitializeComponent();
        }

        private void buttonColour_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonColour.BackColor = cd.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Circle.Radius = int.Parse(textBox1.Text);
            Circle.Surface = int.Parse(textBoxSurface.Text);
            Circle.Colour = buttonColour.BackColor;
            DialogResult = DialogResult.OK;
        }
    }
}
