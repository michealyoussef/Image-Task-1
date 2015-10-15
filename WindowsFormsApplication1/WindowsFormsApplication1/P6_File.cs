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
            int X = 0, Y = 0, Z = 0;
            for (int i = 0; i < ImageHight; i++)
                for (int j = 0; j < ImageWidth; j++)
                {                   
                       X = FS.ReadByte();
                        Y = FS.ReadByte();  
                        Z = FS.ReadByte();
                    if (Z==-1||X==-1||Y==-1)
                        break;
                    ImageBitmap.SetPixel(j, i, Color.FromArgb(X, Y, Z));
                }
            FS.Close();
        }
        public void saving()
        {

        }
    }
}
