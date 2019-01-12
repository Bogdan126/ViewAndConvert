using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_v1
{

	public partial class PrzedzialCzasu : Form
	{
		public PrzedzialCzasu()
		{
			InitializeComponent();
		}

		private void ChangeTimeButton_Click(object sender, EventArgs e)
		{
			if (GlobalValues.database == 1)
			{
				double a = 0, b = 0, c = 0, d = 0;
				if (Beginning.Text != "" && BeginningSec.Text != "" && End.Text != "" && EndSec.Text != "")
				{
					a = Convert.ToDouble(Beginning.Text);
					b = Convert.ToDouble(BeginningSec.Text);
					c = Convert.ToDouble(End.Text);
					d = Convert.ToDouble(EndSec.Text);
				}

				if (Beginning.Text != "" && BeginningSec.Text != "" && a < 31 && a >= 0 && b < 60 && b >= 0)
				{
					GlobalValues.timeBegin = (a * 60 + b) * 360;
				}
				if (End.Text != "" && EndSec.Text != "" && c < 31 && c >= 0 && d < 60 && d >= 0)
				{
					GlobalValues.timeEnd = (c * 60 + d) * 360;
				}
			}

			if (GlobalValues.database == 2)
			{
				double a = 0, b = 0, c = 0, d = 0;
				if (Beginning.Text != "" && BeginningSec.Text != "" && End.Text != "" && EndSec.Text != "")
				{
					a = Convert.ToDouble(Beginning.Text);
					b = Convert.ToDouble(BeginningSec.Text);
					c = Convert.ToDouble(End.Text);
					d = Convert.ToDouble(EndSec.Text);
				}

				if (Beginning.Text != "" && BeginningSec.Text != "" && a >= 0 && b >= 0)
				{
					GlobalValues.timeBegin = (a * 60 + b) * 125;
				}
				if (End.Text != "" && EndSec.Text != "" && c >= 0 && d >= 0)
				{
					GlobalValues.timeEnd = (c * 60 + d) * 125;
				}
			}
		
			this.Close();
		}
	}
}
