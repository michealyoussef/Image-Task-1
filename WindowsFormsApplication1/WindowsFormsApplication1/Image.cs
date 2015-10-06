using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Image
    {
        private String ImagePath;
        public Bitmap ImageBitmap;
        private int ImageWidth;
        private int ImageHigh;
        private int ImageMaxColorValue;
        private String ImageFormat;
        private P3_File P3file;


        public Image() 
        {

        }
        public Bitmap read(String path)
        {
            P3file = new P3_File(ImagePath);
            ImageBitmap = P3file.ImageBitmap;

          //  ImageBitmap = new Bitmap(path);
            return ImageBitmap;
        }

    }

}
