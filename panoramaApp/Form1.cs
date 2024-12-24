using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panoramaApp
{
    public partial class Form1 : Form
    {
        private Mat[] images = new Mat[3];
        private int imageIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (imageIndex >= 3)
            {
                MessageBox.Show("You have already uploaded 3 photos", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.jpeg";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] filePaths = openFileDialog.FileNames;

                    if (filePaths.Length + imageIndex > 3)
                    {
                        MessageBox.Show("You can only upload 3 photos.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (string filePath in filePaths)
                    {
                        if (imageIndex < 3)
                        {
                            images[imageIndex] = Cv2.ImRead(filePath);
                            imageIndex++;
                        }
                    }
                }
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            if (imageIndex < 3)
            {
                MessageBox.Show("Need to upload 3 photos first.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var stitcher = Stitcher.Create())
                {
                    Mat panorama = new Mat();
                    var status = stitcher.Stitch(images, panorama);

                    if (status == Stitcher.Status.OK)
                    {
                        pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(panorama);
                    }
                    else
                    {
                        MessageBox.Show($"Error connecting the images: {status}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
