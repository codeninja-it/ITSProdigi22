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
			txtUrl = new TextBox();
			txtRoot = new TextBox();
			btnScegli = new Button();
			dlgCartella = new FolderBrowserDialog();
			lstRichieste = new ListBox();
			SuspendLayout();
			// 
			// btnAvvia
			// 
			btnAvvia.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnAvvia.Location = new Point(12, 392);
			btnAvvia.Name = "btnAvvia";
			btnAvvia.Size = new Size(623, 46);
			btnAvvia.TabIndex = 0;
			btnAvvia.Text = "avvia";
			btnAvvia.UseVisualStyleBackColor = true;
			btnAvvia.Click += btnAvvia_Click;
			// 
			// txtUrl
			// 
			txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtUrl.Location = new Point(12, 12);
			txtUrl.Name = "txtUrl";
			txtUrl.Size = new Size(623, 39);
			txtUrl.TabIndex = 1;
			txtUrl.Text = "http://127.0.0.1:8080/";
			// 
			// txtRoot
			// 
			txtRoot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			txtRoot.Location = new Point(12, 61);
			txtRoot.Name = "txtRoot";
			txtRoot.ReadOnly = true;
			txtRoot.Size = new Size(532, 39);
			txtRoot.TabIndex = 2;
			// 
			// btnScegli
			// 
			btnScegli.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnScegli.Location = new Point(550, 57);
			btnScegli.Name = "btnScegli";
			btnScegli.Size = new Size(85, 46);
			btnScegli.TabIndex = 3;
			btnScegli.Text = "...";
			btnScegli.UseVisualStyleBackColor = true;
			btnScegli.Click += btnScegli_Click;
			// 
			// lstRichieste
			// 
			lstRichieste.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lstRichieste.FormattingEnabled = true;
			lstRichieste.IntegralHeight = false;
			lstRichieste.ItemHeight = 32;
			lstRichieste.Location = new Point(12, 109);
			lstRichieste.Name = "lstRichieste";
			lstRichieste.Size = new Size(623, 277);
			lstRichieste.TabIndex = 4;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(647, 450);
			Controls.Add(lstRichieste);
			Controls.Add(btnScegli);
			Controls.Add(txtRoot);
			Controls.Add(txtUrl);
			Controls.Add(btnAvvia);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnAvvia;
		private TextBox txtUrl;
		private TextBox txtRoot;
		private Button btnScegli;
		private FolderBrowserDialog dlgCartella;
		private ListBox lstRichieste;
	}
}