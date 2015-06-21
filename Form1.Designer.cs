using System.Windows.Forms.DataVisualization.Charting;
namespace CompresserClient
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
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button1 = new System.Windows.Forms.Button();
			this.checkboxLZW = new System.Windows.Forms.CheckBox();
			this.checkboxRLE = new System.Windows.Forms.CheckBox();
			this.checkboxMULAW = new System.Windows.Forms.CheckBox();
			this.checkboxSMART = new System.Windows.Forms.CheckBox();
			this.radioButtonTime = new System.Windows.Forms.RadioButton();
			this.radioButtonSize = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkboxHuffman = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(12, 1);
			this.chart1.Name = "chart1";
			series1.BorderWidth = 4;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "RLE";
			series2.BorderWidth = 4;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "LZW";
			series3.BorderWidth = 4;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Legend = "Legend1";
			series3.Name = "HUFFMAN";
			series4.BorderWidth = 4;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.Color = System.Drawing.Color.Orchid;
			series4.Legend = "Legend1";
			series4.Name = "MULAW";
			series5.BorderWidth = 4;
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series5.Color = System.Drawing.Color.ForestGreen;
			series5.Legend = "Legend1";
			series5.Name = "SMART";
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Series.Add(series3);
			this.chart1.Series.Add(series4);
			this.chart1.Series.Add(series5);
			this.chart1.Size = new System.Drawing.Size(1300, 800);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1161, 456);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(90, 28);
			this.button1.TabIndex = 1;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkboxLZW
			// 
			this.checkboxLZW.AutoSize = true;
			this.checkboxLZW.Location = new System.Drawing.Point(1175, 204);
			this.checkboxLZW.Name = "checkboxLZW";
			this.checkboxLZW.Size = new System.Drawing.Size(50, 17);
			this.checkboxLZW.TabIndex = 2;
			this.checkboxLZW.Text = "LZW";
			this.checkboxLZW.UseVisualStyleBackColor = true;
			// 
			// checkboxRLE
			// 
			this.checkboxRLE.AutoSize = true;
			this.checkboxRLE.Location = new System.Drawing.Point(1174, 181);
			this.checkboxRLE.Name = "checkboxRLE";
			this.checkboxRLE.Size = new System.Drawing.Size(47, 17);
			this.checkboxRLE.TabIndex = 3;
			this.checkboxRLE.Text = "RLE";
			this.checkboxRLE.UseVisualStyleBackColor = true;
			// 
			// checkboxMULAW
			// 
			this.checkboxMULAW.AutoSize = true;
			this.checkboxMULAW.Location = new System.Drawing.Point(1174, 250);
			this.checkboxMULAW.Name = "checkboxMULAW";
			this.checkboxMULAW.Size = new System.Drawing.Size(59, 17);
			this.checkboxMULAW.TabIndex = 4;
			this.checkboxMULAW.Text = "MLAW";
			this.checkboxMULAW.UseVisualStyleBackColor = true;
			// 
			// checkboxSMART
			// 
			this.checkboxSMART.AutoSize = true;
			this.checkboxSMART.Location = new System.Drawing.Point(1175, 273);
			this.checkboxSMART.Name = "checkboxSMART";
			this.checkboxSMART.Size = new System.Drawing.Size(64, 17);
			this.checkboxSMART.TabIndex = 5;
			this.checkboxSMART.Text = "SMART";
			this.checkboxSMART.UseVisualStyleBackColor = true;
			// 
			// radioButtonTime
			// 
			this.radioButtonTime.AutoSize = true;
			this.radioButtonTime.Checked = true;
			this.radioButtonTime.Location = new System.Drawing.Point(6, 30);
			this.radioButtonTime.Name = "radioButtonTime";
			this.radioButtonTime.Size = new System.Drawing.Size(48, 17);
			this.radioButtonTime.TabIndex = 9;
			this.radioButtonTime.TabStop = true;
			this.radioButtonTime.Text = "Time";
			this.radioButtonTime.UseVisualStyleBackColor = true;
			// 
			// radioButtonSize
			// 
			this.radioButtonSize.AutoSize = true;
			this.radioButtonSize.Location = new System.Drawing.Point(6, 53);
			this.radioButtonSize.Name = "radioButtonSize";
			this.radioButtonSize.Size = new System.Drawing.Size(45, 17);
			this.radioButtonSize.TabIndex = 10;
			this.radioButtonSize.Text = "Size";
			this.radioButtonSize.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonTime);
			this.groupBox1.Controls.Add(this.radioButtonSize);
			this.groupBox1.Location = new System.Drawing.Point(1170, 320);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(92, 100);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Measure";
			// 
			// checkboxHuffman
			// 
			this.checkboxHuffman.AutoSize = true;
			this.checkboxHuffman.Location = new System.Drawing.Point(1174, 227);
			this.checkboxHuffman.Name = "checkboxHuffman";
			this.checkboxHuffman.Size = new System.Drawing.Size(78, 17);
			this.checkboxHuffman.TabIndex = 12;
			this.checkboxHuffman.Text = "HUFFMAN";
			this.checkboxHuffman.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1378, 590);
			this.Controls.Add(this.checkboxHuffman);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.checkboxSMART);
			this.Controls.Add(this.checkboxMULAW);
			this.Controls.Add(this.checkboxRLE);
			this.Controls.Add(this.checkboxLZW);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chart1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkboxLZW;
		private System.Windows.Forms.CheckBox checkboxRLE;
		private System.Windows.Forms.CheckBox checkboxMULAW;
		private System.Windows.Forms.CheckBox checkboxSMART;
		private System.Windows.Forms.RadioButton radioButtonTime;
		private System.Windows.Forms.RadioButton radioButtonSize;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkboxHuffman;
    }
}

