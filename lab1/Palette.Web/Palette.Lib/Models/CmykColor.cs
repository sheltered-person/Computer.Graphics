using System.ComponentModel.DataAnnotations;

namespace Palette.Lib.Models
{
    public class CmykColor
    {
        private byte _cyan;
        private byte _magenta;
        private byte _yellow;
        private byte _key;

        [Range(0, 100)]
        public byte Cyan 
        {
            get => _cyan;
            set
            {
                if (value < 0)
                {
                    _cyan = 0;
                }
                else if (value > 100)
                {
                    _cyan = 100;
                }
                else
                {
                    _cyan = value;
                }
            }
        }

        [Range(0, 100)]
        public byte Magenta 
        {
            get => _magenta;
            set
            {
                if (value < 0)
                {
                    _magenta = 0;
                }
                else if (value > 100)
                {
                    _magenta = 100;
                }
                else
                {
                    _magenta = value;
                }
            }
        }

        [Range(0, 100)]
        public byte Yellow 
        {
            get => _yellow;
            set
            {
                if (value < 0)
                {
                    _yellow = 0;
                }
                else if (value > 100)
                {
                    _yellow = 100;
                }
                else
                {
                    _yellow = value;
                }
            }
        }

        [Range(0, 100)]
        public byte Key 
        {
            get => _key;
            set
            {
                if (value < 0)
                {
                    _key = 0;
                }
                else if (value > 100)
                {
                    _key = 100;
                }
                else
                {
                    _key = value;
                }
            }
        }
    }
}
