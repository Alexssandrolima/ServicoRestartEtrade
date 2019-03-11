using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using System.IO;

using System.Reflection;
using System.Security.Principal;
using System.Security;
using System.Configuration;




namespace SoftFiscal
{
    public partial class FormPrincipal : Form
    {
        readonly string _varSourcePath = Environment.CurrentDirectory;
        private const string LocalPatch = @"c:\Etrade\";
        private const string LocalArquivoMSSQL = "MSSQL$SQL2014";
        private const string LocalArquivoExecutavelEtrade = "ETrade.exe";
        private const string LocalArquivoExecutavelPDV = "PDV.exe";
        //private const string DiretorioTmpPath = @"c:\tmp";
        public int local1 { get; set; }
        public int local2 { get; set; }

        public string sPastaWwinrar { get; set; }
        public string sziparArquivo { get; set; }

        public FormPrincipal()
        {
            InitializeComponent();
            //Security.AdministradorReiniciar(); 

        }

        

        private void FormPrincipal_Load(object sender, EventArgs e)
        {


            // parar serviços do windows mssql
//            bool bServicoMsSql = Controller.ClsPararServicoMsSql.MetodoPararIniciarServicoSql();

            //MessageBox.Show("-->>" + bServicoMsSql);

            //parar executaveis do windos.
            //bool bParaServidorSql = Controller.ClsPararServidorMsSql2014.METODOParaServidorSqlB();

            toolStripStatusLabelDataHora.Text =  DateTime.Now.ToShortDateString();


            labelPrincipal.Text = Properties.Settings.Default.UsarNomeEmpresa;

            toolStripStatusLabelNomeEmpresa.Text = Properties.Settings.Default.UsarNomeEmpresa;


            bCbTEF = Convert.ToBoolean(Properties.Settings.Default.UsarTef);
            listBox1.Items.Add("* Configuração do TEF: = " + bCbTEF);
            //string txtIP =Convert.ToString( Properties.Settings.Default.myColor);

            btReiniciarTef.Enabled = bCbTEF;
            iniciarservidorToolStripMenuItem.Enabled = bCbTEF;
            reiniciarTEFToolStripMenuItem.Enabled = bCbTEF;

# if DEBUG
            listBox1.Items.Add("** Configuração do TEF: = " + bCbTEF);
# endif            //if (bCbTEF) btReiniciarTef.Enabled = true;

            MinimizarMaximizarListBox();
# if DEBUG
            listBox1.Items.Add("** MINIMIZAR LIST BOX");
# endif
            VaiExecutartudoaoIniciar();
            sLocalPatch.Text = LocalPatch;
            sLocalArquivoMSSQL.Text = LocalArquivoMSSQL;
            sLocalArquivoExecutavelEtrade.Text = LocalArquivoExecutavelEtrade;
            sLocalArquivoExecutavelPDV.Text = LocalArquivoExecutavelPDV;
        }

        private void VaiExecutartudoaoIniciar()
        {
            
            //metodo se existe winrar instalado no comptuador.

            sGoogleDriver = Controller.ClsVerificarGoogleDrive.MetodoExisteGdrive();

            listBox1.Items.Add("* " + sGoogleDriver);
            listBox1.Refresh();
            
            sPastaWwinrar = Controller.ClsExisteWinrar.METODOEXISTEWINRAR();


           // MessageBox.Show(" ->>" + sPastaWwinrar);


            listBox1.Items.Add("* " + sPastaWwinrar);
            listBox1.Refresh();
            //metodo para zipar arquivos e para os executaveis no windows.
            sziparArquivo = Controller.ClsZiparArquivoWinrar.METODOZiparArquivoWinrar(sPastaWwinrar);
            //MessageBox.Show(" ->>>> " + sziparArquivo);
            listBox1.Items.Add("* " + sziparArquivo);
            listBox1.Refresh();

        }





        private void Metodo_MinimizarAplicacao()
        {
            Hide();

            /* Minimizando aplicação na bandeja do windows */
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
        }
        private void Metodo_MostrarAplicacao()
        {
            Show();
            /* Minimizando aplicação na bandeja do windows */
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = true;
        }
        private void MetodoSairFechar(object sender, EventArgs e)
        {
            //metodo para zipar arquivos e para os executaveis no windows.
            sziparArquivo = Controller.ClsZiparArquivoWinrar.METODOZiparArquivoWinrar(sPastaWwinrar);
            listBox1.Items.Add("* " + sziparArquivo);
            Application.Exit();
        }
 
        private void Metodo_PararSistemag5()
        {
            try
            {
                var processes = Process.GetProcessesByName(LocalArquivoExecutavelPDV);
                foreach (var p in processes)
                {
                    listBox1.Items.Add("1 - Parando processo :" + LocalArquivoExecutavelPDV);
                    listBox1.Refresh();
                    p.Kill();
                    listBox1.Items.Add("2 - Aguarde um momento :" + LocalArquivoExecutavelPDV);
                    listBox1.Refresh();
                    p.WaitForExit();
                    listBox1.Items.Add("3 - Parou processo :" + LocalArquivoExecutavelPDV);
                    listBox1.Refresh();
                }

            }
            catch (Exception erroreexecutar)
            {
                listBox1.Items.Add(erroreexecutar + "Ao parar MSSQL2014 ");
                listBox1.Refresh();
                MessageBox.Show(erroreexecutar + "\r \n" + @"Ao parar Sistema, nao executado ", @"Error ao Processa o Parar MSSQL2014  ");
            }

        }
        private void Metodo_voltarServidor()
        {
            try
            {
                bool existearquivoexecutavel = File.Exists(LocalArquivoMSSQL + ".exe");
                if (existearquivoexecutavel)
                {
                    listBox1.Items.Add(@"Executando " + LocalArquivoMSSQL);
                    listBox1.Refresh();
                    Process.Start(LocalArquivoMSSQL);
                }
            }
            catch (Exception x)
            {
                listBox1.Items.Add(@"Error ao executar " + LocalArquivoMSSQL + " " + x.Message);
                listBox1.Refresh();
            }
        }



        private void linkLabelAlexssandrolima_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var sInfo = new ProcessStartInfo("http://alexpagernet.blogspot.com.br/p/profissional.html");

            Process.Start(sInfo);
        }


       
        private void ExecutarIniciarservidor(object sender, EventArgs e)
        {
            listBox1.Items.Add("Iniciando Execução da aplicação...");
            Metodo_ExecutarTudosemExcessao();
        }
        private void Metodo_ExecutarTudosemExcessao()
        {
#if DEBUG
            {
                local1 = _varSourcePath.Length;
                local2 = _varSourcePath.Length;
            }
#else
            {
                local1 = _varSourcePath.Length;
                local2 = LocalPatch.Length;
            }
#endif

            if (local1 == local2)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Executando Em: " + _varSourcePath);
                listBox1.Refresh();
                //este metodo para o sistemaG5
                listBox1.Items.Add("Vamos agora parar o MSSQL2014: " + _varSourcePath);
                listBox1.Refresh();
                Metodo_PararServidor();
                listBox1.Refresh();
                //este metodo para o servidor do digisat
     //           listBox1.Items.Add("Vamos agora parar o servidor: " + _varSourcePath);
     //           listBox1.Refresh();
     //           Metodo_PararServidor();
                //listBox1.Items.Add("Vamos agora Deletar o TMP: " + _varSourcePath);
                //listBox1.Refresh();
                // este metodo limpa as pastas tmp da raiz do c:\
                //Metodo_Deletartmp();
                //listBox1.Refresh();
                // este metodo iniciar o servidor da digisat
                listBox1.Items.Add("Vamos agora Iniciar o servidor: " + _varSourcePath);
                listBox1.Refresh();
                Metodo_voltarServidor();
                listBox1.Refresh();
                // este metodo minimiza o sistema ao lado da hora.
                Metodo_MinimizarAplicacao();
                listBox1.Refresh();
            }
            else
            {

                listBox1.Items.Add(@"Por favor Verifique se o programa esta sendo executado em" + "\n");
                listBox1.Items.Add(@"c:\Etrade\");
                listBox1.Refresh();

                MessageBox.Show(@"Por favor Verifique se o programa esta sendo executado em" + "\n" + @"c:\Etrade\", @"Erro ao Executar a aplicação");
            }
        }
        private void Metodo_PararServidor()
        {
            try
            {
                //var processes = Process.GetProcessesByName(LocalArquivoMSSQL);

                //ServiceController[] services = ServiceController.GetServices(LocalArquivoMSSQL);

                var processes = ServiceController.GetServices();


            //    var processes = Process.GetProcesses();

//                var processes = Process.GetProcesses(LocalArquivoMSSQL);




                foreach (var p in processes)
                {
                    listBox1.Items.Add("1 - Parando processo :" + LocalArquivoMSSQL);
                    listBox1.Refresh();
                 //   p.Kill();
                    listBox1.Items.Add("2 - Aguarde um momento :" + LocalArquivoMSSQL);
                    listBox1.Refresh();
                //    p.WaitForExit();
                    listBox1.Items.Add("3 - Parou processo :" + LocalArquivoMSSQL);
                    listBox1.Refresh();
                }

            }
            catch (Exception erroreexecutar)
            {
                listBox1.Items.Add(erroreexecutar + "Ao parar Servidor ");
                listBox1.Refresh();
                MessageBox.Show(erroreexecutar + "\r\n" + @"Ao parar Servidor nao executado ", @"Error ao Processa o Parar Servidor  ");
            }

        }




        private void AbrirIniciarservidor(object sender, EventArgs e)
        {
            Metodo_MostrarAplicacao();
        }
        private void MinimizarIniciarservidor(object sender, EventArgs e)
        {
            Metodo_MinimizarAplicacao();
        }

        private void testeZipandoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            VaiExecutartudoaoIniciar();
        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            MinimizarMaximizarListBox();

        }

        private void MinimizarMaximizarListBox()
        {
            if (toolStripMenuItemMenos.Text == "+")
            {
                this.listBox1.Visible = false;
                this.btEtradeNovo.Visible = true;
                this.btPdvNovo.Visible = true;
                this.toolStripMenuItemMenos.Text = "-";
                return;
            }

            if (toolStripMenuItemMenos.Text == "-")
            {
                this.listBox1.Visible = true;
                this.btEtradeNovo.Visible = false;
                this.btPdvNovo.Visible = false;
                this.toolStripMenuItemMenos.Text = "+";
                return;
            }
        }

        public object sParaServidorSql { get; set; }

        private void btReiniciarTef_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            VaiExecutarReiniciarTef();
        }

        private void btReiniciarTudo_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            VaiExecutartudoaoIniciar();
            VaiExecutarReiniciarTef();


        }

        private void VaiExecutarReiniciarTef()
        {
            if (bCbTEF) sPastaWwinrar = Controller.ClsReiniciarTef.METODOREINICIARTEFAGORA();
            if (bCbTEF) listBox1.Items.Add("* " + sPastaWwinrar);

        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            VaiExecutartudoaoIniciar();
        }

        private void lbVersão_Click(object sender, EventArgs e)
        {
            View.FormConfiguracao frmconfig = new View.FormConfiguracao();
            frmconfig.ShowDialog();

            bool bReiniciarAplicacaoconfigurado = frmconfig.bReiniciarAplicacaoconfigurado();


            if(bReiniciarAplicacaoconfigurado) Application.Restart();
        }



        public bool bCbTEF { get; set; }

        private void btEtradeNovo_Click(object sender, EventArgs e)
        {
            string sIniciarAtualizador = @"C:\Etrade\Etrade.exe";
            string snomeAtualizador = "Etrade";
            string pAstaLocal = @"C:\Etrade\";
            MetodoExecutarArquivosSistema(snomeAtualizador, pAstaLocal, sIniciarAtualizador);
        }

        private void MetodoExecutarArquivosSistema(string snomeAtualizador, string pAstaLocal, string sIniciarAtualizador)
        {
            Process I = new Process();
            try
            {
                // Verificando se o sistema já está em execução
                if (Process.GetProcessesByName(snomeAtualizador).Length == 1)
                {
                    MessageBox.Show(@"Programa " + snomeAtualizador + @", em execusão neste momento. ", snomeAtualizador + @" sendo executado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (File.Exists(sIniciarAtualizador))
                    {
                        I.StartInfo.WorkingDirectory = pAstaLocal;
                        I.EnableRaisingEvents = false;
                        I.StartInfo.FileName = sIniciarAtualizador;
                        I.StartInfo.UseShellExecute = false;
                        I.Start();
                        //I.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("->" + ex.Message);
            }
        }

        private void btPdvNovo_Click(object sender, EventArgs e)
        {
            string sIniciarAtualizador = @"C:\Etrade\PDV.exe";
            string snomeAtualizador = "PDV";
            string pAstaLocal = @"C:\Etrade\";
            MetodoExecutarArquivosSistema(snomeAtualizador, pAstaLocal, sIniciarAtualizador);
        }

        public Process[] nomedoprocesso { get; set; }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            ////metodo para zipar arquivos e para os executaveis no windows.
            //sziparArquivo = Controller.ClsZiparArquivoWinrar.METODOZiparArquivoWinrar(sPastaWwinrar);
            //listBox1.Items.Add("* " + sziparArquivo);
        }

        private void btReiniciarSistema_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("* Reiniciar o SISTEMA.");

            // parar serviços do windows mssql
            bool bServicoMsSqlparar = Controller.ClsPararServicoMsSql.MetodoPararServicoSql();
            listBox1.Items.Add("* Parando o serviço do windows. ->" + bServicoMsSqlparar);

            bool bParaServidorSql = Controller.ClsPararServidorMsSql2014.METODOParaServidorSqlB();
            listBox1.Items.Add("* Parando todos os executaveis do sistema... ->" + bParaServidorSql);

            //MessageBox.Show("-->>" + bServicoMsSql);

            //parar executaveis do windos.
            //bool bParaServidorSql = Controller.ClsPararServidorMsSql2014.METODOParaServidorSqlB();

            bool bServicoMsSqliniciar = Controller.ClsPararServicoMsSql.MetodoIniciarServicoSql();
            listBox1.Items.Add("* Iniciando o serviço do windows. ->" + bServicoMsSqliniciar);


        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public string sGoogleDriver { get; set; }
    }
}
