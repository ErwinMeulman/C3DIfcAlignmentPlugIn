namespace C3DIfcAlignmentPlugIn.Forms
{
	// Token: 0x02000007 RID: 7
	public partial class Export : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000049AF File Offset: 0x00002BAF
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000049D0 File Offset: 0x00002BD0
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.orgaName = new global::System.Windows.Forms.MaskedTextBox();
			this.orgaAddresses = new global::System.Windows.Forms.ListBox();
			this.orgaRoles = new global::System.Windows.Forms.ListBox();
			this.orgaDesc = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.coorMapZone = new global::System.Windows.Forms.TextBox();
			this.coorMapProj = new global::System.Windows.Forms.TextBox();
			this.coorVertDate = new global::System.Windows.Forms.TextBox();
			this.coorGeoDate = new global::System.Windows.Forms.TextBox();
			this.coorDesc = new global::System.Windows.Forms.TextBox();
			this.coorName = new global::System.Windows.Forms.TextBox();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.personAddresses = new global::System.Windows.Forms.ListBox();
			this.personRoles = new global::System.Windows.Forms.ListBox();
			this.personMiddleName = new global::System.Windows.Forms.TextBox();
			this.personLastName = new global::System.Windows.Forms.TextBox();
			this.personTitle = new global::System.Windows.Forms.TextBox();
			this.personFirstName = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.orgaName);
			this.groupBox1.Controls.Add(this.orgaAddresses);
			this.groupBox1.Controls.Add(this.orgaRoles);
			this.groupBox1.Controls.Add(this.orgaDesc);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new global::System.Drawing.Point(576, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(578, 281);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Organisation";
			this.groupBox1.Enter += new global::System.EventHandler(this.groupBox1_Enter);
			this.orgaName.Location = new global::System.Drawing.Point(198, 37);
			this.orgaName.Name = "orgaName";
			this.orgaName.Size = new global::System.Drawing.Size(349, 30);
			this.orgaName.TabIndex = 6;
			this.orgaName.MaskInputRejected += new global::System.Windows.Forms.MaskInputRejectedEventHandler(this.orgaName_MaskInputRejected);
			this.orgaAddresses.AllowDrop = true;
			this.orgaAddresses.FormattingEnabled = true;
			this.orgaAddresses.ItemHeight = 25;
			this.orgaAddresses.Items.AddRange(new object[]
			{
				"DISTRIBUTIONPOINT",
				"HOME",
				"OFFICE",
				"SITE",
				"USERDEFINED"
			});
			this.orgaAddresses.Location = new global::System.Drawing.Point(198, 145);
			this.orgaAddresses.Name = "orgaAddresses";
			this.orgaAddresses.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiExtended;
			this.orgaAddresses.Size = new global::System.Drawing.Size(349, 29);
			this.orgaAddresses.Sorted = true;
			this.orgaAddresses.TabIndex = 9;
			this.orgaAddresses.Visible = false;
			this.orgaRoles.AllowDrop = true;
			this.orgaRoles.FormattingEnabled = true;
			this.orgaRoles.ItemHeight = 25;
			this.orgaRoles.Items.AddRange(new object[]
			{
				"SUPPLIER",
				"MANUFACTURER",
				"CONTRACTOR",
				"SUBCONTRACTOR",
				"ARCHITECT",
				"STRUCTURALENGINEER",
				"COSTENGINEER",
				"CLIENT",
				"BUILDINGOWNER",
				"BUILDINGOPERATOR",
				"MECHANICALENGINEER",
				"ELECTRICALENGINEER",
				"PROJECTMANAGER",
				"FACILITIESMANAGER",
				"CIVILENGINEER",
				"COMISSIONINGENGINEER",
				"ENGINEER",
				"OWNER",
				"CONSULTANT",
				"CONSTRUCTIONMANAGER",
				"FIELDCONSTRUCTIONMANAGER",
				"RESELLER",
				"USERDEFINED"
			});
			this.orgaRoles.Location = new global::System.Drawing.Point(198, 110);
			this.orgaRoles.Name = "orgaRoles";
			this.orgaRoles.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiExtended;
			this.orgaRoles.Size = new global::System.Drawing.Size(349, 29);
			this.orgaRoles.TabIndex = 8;
			this.orgaRoles.Visible = false;
			this.orgaDesc.Location = new global::System.Drawing.Point(198, 75);
			this.orgaDesc.Name = "orgaDesc";
			this.orgaDesc.Size = new global::System.Drawing.Size(349, 30);
			this.orgaDesc.TabIndex = 7;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(6, 149);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(112, 25);
			this.label4.TabIndex = 4;
			this.label4.Text = "Addresses:";
			this.label4.Visible = false;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(6, 42);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(186, 25);
			this.label3.TabIndex = 3;
			this.label3.Text = "Organisation Name:";
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(9, 115);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(67, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "Roles:";
			this.label2.Visible = false;
			this.label2.Click += new global::System.EventHandler(this.label2_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 78);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(115, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Description:";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.groupBox2.Controls.Add(this.coorMapZone);
			this.groupBox2.Controls.Add(this.coorMapProj);
			this.groupBox2.Controls.Add(this.coorVertDate);
			this.groupBox2.Controls.Add(this.coorGeoDate);
			this.groupBox2.Controls.Add(this.coorDesc);
			this.groupBox2.Controls.Add(this.coorName);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 299);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(558, 265);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Coordinate Reference System";
			this.coorMapZone.Location = new global::System.Drawing.Point(172, 218);
			this.coorMapZone.Name = "coorMapZone";
			this.coorMapZone.Size = new global::System.Drawing.Size(360, 30);
			this.coorMapZone.TabIndex = 15;
			this.coorMapProj.Location = new global::System.Drawing.Point(172, 182);
			this.coorMapProj.Name = "coorMapProj";
			this.coorMapProj.Size = new global::System.Drawing.Size(360, 30);
			this.coorMapProj.TabIndex = 14;
			this.coorVertDate.Location = new global::System.Drawing.Point(172, 146);
			this.coorVertDate.Name = "coorVertDate";
			this.coorVertDate.Size = new global::System.Drawing.Size(360, 30);
			this.coorVertDate.TabIndex = 13;
			this.coorGeoDate.Location = new global::System.Drawing.Point(172, 110);
			this.coorGeoDate.Name = "coorGeoDate";
			this.coorGeoDate.Size = new global::System.Drawing.Size(360, 30);
			this.coorGeoDate.TabIndex = 12;
			this.coorDesc.Location = new global::System.Drawing.Point(172, 74);
			this.coorDesc.Name = "coorDesc";
			this.coorDesc.Size = new global::System.Drawing.Size(360, 30);
			this.coorDesc.TabIndex = 11;
			this.coorName.Location = new global::System.Drawing.Point(172, 37);
			this.coorName.Name = "coorName";
			this.coorName.Size = new global::System.Drawing.Size(360, 30);
			this.coorName.TabIndex = 10;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(6, 149);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(145, 25);
			this.label16.TabIndex = 5;
			this.label16.Text = "Vertical Datum:";
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(6, 113);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(158, 25);
			this.label15.TabIndex = 4;
			this.label15.Text = "Geodetic Datum:";
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(6, 77);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(115, 25);
			this.label14.TabIndex = 3;
			this.label14.Text = "Description:";
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(11, 221);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(107, 25);
			this.label13.TabIndex = 2;
			this.label13.Text = "Map Zone:";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(6, 185);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(148, 25);
			this.label12.TabIndex = 1;
			this.label12.Text = "Map Projection:";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(6, 40);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(70, 25);
			this.label6.TabIndex = 0;
			this.label6.Text = "Name:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(6, 42);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(112, 25);
			this.label5.TabIndex = 2;
			this.label5.Text = "First Name:";
			this.label5.Click += new global::System.EventHandler(this.label5_Click);
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(6, 184);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(67, 25);
			this.label7.TabIndex = 1;
			this.label7.Text = "Roles:";
			this.label7.Visible = false;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(6, 149);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(55, 25);
			this.label8.TabIndex = 2;
			this.label8.Text = "Title:";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(6, 78);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(133, 25);
			this.label9.TabIndex = 3;
			this.label9.Text = "Middle Name:";
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(6, 115);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(112, 25);
			this.label10.TabIndex = 3;
			this.label10.Text = "Last Name:";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(6, 219);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(112, 25);
			this.label11.TabIndex = 4;
			this.label11.Text = "Addresses:";
			this.label11.Visible = false;
			this.groupBox3.Controls.Add(this.personAddresses);
			this.groupBox3.Controls.Add(this.personRoles);
			this.groupBox3.Controls.Add(this.personMiddleName);
			this.groupBox3.Controls.Add(this.personLastName);
			this.groupBox3.Controls.Add(this.personTitle);
			this.groupBox3.Controls.Add(this.personFirstName);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(558, 281);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Person";
			this.personAddresses.FormattingEnabled = true;
			this.personAddresses.ItemHeight = 25;
			this.personAddresses.Items.AddRange(new object[]
			{
				"OFFICE",
				"SITE",
				"HOME",
				"DISTRIBUTIONPOINT",
				"USERDEFINED"
			});
			this.personAddresses.Location = new global::System.Drawing.Point(172, 219);
			this.personAddresses.Name = "personAddresses";
			this.personAddresses.Size = new global::System.Drawing.Size(360, 29);
			this.personAddresses.TabIndex = 5;
			this.personAddresses.Visible = false;
			this.personRoles.FormattingEnabled = true;
			this.personRoles.ItemHeight = 25;
			this.personRoles.Items.AddRange(new object[]
			{
				"SUPPLIER",
				"MANUFACTURER",
				"CONTRACTOR",
				"SUBCONTRACTOR",
				"ARCHITECT",
				"STRUCTURALENGINEER",
				"COSTENGINEER",
				"CLIENT",
				"BUILDINGOWNER",
				"BUILDINGOPERATOR",
				"MECHANICALENGINEER",
				"ELECTRICALENGINEER",
				"PROJECTMANAGER",
				"FACILITIESMANAGER",
				"CIVILENGINEER",
				"COMISSIONINGENGINEER",
				"ENGINEER",
				"OWNER",
				"CONSULTANT",
				"CONSTRUCTIONMANAGER",
				"FIELDCONSTRUCTIONMANAGER",
				"RESELLER",
				"USERDEFINED"
			});
			this.personRoles.Location = new global::System.Drawing.Point(172, 184);
			this.personRoles.Name = "personRoles";
			this.personRoles.SelectionMode = global::System.Windows.Forms.SelectionMode.MultiSimple;
			this.personRoles.Size = new global::System.Drawing.Size(360, 29);
			this.personRoles.TabIndex = 4;
			this.personRoles.Visible = false;
			this.personMiddleName.Location = new global::System.Drawing.Point(172, 75);
			this.personMiddleName.Name = "personMiddleName";
			this.personMiddleName.Size = new global::System.Drawing.Size(360, 30);
			this.personMiddleName.TabIndex = 1;
			this.personLastName.Location = new global::System.Drawing.Point(172, 112);
			this.personLastName.Name = "personLastName";
			this.personLastName.Size = new global::System.Drawing.Size(360, 30);
			this.personLastName.TabIndex = 2;
			this.personTitle.Location = new global::System.Drawing.Point(172, 146);
			this.personTitle.Name = "personTitle";
			this.personTitle.Size = new global::System.Drawing.Size(360, 30);
			this.personTitle.TabIndex = 3;
			this.personFirstName.Location = new global::System.Drawing.Point(172, 39);
			this.personFirstName.Name = "personFirstName";
			this.personFirstName.Size = new global::System.Drawing.Size(360, 30);
			this.personFirstName.TabIndex = 0;
			this.button1.Location = new global::System.Drawing.Point(900, 499);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(254, 65);
			this.button1.TabIndex = 18;
			this.button1.Text = "Export";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.pictureBox1.BackgroundImage = global::C3DIfcAlignmentPlugIn.Properties.Resources.Export_Icon;
			this.pictureBox1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new global::System.Drawing.Point(809, 499);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(73, 65);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new global::System.Drawing.Point(823, 375);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(91, 24);
			this.checkBox1.TabIndex = 16;
			this.checkBox1.Text = "Surface";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new global::System.Drawing.Point(823, 405);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(106, 24);
			this.checkBox2.TabIndex = 17;
			this.checkBox2.Text = "Alignment";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new global::System.Drawing.Point(818, 336);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(260, 25);
			this.label17.TabIndex = 11;
			this.label17.Text = "What do you want to export?";
			base.AcceptButton = this.button1;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Menu;
			base.ClientSize = new global::System.Drawing.Size(1174, 585);
			base.Controls.Add(this.label17);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Export";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Export to IFC";
			base.Load += new global::System.EventHandler(this.Export_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000019 RID: 25
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000021 RID: 33
		public global::System.Windows.Forms.ListBox orgaRoles;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000029 RID: 41
		public global::System.Windows.Forms.ListBox orgaAddresses;

		// Token: 0x0400002A RID: 42
		public global::System.Windows.Forms.TextBox orgaDesc;

		// Token: 0x0400002B RID: 43
		public global::System.Windows.Forms.MaskedTextBox orgaName;

		// Token: 0x0400002C RID: 44
		public global::System.Windows.Forms.TextBox coorMapZone;

		// Token: 0x0400002D RID: 45
		public global::System.Windows.Forms.TextBox coorMapProj;

		// Token: 0x0400002E RID: 46
		public global::System.Windows.Forms.TextBox coorVertDate;

		// Token: 0x0400002F RID: 47
		public global::System.Windows.Forms.TextBox coorGeoDate;

		// Token: 0x04000030 RID: 48
		public global::System.Windows.Forms.TextBox coorDesc;

		// Token: 0x04000031 RID: 49
		public global::System.Windows.Forms.TextBox coorName;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000037 RID: 55
		public global::System.Windows.Forms.ListBox personAddresses;

		// Token: 0x04000038 RID: 56
		public global::System.Windows.Forms.ListBox personRoles;

		// Token: 0x04000039 RID: 57
		public global::System.Windows.Forms.TextBox personMiddleName;

		// Token: 0x0400003A RID: 58
		public global::System.Windows.Forms.TextBox personLastName;

		// Token: 0x0400003B RID: 59
		public global::System.Windows.Forms.TextBox personTitle;

		// Token: 0x0400003C RID: 60
		public global::System.Windows.Forms.TextBox personFirstName;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400003E RID: 62
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400003F RID: 63
		public global::System.Windows.Forms.CheckBox checkBox1;

		// Token: 0x04000040 RID: 64
		public global::System.Windows.Forms.CheckBox checkBox2;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label label17;
	}
}
