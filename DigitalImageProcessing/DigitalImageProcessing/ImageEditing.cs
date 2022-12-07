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

        private void loadImage1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded1 = new Bitmap(openFileDialog1.FileName);
        }

        private void loadImage2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            loaded2= new Bitmap(openFileDialog2.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
