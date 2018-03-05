namespace Network_Tick_Tack_To
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupbox1;
		
		private GamePitch gp = new GamePitch();
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.groupbox1 = new System.Windows.Forms.GroupBox();
			this.groupbox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Neues Spiel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 45);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(248, 78);
			this.textBox1.TabIndex = 2;
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(135, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(119, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Spiel beenden";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// groupbox1
			// 
			this.groupbox1.Controls.Add(this.button2);
			this.groupbox1.Controls.Add(this.textBox1);
			this.groupbox1.Controls.Add(this.button1);
			this.groupbox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.groupbox1.Location = new System.Drawing.Point(12, 12);
			this.groupbox1.Name = "groupbox1";
			this.groupbox1.Size = new System.Drawing.Size(260, 129);
			this.groupbox1.TabIndex = 99;
			this.groupbox1.TabStop = false;
			this.groupbox1.Text = "Spielfunktionen";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 415);
			this.Controls.Add(this.groupbox1);
			
			//TODO: Implement dynamic GamePitchItem creation as settings
			for (int down = 0; down <= 2; down++) {
				for (int left = 0; left <= 2; left++) {
					this.Controls.Add(gp.getPitchItem(down, left));
				}
			}
			
			this.Name = "MainForm";
			this.Text = "Network_Tick_Tack_To";
			this.groupbox1.ResumeLayout(false);
			this.groupbox1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
