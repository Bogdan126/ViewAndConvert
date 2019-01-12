using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfdbCsharpWrapper;
using HDF5DotNet;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Runtime.InteropServices;


namespace Program_v1
{
	public partial class Mimic3 : Form
	{
		public Mimic3()
		{
			InitializeComponent();
			chart1.MouseWheel += Chart1_MouseWheel;
		}

		public void ChartLoad(double min, double max, double[][] table, int sign)
		{
			if (GlobalValues.timeBegin > 0) min = GlobalValues.timeBegin;
			else min = 0;

			if (GlobalValues.timeEnd < GlobalValues.samp) max = GlobalValues.timeEnd;
			else max = GlobalValues.samp;

			double a = 0, b = table[sign][0], c = table[sign][0]; ;

			for (int i = 0; i < GlobalValues.samp; i++)
			{
				if (b > a) a = b;
				if (b < c) c = b;
				b = table[sign][i];
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

			chart1.Series.Clear();

			string line = File.ReadLines(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea").Skip(sign+1).Take(1).First();
			string[] separator = { " " };
			string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			string signame = words[8];

			chart1.Series.Add(signame);
			chart1.Series[signame].ChartType = SeriesChartType.Line;
			chart1.Series[signame].Color = Color.Red;

			for (int i = 0; i < GlobalValues.samp; i++)
			{
				chart1.Series[signame].Points.AddXY(i, table[sign][i]);
			}
		}

		private void UsingPInvoke()
		{

			int i, j, nsig;
			Sample[] v;
			Signal[] s;

			nsig = PInvoke.isigopen(GlobalValues.fileName3, null, 0);
			if (nsig < 1)
				return;
			s = new Signal[nsig];

			if (PInvoke.isigopen(GlobalValues.fileName3, s, nsig) != nsig)
				return;

			v = new Sample[nsig];
			for (i = 0; i < 10; i++)
			{
				if (PInvoke.getvec(v) < 0)
					break;
				for (j = 0; j < nsig; j++)
					Console.Write("{0} \t", v[j]);
				Console.WriteLine();
			}
			PInvoke.wfdbquit();
		}

		private double[][] UsingWrapperClasses1(int p, int r)
		{

			// Odczyt ilości próbek z pliku nagłówkowego
			StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
			string line = file.ReadLine();
			string[] separator = { " " };
			string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			int sampcount = Convert.ToInt32(words[3]);
			GlobalValues.samp = sampcount;

			using (var record = new Record(GlobalValues.fileName3))
			{
				double[][] array = new double[p][];
				for(int i=0;i<p;i++)
				{
					array[i] = new double[sampcount];
				}
				int pom = 0;

				record.Open();

				var samples = record.GetSamples(sampcount);

				foreach (var s in samples)
				{

					for (int i = 0; i < s.Length; i++)
					{		
							array[r][pom] = s[r];
					}
					pom++;
				}
				Wfdb.Quit();
				return array;
			}
		}

		private double[][] UsingWrapperClasses2(int p)
		{

			// Odczyt ilości próbek z pliku nagłówkowego
			StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
			string line = file.ReadLine();
			string[] separator = { " " };
			string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			int sampcount = Convert.ToInt32(words[3]);
			GlobalValues.samp = sampcount;

			using (var record = new Record(GlobalValues.fileName3))
			{
				double[][] array = new double[p][];
				for (int i = 0; i < p; i++)
				{
					array[i] = new double[sampcount];
				}
				int pom = 0;

				record.Open();

				var samples = record.GetSamples(sampcount);

				foreach (var s in samples)
				{

					for (int i = 0; i < s.Length; i++)
					{
							array[i][pom] = s[i];
					}
					pom++;
				}
				Wfdb.Quit();
				return array;
			}
		}

		private void chart1Button_Click(object sender, EventArgs e)
		{
			int min = 0, max = 0;
			double[][] table = new double[GlobalValues.samp][];

			StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
			string line = file.ReadLine();
			string[] separator = { " " };
			string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			int sigcount = Convert.ToInt32(words[1]);
			GlobalValues.sig = sigcount;
			table = UsingWrapperClasses1(sigcount, 0);
			ChartLoad(min, max, table,0);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if(GlobalValues.sig >= 2)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 1);
				ChartLoad(min, max, table,1);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (GlobalValues.sig >= 3)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 2);
				ChartLoad(min, max, table,2);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (GlobalValues.sig >= 4)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 3);
				ChartLoad(min, max, table,3);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (GlobalValues.sig >= 5)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 4);
				ChartLoad(min, max, table,4);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (GlobalValues.sig >= 6)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 5);
				ChartLoad(min, max, table,5);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (GlobalValues.sig >= 7)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 6);
				ChartLoad(min, max, table,6);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (GlobalValues.sig == 8)
			{
				int min = 0, max = 0;
				double[][] table = new double[GlobalValues.samp][];

				StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
				string line = file.ReadLine();
				string[] separator = { " " };
				string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int sigcount = Convert.ToInt32(words[1]);
				GlobalValues.sig = sigcount;
				table = UsingWrapperClasses1(sigcount, 7);
				ChartLoad(min, max, table,7);
			}
		}

		private void Chart1_MouseWheel(object sender, MouseEventArgs e)
		{
			try
			{
				Axis xAxis = chart1.ChartAreas[0].AxisX;
				double xMin = xAxis.ScaleView.ViewMinimum;
				double xMax = xAxis.ScaleView.ViewMaximum;
				double xPixelPosition = xAxis.PixelPositionToValue(e.Location.X);
				GlobalValues.FZoomLevel = 1000;

				if (e.Delta < 0 && GlobalValues.FZoomLevel > 0)
				{
					if (--GlobalValues.FZoomLevel <= 0)
					{
						GlobalValues.FZoomLevel = 0;
						xAxis.ScaleView.ZoomReset();
					}
					else
					{
						int xStartPos = (int)Math.Max(xPixelPosition - (xPixelPosition - xMin) * GlobalValues.CZoomScale, 0);
						int xEndPos = (int)Math.Min(xStartPos + (xMax - xMin) * GlobalValues.CZoomScale, xAxis.Maximum);
						xAxis.ScaleView.Zoom(xStartPos, xEndPos);
					}
				}
				else if (e.Delta > 0)
				{
					int xStartPos = (int)Math.Max(xPixelPosition - (xPixelPosition - xMin) / GlobalValues.CZoomScale, 0);
					int xEndPos = (int)Math.Min(xStartPos + (xMax - xMin) / GlobalValues.CZoomScale, xAxis.Maximum);
					xAxis.ScaleView.Zoom(xStartPos, xEndPos);
					GlobalValues.FZoomLevel++;
				}
			}
			catch { }
		}



	////////////////// CONVERT TO HDF5 - MIMIC-3 /////////////////

		static int Function(H5GroupId id, string objectName, Object param)
		{
			Console.WriteLine("Nazwa obiektu: {0}", objectName);
			Console.WriteLine("Parametr obiektu: {0}", param);
			return 0;
		}

		public void ConvertToHDF5(double[][] table, int sigc)
		{
			try
			{
				double min = 0, max = 0;
				if (GlobalValues.timeBegin > 0) min = GlobalValues.timeBegin;
				else min = 0;

				if (GlobalValues.timeEnd < GlobalValues.samp) max = GlobalValues.timeEnd;
				else max = GlobalValues.samp;

				// Zapisywanie i odczytanie tablicy typu double
				int DATA_ARRAY_LENGTH = Convert.ToInt32(max) - Convert.ToInt32(min);

				// RANK- liczba wymiarów tablicy
				const int RANK = 2;

				// Utworzenie pliku HDF5
				H5FileId fileId = H5F.create("SignalTest.h5",
											 H5F.CreateMode.ACC_TRUNC);


				// ATTRIBUTES //
				long[] dimsatr = new long[1];
				float[] attribute = new float[1];
				dimsatr[0] = 1;
				attribute[0] = 125;
				H5DataTypeId typeIdatr = H5T.copy(H5T.H5Type.NATIVE_FLOAT);
				H5DataSpaceId spaceIdatr = H5S.create_simple(1, dimsatr);
				H5AttributeId attr = H5A.create(fileId, "Fs", typeIdatr, spaceIdatr);
				H5A.write(attr, new H5DataTypeId(H5T.H5Type.NATIVE_FLOAT), new H5Array<float>(attribute));


				// INFO //

				string[] separator = { " ", "/" };
				string[] words;
				string[,] tableinfo = new string[GlobalValues.sig,2];
				string lineinfo;
				for (int i = 1; i < sigc+1; i++)
				{
					lineinfo = File.ReadLines(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea").Skip(i).Take(1).First();
					words = lineinfo.Split(separator, StringSplitOptions.RemoveEmptyEntries);
					tableinfo[i - 1,0] = words[9];
					tableinfo[i - 1,1] = words[3];
				}
				
				long[] dimsinfo = new long[2];
				dimsinfo[0] = sigc;
				dimsinfo[1] = 2;

				IntPtr[,] pointers = new IntPtr[sigc, 2];

				string[,] dset_info = new string[sigc, 2];
				int l = 0;
				for (int i = 0; i < 2; i++)
				{
					for (int k = 0; k < sigc; k++)
					{
						dset_info[k, l] = tableinfo[k, i];
						pointers[k, l] = Marshal.StringToHGlobalAnsi(dset_info[k, l]);
					}
					l++;
				}


				H5DataSpaceId spaceIdinfo = H5S.create_simple(RANK, dimsinfo);
				H5DataTypeId typeIdinfo = H5T.create(H5T.CreateClass.STRING, -1);
				H5DataSetId dataSetIdinfo = H5D.create(fileId, "/Info", typeIdinfo, spaceIdinfo);
				H5D.write(dataSetIdinfo, typeIdinfo , new H5Array<IntPtr>(pointers));


				// Utworzenie grupy HDF5.
				H5GroupId groupId = H5G.create(fileId, "/cSharpGroup");
				H5GroupId subGroup = H5G.create(groupId, "mySubGroup");

				// Pobieranie informacje o obiekcie
				ObjectInfo info = H5G.getObjectInfo(fileId, "/cSharpGroup", true);


				H5G.close(subGroup);


				// ///////// DATA /////////

				// Przygotowanie miejsca w pamięci na zapis 
				// dwuwymiarowej tablicy z danymi
				long[] dims = new long[RANK];

				dims[0] = sigc;
				dims[1] = DATA_ARRAY_LENGTH;

				// Wpisanie danych
				float[,] dset_data = new float[sigc, DATA_ARRAY_LENGTH];
				int j = 0;
				for (int i = Convert.ToInt32(min); i < Convert.ToInt32(max); i++)
				{
					for (int k = 0; k < sigc; k++)
					{
						dset_data[k, j] = Convert.ToInt64(table[k][i]);
					}
					j++;
				}

				j = 0;

				// Utworzenie przestrzeni danych do umieszczenia tam tablicy
				// H5DataSpaceId posłuży do stworzenia przestrzeni danych
				H5DataSpaceId spaceId = H5S.create_simple(RANK, dims);

				// Utworzenie kopii standardowego typu danych.
				// H5DataTypeId jest później używany do stworzenia zbioru danych
				H5DataTypeId typeId = H5T.copy(H5T.H5Type.NATIVE_FLOAT);

				// Rozmiar typu danych
				int typeSize = H5T.getSize(typeId);

				// Ustawienie porządku danych na "little endian"
				H5T.setOrder(typeId, H5T.Order.LE);

				// Stworzenie zbioru danych
				H5DataSetId dataSetId = H5D.create(fileId, "/Data", typeId, spaceId);

				// Zapis danych do zbioru danych
				H5D.write(dataSetId, new H5DataTypeId(H5T.H5Type.NATIVE_FLOAT), new H5Array<float>(dset_data));

				// Zamknięcie wszystkich otwartych zasobów
				H5A.close(attr);
				H5D.close(dataSetIdinfo);
				H5S.close(spaceIdinfo);
				H5T.close(typeIdinfo);
				H5D.close(dataSetId);
				H5S.close(spaceId);
				H5T.close(typeId);
				H5G.close(groupId);

				// //////// INFO ////////

				long[] dims_info = new long[RANK];

				dims_info[0] = RANK;
				dims_info[1] = 2;



				//int x = 10;
				//H5T.enumInsert<int>(typeId, "myString", ref x);
				//H5G.close(groupId);

				H5GIterateCallback myDelegate;
				myDelegate = Function;
				int x = 9;
				int r = 0;
				int index = H5G.iterate(fileId, "/cSharpGroup",
					myDelegate, x, ref r);

				H5F.close(fileId);
			}

			// Catch łapie wszystkie wyjątki klas HDF. Można wyodrębnić 
			// poszczególne wyjątki, np. catch (H5FopenException openException).
			catch (HDFException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void ConvertToHDF5Button_Click(object sender, EventArgs e)
		{
			StreamReader file = new StreamReader(Directory.GetCurrentDirectory().Remove(GlobalValues.pathlen - 10) + "/data/" + GlobalValues.fileName3 + ".hea");
			string line = file.ReadLine();
			string[] separator = { " " };
			string[] words = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			int sigcount = Convert.ToInt32(words[1]);
			GlobalValues.sig = sigcount;
			ConvertToHDF5(UsingWrapperClasses2(sigcount), sigcount);
		}
	}
}