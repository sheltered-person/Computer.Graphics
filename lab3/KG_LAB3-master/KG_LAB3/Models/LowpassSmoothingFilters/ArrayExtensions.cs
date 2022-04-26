using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG_LAB3.Models.LowpassSmoothingFilters
{
    static class ArrayExtensions
    {
        public static int GetSum(this int[,] array)
        {
            int sum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
            }

            return sum;
        }
    }
}
