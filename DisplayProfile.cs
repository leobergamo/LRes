using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static LRes.PublicStructures;

namespace LRes
{
    internal class DisplayProfile
    {
        private int Int_Width;
        private int Int_Height;
        private int Int_Frequency;
        private int Int_ColorDepth;
        private Struct_DevMode Struct_DevMode;

        public DisplayProfile(int int_width, int int_height, int int_frequency, int int_colorDepth, Struct_DevMode struct_devMod) { 
            this.Int_Width = int_width;
            this.Int_Height = int_height;
            this.Int_Frequency = int_frequency;
            this.Int_ColorDepth = int_colorDepth;
            this.Struct_DevMode = struct_devMod;
        }

        public int getWidth()
        {
            return this.Int_Width;
        }

        public int getHeight()
        {
            return this.Int_Height;
        }

        public int getFrequency()
        {
            return this.Int_Frequency;
        }

        public int getColorDepth()
        {
            return this.Int_ColorDepth;
        }

        public Struct_DevMode getStructDevMode()
        {
            return this.Struct_DevMode;
        }

        public string ToString()
        {
            return string.Format("Width:{0}     Height:{1}     Frequency:{2}     Color Depth:{3}", this.Int_Width, this.Int_Height, this.Int_Frequency, this.Int_ColorDepth);
        }

    }
}
