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
            FS.Position = 0;
            ImageBitmap = new Bitmap(ImageWidth, ImageHight);
            int X = 0, Y = 0, Z = 0;
            for (int i = 0; i < ImageHight; i++)
                for (int j = 0; j < ImageWidth; j++)
                {
                    X = FS.ReadByte();
                    Y = FS.ReadByte();
                    Z = FS.ReadByte();
                    if (Z == -1 || X == -1 || Y == -1)
                        break;
                    ImageBitmap.SetPixel(j, i, Color.FromArgb(X, Y, Z));
                }
            FS.Close();
        }
        public int saving(Bitmap bt, String ct, String ImageType, String pt)
        {
            try
            {
                FileStream fsw = new FileStream(pt + "/saving image.ppm", FileMode.Append, FileAccess.Write);
                StreamWriter SR = new StreamWriter(fsw);
                /*
                 * read the ppm file 
                 * P3
                 * #comment
                 * width hight 
                 * max colored pixel 
                 * width * hight (R G B) pixels
                 */
                
                SR.WriteLine(ImageType.ToString());
                SR.WriteLine(ct);
                SR.WriteLine(ImageBitmap.Width + " " + ImageBitmap.Height);
                SR.WriteLine("255");
                for (int i = 0; i < bt.Height; i++)
                {
                   
                    for (int j = 0; j < bt.Width; j++)
                    {
                       fsw.WriteByte(ImageBitmap.GetPixel(j, i).R);
                        fsw.WriteByte(ImageBitmap.GetPixel(j, i).G);
                        fsw.WriteByte(ImageBitmap.GetPixel(j, i).B);
                    }                    
                }
                SR.Close();
                fsw.Close();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}
