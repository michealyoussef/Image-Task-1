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

            try
            {
                FileStream FS = new
                    FileStream(path, FileMode.OpenOrCreate);
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
                    
                    for (int y = 0; y < ImageHight; ++y)
                    {
                        for (int x = 0; x < (3 * ImageWidth); x += 3)
                        {
                            int Red = int.Parse(PixelsColors[(y * ImageWidth + x)]);
                            int Green = int.Parse(PixelsColors[(y * ImageWidth + x + 1)]);
                            int Blue = int.Parse(PixelsColors[(y * ImageWidth + x + 2)]);
                            ImageBitmap.SetPixel(x, y, Color.FromArgb(Red, Green, Blue));
                        }
                    }
                
                SR.Close();
            }
            catch { Console.WriteLine("\n Error : File Not Exist !!!"); }

        }
    }
}
