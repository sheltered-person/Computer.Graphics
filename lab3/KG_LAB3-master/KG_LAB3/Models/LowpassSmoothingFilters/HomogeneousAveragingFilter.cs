using System;
using System.Drawing;

namespace KG_LAB3.Models.LowpassSmoothingFilters
{
    static class HomogeneousAveragingFilter
    {
        static Bitmap CurrentImage { get; set; }

        static int[,] Weights { get; set; }

        static int WeigthSum { get; set; }

        public static Bitmap ProcessImage(Bitmap image, int[,] weights)
        {
            if (image.Size.Width < 3 || image.Height < 3)
            {
                throw new BadImageFormatException("Image size is too small");
            }

            CurrentImage = new Bitmap(image);
            Weights = weights;
            WeigthSum = weights.GetSum();
            Bitmap filteredImage = new Bitmap(image.Width, image.Height);

            for (int i = 1; i < image.Width - 1; i++)
            {
                for (int j = 1; j < image.Height - 1; j++)
                {
                    Color filteredPixel = ProcessPixel(i, j);
                    filteredImage.SetPixel(i, j, filteredPixel);
                }
            }

            return filteredImage;
        }

        private static Color ProcessPixel(int x, int y)
        {
            Color[,] pixelBounds = GetBoundary(CurrentImage, x, y);

            int R = ProcessColor(pixelBounds.GetRBounds());
            int G = ProcessColor(pixelBounds.GetGBounds());
            int B = ProcessColor(pixelBounds.GetBBounds());

            return Color.FromArgb(R, G, B);
        }


        private static int ProcessColor(byte[,] bounds)
        {
            int sum = 0;

            for (int i = 0; i < bounds.GetLength(0); i++)
            {
                for (int j = 0; j < bounds.GetLength(1); j++)
                {
                    sum += bounds[i, j] * Weights[i, j];
                }
            }

            return sum / WeigthSum;
        }

        private static Color[,] GetBoundary(Bitmap image, int x, int y)
        {
            Color[,] result = new Color[3, 3];

            for (int i =  x - 1, k = 0; i < x + 2; i++, k++)
            {
                for (int j = y - 1, m = 0; j < y + 2; j++, m++)
                {
                    result[k, m] = image.GetPixel(i, j);
                }
            }

            return result;
        }
    }
}
