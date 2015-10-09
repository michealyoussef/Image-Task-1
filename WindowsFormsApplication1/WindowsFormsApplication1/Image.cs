using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

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
        public Bitmap Read(String path)
        {
            P3file = new P3_File(path);
            ImageBitmap = P3file.ImageBitmap;
            return ImageBitmap;
        }
        public void savingpicture(String writen_path, Bitmap bt)
        {
           P3file.saving();
        }
    }
}
