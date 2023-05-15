namespace LabirintoWin
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
			pctLabirinto = new PictureBox();
			lstSoluzioni = new ListBox();
			btnRisolvi = new Button();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			mnuApri = new ToolStripMenuItem();
			mnuSalva = new ToolStripMenuItem();
			mnuEsci = new ToolStripMenuItem();
			disegnaToolStripMenuItem = new ToolStripMenuItem();
			mnuMuro = new ToolStripMenuItem();
			mnuInizio = new ToolStripMenuItem();
			dlgApri = new OpenFileDialog();
			dlgSalva = new SaveFileDialog();
			txtPreview = new TextBox();
			((System.ComponentModel.ISupportInitialize)pctLabirinto).BeginInit();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// pctLabirinto
			// 
			pctLabirinto.Location = new Point(20, 43);
			pctLabirinto.Margin = new Padding(5);
			pctLabirinto.Name = "pctLabirinto";
			pctLabirinto.Size = new Size(757, 627);
			pctLabirinto.TabIndex = 0;
			pctLabirinto.TabStop = false;
			pctLabirinto.MouseMove += pctLabirinto_MouseMove;
			// 
			// lstSoluzioni
			// 
			lstSoluzioni.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			lstSoluzioni.FormattingEnabled = true;
			lstSoluzioni.IntegralHeight = false;
			lstSoluzioni.ItemHeight = 32;
			lstSoluzioni.Location = new Point(20, 680);
			lstSoluzioni.Margin = new Padding(5);
			lstSoluzioni.Name = "lstSoluzioni";
			lstSoluzioni.Size = new Size(757, 292);
			lstSoluzioni.TabIndex = 1;
			lstSoluzioni.SelectedIndexChanged += lstSoluzioni_SelectedIndexChanged;
			// 
			// btnRisolvi
			// 
			btnRisolvi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			btnRisolvi.Location = new Point(20, 982);
			btnRisolvi.Margin = new Padding(5);
			btnRisolvi.Name = "btnRisolvi";
			btnRisolvi.Size = new Size(1594, 46);
			btnRisolvi.TabIndex = 2;
			btnRisolvi.Text = "risolvi";
			btnRisolvi.UseVisualStyleBackColor = true;
			btnRisolvi.Click += btnRisolvi_Click;
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, disegnaToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(10, 3, 0, 3);
			menuStrip1.Size = new Size(1633, 42);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuApri, mnuSalva, mnuEsci });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(71, 36);
			fileToolStripMenuItem.Text = "File";
			// 
			// mnuApri
			// 
			mnuApri.Name = "mnuApri";
			mnuApri.Size = new Size(202, 44);
			mnuApri.Text = "Apri";
			mnuApri.Click += mnuApri_Click;
			// 
			// mnuSalva
			// 
			mnuSalva.Name = "mnuSalva";
			mnuSalva.Size = new Size(202, 44);
			mnuSalva.Text = "Salva";
			mnuSalva.Click += mnuSalva_Click;
			// 
			// mnuEsci
			// 
			mnuEsci.Name = "mnuEsci";
			mnuEsci.Size = new Size(202, 44);
			mnuEsci.Text = "Esci";
			mnuEsci.Click += mnuEsci_Click;
			// 
			// disegnaToolStripMenuItem
			// 
			disegnaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuMuro, mnuInizio });
			disegnaToolStripMenuItem.Name = "disegnaToolStripMenuItem";
			disegnaToolStripMenuItem.Size = new Size(120, 36);
			disegnaToolStripMenuItem.Text = "Disegna";
			// 
			// mnuMuro
			// 
			mnuMuro.Checked = true;
			mnuMuro.CheckState = CheckState.Checked;
			mnuMuro.Name = "mnuMuro";
			mnuMuro.Size = new Size(291, 44);
			mnuMuro.Text = "muro / strada";
			mnuMuro.Click += mnuMuro_Click;
			// 
			// mnuInizio
			// 
			mnuInizio.Name = "mnuInizio";
			mnuInizio.Size = new Size(291, 44);
			mnuInizio.Text = "inizio / fine";
			mnuInizio.Click += mnuInizio_Click;
			// 
			// dlgApri
			// 
			dlgApri.FileName = "openFileDialog1";
			// 
			// txtPreview
			// 
			txtPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			txtPreview.Location = new Point(785, 45);
			txtPreview.Multiline = true;
			txtPreview.Name = "txtPreview";
			txtPreview.Size = new Size(829, 929);
			txtPreview.TabIndex = 4;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1633, 1048);
			Controls.Add(txtPreview);
			Controls.Add(btnRisolvi);
			Controls.Add(lstSoluzioni);
			Controls.Add(pctLabirinto);
			Controls.Add(menuStrip1);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(5);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pctLabirinto).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pctLabirinto;
		private ListBox lstSoluzioni;
		private Button btnRisolvi;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem mnuApri;
		private ToolStripMenuItem mnuSalva;
		private ToolStripMenuItem mnuEsci;
		private ToolStripMenuItem disegnaToolStripMenuItem;
		private OpenFileDialog dlgApri;
		private SaveFileDialog dlgSalva;
		private ToolStripMenuItem mnuMuro;
		private ToolStripMenuItem mnuInizio;
		private TextBox txtPreview;
	}
}