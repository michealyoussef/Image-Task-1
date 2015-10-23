using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class NeighborhoodOperations
    {
        bufferedLockBitmap bf;
        Bitmap temp;
        public bufferedLockBitmap LinearFilter(bufferedLockBitmap input,int[,]mask,int x,int y )
        {
            temp = new Bitmap(input.Width, input.Height);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();



            bf.UnlockBits();
            return bf;
        }
    }
}
