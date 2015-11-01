using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Pixel_logic__Operations
    {
        bufferedLockBitmap bf;
        Bitmap temp;
        byte[] Word;
        int maxR = 0, maxG = 0, maxb = 0;
        int minR = 1000, minG = 1000, minb = 1000;
        public Pixel_logic__Operations(bufferedLockBitmap input)
        {
            int te = 0;

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    te = input.Getpixel(j, i).R;
                    if (te > maxR) maxR = te;

                    te = input.Getpixel(j, i).G;
                    if (te > maxG) maxG = te;

                    te = input.Getpixel(j, i).B;
                    if (te > maxb) maxb = te;

                    te = input.Getpixel(j, i).R;
                    if (te < minR) minR = te;

                    te = input.Getpixel(j, i).G;
                    if (te < minG) minG = te;

                    te = input.Getpixel(j, i).B;
                    if (te < minb) minb = te;

                }
            }
            Word = new byte[8];
            Word[0] = 1;
            Word[1] = 2;
            Word[2] = 4;
            Word[3] = 8;
            Word[4] = 16;
            Word[5] = 32;
            Word[6] = 64;
            Word[7] = 128;
        }

        public Bitmap OR(bufferedLockBitmap pic1, bufferedLockBitmap pic2)
        {
            temp = new Bitmap(pic1.Width, pic1.Height);
            bufferedLockBitmap bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int R, G, B = 0;
            if (pic1.Width == pic2.Width)
            {
                R = 0; G = 0; B = 0;
                for (int i = 0; i < pic1.Height; i++)
                {
                    for (int j = 0; j < pic1.Width; j++)
                    {
                        R = pic1.Getpixel(j, i).R | pic2.Getpixel(j, i).R;
                        G = pic1.Getpixel(j, i).G | pic2.Getpixel(j, i).G;
                        B = pic1.Getpixel(j, i).B | pic2.Getpixel(j, i).B;

                        bf.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));

                    }
                }
            }
            bf.UnlockBits();
            return bf.source;
        }
        public Bitmap AND(bufferedLockBitmap pic1, bufferedLockBitmap pic2)
        {
            temp = new Bitmap(pic1.Width, pic1.Height);
            bufferedLockBitmap bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int R, G, B = 0;
            if (pic1.Width == pic2.Width)
            {
                R = 0; G = 0; B = 0;
                for (int i = 0; i < pic1.Height; i++)
                {
                    for (int j = 0; j < pic1.Width; j++)
                    {
                        R = pic1.Getpixel(j, i).R & pic2.Getpixel(j, i).R;
                        G = pic1.Getpixel(j, i).G & pic2.Getpixel(j, i).G;
                        B = pic1.Getpixel(j, i).B & pic2.Getpixel(j, i).B;

                        bf.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));

                    }
                }
            }
            bf.UnlockBits();
            return bf.source;
        }
        public bufferedLockBitmap contrast(bufferedLockBitmap input, int x, int y)
        {
            temp = new Bitmap(input.Width, input.Height);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int NewMinR = 0, NewMinG = 0, NewMinB = 0, NewMaxR = 0, NewMaxG = 0, NewMaxB = 0;
            temp = new Bitmap(input.Width, input.Height);
            int R, G, B;
            NewMinR = minR + x;
            NewMinG = minG + x;
            NewMinB = minb + x;

            NewMaxR = maxR + y;
            NewMaxB = maxb + y;
            NewMaxG = maxG + y;

            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.Getpixel(j, i).R;
                    R = Convert.ToInt32(((double)(R - minR) / (maxR - minR)) * ((NewMaxR - NewMinR)) + NewMinR);
                    G = input.Getpixel(j, i).G;
                    G = Convert.ToInt32(((double)(G - minG) / (maxG - minG)) * ((NewMaxG - NewMinG)) + NewMinG);
                    B = input.Getpixel(j, i).B;
                    B = Convert.ToInt32(((double)(B - minb) / (maxb - minb)) * ((NewMaxB - NewMinB)) + NewMinB);

                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    bf.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            bf.UnlockBits();
            return bf;
        }
        public bufferedLockBitmap Bit_plane(bufferedLockBitmap input, int number, bool R, bool G, bool B)
        {
            temp = new Bitmap(input.source);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int p;
            int red = 0, blue = 0, green = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    if (R == true)
                    {
                        p = bf.Getpixel(j, i).R & Word[number ];
                        if (p != 0)
                            red = 255;
                        else if (p == 0)
                            red = 0;
                    }
                    if (G == true)
                    {
                        p = bf.Getpixel(j, i).G & Word[number ];
                        if (p != 0)
                            green = 255;
                        else if (p == 0)
                            green = 0;
                    }
                    if (B == true)
                    {
                        p = bf.Getpixel(j, i).B & Word[number ];
                        if (p != 0)
                            blue = 255;
                        else if (p == 0)
                            blue = 0;
                    }
                    bf.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            bf.UnlockBits();
            return bf;
        }

        public bufferedLockBitmap FlippingHorizontal(bufferedLockBitmap imageLockBitmap)
        {
            Bitmap temp = new Bitmap(imageLockBitmap.Width, imageLockBitmap.Height);
            bufferedLockBitmap t = new bufferedLockBitmap(temp);
            t.LockBits();
            //flip images
            int ImageWidth = imageLockBitmap.Width;
            int ImageHigh = imageLockBitmap.Height;
            Bitmap mimg = new Bitmap(ImageWidth, ImageHigh);
            for (int i = 0; i < ImageHigh; i++)
            {
                for (int lx = 0; lx < ImageWidth; ++lx)
                {
                    Color p = imageLockBitmap.Getpixel(ImageWidth - lx - 1, i);
                    t.SetPixel(lx, i, p);
                }
            }
            t.UnlockBits();
            return t;
        }

        public bufferedLockBitmap Brightness(bufferedLockBitmap input, int dif)
        {
            temp = new Bitmap(input.Width, input.Height);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int R, G, B = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.Getpixel(j, i).R + dif;
                    G = input.Getpixel(j, i).G + dif;
                    B = input.Getpixel(j, i).B + dif;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    bf.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            bf.UnlockBits();
            return bf;
        }
        public bufferedLockBitmap Grayscale(bufferedLockBitmap input)
        {
            input.LockBits();
            int sum = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    sum = 0;
                    sum = input.Getpixel(j, i).R + input.Getpixel(j, i).G + input.Getpixel(j, i).B;
                    sum /= 3;
                    input.SetPixel(j, i, Color.FromArgb(sum, sum, sum));
                }
            }
            input.UnlockBits();
            return input;
        }
        public void Quantization(bufferedLockBitmap input, int num)
        {
            int sum = 0;
            double f = 2;
            int math = Convert.ToInt32(Math.Log(Convert.ToDouble(num), f));
            for (int w = 7; w > 7 - math; w--)
            {
                sum = sum + Convert.ToInt32(Math.Pow(f, Convert.ToInt32(w)));
            }
            temp = new Bitmap(input.Width, input.Height);
            bf = new bufferedLockBitmap(temp);
            input.LockBits();
            int R, G, B;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.Getpixel(j, i).R & sum;
                    G = input.Getpixel(j, i).G & sum;
                    B = input.Getpixel(j, i).B & sum;
                    input.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            input.UnlockBits();
            

        }
        public void notoperation(bufferedLockBitmap input, int dif)
        {


            if (dif == 0)
                for (int i = 0; i < input.Height; i++)
                {
                    for (int j = 0; j < input.Width; j++)
                    {
                        input.SetPixel(j, i, Color.FromArgb(dif - input.Getpixel(j, i).R, dif - input.Getpixel(j, i).G, dif - input.Getpixel(j, i).B));
                    }
                }
            else
            {
                temp = new Bitmap(input.Width, input.Height);
                bufferedLockBitmap bf = new bufferedLockBitmap(temp);
                bf.LockBits();
                int gmaxR = 0, gmaxG = 0, gmaxb = 0, gminR = 1000, gminG = 10000, gminb = 1000;
                int te;

                int R, G, B = 0;
                for (int i = 0; i < input.Height; i++)
                {
                    for (int j = 0; j < input.Width; j++)
                    {
                        R = dif - input.Getpixel(j, i).R;
                        G = dif - input.Getpixel(j, i).G;
                        B = dif - input.Getpixel(j, i).B;
                        te = R;
                        if (te > gmaxR) gmaxR = te;
                        if (te < gminR) gminR = te;

                        te = G;

                        if (te > gmaxb) gmaxb = te;
                        if (te < gminb) gminb = te;
                        te = B;
                        if (te > gmaxG) gmaxG = te;
                        if (te < gminG) gminG = te;

                    }
                }

                for (int i = 0; i < input.Height; i++)
                {
                    for (int j = 0; j < input.Width; j++)
                    {
                        R =Math.Abs( dif - input.Getpixel(j, i).R);
                        G = Math.Abs(dif - input.Getpixel(j, i).G);
                        B = Math.Abs(dif - input.Getpixel(j, i).B);

                        //R = Convert.ToInt32(((double)(R - minR) / (maxR - minR)) * ((255 - 0)));
                        //G = Convert.ToInt32(((double)(G - minG) / (maxG - minG)) * ((255 - 0)));
                        //B = Convert.ToInt32(((double)(B - minb) / (maxb - minb)) * ((255 - 0)));

                        if (R > 255) R = 255;
                        else if (R < 0) R = 0;
                        if (G > 255) G = 255;
                        else if (G < 0) G = 0;
                        if (B > 255) B = 255;
                        else if (B < 0) B = 0;
                        input.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));
                    }


                }
                bf.UnlockBits();
            }
        }
        public bufferedLockBitmap Gamma(bufferedLockBitmap input, double dif)
        {
            if (dif == 0)
                return input;
            if (dif < 0)
                dif = 1 / Math.Abs(dif);
            double te = 0;
            double gmaxR = -10000, gmaxG =-10000, gmaxb = -10000, gminR = 10000, gminG = 10000, gminb = 10000;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    te = Math.Pow(input.Getpixel(j, i).R, dif);
                    if (te > gmaxR) gmaxR = te;
                    else if (te < gminR) gminR = te;

                    te = Math.Pow(input.Getpixel(j, i).B, dif);
                    if (te > gmaxb) gmaxb = te;
                    else if (te < gminb) gminb = te;

                    te = Math.Pow(input.Getpixel(j, i).G, dif);
                    if (te > gmaxG) gmaxG = te;
                     if (te < gminG) gminG = te;

                }
            }


            temp = new Bitmap(input.Width, input.Height);
            bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            double R, G, B = 0,x;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = (Math.Pow(input.Getpixel(j, i).R, dif));
                    x = (Math.Pow(input.Getpixel(j, i).G, dif));
                    B = (Math.Pow(input.Getpixel(j, i).B, dif));

                    R = Convert.ToInt32(((double)(R - gminR) / (gmaxR - gminR)) * (255 - 0));
                    G = Convert.ToInt32(((double)(x - gminG) / (gmaxG - gminG)) * (255 - 0));
                    B = Convert.ToInt32(((double)(B - gminb) / (gmaxb - gminb)) * (255 - 0));

                    //if (R > 255) R = 255;
                    //else if (R < 0) R = 0;
                    //if (G > 255) G = 255;
                    //else if (G < 0) G = 0;
                    //if (B > 255) B = 255;
                    //else if (B < 0) B = 0;
                    bf.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));
                }
            }
            bf.UnlockBits();
            return bf;
        }
        public Bitmap Addpictures(bufferedLockBitmap pic1, bufferedLockBitmap pic2, double fraction)
        {
            if (pic1.Width == pic2.Width && pic1.Height == pic2.Height)
            {
                temp = new Bitmap(pic1.Width, pic1.Height);
                bufferedLockBitmap r = new bufferedLockBitmap(temp);
                r.LockBits();
                int R, G, B = 0;
                double f;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        f = ((((double)pic1.Getpixel(j, i).R)) * fraction) + (((double)pic2.Getpixel(j, i).R) * (1 - fraction));
                        R = Convert.ToInt32(f);
                        f = ((((double)pic1.Getpixel(j, i).G)) * fraction) + (((double)pic2.Getpixel(j, i).G) * (1 - fraction));
                        G = Convert.ToInt32(f);
                        f = ((((double)pic1.Getpixel(j, i).B)) * fraction) + (((double)pic2.Getpixel(j, i).B) * (1 - fraction));
                        B = Convert.ToInt32(f);
                        r.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
                r.UnlockBits();
                return r.source;

            }
            else
                MessageBox.Show("picture 1 size is equal to picture 2 size");
            return temp;
        }
        public Bitmap Subtraction(bufferedLockBitmap pic1, bufferedLockBitmap pic2)
        {
            temp = new Bitmap(pic1.Width, pic1.Height);
            bufferedLockBitmap bf = new bufferedLockBitmap(temp);
            bf.LockBits();
            int gmaxR = 0, gmaxG = 0, gmaxb = 0, gminR = 1000, gminG = 10000, gminb = 1000;
            int te;

            int R, G, B = 0;
            if (pic1.Width == pic2.Width)
            {
                R = 0; G = 0; B = 0;
                for (int i = 0; i < pic1.Height; i++)
                {
                    for (int j = 0; j < pic1.Width; j++)
                    {
                        R = Math.Abs(pic1.Getpixel(j, i).R - pic2.Getpixel(j, i).R);
                        G = Math.Abs(pic1.Getpixel(j, i).G - pic2.Getpixel(j, i).G);
                        B = Math.Abs(pic1.Getpixel(j, i).B - pic2.Getpixel(j, i).B);
                        te = R;
                        if (te > gmaxR) gmaxR = te;
                        if (te < gminR) gminR = te;

                        te = G;

                        if (te > gmaxb) gmaxb = te;
                        if (te < gminb) gminb = te;
                        te = B;
                        if (te > gmaxG) gmaxG = te;
                        if (te < gminG) gminG = te;

                    }
                }
            }

            for (int i = 0; i < pic1.Height; i++)
            {
                for (int j = 0; j < pic1.Width; j++)
                {

                    R = Math.Abs(pic1.Getpixel(j, i).R - pic2.Getpixel(j, i).R);
                    G = Math.Abs(pic1.Getpixel(j, i).G - pic2.Getpixel(j, i).G);
                    B = Math.Abs(pic1.Getpixel(j, i).B - pic2.Getpixel(j, i).B);
                    R = Convert.ToInt32(((double)(R - minR) / (maxR - minR)) * ((255 - 0)));
                    G = Convert.ToInt32(((double)(G - minG) / (maxG - minG)) * ((255 - 0)));
                    B = Convert.ToInt32(((double)(B - minb) / (maxb - minb)) * ((255 - 0)));
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    bf.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B)));
                }
            }

            bf.UnlockBits();
            return bf.source;
        }
        public bufferedLockBitmap Flippingvertical(bufferedLockBitmap pic1)
        {
            Bitmap temp = new Bitmap(pic1.Width, pic1.Height);
            bufferedLockBitmap t = new bufferedLockBitmap(temp);
            t.LockBits();
            //flip images
            Color p;
            int ImageWidth = pic1.Width;
            int ImageHigh = pic1.Height;
            Bitmap mimg = new Bitmap(ImageWidth, ImageHigh);
            for (int i = 0; i < ImageHigh; i++)
            {
                for (int lx = 0; lx < ImageWidth; ++lx)
                {
                    p = pic1.Getpixel(lx, ImageHigh - i - 1);
                    t.SetPixel(lx, i, p);
                }
            }
            t.UnlockBits();
            return t;
        }

    }

}
