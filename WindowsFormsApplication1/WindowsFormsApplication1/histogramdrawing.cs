using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Histogramdrawing
    {
        public int[] Rarray;
        public int[] Garray;
        public int[] Barray;

        public Histogramdrawing(int maxintensity)
        {
            Rarray = new int[256];
            Garray = new int[256];
            Barray = new int[256];
        }
        public void drawing(Bitmap input_image)
        {
            int R, G, B;
            for (int i = 0; i < input_image.Height; i++)
            {
                for (int j = 0; j < input_image.Width; j++)
                {
                    R = input_image.GetPixel(j, i).R;
                    Rarray[R]++;
                    G = input_image.GetPixel(j, i).G;
                    Garray[G]++;
                    B = input_image.GetPixel(j, i).B;
                    Barray[B]++;
                }
            }
        }
        public void get_series_for_chart_component()
        {
            // return series array to be rendered in chart
        }


    }
}
