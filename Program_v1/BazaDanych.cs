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
	public partial class BazaDanych : Form
	{
		public BazaDanych()
		{
			InitializeComponent();
		}

		private void mitbihButton_Click(object sender, EventArgs e)
		{
			GlobalValues.database = 1;
			this.Close();
		}

		private void mimic3Button_Click(object sender, EventArgs e)
		{
			GlobalValues.database = 2;
			this.Close();
		}
	}
}
