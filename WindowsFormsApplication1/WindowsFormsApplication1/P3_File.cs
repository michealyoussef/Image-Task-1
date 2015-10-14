using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace WindowsFormsApplication1
{
    public class P3_File
    {

        private String Comment;


        public Bitmap ImageBitmap;

        public P3_File()
        {

        }
        public P3_File(ref StreamReader SR, int ImageWidth, int ImageHight)
        {
            string tmp = "";/* we will use it to put the pixels of the image*/

            tmp = SR.ReadToEnd();
            String[] PixelsColors = tmp.Split(' ');
            ImageBitmap = new Bitmap(ImageWidth, ImageHight);
            Color[] colors = new Color[PixelsColors.Length];
            int k = 0;
            for (int i = 0; i < PixelsColors.Length; i += 3)
            {
                if (k >= PixelsColors.Length / 3)
                    break;
                colors[k++] = Color.FromArgb(int.Parse(PixelsColors[i]), int.Parse(PixelsColors[i + 1]), int.Parse(PixelsColors[i + 2]));
            }
            int k1 = 0;
            for (int i = 0; i < ImageHight; i++)
                for (int j = 0; j < ImageWidth; j++)
                {
                    ImageBitmap.SetPixel(j, i, colors[k1++]);
                }

            SR.Close();

        }
        public int saving(Bitmap bt, string ImageType)
        {
            try
            {
                FileStream fsw = new FileStream("T.PPM", FileMode.Append, FileAccess.Write);
                StreamWriter SR = new StreamWriter(fsw);
                /*
                 * read the ppm file 
                 * P3
                 * #comment
                 * width hight 
                 * max colored pixel 
                 * width * hight (R G B) pixels
                 */
                String write = "";
                SR.WriteLine(ImageType.ToString());
                SR.WriteLine(ImageBitmap.Width + " " + ImageBitmap.Height);
                for (int i = 0; i < bt.Height; i++)
                {
                    write = "";
                    for (int j = 0; j < bt.Width; j++)
                    {
                        write += ImageBitmap.GetPixel(i, j).ToString() + " ";
                    }
                    SR.WriteLine(write);
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
