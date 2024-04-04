
namespace Sort_Algorithm_Visualizer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.arraySizeChanger = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.delayChanger = new System.Windows.Forms.NumericUpDown();
            this.resetButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.toggle3DButton = new System.Windows.Forms.Button();
            this.colorPickBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arraySizeChanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayChanger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Algorithm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(101, 10);
            this.comboBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(80, 21);
            this.comboBox.TabIndex = 2;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderlineColor = System.Drawing.Color.Maroon;
            this.chart.BorderlineWidth = 0;
            this.chart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Rotation = 15;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Bisque;
            chartArea1.AxisX2.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Bisque;
            chartArea1.AxisY.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Bisque;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY2.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Bisque;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(12, 83);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(984, 586);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBox);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.arraySizeChanger);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.delayChanger);
            this.flowLayoutPanel1.Controls.Add(this.resetButton);
            this.flowLayoutPanel1.Controls.Add(this.startButton);
            this.flowLayoutPanel1.Controls.Add(this.stopButton);
            this.flowLayoutPanel1.Controls.Add(this.toggle3DButton);
            this.flowLayoutPanel1.Controls.Add(this.colorPickBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1008, 40);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(186, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Elements:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // arraySizeChanger
            // 
            this.arraySizeChanger.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.arraySizeChanger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arraySizeChanger.ForeColor = System.Drawing.SystemColors.Window;
            this.arraySizeChanger.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.arraySizeChanger.Location = new System.Drawing.Point(277, 10);
            this.arraySizeChanger.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.arraySizeChanger.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.arraySizeChanger.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.arraySizeChanger.Name = "arraySizeChanger";
            this.arraySizeChanger.Size = new System.Drawing.Size(60, 20);
            this.arraySizeChanger.TabIndex = 18;
            this.arraySizeChanger.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(342, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Delay:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // delayChanger
            // 
            this.delayChanger.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.delayChanger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.delayChanger.ForeColor = System.Drawing.SystemColors.Window;
            this.delayChanger.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.delayChanger.Location = new System.Drawing.Point(405, 10);
            this.delayChanger.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.delayChanger.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.delayChanger.Name = "delayChanger";
            this.delayChanger.Size = new System.Drawing.Size(60, 20);
            this.delayChanger.TabIndex = 16;
            this.delayChanger.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Transparent;
            this.resetButton.BackgroundImage = global::Sort_Algorithm_Visualizer.Properties.Resources.reset_icon;
            this.resetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.resetButton.FlatAppearance.BorderSize = 0;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Location = new System.Drawing.Point(471, 7);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(25, 25);
            this.resetButton.TabIndex = 3;
            this.resetButton.UseVisualStyleBackColor = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.BackgroundImage = global::Sort_Algorithm_Visualizer.Properties.Resources.start_icon;
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(502, 7);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(25, 25);
            this.startButton.TabIndex = 5;
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Transparent;
            this.stopButton.BackgroundImage = global::Sort_Algorithm_Visualizer.Properties.Resources.stop_icon;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Location = new System.Drawing.Point(533, 7);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(25, 25);
            this.stopButton.TabIndex = 6;
            this.stopButton.UseVisualStyleBackColor = false;
            // 
            // toggle3DButton
            // 
            this.toggle3DButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toggle3DButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggle3DButton.Location = new System.Drawing.Point(564, 8);
            this.toggle3DButton.Name = "toggle3DButton";
            this.toggle3DButton.Size = new System.Drawing.Size(75, 23);
            this.toggle3DButton.TabIndex = 13;
            this.toggle3DButton.Text = "Enable 3D";
            this.toggle3DButton.UseVisualStyleBackColor = false;
            // 
            // colorPickBox
            // 
            this.colorPickBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
            this.colorPickBox.Location = new System.Drawing.Point(645, 8);
            this.colorPickBox.Name = "colorPickBox";
            this.colorPickBox.Size = new System.Drawing.Size(50, 23);
            this.colorPickBox.TabIndex = 14;
            this.colorPickBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Sort Algorhitm Visualizer";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arraySizeChanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayChanger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button toggle3DButton;
        private System.Windows.Forms.PictureBox colorPickBox;
        private System.Windows.Forms.NumericUpDown delayChanger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown arraySizeChanger;
    }
}