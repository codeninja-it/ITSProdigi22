namespace EmailScavenger
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
			txtIndirizzo = new TextBox();
			btnAnalizza = new Button();
			lstRisultati = new ListBox();
			SuspendLayout();
			// 
			// txtIndirizzo
			// 
			txtIndirizzo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtIndirizzo.Location = new Point(12, 16);
			txtIndirizzo.Name = "txtIndirizzo";
			txtIndirizzo.PlaceholderText = "indirizzo...";
			txtIndirizzo.Size = new Size(712, 39);
			txtIndirizzo.TabIndex = 0;
			// 
			// btnAnalizza
			// 
			btnAnalizza.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnAnalizza.Location = new Point(730, 12);
			btnAnalizza.Name = "btnAnalizza";
			btnAnalizza.Size = new Size(150, 46);
			btnAnalizza.TabIndex = 1;
			btnAnalizza.Text = "analizza";
			btnAnalizza.UseVisualStyleBackColor = true;
			btnAnalizza.Click += btnAnalizza_Click;
			// 
			// lstRisultati
			// 
			lstRisultati.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstRisultati.FormattingEnabled = true;
			lstRisultati.IntegralHeight = false;
			lstRisultati.ItemHeight = 32;
			lstRisultati.Location = new Point(12, 64);
			lstRisultati.Name = "lstRisultati";
			lstRisultati.Size = new Size(868, 810);
			lstRisultati.TabIndex = 2;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(892, 886);
			Controls.Add(lstRisultati);
			Controls.Add(btnAnalizza);
			Controls.Add(txtIndirizzo);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtIndirizzo;
		private Button btnAnalizza;
		private ListBox lstRisultati;
	}
}