﻿namespace Program_v1
{
	partial class BazaDanych
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BazaDanych));
			this.mitbihButton = new System.Windows.Forms.Button();
			this.mimic3Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mitbihButton
			// 
			this.mitbihButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mitbihButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.mitbihButton.Image = ((System.Drawing.Image)(resources.GetObject("mitbihButton.Image")));
			this.mitbihButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mitbihButton.Location = new System.Drawing.Point(13, 13);
			this.mitbihButton.Name = "mitbihButton";
			this.mitbihButton.Size = new System.Drawing.Size(160, 58);
			this.mitbihButton.TabIndex = 0;
			this.mitbihButton.Text = "MIT-BIH";
			this.mitbihButton.UseVisualStyleBackColor = true;
			this.mitbihButton.Click += new System.EventHandler(this.mitbihButton_Click);
			// 
			// mimic3Button
			// 
			this.mimic3Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mimic3Button.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.mimic3Button.Image = ((System.Drawing.Image)(resources.GetObject("mimic3Button.Image")));
			this.mimic3Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mimic3Button.Location = new System.Drawing.Point(205, 13);
			this.mimic3Button.Name = "mimic3Button";
			this.mimic3Button.Size = new System.Drawing.Size(160, 58);
			this.mimic3Button.TabIndex = 1;
			this.mimic3Button.Text = "MIMIC-III";
			this.mimic3Button.UseVisualStyleBackColor = true;
			this.mimic3Button.Click += new System.EventHandler(this.mimic3Button_Click);
			// 
			// BazaDanych
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.CadetBlue;
			this.ClientSize = new System.Drawing.Size(377, 84);
			this.Controls.Add(this.mimic3Button);
			this.Controls.Add(this.mitbihButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BazaDanych";
			this.Text = "Wybór bazy danych";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button mitbihButton;
		private System.Windows.Forms.Button mimic3Button;
	}
}