namespace C3DIfcAlignmentPlugIn.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class License : global::System.Windows.Forms.Form
	{
		// Token: 0x06000049 RID: 73 RVA: 0x00006283 File Offset: 0x00004483
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000062A4 File Offset: 0x000044A4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::C3DIfcAlignmentPlugIn.Forms.License));
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.colorDialog1 = new global::System.Windows.Forms.ColorDialog();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label4 = new global::System.Windows.Forms.Label();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI", 8f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.SystemColors.WindowFrame;
			this.label3.Location = new global::System.Drawing.Point(23, 106);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(560, 294);
			this.label3.TabIndex = 9;
			this.label3.Text = componentResourceManager.GetString("label3.Text");
			this.label3.Click += new global::System.EventHandler(this.label3_Click_1);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.label2.ForeColor = global::System.Drawing.SystemColors.WindowFrame;
			this.label2.Location = new global::System.Drawing.Point(22, 75);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(404, 25);
			this.label2.TabIndex = 8;
			this.label2.Text = "Copyright (c) 2017 Felix Rampf - f.rampf@tum.de";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 20f, global::System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = global::System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new global::System.Drawing.Point(18, 21);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(568, 54);
			this.label1.TabIndex = 7;
			this.label1.Text = "Civil 3D IFC Alignment Plug-In\r\n";
			this.button1.Location = new global::System.Drawing.Point(419, 499);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(159, 52);
			this.button1.TabIndex = 13;
			this.button1.Text = "Accept";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.SystemColors.ControlDarkDark;
			this.label4.Location = new global::System.Drawing.Point(22, 411);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(934, 56);
			this.label4.TabIndex = 11;
			this.label4.Text = componentResourceManager.GetString("label4.Text");
			this.pictureBox2.BackgroundImage = global::C3DIfcAlignmentPlugIn.Properties.Resources.Logo;
			this.pictureBox2.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox2.InitialImage = global::C3DIfcAlignmentPlugIn.Properties.Resources.Logo;
			this.pictureBox2.Location = new global::System.Drawing.Point(636, 38);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(320, 324);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Window;
			base.ClientSize = new global::System.Drawing.Size(1006, 568);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.label4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "License";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "License Agreement";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000042 RID: 66
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.ColorDialog colorDialog1;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.PictureBox pictureBox2;
	}
}
