using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_LAB3.Models.LowpassSmoothingFilters
{
    static class ColorExtensionMethods
    {
        public static byte[,] GetRBounds(this Color[,] bounds)
        {
            byte[,] rBounds = new byte[bounds.GetLength(0), bounds.GetLength(1)];

            for (int i = 0; i < bounds.GetLength(0); i++)
            {
                for (int j = 0; j < bounds.GetLength(1); j++)
                {
                    rBounds[i, j] = bounds[i, j].R;
                }
            }

            return rBounds;
        }

        public static byte[,] GetGBounds(this Color[,] bounds)
        {
            byte[,] rBounds = new byte[bounds.GetLength(0), bounds.GetLength(1)];

            for (int i = 0; i < bounds.GetLength(0); i++)
            {
                for (int j = 0; j < bounds.GetLength(1); j++)
                {
                    rBounds[i, j] = bounds[i, j].G;
                }
            }

            return rBounds;
        }

        public static byte[,] GetBBounds(this Color[,] bounds)
        {
            byte[,] rBounds = new byte[bounds.GetLength(0), bounds.GetLength(1)];

            for (int i = 0; i < bounds.GetLength(0); i++)
            {
                for (int j = 0; j < bounds.GetLength(1); j++)
                {
                    rBounds[i, j] = bounds[i, j].B;
                }
            }

            return rBounds;
        }
    }
}
