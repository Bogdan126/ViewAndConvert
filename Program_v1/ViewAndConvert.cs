using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WfdbCsharpWrapper;

namespace Program_v1
{
	public partial class ViewAndConvert : Form
	{
		private int FZoomLevel = 0;
		private double CZoomScale = 1.1;
		private int FZoomLevel2 = 0;
		private double CZoomScale2 = 1.1;
		private String fileName = "";
		private String fileName2 = "";
		private String fileName3 = "";
		private String pathName = "";
		private String pathName2 = "";
		private static int pathlen = System.IO.Directory.GetCurrentDirectory().Length;

		private static String curpath = System.IO.Directory.GetCurrentDirectory().Remove(pathlen - 10);

		public ViewAndConvert()
		{
			//Ścieżka dostępu do plików musi być określona w programie, 
			//inaczej jest ona domyślna i nie wiadomo gdzie się znajdują
			Wfdb.WfdbPath = curpath + "/data";

			InitializeComponent();
			chart1.MouseWheel += Chart1_MouseWheel;
			chart2.MouseWheel += Chart2_MouseWheel;
		}


		
		private void UsingPInvoke()
		{
			Console.WriteLine("exgetvec Using PInvoke");

			int i, j, nsig;
			Sample[] v;
			Signal[] s;

			nsig = PInvoke.isigopen(fileName3, null, 0);
			if (nsig < 1)
				return;
			s = new Signal[nsig];

			if (PInvoke.isigopen(fileName3, s, nsig) != nsig)
				return;

			v = new Sample[nsig];
			for (i = 0; i < 649800; i++)
			{
				if (PInvoke.getvec(v) < 0)
					break;
				for (j = 0; j < nsig; j++)
					Console.Write("{0} \t", v[j]);
				Console.WriteLine();
			}
			PInvoke.wfdbquit();
		}

		private void OpenButton_Click(object sender, EventArgs e)
		{
			
			int min = 0, max = 0;
			int[] table = new int[649800];
			int[] table2 = new int[649800];

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
				
				pathName = System.IO.Path.GetFullPath(openFileDialog1.FileName);
				pathName2 = System.IO.Path.GetFullPath(System.IO.Path.ChangeExtension(openFileDialog1.FileName, ".hea"));
				fileName2 = System.IO.Path.GetFileName(System.IO.Path.ChangeExtension(openFileDialog1.FileName, ".hea"));
				fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
				fileName3 = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

				sr.Close();

				System.IO.File.Copy(pathName2, curpath + "/data/" + fileName2, true);
				System.IO.File.Copy(pathName, curpath + "/data/" + fileName, true);
			}
			
			table = UsingWrapperClasses1();
			table2 = UsingWrapperClasses2();

			ChartLoad(min, max, table);
			ChartLoad2(min, max, table2);
		}

		private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Pomoc p = new Pomoc();
			p.ShowDialog();
		}

		private void PickTimeButton_Click(object sender, EventArgs e)
		{
			PrzedzialCzasu prz = new PrzedzialCzasu();
			prz.ShowDialog();
			OpenButton.Enabled = true;
		}















		// ////////////////////////// CHART1 - EKG FOR MIT-BIH /////////////////////////////
		private int[] UsingWrapperClasses1()
		{
			int min = 0, max = 0;

			using (var record = new Record(fileName3))
			{
				int[] voltage_tab1 = new int[649800];

				int pom = 0;

				record.Open();

				var samples = record.GetSamples(649800);

				foreach (var s in samples)
				{

					for (int i = 0; i < s.Length; i++)
					{
						if (i == 0)
						{
							voltage_tab1[i + pom] = s[i];
						}
						
					}
					pom++;
				}
				Wfdb.Quit();
				return voltage_tab1;
			}
		}

		public void ChartLoad(double min, double max, int[] table)
		{

			min = GlobalValues.timeBegin;
			max = GlobalValues.timeEnd;

			int a = 0, b = table[0], c = table[0]; ;

			for (int i = 0; i < 649800; i++)
			{
				if (b > a) a = b;
				if (b < c) c = b;
				b = table[i];
			}

			var chart = chart1.ChartAreas[0];

			chart.AxisX.IntervalType = DateTimeIntervalType.Number;

			chart.AxisY.LabelStyle.Format = "";
			chart.AxisX.LabelStyle.Format = "";
			chart.AxisX.LabelStyle.IsEndLabelVisible = true;

			chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
			chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

			chart.AxisX.Minimum = min;
			chart.AxisX.Maximum = max;
			chart.AxisY.Minimum = c;
			chart.AxisY.Maximum = a;
			chart.AxisX.Interval = (max - min) / 20;
			chart.AxisY.Interval = (a - c) / 10;

			chart1.Series[0].IsVisibleInLegend = false;

			chart1.Series.Add("EKG");
			chart1.Series["EKG"].ChartType = SeriesChartType.Line;
			chart1.Series["EKG"].Color = Color.Blue;

			for (int i = 0; i < GlobalValues.timeEnd - GlobalValues.timeBegin; i++)
			{
				chart1.Series["EKG"].Points.AddXY(i, table[i]);
			}
		}

		private void Chart1_MouseEnter(object sender, EventArgs e)
		{
			if (!chart1.Focused)
				chart1.Focus();
		}

		private void Chart1_MouseLeave(object sender, EventArgs e)
		{
			if (chart1.Focused)
				chart1.Parent.Focus();
		}

		private void Chart1_MouseWheel(object sender, MouseEventArgs e)
		{
			try
			{
				Axis xAxis = chart1.ChartAreas[0].AxisX;
				double xMin = xAxis.ScaleView.ViewMinimum;
				double xMax = xAxis.ScaleView.ViewMaximum;
				double xPixelPosition = xAxis.PixelPositionToValue(e.Location.X);
				FZoomLevel = 1000;

				if (e.Delta < 0 && FZoomLevel > 0)
				{
					if (--FZoomLevel <= 0)
					{
						FZoomLevel = 0;
						xAxis.ScaleView.ZoomReset();
					}
					else
					{
						int xStartPos = (int)Math.Max(xPixelPosition - (xPixelPosition - xMin) * CZoomScale, 0);
						int xEndPos = (int)Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
						xAxis.ScaleView.Zoom(xStartPos, xEndPos);
					}
				}
				else if (e.Delta > 0)
				{
					int xStartPos = (int)Math.Max(xPixelPosition - (xPixelPosition - xMin) / CZoomScale, 0);
					int xEndPos = (int)Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
					xAxis.ScaleView.Zoom(xStartPos, xEndPos);
					FZoomLevel++;
				}
			}
			catch { }
		}








		// ////////////////// CHART 2 - ????? FOR MIT-BIH /////////////////////

		private int[] UsingWrapperClasses2()
		{
			int min = 0, max = 0;

			using (var record = new Record(fileName3))
			{
				int[] voltage_tab2 = new int[649800];

				int pom = 0;

				record.Open();

				var samples = record.GetSamples(649800);

				foreach (var s in samples)
				{

					for (int i = 0; i < s.Length; i++)
					{
						
						if (i == 1)
						{
							voltage_tab2[i + pom - 1] = s[i];
						}
					}
					pom++;
				}
				Wfdb.Quit();
				return voltage_tab2;
			}
		}

		public void ChartLoad2(double min, double max, int[] table)
		{

			min = GlobalValues.timeBegin;
			max = GlobalValues.timeEnd;

			int a = 0, b = table[0], c = table[0]; ;

			for (int i = 0; i < 649800; i++)
			{
				if (b > a) a = b;
				if (b < c) c = b;
				b = table[i];
			}

			var chart = chart2.ChartAreas[0];

			chart.AxisX.IntervalType = DateTimeIntervalType.Number;

			chart.AxisY.LabelStyle.Format = "";
			chart.AxisX.LabelStyle.Format = "";
			chart.AxisX.LabelStyle.IsEndLabelVisible = true;

			chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
			chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

			chart.AxisX.Minimum = min;
			chart.AxisX.Maximum = max;
			chart.AxisY.Minimum = c;
			chart.AxisY.Maximum = a;
			chart.AxisX.Interval = (max - min) / 20;
			chart.AxisY.Interval = (a - c) / 10;

			chart2.Series[0].IsVisibleInLegend = false;

			chart2.Series.Add("???");
			chart2.Series["???"].ChartType = SeriesChartType.Line;
			chart2.Series["???"].Color = Color.Blue;

			

			for (int i = 0; i < GlobalValues.timeEnd - GlobalValues.timeBegin; i++)
			{
				chart2.Series["???"].Points.AddXY(i, table[i]);
			}
		}

		private void Chart2_MouseEnter(object sender, EventArgs e)
		{
			if (!chart2.Focused)
				chart2.Focus();
		}

		private void Chart2_MouseLeave(object sender, EventArgs e)
		{
			if (chart2.Focused)
				chart2.Parent.Focus();
		}

		private void Chart2_MouseWheel(object sender, MouseEventArgs e)
		{
			try
			{
				Axis xAxis = chart2.ChartAreas[0].AxisX;
				double xMin = xAxis.ScaleView.ViewMinimum;
				double xMax = xAxis.ScaleView.ViewMaximum;
				double xPixelPosition = xAxis.PixelPositionToValue(e.Location.X);
				FZoomLevel = 1000;

				if (e.Delta < 0 && FZoomLevel2 > 0)
				{
					if (--FZoomLevel2 <= 0)
					{
						FZoomLevel2 = 0;
						xAxis.ScaleView.ZoomReset();
					}
					else
					{
						int xStartPos = (int)Math.Max(xPixelPosition - (xPixelPosition - xMin) * CZoomScale2, 0);
						int xEndPos = (int)Math.Min(xStartPos + (xMax - xMin) * CZoomScale2, xAxis.Maximum);
						xAxis.ScaleView.Zoom(xStartPos, xEndPos);
					}
				}
				else if (e.Delta > 0)
				{
					int xStartPos = (int)Math.Max(xPixelPosition - (xPixelPosition - xMin) / CZoomScale2, 0);
					int xEndPos = (int)Math.Min(xStartPos + (xMax - xMin) / CZoomScale2, xAxis.Maximum);
					xAxis.ScaleView.Zoom(xStartPos, xEndPos);
					FZoomLevel2++;
				}
			}
			catch { }
		}
	}

	public static class GlobalValues
	{
		public static double timeBegin = 0;
		public static double timeEnd = 649800;
	}


}


