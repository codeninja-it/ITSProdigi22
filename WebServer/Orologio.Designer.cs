namespace WebServer
{
	partial class Orologio
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			lblOrario = new Label();
			tmrOra = new System.Windows.Forms.Timer(components);
			SuspendLayout();
			// 
			// lblOrario
			// 
			lblOrario.AutoSize = true;
			lblOrario.Location = new Point(21, 21);
			lblOrario.Name = "lblOrario";
			lblOrario.Size = new Size(78, 32);
			lblOrario.TabIndex = 0;
			lblOrario.Text = "label1";
			// 
			// tmrOra
			// 
			tmrOra.Enabled = true;
			tmrOra.Interval = 1000;
			tmrOra.Tick += tmrOra_Tick;
			// 
			// Orologio
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(516, 95);
			Controls.Add(lblOrario);
			Name = "Orologio";
			Text = "Orologio";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblOrario;
		private System.Windows.Forms.Timer tmrOra;
	}
}