using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            saveFileDialog1.Filter = "Do I look like I know what a jpeg is?|*.jpeg;";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
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
            Bitmap temp = new Bitmap(loaded1.Width, loaded1.Height);
            Color pixel;
            processed = new Bitmap(256, 240);

            // Greyscale
            for (int x = 0; x < loaded1.Width; x++)
            {
                for (int y = 0; y < loaded1.Height; y++)
                {
                    pixel = loaded1.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    Color greyscale = Color.FromArgb(grey, grey, grey);
                    temp.SetPixel(x, y, greyscale);
                }
            }

            // Histogram Array
            int[] histogram = new int[256];
            for (int x = 0; x < loaded1.Width; x++)
            {
                for (int y = 0; y < loaded1.Height; y++)
                {
                    pixel = loaded1.GetPixel(x, y);
                    histogram[pixel.R]++;
                }
            }

            // BG Colour
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 240; y++)
                {
                    processed.SetPixel(x, y, Color.White);
                }
            }

            // Plot Points
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histogram[x] / 5, processed.Height - 1); y++)
                {
                    processed.SetPixel(x, (processed.Height - 1) - y, Color.Black);
                }
            }

            pictureBox3.Image = processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded1.Width, loaded1.Height);

            for (int x = 0; x < loaded1.Width; x++)
            {
                for (int y = 0; y < loaded1.Height; y++)
                {
                    Color pixel = loaded1.GetPixel(x, y);
                    int sephiRed = (int)((0.393 * pixel.R) + (0.769 * pixel.G) + (0.189 * pixel.B));
                    int sephiBlue = (int)((0.349 * pixel.R) + (0.686 * pixel.G) + (0.168 * pixel.B));
                    int sephiGreen = (int)((0.272 * pixel.R) + (0.534 * pixel.G) + (0.131 * pixel.B));

                    if(sephiRed > 255)
                    {
                        sephiRed = 255;
                    }
                    if(sephiBlue > 255)
                    {
                        sephiBlue = 255;
                    }
                    if(sephiGreen > 255)
                    {
                        sephiGreen = 255;
                    }

                    Color greyscale = Color.FromArgb(sephiRed, sephiBlue, sephiGreen);
                    processed.SetPixel(x, y, greyscale);
                }
            }

            pictureBox3.Image = processed;
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded1.Width, loaded1.Height);
            Color greenScreen = Color.FromArgb(0, 0, 255);
            int greyGreen = (greenScreen.R + greenScreen.G + greenScreen.B) / 3;
            int threshold = 5;

            for (int x = 0; x < loaded1.Width; x++)
            {
                for (int y = 0; y < loaded1.Height; y++)
                {
                    Color pixel = loaded2.GetPixel(x, y);
                    Color backPixel = loaded1.GetPixel(x, y);
                    int grey = (backPixel.R + backPixel.G + backPixel.B) / 3;
                    int subtractVal = Math.Abs(grey - greyGreen);
                    if(subtractVal > threshold)
                        processed.SetPixel(x, y, backPixel);
                    else
                        processed.SetPixel(x, y, pixel);
                }
            }

            pictureBox3.Image = processed;
        }
    }
}
