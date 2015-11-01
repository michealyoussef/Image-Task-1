using System;

namespace WindowsFormsApplication1
{
    class Generatemask
    {
        public double[,] mask;

        public double[,] Generatingmean(int w, int h)
        {
            mask = new double[h, w];
            for (int s = 0; s < h; s++)
                for (int g = 0; g < w; g++)
                    mask[s, g] = 1 / (double)(w * h);
            return mask;
        }
        public double[,] Gaussian_Filter_Option1(int masksize, double sigma)
        {
            mask = new double[masksize, masksize];
            double sum = 0;
            for (int x = (-masksize / 2); x <= (masksize / 2); x++)
                for (int y = (-masksize / 2); y <= (masksize / 2); y++)
                {
                    mask[x + masksize / 2, y + masksize / 2] = Math.Exp(-((x * x) + (y * y)) / (2 * sigma * sigma));
                    sum += mask[x + masksize / 2, y + masksize / 2];
                }

            for (int x = (-masksize / 2); x <= (masksize / 2); x++)
                for (int y = (-masksize / 2); y <= (+masksize / 2); y++)
                    mask[x + masksize / 2, y + masksize / 2] = mask[x + masksize / 2, y + masksize / 2] / sum;


            return mask;
        }
        public double[,] Gaussian_Filter_Option2(double sigma)
        {
            double sum = 0;
            double constant = 1 / (double)(2 * sigma * sigma * Math.PI);///error
            int N = Convert.ToInt32(3.7 * sigma - 0.5);
            int masksize = 2 * N + 1;
            mask = new double[masksize, masksize];
            for (int x = (-masksize / 2); x <= (masksize / 2); x++)
                for (int y = (-masksize / 2); y <= (masksize / 2); y++)
                {
                    mask[x + masksize / 2, y + masksize / 2] = constant * (double)Math.Exp(-((x * x) + (y * y)) / (2 * sigma * sigma));
                    sum += constant * (double)Math.Exp(-((x * x) + (y * y)) / (2 * sigma * sigma)); ;
                }
            sum += 0;
            return mask;
        }
        public double[,] lap()
        {
            mask = new double[3, 3];
            mask[0, 0] = 0; mask[0, 1] = -1; mask[0, 2] = 0;
            mask[1, 0] = -1;mask[1, 1] = 4; mask[1, 2] = -1;
            mask[2, 0] = 0; mask[2, 1] = -1; mask[2, 2] = 0;
            return mask;
        }
        public double[,] line_detect_Horizontal()
        {
            mask = new double[,] { { 1, 2, 1 }, 
                                  { 0, 0, 0 }, 
                               { -1, -2, -1 } };
            return mask;
        }
        public double[,] line_detect_vertical()
        {
            mask = new double[,] { { -1, 0, 1 },
                                { -2, 0, 2 }, 
                               { -1, 0, 1 } };
            return mask;
        }
    }
}
