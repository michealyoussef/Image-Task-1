using System;
using System.Collections.Generic;
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
            Rarray = new int[maxintensity+1];
            Garray = new int[maxintensity+1];
            Barray = new int[maxintensity+1];
        }
        public void drawing(bufferedLockBitmap input_image)
        {




        }

        public void get_series_for_chart_component()
        {
            // return series array to be rendered in chart in ui
        }

        
    }
}
