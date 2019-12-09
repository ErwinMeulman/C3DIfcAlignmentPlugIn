namespace C3DIfcAlignmentPlugIn.forms
{
	// Token: 0x02000005 RID: 5
	public partial class Progress : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002D RID: 45 RVA: 0x0000446B File Offset: 0x0000266B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000448C File Offset: 0x0000268C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.progressBar1.Location = new global::System.Drawing.Point(12, 42);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(661, 45);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(295, 110);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(92, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Importing ...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(685, 168);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Progress";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Progress";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000E RID: 14
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x04000010 RID: 16
		public global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x04000011 RID: 17
		internal global::System.Windows.Forms.Label label1;
	}
}
