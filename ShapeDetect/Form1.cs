using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ShapeDetect
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture = null;
        private bool _captureInProgress;
        private Mat _frame;
        private Mat _grayFrame;
        private Mat _smallGrayFrame;
        private Mat _smoothedGrayFrame;
        private Mat _cannyFrame;
        private Mat _circleImage;
        private Mat _resizedFrame;
        private Mat _triangleRectangleImage;

        IntPtr m_handle;    //连接标识

        private void Form1_Load(object sender, EventArgs e)
        {
            m_handle = (IntPtr)(0);
        }

        public Form1()
        {
            InitializeComponent();
            //CvInvoke.UseOpenCL = false;
            _frame = new Mat(); 
            _grayFrame = new Mat();
            _smallGrayFrame = new Mat();
            _smoothedGrayFrame = new Mat();
            _cannyFrame = new Mat();
            _resizedFrame = new Mat();

            _circleImage = new Mat();
            _triangleRectangleImage = new Mat();
        }
        /// <summary>
        /// 处理摄像头捕获的视频帧
        /// </summary>
        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                _capture.Retrieve(_frame, 0);

                CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);
                CvInvoke.PyrDown(_grayFrame, _smallGrayFrame);
                CvInvoke.PyrUp(_smallGrayFrame, _smoothedGrayFrame);

                double th1 = (double)canny_th1_UpDown.Value;
                double th2 = (double)canny_th2_UpDown.Value;
                CvInvoke.Canny(_smoothedGrayFrame, _cannyFrame, th1, th2);

                CvInvoke.Resize(_frame, _resizedFrame, rawImageBox.Size);
                rawImageBox.Image = _resizedFrame;
            }
        }
        /// <summary>
        /// 打开摄像头被点击
        /// </summary>
        private void 打开内部摄像头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_captureInProgress)
            {  //stop the capture
                camera_MenuItem.Text = "打开摄像头(自带)";
                _capture.Pause();
                process_timer.Stop();
                _capture.Dispose();
                excamera_MenuItem.Enabled = true;
            }
            else
            {
                //start the capture
                try
                {
                    _capture = new VideoCapture(0);
                    _capture.ImageGrabbed += ProcessFrame;
                }
                catch
                {
                    MessageBox.Show("打开自带摄像头失败");
                }
                camera_MenuItem.Text = "关闭摄像头(自带)";
                excamera_MenuItem.Enabled = false;
                _capture.Start();
                process_timer.Start();
            }

            _captureInProgress = !_captureInProgress;
        }
        private void 打开外部摄像头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_captureInProgress)
            {  //stop the capture
                excamera_MenuItem.Text = "打开摄像头(USB)";
                _capture.Pause();
                process_timer.Stop();
                _capture.Dispose();
                camera_MenuItem.Enabled = true;
            }
            else
            {
                //start the capture
                try
                {
                    _capture = new VideoCapture(1);
                    _capture.ImageGrabbed += ProcessFrame;
                }
                catch 
                {
                    MessageBox.Show("打开外部摄像头失败，请检查是否连接");
                }
                excamera_MenuItem.Text = "关闭摄像头(USB)";
                camera_MenuItem.Enabled = false;
                _capture.Start();
                process_timer.Start();
            }

            _captureInProgress = !_captureInProgress;
        }
        /// <summary>
        /// 图像处理定时器，定时响应函数，完成霍夫变换，矩形三角形检测
        /// </summary>
        private void ProcessTick(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();      //计时运算时间

            if (houghCircles_radioButton.Checked)
            {
                #region circle detection
                watch.Start();
                //霍夫圆变换的四个参数
                double cannyThreshold = (double)param1_UpDown.Value;
                double circleAccumulatorThreshold = (double)param2_UpDown.Value;
                double dp = (double)dp_UpDown.Value;
                double min_dist = (double)minDist_UpDown.Value;
                //霍夫圆变换检测圆形
                CircleF[] circles = CvInvoke.HoughCircles(_smoothedGrayFrame, HoughType.Gradient, 
                                            dp, min_dist, cannyThreshold, circleAccumulatorThreshold, 5);
                watch.Stop();
                houghTime_lab.Text = String.Format("耗时: {0} ms", watch.ElapsedMilliseconds);
                #endregion

                #region draw circles
                _frame.CopyTo(_circleImage);
                foreach (CircleF circle in circles)
                {
                    //构造字符串，包含圆心、半径信息
                    String centerText = String.Format(" ({0}, {1}, R={2})", circle.Center.X, circle.Center.Y, circle.Radius);
                    //在图像中绘制检测到的圆心（在圆心处画半径为1的圆）
                    CvInvoke.Circle(_circleImage, Point.Round(circle.Center), 1, new Bgr(Color.Red).MCvScalar, 2);
                    //在图像中绘制检测到的圆轮廓
                    CvInvoke.Circle(_circleImage, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Red).MCvScalar, 2);
                    //在圆心处显示圆心、半径信息
                    CvInvoke.PutText(_circleImage, centerText, Point.Round(circle.Center), 
                                        FontFace.HersheyPlain, 0.8, new Bgr(Color.DarkOrange).MCvScalar);                    
                }
                proImageBox.Image = _circleImage;
                #endregion
            }
            else if (rectDetect_radioButton.Checked)
            {
                #region Find triangles and rectangles
                watch.Reset(); watch.Start();
                //新建存储三角形圆形信息的两个List
                List<Triangle2DF> triangleList = new List<Triangle2DF>();
                List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(_cannyFrame, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    int count = contours.Size;
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                            {
                                if (approxContour.Size == 3) //The contour has 3 vertices, it is a triangle
                                {
                                    Point[] pts = approxContour.ToArray();
                                    triangleList.Add(new Triangle2DF(
                                        pts[0],
                                        pts[1],
                                        pts[2]
                                        ));
                                }
                                else if (approxContour.Size == 4) //The contour has 4 vertices.
                                {
                                    #region determine if all the angles in the contour are within [80, 100] degree
                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    for (int j = 0; j < edges.Length; j++)
                                    {
                                        double angle = Math.Abs(
                                            edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }
                                    #endregion

                                    if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                }
                            }
                        }
                    }
                }

                watch.Stop();
                rectTime_lab.Text = String.Format("耗时： {0} ms", watch.ElapsedMilliseconds);
                #endregion

                #region draw triangles and rectangles
                _frame.CopyTo(_triangleRectangleImage);
                foreach (Triangle2DF triangle in triangleList)
                {
                    CvInvoke.Polylines(_triangleRectangleImage, Array.ConvertAll(triangle.GetVertices(), Point.Round), true, new Bgr(Color.Blue).MCvScalar, 2);
                }
                foreach (RotatedRect box in boxList)
                {
                    CvInvoke.Polylines(_triangleRectangleImage, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.DarkOrange).MCvScalar, 2);
                }
                proImageBox.Image = _triangleRectangleImage;
                #endregion
            }
            else if (canny_radioButton.Checked)
            {
                proImageBox.Image = _cannyFrame;
            }
        }

        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_capture != null) _capture.FlipHorizontal = !_capture.FlipHorizontal;
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_capture != null) _capture.FlipVertical = !_capture.FlipVertical;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process_timer.Stop();
            ReleaseData();
            Close();
        }
        
        private void ReleaseData()
        {
            if (_capture != null)
                _capture.Dispose();
        }
    }
}
