using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using C3DIfcAlignmentPlugIn.Properties;

namespace C3DIfcAlignmentPlugIn.forms
{
	// Token: 0x02000004 RID: 4
	public partial class Import : Form
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00003E98 File Offset: 0x00002098
		public Import()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void Import_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003EA8 File Offset: 0x000020A8
		private void button1_Click(object sender, EventArgs e)
		{
			int num;
			if (int.TryParse(this.simplicity.Text, out num) && Convert.ToInt32(this.simplicity.Text) != 0)
			{
				this.simplicity.BackColor = Color.LightGreen;
				this.simplifier = Convert.ToInt32(this.simplicity.Text);
				this.importTest = true;
				base.Close();
			}
			else
			{
				this.simplicity.BackColor = Color.IndianRed;
				MessageBox.Show("Only even values greater than \"0\" are allowed!");
			}
			this.simplicity.BackColor = Color.White;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000003 RID: 3
		public bool importTest;

		// Token: 0x04000004 RID: 4
		public int simplifier;
	}
}
