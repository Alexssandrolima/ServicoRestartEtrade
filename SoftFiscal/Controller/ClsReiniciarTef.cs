using System;
using System.Collections.Generic;
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

namespace SoftFiscal.Controller
{
    class ClsReiniciarTef
    {
        public static string rEturnMensagem { get; set; }
        public static string[] vARQUIVOSTEMPORARIOS { get; set; }
        public static string sIniciarAtualizador { get; set; }
        public static string pAstaLocal = @"C:\Tef_Dial";

        //        @echo off 
        //net start OpenVPNService
        //cd C:\Tef_Dial\Req
        //del *.001
        //cd C:\Tef_Dial
        //start C:\Tef_Dial\atualizador.exe
        //exit

        internal static string METODOREINICIARTEFAGORA()
        {
            string Satualizador = "atualizador";
            string sTEF_DIAL = "TEF_DIAL";
            Process[] processos = Process.GetProcesses();
            foreach (Process p in processos)
            {
                try
                {
                    //parando os serviços.
                    if (p.ProcessName.ToUpper() == Satualizador.ToUpper())
                    {
                        p.Kill();
                        p.WaitForExit();
                        rEturnMensagem = "Parado o processo " + Satualizador + " Com sucesso!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("->" + ex.Message);
                    rEturnMensagem = "Erro ao Parar o processo " + Satualizador;
                }

                try
                {
                    //parando os serviços.
                    if (p.ProcessName.ToUpper() == sTEF_DIAL.ToUpper())
                    {
                        p.Kill();
                        p.WaitForExit();
                        rEturnMensagem = "Parado o processo " + sTEF_DIAL + " Com sucesso!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("->" + ex.Message);
                    rEturnMensagem = "Erro ao Parar o processo " + sTEF_DIAL;
                }
            }

            vARQUIVOSTEMPORARIOS = Directory.GetFiles(@"C:\Tef_Dial\Req\");
            //bFileExistMDFSimNao = File.Exists(@"C:\Tef_Dial\Req\*.001");
            try
            {
                foreach (var dEletar in vARQUIVOSTEMPORARIOS)
                {
                    // System.IO.File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
                    File.Delete(dEletar);
                    rEturnMensagem = dEletar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("->" + ex.Message);
                rEturnMensagem = ex.Message;
            }
            sIniciarAtualizador = @"C:\Tef_Dial\atualizador.exe";
            Process I = new Process();
            try
            {
                if(File.Exists(sIniciarAtualizador))
                {
                    I.StartInfo.WorkingDirectory = pAstaLocal;
                    I.EnableRaisingEvents = false;
                    I.StartInfo.FileName = sIniciarAtualizador;
                    I.StartInfo.UseShellExecute = false;
                    I.Start();
                    I.WaitForExit();
                    rEturnMensagem = "Iniciando o " + sIniciarAtualizador;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("->" + ex.Message);
                rEturnMensagem = ex.Message;
            }

            return rEturnMensagem;
        }
    }
}
