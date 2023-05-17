namespace WebServer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnAvvia = new Button();
			SuspendLayout();
			// 
			// btnAvvia
			// 
			btnAvvia.Location = new Point(333, 124);
			btnAvvia.Name = "btnAvvia";
			btnAvvia.Size = new Size(150, 46);
			btnAvvia.TabIndex = 0;
			btnAvvia.Text = "avvia";
			btnAvvia.UseVisualStyleBackColor = true;
			btnAvvia.Click += btnAvvia_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnAvvia);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button btnAvvia;
	}
}