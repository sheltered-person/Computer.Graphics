using System.ComponentModel.DataAnnotations;

namespace Palette.Lib.Models
{
    public class RgbColor
    {
        [Range(0, 255)]
        public byte Red { get; set; }

        [Range(0, 255)]
        public byte Green { get; set; }
        
        [Range(0, 255)]
        public byte Blue { get; set; }
    }
}
