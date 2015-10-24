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

        public bufferedLockBitmap LinearFilter(bufferedLockBitmap input,double [,]mask,int w,int h,int x,int y ,String word)
        {
            
            int R=0, G=0, B=0;

            bf = new bufferedLockBitmap(input.source);
            bf.LockBits();
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    for(int maskh = 0;maskh <h;maskh++)
                    {
                        for(int maskw=0;maskw<w;maskw++)
                        {


                        }

                    }
 
                     bf.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }



            bf.UnlockBits();
            return bf;
        }
    }
}
