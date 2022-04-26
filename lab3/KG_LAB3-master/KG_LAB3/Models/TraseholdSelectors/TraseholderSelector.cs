using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_LAB3.Models.TraseholdSelectors
{
    static class TraseholderSelector
    {
        public static double GetTraseholdByHistogram(
            this Bitmap image,
            double startTrasehold,
            double delta)
        {
            double currentTrasehold = startTrasehold;

            ConcurrentBag<double> G1 = new ConcurrentBag<double>();
            ConcurrentBag<double> G2 = new ConcurrentBag<double>();

            List<Task> tasks = new List<Task>();
            List<Bitmap> imageRectangles = new List<Bitmap>();

            int partSize = image.Width % 8 == 0 ? image.Width / 8 : image.Width / 8 + 1;

            for (int i = 0; i < 8; i++)
            {
                imageRectangles.Add(GetImageRectangle(image, i * partSize, (image.Width % 8 != 0 && i == 7) ? image.Width - (7 * partSize) : partSize));
            }

            while(true)
            {

                for (int i = 0; i < 8; i++)
                {
                    int m = i;
                    tasks.Add(new Task(() =>
                    {
                        int startIndex = m * partSize;
                        ParallelImage(currentTrasehold, G1, G2, imageRectangles[m]);
                    }));
                }

                foreach (var task in tasks)
                {
                    task.Start();
                }

                Task.WaitAll(tasks.ToArray());

                var tempTrasehold = (G1.Average() + G2.Average()) / 2.0;

                if (Math.Abs(currentTrasehold - tempTrasehold) < delta)
                {
                    return tempTrasehold;
                }

                currentTrasehold = tempTrasehold;
                G1 = new ConcurrentBag<double>();
                G2 = new ConcurrentBag<double>();
                tasks = new List<Task>();
            }
        }

        private static void ParallelImage(
            double currentTrasehold,
            ConcurrentBag<double> G1,
            ConcurrentBag<double> G2,
            Bitmap image)
        {
            Func<Color, bool> checkBrightness = c => (0.2126 * c.R + 0.7152 * c.G + 0.0722 * c.B) > currentTrasehold;
            Func<Color, double> getBrightness = c => (0.2126 * c.R + 0.7152 * c.G + 0.0722 * c.B);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    if (checkBrightness(image.GetPixel(i, j)))
                    {
                        G1.Add(getBrightness(image.GetPixel(i, j)));
                    }
                    else
                    {
                        G2.Add(getBrightness(image.GetPixel(i, j)));
                    }
                }
            }
        }

        private static Bitmap GetImageRectangle(Bitmap image, int startIndex, int size)
        {
            Bitmap result = new Bitmap(size, image.Height);

            for (int i = startIndex, k = 0; i < startIndex + size; i++, k++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    result.SetPixel(k, j, image.GetPixel(i, j));
                }
            }

            return result;
        }
    }
}
