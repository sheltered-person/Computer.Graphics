using KG_LAB3.Models.LowpassSmoothingFilters;
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using KG_LAB3.Models.TraseholdSelectors;

namespace KG_LAB3
{
    public partial class Form1 : Form
    {
        Bitmap currentImage;
        string imagePath;

        public Form1()
        {
            InitializeComponent();

            HAFUpDown.SelectedIndex = 0;
            GaussUpDown.SelectedIndex = 0;
            AdaptiveTUpDown.SelectedIndex = 0;
            defaultPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            resultPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opf = new OpenFileDialog())
            {
                if (opf.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                currentImage = new Bitmap(opf.FileName);
                imagePath = opf.FileName;
                defaultPictureBox.ImageLocation = opf.FileName;
                resultPictureBox.Image = null;
            }
        }

        private void HAF_Click(object sender, EventArgs e)
        {
            resultPictureBox.Image = HomogeneousAveragingFilter.ProcessImage(
                currentImage,
                GenerateHomoWeights(Int32.Parse(HAFUpDown.Items[HAFUpDown.SelectedIndex].ToString())));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultPictureBox.Image = HomogeneousAveragingFilter.ProcessImage(
                currentImage,
                GenerateGaussWeights(Int32.Parse(GaussUpDown.Items[GaussUpDown.SelectedIndex].ToString())));
        }

        private int[,] GenerateGaussWeights(int b)
        {
            return new int[,]
            {
                { 1,   b,   1 },
                { b, b * b, b },
                { 1,   b,   1 }
            };
        }

        private int[,] GenerateHomoWeights(int a)
        {
            return new int[,]
            {
                { 1, 1, 1 },
                { 1, a, 1 },
                { 1, 1, 1 }
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> imageGray = new Image<Bgr, byte>(imagePath).Convert<Gray, byte>();
            Image<Gray, byte> imageBinarize = new Image<Gray, byte>(imageGray.Width, imageGray.Height, new Gray(0));

            CvInvoke.AdaptiveThreshold(
                imageGray,
                imageBinarize,
                255,
                Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC,
                Emgu.CV.CvEnum.ThresholdType.Binary,
                Int32.Parse(AdaptiveTUpDown.Items[AdaptiveTUpDown.SelectedIndex].ToString()),
                0.0);

            resultPictureBox.Image = imageBinarize.Bitmap;

            imageGray.Dispose();
            imageBinarize.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> imageGray = new Image<Bgr, byte>(imagePath).Convert<Gray, byte>();
            Image<Gray, byte> imageBinarize = new Image<Gray, byte>(imageGray.Width, imageGray.Height, new Gray(0));

            CvInvoke.Threshold(
                imageGray,
                imageBinarize,
                50,
                255,
                Emgu.CV.CvEnum.ThresholdType.Otsu);

            resultPictureBox.Image = imageBinarize.Bitmap;

            imageGray.Dispose();
            imageBinarize.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> imageGray = new Image<Bgr, byte>(imagePath).Convert<Gray, byte>();
            Image<Gray, byte> imageBinarize = new Image<Gray, byte>(imageGray.Width, imageGray.Height, new Gray(0));

            CvInvoke.Threshold(
                imageGray,
                imageBinarize,
                currentImage.GetTraseholdByHistogram(50, 0.1),
                255,
                Emgu.CV.CvEnum.ThresholdType.Binary);

            resultPictureBox.Image = imageBinarize.Bitmap;

            imageGray.Dispose();
            imageBinarize.Dispose();
        }

        private void defaultPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
