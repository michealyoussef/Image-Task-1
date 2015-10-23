using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace TestMatrixTransformations
{
    class ImageMatrixTransformations
    {
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
        public Bitmap perform_concat_matrices_operations(bufferedLockBitmap _src_img, float _shear_x = (float)0, float _shear_y = (float)0, float _scale_x = (float)1, float _scale_y = (float)1, float _rotate_theta = (float)0)
        {
                  bufferedLockBitmap ret;
            
            // 1 - Create new object with identity matrix (empty constructor)
            Matrix transformations_matrix = new Matrix();
            // 2 - Apply a set of transformations that you want to this matrix
            transformations_matrix.Rotate(_rotate_theta);
            transformations_matrix.Scale(_scale_x, _scale_y);
            transformations_matrix.Shear(_shear_x, _shear_y);
            // 3 - Transform the four corners of the original image to calculate
            /**
             * To get the size of the new (destination) image,
             * apply the forward mapping to the four corners of the original image
             * ([0,0], [W-1,0], [0,H-1], [W-1,H-1])
             * to get their new locations.
             * Then use these new four locations to get the width and height of the destination image
             * (e.g. to get new width:
             * find min X & max X of the four new points and subtract them,
             * do the same for Y to get the new height)
             */
            Point[] corner_points = {
                                        new Point(0, 0),
                                        new Point(_src_img.source.Width - 1, 0),
                                        new Point(0, _src_img.source.Height - 1),
                                        new Point(_src_img.source.Width - 1, _src_img.source.Height - 1)
                                    };

            transformations_matrix.TransformPoints(corner_points);

            int min_x = find_min_x(corner_points);
            int min_y = find_min_y(corner_points);

            int max_x = find_max_x(corner_points);
            int max_y = find_max_y(corner_points);

            int new_width = max_x - min_x;
            int new_height = max_y - min_y;

            // 4 - The min X and min Y of the transformed image
            /**
             * To make the transformed image totally fit inside the buffer, a translation with (- min X, - min Y) should be appended to the original transformation matrix (W) before inverting it.
             */

            // 6 - Translate this matrix by (- min X, - min Y)
            transformations_matrix.Translate(-min_x, -min_y);

            // 7 - Invert the matrix
            transformations_matrix.Invert();

            // 8 - Use the inverted version to reverse transform all new locations in the new image buffer
            return apply_transformation_matrix_to_bitmap_or_buffer(transformations_matrix, _src_img, new_width, new_height).source2;
            
        }

        public int find_min_x(Point[] _hay_stack)
        {
            int ret = int.MaxValue;
            for (int i = 0; i < _hay_stack.Length; i++)
            {
                if (_hay_stack[i].X < ret)
                    ret = _hay_stack[i].X;
            }
            return ret;
        }

        public int find_min_y(Point[] _hay_stack)
        {
            int ret = int.MaxValue;
            for (int i = 0; i < _hay_stack.Length; i++)
            {
                if (_hay_stack[i].Y < ret)
                    ret = _hay_stack[i].X;
            }
            return ret;
        }

        public int find_max_x(Point[] _hay_stack)
        {
            int ret = int.MinValue;
            for (int i = 0; i < _hay_stack.Length; i++)
            {
                if (_hay_stack[i].X > ret)
                    ret = _hay_stack[i].X;
            }
            return ret;
        }

        public int find_max_y(Point[] _hay_stack)
        {
            int ret = int.MinValue;
            for (int i = 0; i < _hay_stack.Length; i++)
            {
                if (_hay_stack[i].Y > ret)
                    ret = _hay_stack[i].X;
            }
            return ret;
        }

        /**
        For each pixel location in the new buffer P' (NewX, NewY), do:
            Find corresponding old location, P = W-1.P'
            Validate that this old location lie inside the original image boundary (i.e. 0 ≤ OldX < W,  0  ≤ Old Y < H). Otherwise, set the new empty pixel to 0 and continue to next location.
            If Validated, apply Bilinear Interpolation Algorithm to get the new pixel value, as follows:(Refer to above figure)
                */
        public bufferedLockBitmap apply_transformation_matrix_to_bitmap_or_buffer(Matrix _transformations_matrix, bufferedLockBitmap _src_img, int _new_width, int _new_height)
        {
            Bitmap temp = new Bitmap(_new_width, _new_height);
            bufferedLockBitmap ret = new bufferedLockBitmap(temp);
            ret.LockBits();
            BilinearInterpolation obj_bi_lin_interpol = new BilinearInterpolation();
            for (int i = 0; i < _new_width; i++)
            {
                for (int j = 0; j < _new_height; j++)
                {
                    PointF[] points = {
                                          new PointF(i, j)
                                      };
                    _transformations_matrix.TransformPoints(points);


                    Color _color = Color.FromArgb(0);
                    if (points[0].X >= 0 && points[0].X < _src_img.source.Width && points[0].Y >= 0 && points[0].Y < _src_img.source.Height)
                        _color = obj_bi_lin_interpol.calculate(_src_img, points[0].X, points[0].Y);
                    ret.SetPixel(i, j, _color);
                }
            }
            ret.UnlockBits();
            return ret;
        }

    }
}
