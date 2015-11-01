using System;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class NeighborhoodOperations
    {

        public bufferedLockBitmap LinearFilter(bufferedLockBitmap input, double[,] mask, int w, int h, int x, int y, String word)
        {
            Bitmap temp = new Bitmap(input.Width, input.Height);
            bufferedLockBitmap bt = new bufferedLockBitmap(temp);
            bt.LockBits();
            double sumR = 0, sumG = 0, sumB = 0;
            for (int i = 0; i < input.Height; i++)
            {
                for (int j = 0; j < input.Width; j++)
                {
                    for (int maskh = 0; maskh < h; maskh++)
                    {
                        for (int maskw = 0; maskw < w; maskw++)
                        {
                            if (j + maskw - x < 0)
                                continue;
                            else if (j + maskw - x >= input.Width)
                                continue;
                            else if ((i + maskh - y >= input.Height))
                                continue;
                            else if (i + maskh - y < 0)
                                continue;
                            else
                            {
                                sumR += (double)input.Getpixel(j + maskw - x, i + maskh - y).R * mask[maskh, maskw];
                                sumG += (double)input.Getpixel(j + maskw - x, i + maskh - y).G * mask[maskh, maskw];
                                sumB += (double)input.Getpixel(j + maskw - x, i + maskh - y).B * mask[maskh, maskw];
                            }
                        }
                    }

                    if (word == "cutoff")
                    {
                        if (sumR > 255) sumR = 255;
                        else if (sumR < 0) sumR = 0;
                        if (sumG > 255) sumG = 255;
                        else if (sumG < 0) sumG = 0;
                        if (sumB > 255) sumB = 255;
                        else if (sumB < 0) sumB = 0;
                    }
                    else if (word == "abs")
                    {
                        sumB = Math.Abs(sumB);
                        sumR = Math.Abs(sumR);
                        sumG = Math.Abs(sumG);
                        if (sumR > 255) sumR = 255;
                        else if (sumR < 0) sumR = 0;
                        if (sumG > 255) sumG = 255;
                        else if (sumG < 0) sumG = 0;
                        if (sumB > 255) sumB = 255;
                        else if (sumB < 0) sumB = 0;
                    }
                    bt.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(sumR), Convert.ToInt32(sumG), Convert.ToInt32(sumB)));
                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                }
            }
            bt.UnlockBits();
            return bt;
        }
    }
}
