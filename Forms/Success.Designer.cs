namespace C3DIfcAlignmentPlugIn.forms
{
	// Token: 0x02000006 RID: 6
	public partial class Success : global::System.Windows.Forms.Form
	{
		// Token: 0x06000032 RID: 50 RVA: 0x00004653 File Offset: 0x00002853
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004674 File Offset: 0x00002874
		private void InitializeComponent()
		{
			this.label1 = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.SystemColors.Window;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(61, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(250, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "IFC Export successful!";
			this.button1.BackColor = global::System.Drawing.SystemColors.ButtonFace;
			this.button1.Location = new global::System.Drawing.Point(216, 150);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(164, 47);
			this.button1.TabIndex = 1;
			this.button1.Text = "Close";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.SystemColors.ButtonFace;
			this.button2.Location = new global::System.Drawing.Point(12, 150);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(164, 47);
			this.button2.TabIndex = 0;
			this.button2.Text = "Show File";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.SystemColors.Window;
			this.label2.Location = new global::System.Drawing.Point(62, 62);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(274, 60);
			this.label2.TabIndex = 3;
			this.label2.Text = "If you experienced any problems or \r\nerrors or have some feedback please \r\nconsult <f.rampf@tum.de>.";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Window;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			base.ClientSize = new global::System.Drawing.Size(392, 212);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Success";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Success";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000013 RID: 19
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Button button2;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Label label2;
	}
}
