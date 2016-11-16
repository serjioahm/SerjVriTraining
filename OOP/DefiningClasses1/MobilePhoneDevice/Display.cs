using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class Display
    {
        private int height;
        private int width;
        private long numberOfColors;

        //Problem 2. -> constructor
        public Display(int height, int width, long numberOfColors)
        {
            //this.Height = height;
            //this.Width = width;
            //this.NumberOfColors = numberOfColors;
        }

        public Display()
        {
        }

        //Properties
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be > 0");
                }

                this.height = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be > 0");
                }

                this.width = value;
            }
        }

        public long NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of colors must be > 0");
                }

                this.numberOfColors = value;
            }
        }

    }
}
