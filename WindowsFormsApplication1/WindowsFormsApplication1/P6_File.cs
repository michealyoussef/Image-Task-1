using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class P6_File
    {
        public Bitmap ImageBitmap;


        public P6_File(ref FileStream FS, int ImageWidth, int ImageHight)
        {
            ImageBitmap = new Bitmap(ImageWidth, ImageHight);
            Color[] colors = new Color[ImageWidth * ImageHight];
            int k = 0, X = 0, Y = 0, Z = 0;
            int length = ImageWidth * ImageHight;
            for (int i = 0; i < length; i += 3)
            {
                if (k >= length / 3)
                    break;
                X = FS.ReadByte();
                Y = FS.ReadByte();
                Z = FS.ReadByte();
                colors[k++] = Color.FromArgb(X, Y, Z);
            }
            int k1 = 0;
            for (int i = 0; i < ImageHight; i++)
                for (int j = 0; j < ImageWidth; j++)
                {
                    ImageBitmap.SetPixel(j, i, colors[k1++]);
                }

            FS.Close();

        }
        public void saving()
        {

        }
    }
}
