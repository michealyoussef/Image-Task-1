using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class matrix
    {

        public Bitmap NearestNeighborScale(Bitmap bmp, int newXSize, int newYSize)
        {

            Bitmap newBMP = new Bitmap(newXSize, newYSize);
            int w1 = bmp.Width;
            int h1 = bmp.Height;

            // EDIT: added +1 to account for an early rounding problem
            int x_ratio = (int)((w1 << 16) / newXSize) + 1;
            int y_ratio = (int)((h1 << 16) / newYSize) + 1;

            int x2, y2;
            for (int i = 0; i < newYSize; i++)
            {
                for (int j = 0; j < newXSize; j++)
                {
                    //Get the source position of the pixel
                    x2 = ((j * x_ratio) >> 16);
                    y2 = ((i * y_ratio) >> 16);
                    newBMP.SetPixel(j, i, bmp.GetPixel(x2, y2));
                }
            }
            return newBMP;
        }
        public Bitmap RotatingRigth (Bitmap bmp, int XSize, int YSize)
        {
            Bitmap temp = new Bitmap(YSize, XSize);
            for (int i = 0; i < YSize; i++)
            {
                for (int j = 0; j < XSize; j++)
                {
                    //Get the source position of the pixel
                    temp.SetPixel(i,j ,bmp.GetPixel(j, i));
                }
            }
            return temp;
        }
        //public Bitmap RotatingLeft(Bitmap bmp, int XSize, int YSize)
        //{
        //    Bitmap temp = new Bitmap(YSize, XSize)
        //    for (int i = 0; i < YSize; i++)
        //    {
        //        for (int j = 0; j < XSize; j++)
        //        {
                   
        //            temp.SetPixel(j, i, bmp.GetPixel(j, i));
        //        }
        //    }
        //    return temp;
        //}

    }
}
