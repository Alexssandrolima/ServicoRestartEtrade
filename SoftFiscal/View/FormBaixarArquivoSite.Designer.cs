namespace SoftFiscal.View
{
    partial class FormBaixarArquivoSite
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LbStatusDownload = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 226);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(860, 23);
            this.progressBar.TabIndex = 0;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // LbStatusDownload
            // 
            this.LbStatusDownload.AutoSize = true;
            this.LbStatusDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbStatusDownload.Location = new System.Drawing.Point(12, 83);
            this.LbStatusDownload.Name = "LbStatusDownload";
            this.LbStatusDownload.Size = new System.Drawing.Size(225, 29);
            this.LbStatusDownload.TabIndex = 1;
            this.LbStatusDownload.Text = "Download Arquivo";
            this.LbStatusDownload.Click += new System.EventHandler(this.LbStatusDownload_Click);
            // 
            // FormBaixarArquivoSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 261);
            this.Controls.Add(this.LbStatusDownload);
            this.Controls.Add(this.progressBar);
            this.Name = "FormBaixarArquivoSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixando Arquivo do Site";
            this.Load += new System.EventHandler(this.FormBaixarArquivoSite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label LbStatusDownload;
    }
}