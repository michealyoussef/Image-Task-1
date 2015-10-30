using System;
using System.Drawing;
using TestMatrixTransformations;

namespace WindowsFormsApplication1
{
   public class ImageController
    {
        public Bitmap ImageBitmap = new Bitmap(1000, 800);
        public int ImageWidth;
        public int ImageHigh;
        NeighborhoodOperations NO = new NeighborhoodOperations();
        public PP36FileReading PP36File;
        Generatemask gn = new Generatemask();
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
                PP36File = new PP36FileReading(path);
                ImageBitmap = PP36File.ImageBitmap;
                ImageHigh = ImageBitmap.Height;
                ImageWidth = ImageBitmap.Width;
            }
            else
            {

                PP36File = new PP36FileReading();
                PP36File.readbitmap(path);
                ImageBitmap = PP36File.ImageBitmap;
                ImageHigh = ImageBitmap.Height;
                ImageWidth = ImageBitmap.Width;
            }

            ImageLockBitmap = new bufferedLockBitmap(ImageBitmap);
            ImageLockBitmap.LockBits();
            op = new Pixel_logic__Operations(this.ImageLockBitmap);
            return ImageLockBitmap.source;

        }
        public void savingpicture(String writen_path)
        {
            
            PP36File.ImageBitmap = ImageLockBitmap.source;
            PP36File.saving(this.ImageLockBitmap.source, writen_path);
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
            this.ImageLockBitmap = op.Grayscale(this.ImageLockBitmap);
            return this.ImageLockBitmap.source;
        }
        public Bitmap NOT(int x)
        {
            this.ImageLockBitmap.LockBits();
            op.notoperation(this.ImageLockBitmap, x);
            this.ImageLockBitmap.UnlockBits();
            return this.ImageLockBitmap.source;
        }
        public bufferedLockBitmap Brightness(int dif)
        {
            this.ImageLockBitmap = op.Brightness(this.ImageLockBitmap, dif);
            return this.ImageLockBitmap;
        }
        public bufferedLockBitmap Gamma(double dif)
        {
            this.ImageLockBitmap = op.Gamma(this.ImageLockBitmap, dif);
            return this.ImageLockBitmap;
        }
        public Bitmap Flipping()
        {
            this.ImageLockBitmap = op.FlippingHorizontal(this.ImageLockBitmap);
            return this.ImageLockBitmap.source;
        }
        public Bitmap Flippingvertical()
        {
            this.ImageLockBitmap = op.Flippingvertical(this.ImageLockBitmap);
            return this.ImageLockBitmap.source;
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
            this.ImageLockBitmap = NO.LinearFilter(this.ImageLockBitmap, gn.Generatingmean(w, h), w, h, x, y, "NO");
            return this.ImageLockBitmap;
        }
        public bufferedLockBitmap Gus1(int ms, double s)
        {
            NO.LinearFilter(this.ImageLockBitmap, gn.Gaussian_Filter_Option1(ms, s), ms / 2, ms / 2, 0, 0, "NO");
            return this.ImageLockBitmap;
        }
        public bufferedLockBitmap Gus2(double s)
        {

            int N = Convert.ToInt32(3.7 * s - 0.5);
            int masksize = 2 * N + 1;
            NO.LinearFilter(this.ImageLockBitmap, gn.Gaussian_Filter_Option2(s), masksize, masksize, masksize / 2, masksize / 2, "NO");
            return this.ImageLockBitmap;

        }
        public bufferedLockBitmap mean1D(int masksize)
        {
            this.ImageLockBitmap = NO.LinearFilter(this.ImageLockBitmap, gn.Generatingmean(1, masksize), 1, masksize, 0, 0, "NO");
            return this.ImageLockBitmap;
        }
        public Bitmap laplacian()
        {    
            this.ImageLockBitmap = NO.LinearFilter(this.ImageLockBitmap, gn.lap(), 3, 3, 0, 0, "cutoff");
        
            return this.ImageLockBitmap.source;
        }
        public bufferedLockBitmap line_detectionh()
        {
            this.ImageLockBitmap = NO.LinearFilter(this.ImageLockBitmap, gn.line_detect_Horizontal(), 3, 3, 1 ,1, "abs");
            
            return this.ImageLockBitmap;
        }

        public bufferedLockBitmap line_detectionv()
        {
            this.ImageLockBitmap = NO.LinearFilter(this.ImageLockBitmap, gn.line_detect_vertical(), 3, 3, 1, 1, "abs");
            return this.ImageLockBitmap;
        }
        public bufferedLockBitmap EdgeMagnitude()
        {
            bufferedLockBitmap pic1 = NO.LinearFilter(this.ImageLockBitmap, gn.line_detect_vertical(), 3, 3, 1, 1, "abs");
            bufferedLockBitmap pic2 = NO.LinearFilter(this.ImageLockBitmap, gn.line_detect_Horizontal(), 3, 3, 1, 1, "abs");
            Bitmap temp = new Bitmap(this.ImageLockBitmap.Width, this.ImageLockBitmap.Height);
            bufferedLockBitmap bt = new bufferedLockBitmap(temp);
            bt.LockBits();
            double sumR = 0, sumG = 0, sumB = 0;
            for (int i = 0; i < this.ImageLockBitmap.Height; i++)
            {
                for (int j = 0; j < this.ImageLockBitmap.Width; j++)
                {
                    sumR += (double)pic1.Getpixel(j, i).R + pic2.Getpixel(j, i).R;
                    sumG += (double)pic1.Getpixel(j, i).G + pic2.Getpixel(j, i).G;
                    sumB += (double)pic1.Getpixel(j, i).B + pic2.Getpixel(j, i).B;
                    if (sumR > 255) sumR = 255;
                    else if (sumR < 0) sumR = 0;
                    if (sumG > 255) sumG = 255;
                    else if (sumG < 0) sumG = 0;
                    if (sumB > 255) sumB = 255;
                    else if (sumB < 0) sumB = 0;
                    bt.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(sumR), Convert.ToInt32(sumG), Convert.ToInt32(sumB)));
                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                }
            }
            bt.UnlockBits();
            this.ImageLockBitmap = bt;
            return this.ImageLockBitmap;
        }
    }
}
