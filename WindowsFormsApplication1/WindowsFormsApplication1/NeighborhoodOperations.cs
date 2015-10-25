using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class NeighborhoodOperations
    {
        bufferedLockBitmap f;
        Bitmap temp;
        public bufferedLockBitmap LinearFilter(bufferedLockBitmap input, double[,] mask, int w, int h, int x, int y, String word)
        {
            temp = new Bitmap(input.Width, input.Height);
            f = new bufferedLockBitmap(temp);
            f.LockBits();
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
                                sumR += (double)input.source.GetPixel(j + maskw - x, i + maskh - y).R * mask[maskw, maskh];
                                sumG += (double)input.source.GetPixel(j + maskw - x, i + maskh - y).G * mask[maskw, maskh];
                                sumB += (double)input.source.GetPixel(j + maskw - x, i + maskh - y).B * mask[maskw, maskh];
                            }
                        }
                    }

                    f.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(sumR), Convert.ToInt32(sumG), Convert.ToInt32(sumB)));
                    sumR = 0;
                    sumG = 0;
                    sumB = 0;
                }
            }
            f.UnlockBits();
            return f;
        }
    }
}
