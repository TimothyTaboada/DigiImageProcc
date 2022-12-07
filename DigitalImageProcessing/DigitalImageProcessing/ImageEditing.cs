using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalImageProcessing
{
    public partial class ImageEditing : Form
    {
        Bitmap loaded1, loaded2, processed;
        public ImageEditing()
        {
            InitializeComponent();
        }

        private void setImage1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded1 = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded1;
        }

        private void setImage2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            loaded2 = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = loaded2;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = loaded1;
            pictureBox3.Image = processed;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded1.Width, loaded1.Height);

            for(int x = 0; x < loaded1.Width; x++)
            {
                for(int y = 0; y < loaded1.Height; y++)
                {
                    Color pixel = loaded1.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    Color greyscale = Color.FromArgb(grey, grey, grey);
                    processed.SetPixel(x, y, greyscale);
                }
            }
            pictureBox3.Image = processed;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded1.Width, loaded1.Height);

            for (int x = 0; x < loaded1.Width; x++)
            {
                for (int y = 0; y < loaded1.Height; y++)
                {
                    Color pixel = loaded1.GetPixel(x, y);
                    Color seija = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    processed.SetPixel(x, y, seija);
                }
            }
            pictureBox3.Image = processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
