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
            this.pctLabirinto = new System.Windows.Forms.PictureBox();
            this.lstSoluzioni = new System.Windows.Forms.ListBox();
            this.btnRisolvi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuApri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalva = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEsci = new System.Windows.Forms.ToolStripMenuItem();
            this.disegnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgApri = new System.Windows.Forms.OpenFileDialog();
            this.dlgSalva = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pctLabirinto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctLabirinto
            // 
            this.pctLabirinto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pctLabirinto.Location = new System.Drawing.Point(12, 27);
            this.pctLabirinto.Name = "pctLabirinto";
            this.pctLabirinto.Size = new System.Drawing.Size(466, 392);
            this.pctLabirinto.TabIndex = 0;
            this.pctLabirinto.TabStop = false;
            this.pctLabirinto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctLabirinto_MouseMove);
            // 
            // lstSoluzioni
            // 
            this.lstSoluzioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSoluzioni.FormattingEnabled = true;
            this.lstSoluzioni.IntegralHeight = false;
            this.lstSoluzioni.ItemHeight = 20;
            this.lstSoluzioni.Location = new System.Drawing.Point(484, 27);
            this.lstSoluzioni.Name = "lstSoluzioni";
            this.lstSoluzioni.Size = new System.Drawing.Size(477, 392);
            this.lstSoluzioni.TabIndex = 1;
            // 
            // btnRisolvi
            // 
            this.btnRisolvi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRisolvi.Location = new System.Drawing.Point(12, 430);
            this.btnRisolvi.Name = "btnRisolvi";
            this.btnRisolvi.Size = new System.Drawing.Size(949, 29);
            this.btnRisolvi.TabIndex = 2;
            this.btnRisolvi.Text = "risolvi";
            this.btnRisolvi.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.disegnaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuApri,
            this.mnuSalva,
            this.mnuEsci});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuApri
            // 
            this.mnuApri.Name = "mnuApri";
            this.mnuApri.Size = new System.Drawing.Size(224, 26);
            this.mnuApri.Text = "Apri";
            this.mnuApri.Click += new System.EventHandler(this.mnuApri_Click);
            // 
            // mnuSalva
            // 
            this.mnuSalva.Name = "mnuSalva";
            this.mnuSalva.Size = new System.Drawing.Size(224, 26);
            this.mnuSalva.Text = "Salva";
            this.mnuSalva.Click += new System.EventHandler(this.mnuSalva_Click);
            // 
            // mnuEsci
            // 
            this.mnuEsci.Name = "mnuEsci";
            this.mnuEsci.Size = new System.Drawing.Size(224, 26);
            this.mnuEsci.Text = "Esci";
            this.mnuEsci.Click += new System.EventHandler(this.mnuEsci_Click);
            // 
            // disegnaToolStripMenuItem
            // 
            this.disegnaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muroToolStripMenuItem,
            this.stradaToolStripMenuItem});
            this.disegnaToolStripMenuItem.Name = "disegnaToolStripMenuItem";
            this.disegnaToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.disegnaToolStripMenuItem.Text = "Disegna";
            // 
            // muroToolStripMenuItem
            // 
            this.muroToolStripMenuItem.Name = "muroToolStripMenuItem";
            this.muroToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.muroToolStripMenuItem.Text = "Muro";
            // 
            // stradaToolStripMenuItem
            // 
            this.stradaToolStripMenuItem.Name = "stradaToolStripMenuItem";
            this.stradaToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.stradaToolStripMenuItem.Text = "Strada";
            // 
            // dlgApri
            // 
            this.dlgApri.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 471);
            this.Controls.Add(this.btnRisolvi);
            this.Controls.Add(this.lstSoluzioni);
            this.Controls.Add(this.pctLabirinto);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pctLabirinto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ToolStripMenuItem muroToolStripMenuItem;
        private ToolStripMenuItem stradaToolStripMenuItem;
    }
}