using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

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

        public bufferedLockBitmap scale(bufferedLockBitmap _input_image, float _scale_x, int _scale_y)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            return ret;
        }

        public bufferedLockBitmap rotate(bufferedLockBitmap _input_image, float _angle_theta)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            return ret;
        }

        public bufferedLockBitmap shear(bufferedLockBitmap _input_image, float _shear_x, int _shear_y)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            return ret;
        }

        public bufferedLockBitmap concatenated(bufferedLockBitmap _input_image, float _scale_x, int _scale_y, int _shear_x, int _shear_y, float _angle_theta)
        {
            Bitmap bmp = new Bitmap(_input_image.Width, _input_image.Height);
            bufferedLockBitmap ret = new bufferedLockBitmap(bmp);
            /**
                You can use this matrix as follows:
                1 - Create new object with identity matrix (empty constructor)
                2 - Apply a set of transformations that you want to this matrix
                3 - Transform the four corners of the original image to calculate 
                4 - The min X and min Y of the transformed image
                5 - The width & height of the new image buffer
                6 - Translate this matrix by (- min X, - min Y)
                7 - Invert the matrix
                8 - Use the inverted version to reverse transform all new locations in the new image buffer
            **/
            // 1 - Create new object with identity matrix (empty constructor)
            Matrix transformation_matrix = new Matrix();
            // 2 - Apply a set of transformations that you want to this matrix
            transformation_matrix.Rotate(_angle_theta);
            transformation_matrix.Scale(_scale_x, _scale_y);
            transformation_matrix.Shear(_shear_x, _shear_y);
            // 3 - Transform the four corners of the original image to calculate
            
            return ret;
        }

        public Matrix get_translation_matrix(bufferedLockBitmap _input_image, int _trans_x, int _trans_y, bool inverse = false)
        {
            Matrix ret = new Matrix();
            ret.Translate(_trans_x, _trans_y);
            return ret;
        }

        public Matrix get_scaling_matrix(bufferedLockBitmap _input_image, float _scale_x, int _scale_y, bool inverse = false)
        {
            Matrix ret = new Matrix();
            return ret;
        }

        public Matrix get_rotation_matrix(bufferedLockBitmap _input_image, float _angle_theta, bool inverse = false)
        {
            Matrix ret = new Matrix();
            return ret;
        }

        public Matrix get_shear_matrix(bufferedLockBitmap _input_image, float _shear_x, float _shear_y, bool inverse = false)
        {
            Matrix ret = new Matrix();
            return ret;
        }

    }
}
