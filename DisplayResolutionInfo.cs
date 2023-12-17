using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static LRes.PublicStructures;

namespace LRes
{
    internal class DisplayResolutionInfo
    {
        private int miWidth;
        private int miHeight;
        private int miFrequency;

        public DisplayResolutionInfo(int iWidth, int iHeight, int iFrequency) { 
            this.miWidth = iWidth;
            this.miHeight = iHeight;
            this.miFrequency = iFrequency;
        }

        public int getWidth()
        {
            return this.miWidth;
        }

        public int getHeight()
        {
            return this.miHeight;
        }

        public int getFrequency()
        {
            return this.miFrequency;
        }

        public string toString()
        {
            return string.Format("Width:{0} Height:{1} Frequency:{2}", this.miWidth, this.miHeight, this.miFrequency);
        }
    }
}
