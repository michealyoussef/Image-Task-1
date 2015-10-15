using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    /**
     * @author Mustafa Qamar-ud-Din <mustafa.mahrous.89@gmail.com>
     */
    class ImageTransformations
    {
        public ImageTransformations()
        {
        }

        public bufferedLockBitmap translate(bufferedLockBitmap _input_image, int _trans_x, int _trans_y)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            return ret;
        }

        public bufferedLockBitmap scale(bufferedLockBitmap _input_image, double _scale_x, int _scale_y)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            return ret;
        }

        public bufferedLockBitmap rotate(bufferedLockBitmap _input_image, double _angle_theta)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            return ret;
        }
    }
}
