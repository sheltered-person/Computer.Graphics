using Palette.Lib.Models;
using System;

namespace Palette.Lib.Mappers
{
    public static class RgbMapper
    {
        public static CmykColor ToCmyk(this RgbColor rgbColor)
        {
            if (rgbColor is null)
            {
                return null;
            }

            var r = rgbColor.Red / 255.0;
            var g = rgbColor.Green / 255.0;
            var b = rgbColor.Blue / 255.0;

            var key = Math.Min(
                Math.Min(
                    1.0 - r,
                    1.0 - g),
                1.0 - b);

            var invKey = 1.0 - key;

            return new CmykColor()
            {
                Key = (byte) (key * 100.0),
                Cyan = (byte) ((1.0 - r - key) / invKey * 100.0),
                Magenta = (byte) ((1.0 - g - key) / invKey * 100.0),
                Yellow = (byte) ((1.0 - b - key) / invKey * 100.0)
            };
        }

        public static HsvColor ToHsv(this RgbColor rgbColor)
        {
            if (rgbColor is null)
            {
                return null;
            }

            var r = rgbColor.Red / 255.0;
            var g = rgbColor.Green / 255.0;
            var b = rgbColor.Blue / 255.0;

            var cmax = Math.Max(r, Math.Max(g, b));
            var cmin = Math.Min(r, Math.Min(g, b));
            var diff = cmax - cmin;

            var h = -1.0;
            var s = -1.0;

            if (cmax == cmin)
            {
                h = 0;
            }
            else if (cmax == r)
            {
                h = (60 * ((g - b) / diff) + 360) % 360;
            }
            else if (cmax == g)
            {
                h = (60 * ((b - r) / diff) + 120) % 360;
            }
            else if (cmax == b)
            {
                h = (60 * ((r - g) / diff) + 240) % 360;
            }

            if (cmax == 0)
            {
                s = 0;
            }
            else
            {
                s = (diff / cmax) * 100;
            }

            var v = cmax * 100;

            return new HsvColor()
            {
                Hue = (uint) h,
                Saturation = (byte) s,
                Value = (byte) v
            };
        }

        public static string ToHexString(this RgbColor rgbColor)
        {
            return $"#{rgbColor.Red:X2}{rgbColor.Green:X2}{rgbColor.Blue:X2}";
        }

        public static RgbColor ToRgb(this string hex)
        {
            var hexNumber = hex.Trim('#');

            return new RgbColor()
            {
                Red = Convert.ToByte(hexNumber.Substring(0, 2), 16),
                Green = Convert.ToByte(hexNumber.Substring(2, 2), 16),
                Blue = Convert.ToByte(hexNumber.Substring(4, 2), 16)
            };
        }
    }
}
