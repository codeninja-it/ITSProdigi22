namespace WebClient
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
			txtUrl = new TextBox();
			btnVai = new Button();
			lstParole = new ListBox();
			SuspendLayout();
			// 
			// txtUrl
			// 
			txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtUrl.Location = new Point(12, 16);
			txtUrl.Name = "txtUrl";
			txtUrl.Size = new Size(637, 39);
			txtUrl.TabIndex = 0;
			// 
			// btnVai
			// 
			btnVai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnVai.Location = new Point(655, 12);
			btnVai.Name = "btnVai";
			btnVai.Size = new Size(150, 46);
			btnVai.TabIndex = 1;
			btnVai.Text = "vai";
			btnVai.UseVisualStyleBackColor = true;
			btnVai.Click += btnVai_Click;
			// 
			// lstParole
			// 
			lstParole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstParole.FormattingEnabled = true;
			lstParole.IntegralHeight = false;
			lstParole.ItemHeight = 32;
			lstParole.Location = new Point(12, 64);
			lstParole.Name = "lstParole";
			lstParole.Size = new Size(793, 381);
			lstParole.TabIndex = 2;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(817, 457);
			Controls.Add(lstParole);
			Controls.Add(btnVai);
			Controls.Add(txtUrl);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtUrl;
		private Button btnVai;
		private ListBox lstParole;
	}
}