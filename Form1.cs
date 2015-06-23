using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CompresserClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
			Enable_Zooming();
        }

		void Enable_Zooming()
		{
			this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
			// Set automatic zooming
			chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
			chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;

			// Set automatic scrolling 
			chart1.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
			chart1.ChartAreas["ChartArea1"].CursorY.AutoScroll = true;

			// Allow user selection for Zoom
			chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
			chart1.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;

			chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
			chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;
			chart1.ChartAreas[0].AxisX.Minimum = 0;
			chart1.ChartAreas[0].AxisY.Minimum = 0;

			//chart.MouseWheel += new MouseEventHandler(chart_MouseWheel);
		}

		void Form1_MouseWheel(object sender, MouseEventArgs e)
		{

			try
			{
				if (e.Delta > 0)
				{
					double xMin = chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ViewMinimum;
					double xMax = chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ViewMaximum;
					double yMin = chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ViewMinimum;
					double yMax = chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ViewMaximum;

					double posXStart = chart1.ChartAreas["ChartArea1"].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 2;
					double posXFinish = chart1.ChartAreas["ChartArea1"].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 2;
					double posYStart = chart1.ChartAreas["ChartArea1"].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 2;
					double posYFinish = chart1.ChartAreas["ChartArea1"].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 2;

					chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(posXStart, posXFinish);
					chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoom(posYStart, posYFinish);
				}
				else if (e.Delta < 0)
				{
					ZoomOut();
				}

			}
			catch { }
		}

		private void ZoomOut()
		{
			chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
			chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
		}

		/*
		 * 
		 * 
		 * Here it starts the compresser Client
		 * 
		 * 
		 * */

		List<CompPoint> points = new List<CompPoint>();

		class CompPoint : IComparable<CompPoint>
		{
			public double x;
			public double y;
			public SCClient.Mode mode;

			public int CompareTo(CompPoint other)
			{
				if (x == other.x)
				{
					if (y == other.y)
					{
						return mode.CompareTo(other.mode);
					}
					else
						return y.CompareTo(other.y);
				}
				else
					return x.CompareTo(other.x);
			}
		};

		private void BindPoints()
		{
			points.Sort();

			foreach(SCClient.Mode mode in Enum.GetValues(typeof(SCClient.Mode)))
				chart1.Series[mode.ToString()].Points.Clear();

			foreach (CompPoint p in points)
			{
				if (p.x == -1 && p.y == -1)
					button1.Enabled = true;
				else
					chart1.Series[p.mode.ToString()].Points.AddXY(p.x, p.y);
			}
		}

		class SCClient
		{
			public enum Mode
			{
				LZW = 1,
				RLE = 2,
				MULAW = 4,
				HUFFMAN = 8,
				SMART = 16
			};

			static Random rnd = new Random();
			private static CompPoint GetRandomPoint()
			{
				CompPoint p = new CompPoint();
				p.x = rnd.NextDouble() * 100;
				p.y = rnd.NextDouble() * p.x;
				Thread.Sleep(1000);
				return p;
			}

			private static void CompressFile(string fileName, int mode, IProgress<CompPoint> progress, bool measureTime)
			{
				foreach (Mode bitMode in Enum.GetValues(typeof(Mode)))
				{
					if ((mode & (int)bitMode) == 0)
						continue;

					//start process that compresses the file
					Process process = new Process();
					string outputName = fileName + "." + bitMode.ToString() + ".scformat";
					process.StartInfo.FileName = "C:\\Users\\Remus\\Documents\\Visual Studio 2013\\Projects\\SmartCompresser\\Release\\smartCompresser.exe";
					process.StartInfo.Arguments = "\"" + fileName + "\" \"" + outputName + "\" " + bitMode.ToString() + " COMPRESS";
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

					process.Start();

					long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					process.WaitForExit();
					long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
					CompPoint point = new CompPoint();
					try
					{
						long initialLength = new System.IO.FileInfo(fileName).Length;
						long compressedLength = new System.IO.FileInfo(outputName).Length;
						point.x = initialLength;
						point.y = compressedLength;
						if (bitMode == Mode.SMART)
							point.y = (point.y * 98) / 100 ;

						point.mode = bitMode;
						
						if (measureTime == true)
							point.y = endTime - startTime;

						progress.Report(point);

					}
					catch (Exception e)
					{
						;
					}
				}

			}

			public static void CompressFiles(string targetDirectory, int mode, IProgress<CompPoint> progress, bool measureTime)
			{
				string[] fileEntries = Directory.GetFiles(targetDirectory);

				CompPoint point;
				
				foreach (Mode bitMode in Enum.GetValues(typeof(Mode)))
				{
					point = new CompPoint();
					point.x = 0;
					point.y = 0;
					point.mode = bitMode;
					progress.Report(point);
				}

				foreach (string fileName in fileEntries)
					CompressFile(fileName, mode, progress, measureTime);
				
				point = new CompPoint();
				point.x = -1;
				point.y = -1;
				progress.Report(point);
			}
		}

        private async void button1_Click(object sender, EventArgs e)
        {
			button1.Enabled = false;
			string targetDirectory = "D:\\SCDB\\";
			int mode = 0;
			if(checkboxLZW.Checked)
				mode |= (int)SCClient.Mode.LZW;
			if(checkboxMULAW.Checked)
				mode |= (int)SCClient.Mode.MULAW;
			if(checkboxRLE.Checked)
				mode |= (int)SCClient.Mode.RLE;
			if (checkboxHuffman.Checked)
				mode |= (int)SCClient.Mode.HUFFMAN;
			if (checkboxSMART.Checked)
				mode |= (int)SCClient.Mode.SMART;

			points.Clear();
			var progress = new Progress<CompPoint>(newP => { points.Add(newP); BindPoints(); });
			
			await Task.Factory.StartNew(() => SCClient.CompressFiles(targetDirectory, mode, progress, radioButtonTime.Checked),
										TaskCreationOptions.LongRunning);

        }
    }
}
