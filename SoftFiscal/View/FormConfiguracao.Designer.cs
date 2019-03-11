namespace SoftFiscal.View
{
    partial class FormConfiguracao
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btSair = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPasta = new System.Windows.Forms.ComboBox();
            this.cbTEF = new System.Windows.Forms.CheckBox();
            this.lbUsarTEF = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelNomeempresa = new System.Windows.Forms.Label();
            this.textBoxNomeEmpresa = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panelmenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelmenu);
            this.panel1.Controls.Add(this.btSair);
            this.panel1.Controls.Add(this.btFechar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 303);
            this.panel1.TabIndex = 0;
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panelmenu.Controls.Add(this.label2);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelmenu.Location = new System.Drawing.Point(0, 0);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(599, 24);
            this.panelmenu.TabIndex = 4;
            this.panelmenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelmenu_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Configuração";
            // 
            // btSair
            // 
            this.btSair.Location = new System.Drawing.Point(363, 268);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(109, 23);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "Fec&har";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btFechar
            // 
            this.btFechar.Location = new System.Drawing.Point(478, 268);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(109, 23);
            this.btFechar.TabIndex = 2;
            this.btFechar.Text = "Salvar/&Fechar";
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNomeEmpresa);
            this.groupBox1.Controls.Add(this.labelNomeempresa);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxPasta);
            this.groupBox1.Controls.Add(this.cbTEF);
            this.groupBox1.Controls.Add(this.lbUsarTEF);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 261);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuração Padrão";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escolha o programa de BACKUP?";
            // 
            // comboBoxPasta
            // 
            this.comboBoxPasta.FormattingEnabled = true;
            this.comboBoxPasta.Items.AddRange(new object[] {
            "Etrade",
            "Arpa"});
            this.comboBoxPasta.Location = new System.Drawing.Point(180, 42);
            this.comboBoxPasta.Name = "comboBoxPasta";
            this.comboBoxPasta.Size = new System.Drawing.Size(109, 21);
            this.comboBoxPasta.TabIndex = 2;
            // 
            // cbTEF
            // 
            this.cbTEF.AutoSize = true;
            this.cbTEF.Location = new System.Drawing.Point(180, 19);
            this.cbTEF.Name = "cbTEF";
            this.cbTEF.Size = new System.Drawing.Size(105, 17);
            this.cbTEF.TabIndex = 1;
            this.cbTEF.Text = "Selecionado Sim";
            this.cbTEF.UseVisualStyleBackColor = true;
            this.cbTEF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbTEF_MouseDown);
            // 
            // lbUsarTEF
            // 
            this.lbUsarTEF.AutoSize = true;
            this.lbUsarTEF.Location = new System.Drawing.Point(6, 20);
            this.lbUsarTEF.Name = "lbUsarTEF";
            this.lbUsarTEF.Size = new System.Drawing.Size(55, 13);
            this.lbUsarTEF.TabIndex = 0;
            this.lbUsarTEF.Text = "Usa TEF?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SoftFiscal.Properties.Resources.received_1888505661170849;
            this.pictureBox1.Location = new System.Drawing.Point(313, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelNomeempresa
            // 
            this.labelNomeempresa.AutoSize = true;
            this.labelNomeempresa.Location = new System.Drawing.Point(6, 76);
            this.labelNomeempresa.Name = "labelNomeempresa";
            this.labelNomeempresa.Size = new System.Drawing.Size(100, 13);
            this.labelNomeempresa.TabIndex = 4;
            this.labelNomeempresa.Text = "Nome da Empresa: ";
            // 
            // textBoxNomeEmpresa
            // 
            this.textBoxNomeEmpresa.Location = new System.Drawing.Point(112, 73);
            this.textBoxNomeEmpresa.Name = "textBoxNomeEmpresa";
            this.textBoxNomeEmpresa.Size = new System.Drawing.Size(177, 20);
            this.textBoxNomeEmpresa.TabIndex = 5;
            // 
            // FormConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 303);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.FormConfiguracao_Load);
            this.panel1.ResumeLayout(false);
            this.panelmenu.ResumeLayout(false);
            this.panelmenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbUsarTEF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPasta;
        private System.Windows.Forms.CheckBox cbTEF;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNomeEmpresa;
        private System.Windows.Forms.Label labelNomeempresa;
    }
}