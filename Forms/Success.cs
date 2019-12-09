using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace C3DIfcAlignmentPlugIn.forms
{
	// Token: 0x02000006 RID: 6
	public partial class Success : Form
	{
		// Token: 0x0600002F RID: 47 RVA: 0x0000460B File Offset: 0x0000280B
		public Success()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00004619 File Offset: 0x00002819
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004624 File Offset: 0x00002824
		private void button2_Click(object sender, EventArgs e)
		{
			string arguments = "/select, \"" + this.ifcFilePath + "\"";
			Process.Start("explorer.exe", arguments);
		}

		// Token: 0x04000012 RID: 18
		public string ifcFilePath;
	}
}
