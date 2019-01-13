namespace Program_v1
{

	partial class ViewAndConvert
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAndConvert));
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ConvertTXTButton = new System.Windows.Forms.Button();
			this.PickDatabase = new System.Windows.Forms.Button();
			this.ConvertXDFButton = new System.Windows.Forms.Button();
			this.ConvertHDF5Button = new System.Windows.Forms.Button();
			this.PickTimeButton = new System.Windows.Forms.Button();
			this.OpenButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.PowderBlue;
			chartArea5.AxisX.MajorGrid.Enabled = false;
			chartArea5.AxisY.MajorGrid.Enabled = false;
			chartArea5.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea5);
			legend5.Name = "Legend1";
			this.chart1.Legends.Add(legend5);
			this.chart1.Location = new System.Drawing.Point(230, 27);
			this.chart1.Name = "chart1";
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series5.Legend = "Legend1";
			series5.Name = "Series1";
			this.chart1.Series.Add(series5);
			this.chart1.Size = new System.Drawing.Size(1054, 320);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pomocToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1296, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// pomocToolStripMenuItem
			// 
			this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
			this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.pomocToolStripMenuItem.Text = "Pomoc";
			this.pomocToolStripMenuItem.Click += new System.EventHandler(this.pomocToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.CadetBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.ConvertTXTButton);
			this.panel1.Controls.Add(this.PickDatabase);
			this.panel1.Controls.Add(this.ConvertXDFButton);
			this.panel1.Controls.Add(this.ConvertHDF5Button);
			this.panel1.Controls.Add(this.PickTimeButton);
			this.panel1.Controls.Add(this.OpenButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(224, 664);
			this.panel1.TabIndex = 2;
			// 
			// ConvertTXTButton
			// 
			this.ConvertTXTButton.BackColor = System.Drawing.Color.CadetBlue;
			this.ConvertTXTButton.Enabled = false;
			this.ConvertTXTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConvertTXTButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ConvertTXTButton.Image = ((System.Drawing.Image)(resources.GetObject("ConvertTXTButton.Image")));
			this.ConvertTXTButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ConvertTXTButton.Location = new System.Drawing.Point(3, 298);
			this.ConvertTXTButton.Name = "ConvertTXTButton";
			this.ConvertTXTButton.Size = new System.Drawing.Size(214, 38);
			this.ConvertTXTButton.TabIndex = 7;
			this.ConvertTXTButton.Text = "Konwertuj do TXT";
			this.ConvertTXTButton.UseVisualStyleBackColor = false;
			// 
			// PickDatabase
			// 
			this.PickDatabase.BackColor = System.Drawing.Color.CadetBlue;
			this.PickDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PickDatabase.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.PickDatabase.ForeColor = System.Drawing.Color.Black;
			this.PickDatabase.Image = ((System.Drawing.Image)(resources.GetObject("PickDatabase.Image")));
			this.PickDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PickDatabase.Location = new System.Drawing.Point(3, 10);
			this.PickDatabase.Name = "PickDatabase";
			this.PickDatabase.Size = new System.Drawing.Size(214, 38);
			this.PickDatabase.TabIndex = 5;
			this.PickDatabase.Text = "Wybierz bazę danych";
			this.PickDatabase.UseVisualStyleBackColor = false;
			this.PickDatabase.Click += new System.EventHandler(this.PickDatabase_Click);
			// 
			// ConvertXDFButton
			// 
			this.ConvertXDFButton.BackColor = System.Drawing.Color.CadetBlue;
			this.ConvertXDFButton.Enabled = false;
			this.ConvertXDFButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConvertXDFButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ConvertXDFButton.Image = ((System.Drawing.Image)(resources.GetObject("ConvertXDFButton.Image")));
			this.ConvertXDFButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ConvertXDFButton.Location = new System.Drawing.Point(3, 254);
			this.ConvertXDFButton.Name = "ConvertXDFButton";
			this.ConvertXDFButton.Size = new System.Drawing.Size(214, 38);
			this.ConvertXDFButton.TabIndex = 6;
			this.ConvertXDFButton.Text = "Konwertuj do XDF";
			this.ConvertXDFButton.UseVisualStyleBackColor = false;
			this.ConvertXDFButton.Click += new System.EventHandler(this.ConvertXDFButton_Click);
			// 
			// ConvertHDF5Button
			// 
			this.ConvertHDF5Button.BackColor = System.Drawing.Color.CadetBlue;
			this.ConvertHDF5Button.Enabled = false;
			this.ConvertHDF5Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConvertHDF5Button.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ConvertHDF5Button.Image = ((System.Drawing.Image)(resources.GetObject("ConvertHDF5Button.Image")));
			this.ConvertHDF5Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ConvertHDF5Button.Location = new System.Drawing.Point(3, 210);
			this.ConvertHDF5Button.Name = "ConvertHDF5Button";
			this.ConvertHDF5Button.Size = new System.Drawing.Size(214, 38);
			this.ConvertHDF5Button.TabIndex = 5;
			this.ConvertHDF5Button.Text = "Konwertuj do HDF5";
			this.ConvertHDF5Button.UseVisualStyleBackColor = false;
			this.ConvertHDF5Button.Click += new System.EventHandler(this.ConvertHDF5Button_Click);
			// 
			// PickTimeButton
			// 
			this.PickTimeButton.BackColor = System.Drawing.Color.CadetBlue;
			this.PickTimeButton.Enabled = false;
			this.PickTimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PickTimeButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.PickTimeButton.Image = ((System.Drawing.Image)(resources.GetObject("PickTimeButton.Image")));
			this.PickTimeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PickTimeButton.Location = new System.Drawing.Point(3, 54);
			this.PickTimeButton.Name = "PickTimeButton";
			this.PickTimeButton.Size = new System.Drawing.Size(214, 38);
			this.PickTimeButton.TabIndex = 3;
			this.PickTimeButton.Text = "Wybierz przedział czasu";
			this.PickTimeButton.UseVisualStyleBackColor = false;
			this.PickTimeButton.Click += new System.EventHandler(this.PickTimeButton_Click);
			// 
			// OpenButton
			// 
			this.OpenButton.BackColor = System.Drawing.Color.CadetBlue;
			this.OpenButton.Enabled = false;
			this.OpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OpenButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
			this.OpenButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.OpenButton.Location = new System.Drawing.Point(3, 132);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(214, 38);
			this.OpenButton.TabIndex = 0;
			this.OpenButton.Text = "Otwórz plik";
			this.OpenButton.UseVisualStyleBackColor = false;
			this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// chart2
			// 
			this.chart2.BackColor = System.Drawing.Color.PowderBlue;
			chartArea6.AxisX.MajorGrid.Enabled = false;
			chartArea6.AxisY.MajorGrid.Enabled = false;
			chartArea6.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea6);
			legend6.Name = "Legend1";
			this.chart2.Legends.Add(legend6);
			this.chart2.Location = new System.Drawing.Point(230, 356);
			this.chart2.Name = "chart2";
			series6.ChartArea = "ChartArea1";
			series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series6.Legend = "Legend1";
			series6.Name = "Series1";
			this.chart2.Series.Add(series6);
			this.chart2.Size = new System.Drawing.Size(1054, 320);
			this.chart2.TabIndex = 3;
			this.chart2.Text = "chart2";
			// 
			// ViewAndConvert
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.CadetBlue;
			this.ClientSize = new System.Drawing.Size(1296, 688);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ViewAndConvert";
			this.Text = "ViewAndConvert";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button PickTimeButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private System.Windows.Forms.Button PickDatabase;
		private System.Windows.Forms.Button ConvertTXTButton;
		private System.Windows.Forms.Button ConvertXDFButton;
		private System.Windows.Forms.Button ConvertHDF5Button;
		private System.Windows.Forms.Button OpenButton;
	}
}

