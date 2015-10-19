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
    class ImageController
    {
        private String ImagePath;
        public Bitmap ImageBitmap = new Bitmap(1000, 800);
        public int ImageWidth;
        public int ImageHigh;
        private int ImageMaxColorValue;
        private String ImageFormat;
        private PP36FileReading P3file;
        public bufferedLockBitmap ImageLockBitmap;
        public Pixel_logic__Operations op;

        public ImageController()
        {

        }
        public Bitmap Read(String path)
        {
            String[] pa = path.Split('.');
            if (pa[pa.Length - 1] == "ppm" || pa[pa.Length - 1] == "PPM")
            {
                P3file = new PP36FileReading(path);
                ImageBitmap = P3file.ImageBitmap;
                ImageHigh = ImageBitmap.Height;
                ImageWidth = ImageBitmap.Width;
            }
            else
                ImageBitmap = new Bitmap(path);
            ImageLockBitmap = new bufferedLockBitmap(ImageBitmap);
            return ImageBitmap;
        }
        public void savingpicture(String writen_path, Bitmap bt)
        {
            P3file.saving(bt, writen_path);
            //  P3file.saving();
        }
        public void Scale(float Xsize, float Ysize, Graphics gg)
        {
            ImageWidth *= int.Parse(Xsize.ToString());
            ImageHigh *= int.Parse(Ysize.ToString());

            Matrix mat = new Matrix();
            mat.Scale(Xsize, Ysize);
            Graphics g = gg;
            gg.Transform = mat;

            gg.DrawImage(ImageBitmap, 0, 0, ImageBitmap.Width, ImageBitmap.Height);
        }
        public void Rotate(float angle, Graphics gg)
        {
            Matrix mat = new Matrix();
            mat.Rotate(angle);
            Graphics g = gg;
            g.Transform = mat;
            g.DrawImage(ImageBitmap, 0, 0, ImageBitmap.Width, ImageBitmap.Height);
        }
        public void Shearing(float x, float y, Graphics gg)
        {
            Matrix mat = new Matrix();
            mat.Scale(x, y);
            Graphics g = gg;
            g.Transform = mat;
            g.DrawImage(ImageBitmap, 0, 0, ImageBitmap.Width, ImageBitmap.Height);
        }
        public void all(float Xsize, float ysize, float angle, float shx, float shy, Graphics gg)
        {
            Matrix mat = new Matrix();
            mat.Scale(Xsize, ysize);
            mat.Rotate(angle);
            mat.Shear(shx, shy);
            Graphics g = gg;
            g.Transform = mat;
            g.DrawImage(ImageBitmap, 0, 0, ImageBitmap.Width, ImageBitmap.Height);
        }
        public Bitmap Grayscale()
        {
            op = new Pixel_logic__Operations();
            return op.Grayscale(this.ImageBitmap);
        }
        public Bitmap NOT()
        {
            op = new Pixel_logic__Operations();
            return op.notoperation(this.ImageBitmap);
        }
        public Bitmap Brightness(int dif)
        {
            op = new Pixel_logic__Operations();
            return op.Brightness(this.ImageBitmap, dif);

        }
        public Bitmap Gamma(int dif)
        {
            op = new Pixel_logic__Operations();
            return op.Gamma(this.ImageBitmap, dif);

        }
        public Bitmap Flipping()
        {
            //flip images
            ImageWidth = ImageBitmap.Width;
            ImageHigh = ImageBitmap.Height;
            Bitmap mimg = new Bitmap(ImageWidth, ImageHigh);
            for (int i = 0; i < ImageHigh; i++)
            {
                for (int lx = 0; lx < ImageWidth; ++lx)
                {
                    Color p = ImageBitmap.GetPixel(ImageWidth - lx - 1, i);
                    mimg.SetPixel(lx, i, p);
                }
            }
            return mimg;
        }
        public Bitmap Flippingvertical()
        {
            //flip images
            ImageWidth = ImageBitmap.Width;
            ImageHigh = ImageBitmap.Height;
            Bitmap mimg = new Bitmap(ImageWidth, ImageHigh);
            for (int i = 0; i < ImageHigh; i++)
            {
                for (int lx = 0; lx < ImageWidth; ++lx)
                {
                    Color p = ImageBitmap.GetPixel(lx, ImageHigh - i - 1);
                    mimg.SetPixel(lx, i, p);
                }
            }
            return mimg;
        }
        public Bitmap subtraction(Bitmap input1)
        {
            op = new Pixel_logic__Operations();
            return op.Subtraction(input1, this.ImageBitmap);

        }
        public Bitmap addtion(Bitmap input1, double diff)
        {
            op = new Pixel_logic__Operations();
            return op.Addpictures(input1, this.ImageBitmap, diff);

        }
        public Bitmap Bit_plane_slicing(int x,bool R,bool G,bool B)
        {
            op = new Pixel_logic__Operations();
            return op.Bit_plane(this.ImageBitmap, x,R,G,B);
        }
        public Bitmap cont(int x, int y)
        {
            op = new Pixel_logic__Operations();
            return op.contrast(this.ImageBitmap, x, y);

        }
        public Bitmap Quantization(int x)
        {
            op = new Pixel_logic__Operations();
            return op.Quantization(this.ImageBitmap, x);

        }


    }
}
