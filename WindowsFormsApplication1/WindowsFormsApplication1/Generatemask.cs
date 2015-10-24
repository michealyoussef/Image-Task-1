using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Generatemask
    {
        public double[,] mask;

        public double[,] Generatingmean(int w, int h)
        {
            mask = new double[w, h];
            int mul = w * h;
            for (int s = 0; s < w; s++)
                for (int g = 0; g < h; g++)
                    mask[s, g] = 1 / mul;
            return mask;
        }
        public double[,] Gaussian_Filter_Option1(int masksize, int sigma)
        {
            mask = new double[masksize, masksize];
            double sum = 0;
            for (int x = (-masksize / 2); x <= (masksize / 2); x++)
                for (int y = (-masksize / 2); y <= (+masksize / 2); y++)
                {
                    mask[x + masksize / 2, y + masksize / 2] = Math.Pow(Math.E, -((x * x) + (y * y)) / (2 * sigma * sigma));
                    sum += mask[x + masksize / 2, y + masksize / 2];
                }

            for (int x = (-masksize / 2); x <= (masksize / 2); x++)
                for (int y = (-masksize / 2); y <= (+masksize / 2); y++)
                {
                    mask[x + masksize / 2, y + masksize / 2] = mask[x + masksize / 2, y + masksize / 2] / sum;

                }





            return mask;
        }
        public double[,] Gaussian_Filter_Option2(int sigma)
        {
            double constant = 1 / (2 * sigma * sigma*Math.PI);
            int N = Convert.ToInt32(3.7 * sigma - 0.5);
            int masksize = 2 * N + 1;
            mask = new double[masksize, masksize];
            for (int x = (-masksize / 2); x <= (masksize / 2); x++)
                for (int y = (-masksize / 2); y <= (+masksize / 2); y++)
                {
                    mask[x + masksize / 2, y + masksize / 2] = Math.Pow(Math.E, -((x * x) + (y * y)) / (2 * sigma * sigma));
                 
                }


            return mask;
        }
    }
}
