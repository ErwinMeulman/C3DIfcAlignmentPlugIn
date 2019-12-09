namespace C3DIfcAlignmentPlugIn.forms
{
	// Token: 0x02000004 RID: 4
	public partial class Import : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00003F3B File Offset: 0x0000213B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003F5C File Offset: 0x0000215C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::C3DIfcAlignmentPlugIn.forms.Import));
			this.label17 = new global::System.Windows.Forms.Label();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.simplicity = new global::System.Windows.Forms.TextBox();
			this.toolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new global::System.Drawing.Point(12, 63);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(259, 25);
			this.label17.TabIndex = 16;
			this.label17.Text = "What do you want to import?";
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(17, 136);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(106, 24);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "Alignment";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(17, 106);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(91, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Surface";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.pictureBox1.BackgroundImage = global::C3DIfcAlignmentPlugIn.Properties.Resources.Import_Icon;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new global::System.Drawing.Point(280, 210);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(73, 65);
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			this.button1.Location = new global::System.Drawing.Point(371, 210);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(254, 65);
			this.button1.TabIndex = 3;
			this.button1.Text = "Import";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(382, 25);
			this.label1.TabIndex = 17;
			this.label1.Text = "Specifiy simplification of the surface import:";
			this.simplicity.Location = new global::System.Drawing.Point(415, 10);
			this.simplicity.Name = "simplicity";
			this.simplicity.Size = new global::System.Drawing.Size(201, 26);
			this.simplicity.TabIndex = 0;
			this.simplicity.Text = "1";
			this.toolTip1.SetToolTip(this.simplicity, componentResourceManager.GetString("simplicity.ToolTip"));
			this.simplicity.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Menu;
			base.ClientSize = new global::System.Drawing.Size(637, 287);
			base.Controls.Add(this.simplicity);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label17);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Name = "Import";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Import";
			base.Load += new global::System.EventHandler(this.Import_Load);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000005 RID: 5
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000007 RID: 7
		public global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x04000008 RID: 8
		public global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.ToolTip toolTip1;

		// Token: 0x0400000D RID: 13
		internal global::System.Windows.Forms.TextBox simplicity;
	}
}
