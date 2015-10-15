using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    public class PP36FileReading
    {
        private P3_File p3;
        private P6_File p6;
        private String ImageType;
        private String Comment;
        private int ImageWidth;
        private int ImageHight;
        private int ImageMaxColoredValue;
        public Bitmap ImageBitmap;
        public PP36FileReading(String path)
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
            if (ImageType == "P3")
            {
                p3 = new P3_File(ref SR, ImageWidth, ImageHight);
                this.ImageBitmap = p3.ImageBitmap;
                FS.Close();
            }
            else if (ImageType == "P6")
            {
                p6 = new P6_File(ref FS, ImageWidth, ImageHight);
                this.ImageBitmap = p6.ImageBitmap;
                SR.Close();
                FS.Close();
            }
        }
        public int saving(Bitmap bt)
        {
            if (ImageType == "p3")
                return p3.saving(ImageBitmap, ImageType);
            return 0;
        }

        ~PP36FileReading()
        {

        }
    }
}
