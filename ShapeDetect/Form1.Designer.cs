namespace ShapeDetect
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rawImageBox = new Emgu.CV.UI.ImageBox();
            this.proImageBox = new Emgu.CV.UI.ImageBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.输入源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.camera_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excamera_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipH_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipV_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.connect_btn = new System.Windows.Forms.Button();
            this.state_lab = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ip_tbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.process_timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rectDetect_radioButton = new System.Windows.Forms.RadioButton();
            this.houghCircles_radioButton = new System.Windows.Forms.RadioButton();
            this.canny_radioButton = new System.Windows.Forms.RadioButton();
            this.minDist_UpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.dp_UpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.param2_UpDown = new System.Windows.Forms.NumericUpDown();
            this.param1_UpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.houghTime_lab = new System.Windows.Forms.Label();
            this.canny_th2_UpDown = new System.Windows.Forms.NumericUpDown();
            this.canny_th1_UpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rectTime_lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rawImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDist_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.param2_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.param1_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canny_th2_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canny_th1_UpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // rawImageBox
            // 
            this.rawImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawImageBox.Location = new System.Drawing.Point(3, 17);
            this.rawImageBox.Name = "rawImageBox";
            this.rawImageBox.Size = new System.Drawing.Size(249, 184);
            this.rawImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.rawImageBox.TabIndex = 2;
            this.rawImageBox.TabStop = false;
            // 
            // proImageBox
            // 
            this.proImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proImageBox.Location = new System.Drawing.Point(3, 17);
            this.proImageBox.Name = "proImageBox";
            this.proImageBox.Size = new System.Drawing.Size(640, 480);
            this.proImageBox.TabIndex = 2;
            this.proImageBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rawImageBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 204);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原始图像";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.proImageBox);
            this.groupBox2.Location = new System.Drawing.Point(273, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 500);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "处理后图像";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.输入源ToolStripMenuItem,
            this.图像操作ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 输入源ToolStripMenuItem
            // 
            this.输入源ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.camera_MenuItem,
            this.excamera_MenuItem,
            this.exit_MenuItem});
            this.输入源ToolStripMenuItem.Name = "输入源ToolStripMenuItem";
            this.输入源ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.输入源ToolStripMenuItem.Text = "输入源";
            // 
            // camera_MenuItem
            // 
            this.camera_MenuItem.Name = "camera_MenuItem";
            this.camera_MenuItem.Size = new System.Drawing.Size(168, 22);
            this.camera_MenuItem.Text = "打开摄像头(自带)";
            this.camera_MenuItem.Click += new System.EventHandler(this.打开内部摄像头ToolStripMenuItem_Click);
            // 
            // excamera_MenuItem
            // 
            this.excamera_MenuItem.Name = "excamera_MenuItem";
            this.excamera_MenuItem.Size = new System.Drawing.Size(168, 22);
            this.excamera_MenuItem.Text = "打开摄像头(USB)";
            this.excamera_MenuItem.Click += new System.EventHandler(this.打开外部摄像头ToolStripMenuItem_Click);
            // 
            // exit_MenuItem
            // 
            this.exit_MenuItem.Name = "exit_MenuItem";
            this.exit_MenuItem.Size = new System.Drawing.Size(168, 22);
            this.exit_MenuItem.Text = "退出";
            this.exit_MenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 图像操作ToolStripMenuItem
            // 
            this.图像操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipH_MenuItem,
            this.flipV_MenuItem});
            this.图像操作ToolStripMenuItem.Name = "图像操作ToolStripMenuItem";
            this.图像操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.图像操作ToolStripMenuItem.Text = "图像操作";
            // 
            // flipH_MenuItem
            // 
            this.flipH_MenuItem.Name = "flipH_MenuItem";
            this.flipH_MenuItem.Size = new System.Drawing.Size(152, 22);
            this.flipH_MenuItem.Text = "水平翻转";
            this.flipH_MenuItem.Click += new System.EventHandler(this.水平翻转ToolStripMenuItem_Click);
            // 
            // flipV_MenuItem
            // 
            this.flipV_MenuItem.Name = "flipV_MenuItem";
            this.flipV_MenuItem.Size = new System.Drawing.Size(152, 22);
            this.flipV_MenuItem.Text = "垂直翻转";
            this.flipV_MenuItem.Click += new System.EventHandler(this.垂直翻转ToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.connect_btn);
            this.groupBox3.Controls.Add(this.state_lab);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ip_tbx);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 67);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "连接运动控制器";
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(172, 17);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(75, 23);
            this.connect_btn.TabIndex = 4;
            this.connect_btn.Text = "连接设备";
            this.connect_btn.UseVisualStyleBackColor = true;
            // 
            // state_lab
            // 
            this.state_lab.AutoSize = true;
            this.state_lab.Location = new System.Drawing.Point(109, 47);
            this.state_lab.Name = "state_lab";
            this.state_lab.Size = new System.Drawing.Size(41, 12);
            this.state_lab.TabIndex = 3;
            this.state_lab.Text = "未连接";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "连接状态：";
            // 
            // ip_tbx
            // 
            this.ip_tbx.Location = new System.Drawing.Point(66, 18);
            this.ip_tbx.Name = "ip_tbx";
            this.ip_tbx.Size = new System.Drawing.Size(100, 21);
            this.ip_tbx.TabIndex = 1;
            this.ip_tbx.Text = "192.168.1.11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备IP：";
            // 
            // process_timer
            // 
            this.process_timer.Tick += new System.EventHandler(this.ProcessTick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rectDetect_radioButton);
            this.groupBox4.Controls.Add(this.houghCircles_radioButton);
            this.groupBox4.Controls.Add(this.canny_radioButton);
            this.groupBox4.Controls.Add(this.minDist_UpDown);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dp_UpDown);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.param2_UpDown);
            this.groupBox4.Controls.Add(this.param1_UpDown);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.houghTime_lab);
            this.groupBox4.Controls.Add(this.canny_th2_UpDown);
            this.groupBox4.Controls.Add(this.canny_th1_UpDown);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.rectTime_lab);
            this.groupBox4.Location = new System.Drawing.Point(12, 311);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 217);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "图像处理";
            // 
            // rectDetect_radioButton
            // 
            this.rectDetect_radioButton.AutoSize = true;
            this.rectDetect_radioButton.Location = new System.Drawing.Point(9, 163);
            this.rectDetect_radioButton.Name = "rectDetect_radioButton";
            this.rectDetect_radioButton.Size = new System.Drawing.Size(119, 16);
            this.rectDetect_radioButton.TabIndex = 29;
            this.rectDetect_radioButton.Text = "矩形及三角形检测";
            this.rectDetect_radioButton.UseVisualStyleBackColor = true;
            // 
            // houghCircles_radioButton
            // 
            this.houghCircles_radioButton.AutoSize = true;
            this.houghCircles_radioButton.Location = new System.Drawing.Point(9, 77);
            this.houghCircles_radioButton.Name = "houghCircles_radioButton";
            this.houghCircles_radioButton.Size = new System.Drawing.Size(83, 16);
            this.houghCircles_radioButton.TabIndex = 28;
            this.houghCircles_radioButton.Text = "霍夫圆变换";
            this.houghCircles_radioButton.UseVisualStyleBackColor = true;
            // 
            // canny_radioButton
            // 
            this.canny_radioButton.AutoSize = true;
            this.canny_radioButton.Checked = true;
            this.canny_radioButton.Location = new System.Drawing.Point(9, 20);
            this.canny_radioButton.Name = "canny_radioButton";
            this.canny_radioButton.Size = new System.Drawing.Size(101, 16);
            this.canny_radioButton.TabIndex = 27;
            this.canny_radioButton.TabStop = true;
            this.canny_radioButton.Text = "Canny边缘检测";
            this.canny_radioButton.UseVisualStyleBackColor = true;
            // 
            // minDist_UpDown
            // 
            this.minDist_UpDown.DecimalPlaces = 1;
            this.minDist_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.minDist_UpDown.Location = new System.Drawing.Point(183, 96);
            this.minDist_UpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.minDist_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minDist_UpDown.Name = "minDist_UpDown";
            this.minDist_UpDown.Size = new System.Drawing.Size(44, 21);
            this.minDist_UpDown.TabIndex = 25;
            this.minDist_UpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            65536});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "min_dist：";
            // 
            // dp_UpDown
            // 
            this.dp_UpDown.DecimalPlaces = 1;
            this.dp_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dp_UpDown.Location = new System.Drawing.Point(72, 96);
            this.dp_UpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dp_UpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dp_UpDown.Name = "dp_UpDown";
            this.dp_UpDown.Size = new System.Drawing.Size(44, 21);
            this.dp_UpDown.TabIndex = 23;
            this.dp_UpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "dp：";
            // 
            // param2_UpDown
            // 
            this.param2_UpDown.Location = new System.Drawing.Point(183, 123);
            this.param2_UpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.param2_UpDown.Name = "param2_UpDown";
            this.param2_UpDown.Size = new System.Drawing.Size(44, 21);
            this.param2_UpDown.TabIndex = 20;
            this.param2_UpDown.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // param1_UpDown
            // 
            this.param1_UpDown.Location = new System.Drawing.Point(72, 123);
            this.param1_UpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.param1_UpDown.Name = "param1_UpDown";
            this.param1_UpDown.Size = new System.Drawing.Size(44, 21);
            this.param1_UpDown.TabIndex = 19;
            this.param1_UpDown.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "参数2：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "参数1：";
            // 
            // houghTime_lab
            // 
            this.houghTime_lab.AutoSize = true;
            this.houghTime_lab.Location = new System.Drawing.Point(99, 79);
            this.houghTime_lab.Name = "houghTime_lab";
            this.houghTime_lab.Size = new System.Drawing.Size(41, 12);
            this.houghTime_lab.TabIndex = 10;
            this.houghTime_lab.Text = "耗时：";
            // 
            // canny_th2_UpDown
            // 
            this.canny_th2_UpDown.Location = new System.Drawing.Point(183, 38);
            this.canny_th2_UpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.canny_th2_UpDown.Name = "canny_th2_UpDown";
            this.canny_th2_UpDown.Size = new System.Drawing.Size(44, 21);
            this.canny_th2_UpDown.TabIndex = 16;
            this.canny_th2_UpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // canny_th1_UpDown
            // 
            this.canny_th1_UpDown.Location = new System.Drawing.Point(72, 38);
            this.canny_th1_UpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.canny_th1_UpDown.Name = "canny_th1_UpDown";
            this.canny_th1_UpDown.Size = new System.Drawing.Size(44, 21);
            this.canny_th1_UpDown.TabIndex = 14;
            this.canny_th1_UpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "阈值2：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "阈值1：";
            // 
            // rectTime_lab
            // 
            this.rectTime_lab.AutoSize = true;
            this.rectTime_lab.Location = new System.Drawing.Point(135, 165);
            this.rectTime_lab.Name = "rectTime_lab";
            this.rectTime_lab.Size = new System.Drawing.Size(41, 12);
            this.rectTime_lab.TabIndex = 13;
            this.rectTime_lab.Text = "耗时：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(929, 540);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "图形识别及跟踪调试软件";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rawImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minDist_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dp_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.param2_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.param1_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canny_th2_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canny_th1_UpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox rawImageBox;
        private Emgu.CV.UI.ImageBox proImageBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 输入源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem camera_MenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.Label state_lab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip_tbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer process_timer;
        private System.Windows.Forms.ToolStripMenuItem 图像操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipH_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipV_MenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label houghTime_lab;
        private System.Windows.Forms.Label rectTime_lab;
        private System.Windows.Forms.NumericUpDown canny_th1_UpDown;
        private System.Windows.Forms.NumericUpDown canny_th2_UpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown param2_UpDown;
        private System.Windows.Forms.NumericUpDown param1_UpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown minDist_UpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown dp_UpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rectDetect_radioButton;
        private System.Windows.Forms.RadioButton houghCircles_radioButton;
        private System.Windows.Forms.RadioButton canny_radioButton;
        private System.Windows.Forms.ToolStripMenuItem excamera_MenuItem;
    }
}

