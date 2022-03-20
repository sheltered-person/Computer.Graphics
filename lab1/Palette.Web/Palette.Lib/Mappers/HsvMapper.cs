using Palette.Lib.Models;
using System;

namespace Palette.Lib.Mappers
{
    public static class HsvMapper
    {
        public static RgbColor ToRgb(this HsvColor hsvColor)
        {
            if (hsvColor is null)
            {
                return null;
            }

            var c = hsvColor.Value * hsvColor.Saturation / 100.0;
            var x = c * (1.0 - Math.Abs((hsvColor.Hue / 60.0) % 2 - 1));
            var m = hsvColor.Value  - c;

            (var r, var g, var b) = PickRgb((byte) c, (byte) x, hsvColor.Hue);

            return new RgbColor()
            {
                Red = (byte) ((r + m) * 2.55),
                Green = (byte) ((g + m) * 2.55),
                Blue = (byte) ((b + m) * 2.55)
            };
        }

        public static CmykColor ToCmyk(this HsvColor hsvColor)
        {
            if (hsvColor is null)
            {
                return null;
            }

            return hsvColor
                .ToRgb()
                .ToCmyk();
        }

        private static (byte red, byte green, byte blue) PickRgb(byte c, byte x, uint h)
        {
            return h switch
            {
                >= 0 and < 60 => (c, x, 0),
                >= 60 and < 120 => (x, c, 0),
                >= 120 and < 180 => (0, c, x),
                >= 180 and < 240 => (0, x, c),
                >= 240 and < 300 => (x, 0, c),
                >= 300 and < 360 => (c, 0, x),
                _ => throw new ArgumentException()
            };
        }
    }
}
