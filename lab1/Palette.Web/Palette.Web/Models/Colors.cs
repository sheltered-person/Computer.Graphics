using Palette.Lib.Models;

namespace Palette.Web.Models
{
    public class Colors
    {
        public RgbColor RGB { get; set; } = new RgbColor();
        public CmykColor CMYK { get; set; } = new CmykColor();
        public HsvColor HSV { get; set; } = new HsvColor();
        public string Hex { get; set; }
    }
}
