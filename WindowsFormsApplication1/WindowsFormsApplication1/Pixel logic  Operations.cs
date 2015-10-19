using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Pixel_logic__Operations
    {
        Bitmap temp;
        byte[] Word;
        public Pixel_logic__Operations()
        {
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

        public Bitmap contrast(Bitmap input, int x, int y)
        {
            int NewMinR = 0, NewMinG = 0, NewMinB = 0, NewMaxR = 0, NewMaxG = 0, NewMaxB = 0;
            temp = new Bitmap(input.Width, input.Height);
            int minR = 1000, minG = 1000, minb = 1000;
            int maxR = 0, maxG = 0, maxb = 0;
            int te = 0;
            int R, G, B;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    te = input.GetPixel(j, i).R;
                    if (te > maxR) maxR = te;

                    te = input.GetPixel(j, i).G;
                    if (te > maxG) maxG = te;

                    te = input.GetPixel(j, i).B;
                    if (te > maxb) maxb = te;

                    te = input.GetPixel(j, i).R;
                    if (te < minR) minR = te;

                    te = input.GetPixel(j, i).G;
                    if (te < minG) minG = te;

                    te = input.GetPixel(j, i).B;
                    if (te < minb) minb = te;

                }
            }
            // if(minR<minb&&minR<minG)
            // NewMin = minR + x;
            //else if (minG<minR&&minG<minb)
            //     NewMin = minG + x;
            // else
            //     NewMin = minb + x;

            // if (minR > minb && minR > minG)
            //     NewMax = maxR + y;
            // else if (minG > minR && minG > minb)
            //     NewMax = maxG + y;
            // else
            //     NewMax = maxb + y;
            NewMinR = minR + x;
            NewMinG = minG + x;
            NewMinB = minb + x;

            NewMaxR = maxR + y;
            NewMaxB = maxb + y;
            NewMaxG = maxG + y;


            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    R = input.GetPixel(j, i).R;
                    R = Convert.ToInt32(((double)(R - minR) / (maxR - minR)) * ((NewMaxR - NewMinR)) + NewMinR);
                    G = input.GetPixel(j, i).G;
                    G = Convert.ToInt32(((double)(G - minG) / (maxG - minG)) * ((NewMaxG - NewMinG)) + NewMinG);
                    B = input.GetPixel(j, i).B;
                    B = Convert.ToInt32(((B - minb) / (maxb - minb)) * ((NewMaxB - NewMinB)) + NewMinB);

                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return temp;
        }
        public Bitmap Bit_plane(Bitmap input, int number, bool R, bool G, bool B)
        {
            temp = new Bitmap(input);
            int p;
            int red = 0, blue = 0, green = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    if (R == true)
                    {
                        p = input.GetPixel(j, i).R & Word[number - 1];
                        if (p != 0)
                            red = 255;
                        else if (p == 0)
                            red = 0;
                    }
                    if (G == true)
                    {
                        p = input.GetPixel(j, i).G & Word[number - 1];
                        if (p != 0)
                            green = 255;
                        else if (p == 0)
                            green = 0;
                    }
                    if (B == true)
                    {
                        p = input.GetPixel(j, i).B & Word[number - 1];
                        if (p != 0)
                            blue = 255;
                        else if (p == 0)
                            blue = 0;
                    }
                    temp.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
            }
            return temp;
        }

        public Bitmap Brightness(Bitmap input, int dif)
        {
            temp = new Bitmap(input);
            int R, G, B = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {
                    R = input.GetPixel(j, i).R + dif;
                    G = input.GetPixel(j, i).G + dif;
                    B = input.GetPixel(j, i).B + dif;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return temp;

        }
        public Bitmap Grayscale(Bitmap input)
        {
            int sum = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    sum = 0;
                    sum = input.GetPixel(j, i).R + input.GetPixel(j, i).G + input.GetPixel(j, i).B;
                    sum /= 3;
                    input.SetPixel(j, i, Color.FromArgb(sum, sum, sum));
                }
            }
            return input;
        }
        public Bitmap Quantization(Bitmap input, int num)
        {
            int sum = 0;
            double f = 2;
            int math = Convert.ToInt32(Math.Log(Convert.ToDouble(num), f));
            for (int w = 7; w > 7 - math; w--)
            {
                sum = sum + Convert.ToInt32(Math.Pow(f, Convert.ToInt32(w)));
            }
            
            temp = new Bitmap(input.Width,input.Height);

            int R, G, B;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    R = input.GetPixel(j, i).R & sum;
                    G = input.GetPixel(j, i).G & sum;
                    B = input.GetPixel(j, i).B & sum;
                    temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return temp;

        }
        public Bitmap notoperation(Bitmap input)
        {
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    input.SetPixel(j, i, Color.FromArgb(255 - input.GetPixel(j, i).R, 255 - input.GetPixel(j, i).G, 255 - input.GetPixel(j, i).B));
                }
            }
            return input;
        }
        public Bitmap Gamma(Bitmap input, int dif)
        {
            temp = new Bitmap(input);
            int R, G, B = 0;
            for (int i = 0; i < temp.Height; i++)
            {
                for (int j = 0; j < temp.Width; j++)
                {

                    R = int.Parse(Math.Pow(double.Parse(input.GetPixel(j, i).R.ToString()), dif).ToString());
                    G = int.Parse(Math.Pow(double.Parse(input.GetPixel(j, i).G.ToString()), dif).ToString());
                    B = int.Parse(Math.Pow(double.Parse(input.GetPixel(j, i).B.ToString()), dif).ToString());
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (B > 255) B = 255;
                    else if (B < 0) B = 0;
                    temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }
            return temp;
        }
        public Bitmap Addpictures(Bitmap pic1, Bitmap pic2, double fraction)
        {
            if (pic1.Size == pic2.Size)
            {
                Bitmap temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                double f;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        f = ((((double)pic1.GetPixel(j, i).R)) * fraction) + (((double)pic2.GetPixel(j, i).R) * (1 - fraction));
                        R = Convert.ToInt32(f);
                        f = ((((double)pic1.GetPixel(j, i).G)) * fraction) + (((double)pic2.GetPixel(j, i).G) * (1 - fraction));
                        G = Convert.ToInt32(f);
                        f = ((((double)pic1.GetPixel(j, i).B)) * fraction) + (((double)pic2.GetPixel(j, i).B) * (1 - fraction));
                        B = Convert.ToInt32(f);
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
                return temp;

            }
            else
                MessageBox.Show("picture 1 size is equal to picture 2 size");
            return temp;
        }

        public Bitmap OR(Bitmap pic1, Bitmap pic2)
        {
            if (pic1.Size == pic2.Size)
            {
                Bitmap temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        R = pic1.GetPixel(j, i).R | pic2.GetPixel(j, i).R;
                        G = pic1.GetPixel(j, i).G | pic2.GetPixel(j, i).G;
                        B = pic1.GetPixel(j, i).B | pic2.GetPixel(j, i).B;
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            return temp;
        }
        public Bitmap AND(Bitmap pic1, Bitmap pic2)//////na2s el contrast
        {
            if (pic1.Size == pic2.Size)
            {
                Bitmap temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        R = pic1.GetPixel(j, i).R & pic2.GetPixel(j, i).R;
                        G = pic1.GetPixel(j, i).G & pic2.GetPixel(j, i).G;
                        B = pic1.GetPixel(j, i).B & pic2.GetPixel(j, i).B;
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            return temp;
        }


        public Bitmap Subtraction(Bitmap pic1, Bitmap pic2)//////na2s el contrast
        {
            if (pic1.Size == pic2.Size)
            {
                temp = new Bitmap(pic1.Size.Width, pic1.Size.Height);
                int R, G, B = 0;
                for (int i = 0; i < temp.Height; i++)
                {
                    for (int j = 0; j < temp.Width; j++)
                    {
                        R = pic1.GetPixel(j, i).R - pic2.GetPixel(j, i).R;
                        G = pic1.GetPixel(j, i).G - pic2.GetPixel(j, i).G;
                        B = pic1.GetPixel(j, i).B - pic2.GetPixel(j, i).B;
                        if (R < 0)
                        {
                            R = 0;

                        }
                        if (G < 0)
                            G = 0;
                        if (B < 0) B = 0;
                        temp.SetPixel(j, i, Color.FromArgb(R, G, B));
                    }
                }
            }
            return temp;
        }

    }
}