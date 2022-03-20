using Palette.Lib.Models;

namespace Palette.Lib.Mappers
{
    public static class CmykMapper
    {
        public static RgbColor ToRgb(this CmykColor cmykColor)
        {
            if (cmykColor is null)
            {
                return null;
            }

            var c = cmykColor.Cyan / 100.0;
            var m = cmykColor.Magenta / 100.0;
            var y = cmykColor.Yellow / 100.0;
            var keyInv = 1 - cmykColor.Key / 100.0;

            return new RgbColor()
            {
                Red = (byte) (255 * (1 - c) * keyInv),
                Green = (byte) (255 * (1 - m) * keyInv),
                Blue = (byte) (255 * (1 - y) * keyInv)
            };
        }

        public static HsvColor ToHsv(this CmykColor cmykColor)
        {
            if (cmykColor is null)
            {
                return null;
            }

            return cmykColor
                .ToRgb()
                .ToHsv();
        }
    }
}
