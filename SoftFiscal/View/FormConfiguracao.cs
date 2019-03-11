using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftFiscal.View
{
    public partial class FormConfiguracao : Form
    {
        public FormConfiguracao()
        {
            InitializeComponent();
        }

        private void FormConfiguracao_Load(object sender, EventArgs e)
        {

            cbTEF.Checked = Convert.ToBoolean(Properties.Settings.Default.UsarTef);

            comboBoxPasta.Text = Properties.Settings.Default.UsarSistema;
            textBoxNomeEmpresa.Text = Properties.Settings.Default.UsarNomeEmpresa;
            
            
            //comboBoxPasta.Text = "Etrade";




            
            string txtIP = Convert.ToString(Properties.Settings.Default.myColor);




            //Properties.Settings.Default.myColor = Color.AliceBlue;

           // Properties.Settings.Default.Save();

            //MetodoSalvarConfiguracoes();

        }

        private void MetodoSalvarConfiguracoes()
        { 
            Properties.Settings.Default.UsarTef = Convert.ToString(cbTEF.Checked);
            Properties.Settings.Default.UsarSistema = Convert.ToString(comboBoxPasta.Text);
            Properties.Settings.Default.UsarNomeEmpresa = Convert.ToString(textBoxNomeEmpresa.Text);
            Properties.Settings.Default.Save();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            MetodoSalvarConfiguracoes();
            vairealmentereiniciaraplicacao = true;
            bReiniciarAplicacaoconfigurado();
            this.Close();
        }

        private void cbTEF_MouseDown(object sender, MouseEventArgs e)
        {

           // MetodoSalvarConfiguracoes();
        }

        public string sValor { get; set; }

        internal bool bReiniciarAplicacaoconfigurado()
        {
            return vairealmentereiniciaraplicacao;
        }

        public bool vairealmentereiniciaraplicacao { get; set; }

        private void btSair_Click(object sender, EventArgs e)
        {
            vairealmentereiniciaraplicacao = false;
            bReiniciarAplicacaoconfigurado();
            this.Close();

        }

        private void panelmenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
