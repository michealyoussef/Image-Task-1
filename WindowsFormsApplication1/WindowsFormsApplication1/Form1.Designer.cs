namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.with255ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filppingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filpHorizontalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filpVerticalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplasinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelFilterslineDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalLineDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelEdgeMagnitudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bluringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanFilter1DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanFilter2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianoption1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianOption2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ch2 = new System.Windows.Forms.CheckBox();
            this.ch3 = new System.Windows.Forms.CheckBox();
            this.ch1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.calculationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1274, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 55);
            this.button5.TabIndex = 5;
            this.button5.Text = "Scale";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1263, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Rotate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1263, 140);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(64, 47);
            this.button7.TabIndex = 7;
            this.button7.Text = "shearing";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1252, 232);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "ALL";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1169, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 20);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1169, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(81, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1098, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Size X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1098, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Size Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1098, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Angle";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1169, 96);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(81, 20);
            this.textBox3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1098, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sh Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1102, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "Sh X";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1169, 140);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(81, 20);
            this.textBox4.TabIndex = 17;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1169, 196);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(81, 20);
            this.textBox5.TabIndex = 16;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.fileToolStripMenuItem.AutoSize = false;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.saveToolStripMenuItem.Text = "Save AS";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationToolStripMenuItem,
            this.filteringToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1354, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.operationToolStripMenuItem.AutoSize = false;
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adjustmentToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.nOTToolStripMenuItem,
            this.aDDToolStripMenuItem,
            this.subtractionToolStripMenuItem,
            this.quanToolStripMenuItem,
            this.filppingToolStripMenuItem,
            this.calculationToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.operationToolStripMenuItem.Text = "Operations";
            // 
            // adjustmentToolStripMenuItem
            // 
            this.adjustmentToolStripMenuItem.Name = "adjustmentToolStripMenuItem";
            this.adjustmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.adjustmentToolStripMenuItem.Text = "Adjustment";
            this.adjustmentToolStripMenuItem.Click += new System.EventHandler(this.adjustmentToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.grayscaleToolStripMenuItem.AutoSize = false;
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.nOTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.with255ToolStripMenuItem,
            this.withInputToolStripMenuItem});
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nOTToolStripMenuItem.Text = "NOT ";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.nOTToolStripMenuItem_Click);
            // 
            // with255ToolStripMenuItem
            // 
            this.with255ToolStripMenuItem.Name = "with255ToolStripMenuItem";
            this.with255ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.with255ToolStripMenuItem.Text = "with 255";
            this.with255ToolStripMenuItem.Click += new System.EventHandler(this.with255ToolStripMenuItem_Click);
            // 
            // withInputToolStripMenuItem
            // 
            this.withInputToolStripMenuItem.Name = "withInputToolStripMenuItem";
            this.withInputToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.withInputToolStripMenuItem.Text = "with input";
            this.withInputToolStripMenuItem.Click += new System.EventHandler(this.withInputToolStripMenuItem_Click);
            // 
            // aDDToolStripMenuItem
            // 
            this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
            this.aDDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aDDToolStripMenuItem.Text = "Addition";
            this.aDDToolStripMenuItem.Click += new System.EventHandler(this.aDDToolStripMenuItem_Click);
            // 
            // subtractionToolStripMenuItem
            // 
            this.subtractionToolStripMenuItem.Name = "subtractionToolStripMenuItem";
            this.subtractionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.subtractionToolStripMenuItem.Text = "Subtraction";
            this.subtractionToolStripMenuItem.Click += new System.EventHandler(this.subtractionToolStripMenuItem_Click);
            // 
            // quanToolStripMenuItem
            // 
            this.quanToolStripMenuItem.Name = "quanToolStripMenuItem";
            this.quanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quanToolStripMenuItem.Text = "Quantization";
            this.quanToolStripMenuItem.Click += new System.EventHandler(this.quanToolStripMenuItem_Click);
            // 
            // filppingToolStripMenuItem
            // 
            this.filppingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filpHorizontalToolStripMenuItem1,
            this.filpVerticalToolStripMenuItem1});
            this.filppingToolStripMenuItem.Name = "filppingToolStripMenuItem";
            this.filppingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filppingToolStripMenuItem.Text = "Filpping";
            // 
            // filpHorizontalToolStripMenuItem1
            // 
            this.filpHorizontalToolStripMenuItem1.Name = "filpHorizontalToolStripMenuItem1";
            this.filpHorizontalToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.filpHorizontalToolStripMenuItem1.Text = "Filp Horizontal";
            this.filpHorizontalToolStripMenuItem1.Click += new System.EventHandler(this.filpHorizontalToolStripMenuItem1_Click);
            // 
            // filpVerticalToolStripMenuItem1
            // 
            this.filpVerticalToolStripMenuItem1.Name = "filpVerticalToolStripMenuItem1";
            this.filpVerticalToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.filpVerticalToolStripMenuItem1.Text = "Filp Vertical";
            this.filpVerticalToolStripMenuItem1.Click += new System.EventHandler(this.filpVerticalToolStripMenuItem1_Click);
            // 
            // filteringToolStripMenuItem
            // 
            this.filteringToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.filteringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sharpungToolStripMenuItem,
            this.bluringToolStripMenuItem});
            this.filteringToolStripMenuItem.Name = "filteringToolStripMenuItem";
            this.filteringToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filteringToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.filteringToolStripMenuItem.Text = "Filtering";
            // 
            // sharpungToolStripMenuItem
            // 
            this.sharpungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laplasinToolStripMenuItem,
            this.sobelFilterslineDetectionToolStripMenuItem,
            this.verticalLineDetectionToolStripMenuItem,
            this.sobelEdgeMagnitudeToolStripMenuItem});
            this.sharpungToolStripMenuItem.Name = "sharpungToolStripMenuItem";
            this.sharpungToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sharpungToolStripMenuItem.Text = "Sharpening";
            // 
            // laplasinToolStripMenuItem
            // 
            this.laplasinToolStripMenuItem.Name = "laplasinToolStripMenuItem";
            this.laplasinToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.laplasinToolStripMenuItem.Text = "Laplacian";
            this.laplasinToolStripMenuItem.Click += new System.EventHandler(this.laplasinToolStripMenuItem_Click);
            // 
            // sobelFilterslineDetectionToolStripMenuItem
            // 
            this.sobelFilterslineDetectionToolStripMenuItem.Name = "sobelFilterslineDetectionToolStripMenuItem";
            this.sobelFilterslineDetectionToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.sobelFilterslineDetectionToolStripMenuItem.Text = "Sobel filters (Horzontal line detection)";
            this.sobelFilterslineDetectionToolStripMenuItem.Click += new System.EventHandler(this.sobelFilterslineDetectionToolStripMenuItem_Click);
            // 
            // verticalLineDetectionToolStripMenuItem
            // 
            this.verticalLineDetectionToolStripMenuItem.Name = "verticalLineDetectionToolStripMenuItem";
            this.verticalLineDetectionToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.verticalLineDetectionToolStripMenuItem.Text = "Sobel filters(Vertical line detection)";
            this.verticalLineDetectionToolStripMenuItem.Click += new System.EventHandler(this.verticalLineDetectionToolStripMenuItem_Click);
            // 
            // sobelEdgeMagnitudeToolStripMenuItem
            // 
            this.sobelEdgeMagnitudeToolStripMenuItem.Name = "sobelEdgeMagnitudeToolStripMenuItem";
            this.sobelEdgeMagnitudeToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.sobelEdgeMagnitudeToolStripMenuItem.Text = "Sobel Edge Magnitude";
            this.sobelEdgeMagnitudeToolStripMenuItem.Click += new System.EventHandler(this.sobelEdgeMagnitudeToolStripMenuItem_Click);
            // 
            // bluringToolStripMenuItem
            // 
            this.bluringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meanFilter1DToolStripMenuItem,
            this.meanFilter2DToolStripMenuItem,
            this.gaussianoption1ToolStripMenuItem,
            this.gaussianOption2ToolStripMenuItem});
            this.bluringToolStripMenuItem.Name = "bluringToolStripMenuItem";
            this.bluringToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bluringToolStripMenuItem.Text = "Bluring";
            // 
            // meanFilter1DToolStripMenuItem
            // 
            this.meanFilter1DToolStripMenuItem.Name = "meanFilter1DToolStripMenuItem";
            this.meanFilter1DToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.meanFilter1DToolStripMenuItem.Text = "Mean Filter 1D";
            this.meanFilter1DToolStripMenuItem.Click += new System.EventHandler(this.meanFilter1DToolStripMenuItem_Click);
            // 
            // meanFilter2DToolStripMenuItem
            // 
            this.meanFilter2DToolStripMenuItem.Name = "meanFilter2DToolStripMenuItem";
            this.meanFilter2DToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.meanFilter2DToolStripMenuItem.Text = "Mean Filter 2D";
            this.meanFilter2DToolStripMenuItem.Click += new System.EventHandler(this.meanFilter2DToolStripMenuItem_Click);
            // 
            // gaussianoption1ToolStripMenuItem
            // 
            this.gaussianoption1ToolStripMenuItem.Name = "gaussianoption1ToolStripMenuItem";
            this.gaussianoption1ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.gaussianoption1ToolStripMenuItem.Text = "Gaussian [Option 1]";
            this.gaussianoption1ToolStripMenuItem.Click += new System.EventHandler(this.gaussianoption1ToolStripMenuItem_Click);
            // 
            // gaussianOption2ToolStripMenuItem
            // 
            this.gaussianOption2ToolStripMenuItem.Name = "gaussianOption2ToolStripMenuItem";
            this.gaussianOption2ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.gaussianOption2ToolStripMenuItem.Text = "Gaussian [Option 2]";
            this.gaussianOption2ToolStripMenuItem.Click += new System.EventHandler(this.gaussianOption2ToolStripMenuItem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(883, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Additon";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(993, 320);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(71, 20);
            this.textBox6.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(868, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Bit-plane slicing";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(993, 357);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(71, 20);
            this.textBox7.TabIndex = 37;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1070, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 38;
            this.button3.Text = "GO";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(740, 443);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Red";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Green";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Blue";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(610, 272);
            this.chart1.TabIndex = 45;
            this.chart1.Text = "chart1";
            // 
            // ch2
            // 
            this.ch2.AutoSize = true;
            this.ch2.Location = new System.Drawing.Point(1172, 361);
            this.ch2.Name = "ch2";
            this.ch2.Size = new System.Drawing.Size(55, 17);
            this.ch2.TabIndex = 47;
            this.ch2.Text = "Green";
            this.ch2.UseVisualStyleBackColor = true;
            // 
            // ch3
            // 
            this.ch3.AutoSize = true;
            this.ch3.Location = new System.Drawing.Point(1181, 384);
            this.ch3.Name = "ch3";
            this.ch3.Size = new System.Drawing.Size(47, 17);
            this.ch3.TabIndex = 48;
            this.ch3.Text = "Blue";
            this.ch3.UseVisualStyleBackColor = true;
            // 
            // ch1
            // 
            this.ch1.AutoSize = true;
            this.ch1.Location = new System.Drawing.Point(1181, 338);
            this.ch1.Name = "ch1";
            this.ch1.Size = new System.Drawing.Size(46, 17);
            this.ch1.TabIndex = 49;
            this.ch1.Text = "Red";
            this.ch1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 462);
            this.tabControl1.TabIndex = 52;
            // 
            // calculationToolStripMenuItem
            // 
            this.calculationToolStripMenuItem.Name = "calculationToolStripMenuItem";
            this.calculationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.calculationToolStripMenuItem.Text = "Calculation";
            this.calculationToolStripMenuItem.Click += new System.EventHandler(this.calculationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1354, 720);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ch1);
            this.Controls.Add(this.ch3);
            this.Controls.Add(this.ch2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nOTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractionToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox ch2;
        private System.Windows.Forms.CheckBox ch3;
        private System.Windows.Forms.CheckBox ch1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplasinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bluringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanFilter1DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanFilter2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelFilterslineDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalLineDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelEdgeMagnitudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianoption1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianOption2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filppingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filpHorizontalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filpVerticalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem with255ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustmentToolStripMenuItem;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem calculationToolStripMenuItem;
    }
}

