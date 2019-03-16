using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Windows.Forms;


namespace SoftFiscal.Controller
{
    class ClsVerificarProcesso
    {




        public bool bCbTEF { get; set; }

        public string sPastaWwinrar { get; set; }
        public string sziparArquivo { get; set; }



        internal void Fecharprocesso()
        {


            bCbTEF = Convert.ToBoolean(Properties.Settings.Default.UsarTef);
            //string txtIP =Convert.ToString( Properties.Settings.Default.myColor);
            
            //vai executar o backup ao iniciar.

            //Shutdown();

            try
            {
                // Verificando se o sistema já está em execução
                Process execucao = Process.GetCurrentProcess();
                string nomeProcesso = execucao.ProcessName;
                if (Process.GetProcessesByName(nomeProcesso).Length > 1)
                {

                    VaiExecutartudoaoIniciar();



//                    MessageBox.Show(@"Programa " + nomeProcesso + @", em execusão neste momento. 
///n /n Backup comcluído com sucesso." + "Existe a pasta winrar: " + sPastaWwinrar + "Zipou arquivo: " + sziparArquivo, nomeProcesso + @" sendo executado", MessageBoxButtons.OK, MessageBoxIcon.Information);




                    
//                    Process.GetCurrentProcess().Kill();








                    DialogResult result = MessageBox.Show(" \n Backup comcluído com sucesso. \n \n Deseja desligar o computador Sim/Não \n vai demorar um pouvo mas é para sua segurança...", nomeProcesso + @" sendo executado",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if(result == DialogResult.Yes)
                            {

                                Shutdown();


                                Process.GetCurrentProcess().Kill();



                            }
                            else if(result == DialogResult.No)
                            {


                                Process.GetCurrentProcess().Kill();


                            }
                            
























                }
            }
            catch (Exception erroreexecutar)
            {
                MessageBox.Show(erroreexecutar + "\r \n" + @" Comando nao executado \n \n Backup comcluído com sucesso." + " \n Existe a pasta winrar: " + sPastaWwinrar + " \n Zipou arquivo: " + sziparArquivo, @"Error ao Processa Arquivos ");
            }
        }



        private void VaiExecutartudoaoIniciar()
        {

            // verificar se o winrar esta instalado.
            sPastaWwinrar = Controller.ClsExisteWinrar.METODOEXISTEWINRAR();

            // zipar arquivos do winrar ao iniciar novamente.
            sziparArquivo = Controller.ClsZiparArquivoWinrar.METODOZiparArquivoWinrar(sPastaWwinrar);
 
        }

        void Shutdown()
        {


//            shutdown /s /T 60 /C "Computador vai ser desligado apos fazer o backup no google driver" /f /d p:4:1



            Process.Start("shutdown.exe", "-s -t 60 -f -d p:4:1");
        }



    }
}
