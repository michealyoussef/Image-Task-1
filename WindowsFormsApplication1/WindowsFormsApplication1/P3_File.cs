using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace WindowsFormsApplication1
{
    class P3_File
    {
        private String ImageType;
        private String Comment;
        private int ImageWidth;
        private int ImageHight;
        private int ImageMaxColoredValue;
        // private Buffer ImageBuffer;
        public Bitmap ImageBitmap;
        public P3_File(String path)
        {
            FileStream FS = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(FS);
            /*
             * read the ppm file 
             * P3
             * #comment
             * width hight 
             * max colored pixel 
             * width * hight (R G B) pixels
             */

            ImageType = SR.ReadLine();
            Console.WriteLine("\n type : " + ImageType);
            String WidthHight = SR.ReadLine();
            if (WidthHight[0] == '#')
            {
                Comment = WidthHight;
                WidthHight = SR.ReadLine();
            }

            String[] resolution = WidthHight.Split(' ');
            ImageWidth = int.Parse(resolution[0]);
            ImageHight = int.Parse(resolution[1]);
            ImageMaxColoredValue = int.Parse(SR.ReadLine());
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
            matrix m = new matrix();
            // ImageBitmap = m.NearestNeighborScale(ImageBitmap, ImageWidth*2*2, ImageHight*2*2);//for scaling experiment
            SR.Close();

        }



        public int saving()
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
            for (int i = 0; i < ImageHight; i++)
            {
                write = "";
                for (int j = 0; j < ImageWidth; j++)
                {
                    write += ImageBitmap.GetPixel(i, j).ToString() + " ";
                }
                SR.WriteLine(write);
            }
            return 0;

        }
    }
}
