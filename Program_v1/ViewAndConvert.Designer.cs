﻿namespace Program_v1
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.SaveButton = new System.Windows.Forms.Button();
			this.PickTimeButton = new System.Windows.Forms.Button();
			this.CloseButton = new System.Windows.Forms.Button();
			this.OpenButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisY.MajorGrid.Enabled = false;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(230, 27);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
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
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.CloseButton);
			this.panel1.Controls.Add(this.OpenButton);
			this.panel1.Location = new System.Drawing.Point(0, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(224, 661);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.SaveButton);
			this.panel2.Controls.Add(this.PickTimeButton);
			this.panel2.Location = new System.Drawing.Point(4, 48);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(213, 562);
			this.panel2.TabIndex = 2;
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.SaveButton.Location = new System.Drawing.Point(3, 517);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(203, 38);
			this.SaveButton.TabIndex = 4;
			this.SaveButton.Text = "Zapisz jako...";
			this.SaveButton.UseVisualStyleBackColor = false;
			// 
			// PickTimeButton
			// 
			this.PickTimeButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.PickTimeButton.Location = new System.Drawing.Point(3, 3);
			this.PickTimeButton.Name = "PickTimeButton";
			this.PickTimeButton.Size = new System.Drawing.Size(203, 38);
			this.PickTimeButton.TabIndex = 3;
			this.PickTimeButton.Text = "Wybierz przedział czasu";
			this.PickTimeButton.UseVisualStyleBackColor = false;
			this.PickTimeButton.Click += new System.EventHandler(this.PickTimeButton_Click);
			// 
			// CloseButton
			// 
			this.CloseButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.CloseButton.Location = new System.Drawing.Point(3, 616);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(214, 38);
			this.CloseButton.TabIndex = 1;
			this.CloseButton.Text = "Zamknij plik";
			this.CloseButton.UseVisualStyleBackColor = false;
			// 
			// OpenButton
			// 
			this.OpenButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.OpenButton.Enabled = false;
			this.OpenButton.Location = new System.Drawing.Point(3, 3);
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
			chartArea2.AxisX.MajorGrid.Enabled = false;
			chartArea2.AxisY.MajorGrid.Enabled = false;
			chartArea2.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend1";
			this.chart2.Legends.Add(legend2);
			this.chart2.Location = new System.Drawing.Point(230, 356);
			this.chart2.Name = "chart2";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			this.chart2.Series.Add(series2);
			this.chart2.Size = new System.Drawing.Size(1054, 320);
			this.chart2.TabIndex = 3;
			this.chart2.Text = "chart2";
			// 
			// ViewAndConvert
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.ClientSize = new System.Drawing.Size(1296, 688);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ViewAndConvert";
			this.Text = "ViewAndConvert";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button PickTimeButton;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
	}
}
