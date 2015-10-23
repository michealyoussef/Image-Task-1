using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    class Histogramdrawing
    {
        public int[] Rarray;
        public int[] Garray;
        public int[] Barray;

        public Histogramdrawing()
        {
            Rarray = new int[256];
            Garray = new int[256];
            Barray = new int[256];
            for(int u=0; u<256;u++)
            {
                Rarray[u] = 0;
                Garray[u] = 0;
                Barray[u] = 0;
            }
        }
        public void drawing(bufferedLockBitmap pixel, Chart chart1)
        {
            int R, G, B;
            for (int i = 0; i < pixel.Height; i++)
            {
                for (int j = 0; j <pixel.Width; j++)
                {
                    R = pixel.Getpixel(j,i).R;
                    Rarray[R]++;
                    G = pixel.Getpixel(j, i).G;
                    Garray[G]++;
                    B = pixel.Getpixel(j, i).B;
                    Barray[B]++;
                }
            }

            for (int w = 0; w < 256; w++)
            {
                chart1.Series["Red"].Points.AddXY(w, this.Rarray[w]);
                chart1.Series["Green"].Points.AddXY(w, this.Garray[w]);
                chart1.Series["Blue"].Points.AddXY(w, this.Barray[w]);

            }
            chart1.Series["Green"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Green"].Color = Color.Green;

            chart1.Series["Red"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Red"].Color = Color.Red;

            chart1.Series["Blue"].ChartType = SeriesChartType.SplineArea;
            chart1.Series["Blue"].Color = Color.Blue;

        }
        public void get_series_for_chart_component()
        {
            // return series array to be rendered in chart
        }


    }
}
