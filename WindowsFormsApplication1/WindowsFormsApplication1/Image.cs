using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using TestMatrixTransformations;

namespace WindowsFormsApplication1
{
    class ImageController
    {
        public Bitmap ImageBitmap = new Bitmap(1000, 800);
        public int ImageWidth;
        public int ImageHigh;
        NeighborhoodOperations NO = new NeighborhoodOperations();
        private PP36FileReading P3file;
        public bufferedLockBitmap ImageLockBitmap;
        public Pixel_logic__Operations op;
        ImageMatrixTransformations mat = new ImageMatrixTransformations();
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
            ImageLockBitmap.LockBits();
            op = new Pixel_logic__Operations(this.ImageLockBitmap);

            return ImageLockBitmap.source;

        }
        public void savingpicture(String writen_path, bufferedLockBitmap bt)
        {
            P3file.saving(bt.source2, writen_path);
        }
        public Bitmap Scale(float Xsize, float Ysize)
        {
            return mat.perform_concat_matrices_operations(this.ImageLockBitmap, 0, 0, Xsize, Ysize, 0);
        }
        public Bitmap Rotate(float angle)
        {

            return mat.perform_concat_matrices_operations(ImageLockBitmap, 0, 0, 1, 1, angle);


        }
        public Bitmap Shearing(float x, float y)
        {
            return mat.perform_concat_matrices_operations(ImageLockBitmap, x, y, 1, 1, 0);

        }
        public void all(float Xsize, float ysize, float angle, float shx, float shy, Graphics gg)
        {

        }
        public Bitmap Grayscale()
        {
            this.ImageLockBitmap.LockBits();
            op.Grayscale(this.ImageLockBitmap);
            this.ImageLockBitmap.UnlockBits();
            return this.ImageLockBitmap.source2;
        }
        public Bitmap NOT()
        {
            this.ImageLockBitmap.LockBits();
            op.notoperation(this.ImageLockBitmap);
            this.ImageLockBitmap.UnlockBits();
            return this.ImageLockBitmap.source2;
        }
        public bufferedLockBitmap Brightness(int dif)
        {
            return op.Brightness(this.ImageLockBitmap, dif);
        }
        public Bitmap Gamma(double dif)
        {
            return op.Gamma(this.ImageLockBitmap, dif);

        }
        public Bitmap Flipping()
        {
            Bitmap temp = new Bitmap(ImageLockBitmap.Width, ImageLockBitmap.Height);
            bufferedLockBitmap t = new bufferedLockBitmap(temp);
            t.LockBits();
            ImageLockBitmap.LockBits();
            //flip images
            ImageWidth = ImageBitmap.Width;
            ImageHigh = ImageBitmap.Height;
            Bitmap mimg = new Bitmap(ImageWidth, ImageHigh);
            for (int i = 0; i < ImageHigh; i++)
            {
                for (int lx = 0; lx < ImageWidth; ++lx)
                {
                    Color p = ImageLockBitmap.Getpixel(ImageWidth - lx - 1, i);
                    t.SetPixel(lx, i, p);
                }
            }
            ImageLockBitmap.UnlockBits();
            t.UnlockBits();
            temp.Dispose();
            return t.source2;
        }
        public Bitmap Flippingvertical()
        {
            Bitmap temp = new Bitmap(ImageLockBitmap.Width, ImageLockBitmap.Height);
            bufferedLockBitmap t = new bufferedLockBitmap(temp);
            t.LockBits();
            ImageLockBitmap.LockBits();
            //flip images
            Color p;
            ImageWidth = ImageLockBitmap.Width;
            ImageHigh = ImageLockBitmap.Height;
            Bitmap mimg = new Bitmap(ImageWidth, ImageHigh);
            for (int i = 0; i < ImageHigh; i++)
            {
                for (int lx = 0; lx < ImageWidth; ++lx)
                {
                    p = ImageLockBitmap.Getpixel(lx, ImageHigh - i - 1);

                    t.SetPixel(lx, i, p);
                }
            }
            ImageLockBitmap.UnlockBits();
            t.UnlockBits();
            temp.Dispose();
            return t.source2;
        }
        public Bitmap subtraction(bufferedLockBitmap input1)
        {
            return op.Subtraction(input1, this.ImageLockBitmap);
        }
        public Bitmap addtion(bufferedLockBitmap input1, double diff)
        {
            return op.Addpictures(input1, this.ImageLockBitmap, diff);
        }
        public Bitmap Bit_plane_slicing(int x, bool R, bool G, bool B)
        {
            return op.Bit_plane(this.ImageLockBitmap, x, R, G, B);
        }
        public bufferedLockBitmap cont(int x, int y)
        {
            return op.contrast(this.ImageLockBitmap, x, y);
        }
        public Bitmap Quantization(int x)
        {
            return op.Quantization(this.ImageLockBitmap, x);
        }
        public bufferedLockBitmap meanfilter(int w, int h, int x, int y)
        {
            Generatemask gn = new Generatemask();
            return NO.LinearFilter(this.ImageLockBitmap, gn.Generatingmean(w, h), w, h, x, y, "NO");
        }
        public bufferedLockBitmap Gus1(int ms, int s)
        {
            Generatemask gn = new Generatemask();
            return NO.LinearFilter(this.ImageLockBitmap, gn.Gaussian_Filter_Option1(ms, s), ms, ms, 0, 0, "NO");

        }
        public bufferedLockBitmap Gus2(int s)
        {
            Generatemask gn = new Generatemask();
            double constant = 1 / (2 * s * s * Math.PI);
            int N = Convert.ToInt32(3.7 * s - 0.5);
            int masksize = 2 * N + 1;
            return NO.LinearFilter(this.ImageLockBitmap, gn.Gaussian_Filter_Option2(s), masksize, masksize, 0, 0, "NO");

        }
    }
}
