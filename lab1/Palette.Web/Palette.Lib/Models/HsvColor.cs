using System.ComponentModel.DataAnnotations;

namespace Palette.Lib.Models
{
    public class HsvColor
    {
        private uint _hue;
        private byte _saturation;
        private byte _value;

        [Range(0, 360)]
        public uint Hue 
        {
            get => _hue;
            set
            {
                if (value < 0)
                {
                    _hue = 0;
                }
                else if (value > 360)
                {
                    _hue = value % 360;
                }
                else
                {
                    _hue = value;
                }
            }
        }

        [Range(0, 100)]
        public byte Saturation 
        {
            get => _saturation;
            set
            {
                if (value < 0)
                {
                    _saturation = 0;
                }
                else if (value > 100)
                {
                    _saturation = 100;
                }
                else
                {
                    _saturation = value;
                }
            }
        }

        [Range(0, 100)]
        public byte Value 
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    _value = 0;
                }
                else if (value > 100)
                {
                    _value = 100;
                }
                else
                {
                    _value = value;
                }
            }
        }
    }
}
