using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using C3DIfcAlignmentPlugIn.Properties;

namespace C3DIfcAlignmentPlugIn.Forms
{
	// Token: 0x02000007 RID: 7
	public partial class Export : Form
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00004992 File Offset: 0x00002B92
		public Export()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void groupBox1_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void label2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void label5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000049A0 File Offset: 0x00002BA0
		public void button1_Click(object sender, EventArgs e)
		{
			base.Close();
			this.buttonWasClicked = true;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void Export_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003EA6 File Offset: 0x000020A6
		private void orgaName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{
		}

		// Token: 0x04000018 RID: 24
		public bool buttonWasClicked;
	}
}
