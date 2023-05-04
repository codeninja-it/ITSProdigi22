namespace BloccoNote
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuApri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalva = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEsci = new System.Windows.Forms.ToolStripMenuItem();
            this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCorpo = new System.Windows.Forms.TextBox();
            this.dlgApri = new System.Windows.Forms.OpenFileDialog();
            this.dlgSalva = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.opzioniToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(523, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuApri,
            this.mnuSalva,
            this.mnuEsci});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fIleToolStripMenuItem.Text = "FIle";
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
            // opzioniToolStripMenuItem
            // 
            this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.opzioniToolStripMenuItem.Text = "Opzioni";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 24);
            this.toolStripMenuItem1.Text = "?";
            // 
            // txtCorpo
            // 
            this.txtCorpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCorpo.Location = new System.Drawing.Point(0, 28);
            this.txtCorpo.Multiline = true;
            this.txtCorpo.Name = "txtCorpo";
            this.txtCorpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCorpo.Size = new System.Drawing.Size(523, 256);
            this.txtCorpo.TabIndex = 1;
            // 
            // dlgApri
            // 
            this.dlgApri.Filter = "File di testo|*.txt|Tutti i file|*.*";
            // 
            // dlgSalva
            // 
            this.dlgSalva.Filter = "File di testo|*.txt|Tutti i file|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 284);
            this.Controls.Add(this.txtCorpo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fIleToolStripMenuItem;
        private ToolStripMenuItem mnuApri;
        private ToolStripMenuItem mnuSalva;
        private ToolStripMenuItem mnuEsci;
        private ToolStripMenuItem opzioniToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private TextBox txtCorpo;
        private OpenFileDialog dlgApri;
        private SaveFileDialog dlgSalva;
    }
}