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
    class ClsPararServidorMsSql2014
    {
        public static bool bEncontrouProcessoSimNao { get; set; }
        public static string sProcessoMYSQL2014 { get; set; }
        public static bool bExecutarParaServidorSqlB { get; set; }
        public static object sMETODOParaServidorSql { get; set; }

        internal static bool METODOParaServidorSqlB()
        {
            //var aThread = new System.Threading.Thread(() =>
            //{
            //    var count = 0;
            //    while (count <= 3)
            //    {
            //        MessageBox.Show("Olá " + DateTime.Now.ToShortTimeString());
            //        System.Threading.Thread.Sleep(1000);
            //        count++;
            //    }
            //});
            //aThread.Start();
            ExecutarParaServidorSqlB();
            return bExecutarParaServidorSqlB;
        }

        private static void ExecutarParaServidorSqlB()
        {
            string sPDV = "PDV";
            string sEtrade = "Etrade";
            Process[] processos = Process.GetProcesses();
            foreach (Process p in processos)
            {
                try
                {
                    //parando os serviços.
                    if (p.ProcessName.ToUpper() == sPDV.ToUpper())
                    {
                        // Tenta fechar a janela principal,
                        // se falhar invoca o método Kill()
                        //if (!p.CloseMainWindow())
                        //{
                        p.Kill();
                        //p.Refresh();
                        p.WaitForExit();
                        //}
                        //p.Close(); // Libera recursos associados.
                        sMETODOParaServidorSql = "Parado o processo " + sPDV + " Com sucesso!";
                        bExecutarParaServidorSqlB = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("->" + ex.Message);
                    sMETODOParaServidorSql = "Erro ao Parar o processo " + sPDV; 
                    bExecutarParaServidorSqlB = false;
                }
                try
                {
                    if (p.ProcessName.ToUpper() == sEtrade.ToUpper())
                    {
                        // Tenta fechar a janela principal,
                        // se falhar invoca o método Kill()
                        //if (!p.CloseMainWindow())
                        //{
                        p.Kill();
                        //p.Refresh();
                        p.WaitForExit();
                        //}
                        //p.Close(); // Libera recursos associados.
                        sMETODOParaServidorSql = "Parado o processo " + sEtrade + " Com sucesso!";
                        bExecutarParaServidorSqlB = true;
                    }

                }
                catch (Exception ex2)
                {
                    MessageBox.Show("->" + ex2.Message);
                    sMETODOParaServidorSql = "Erro ao Parar o processo " + sEtrade; 
                    bExecutarParaServidorSqlB = false;
                }
            }
        }

        internal static object METODOParaServidorSql()
        {
            ExecutarParaServidorSqlB();
            return sMETODOParaServidorSql; // "Erro ao Parar o processo " + sProcessoMYSQL2014;
        }

     }
}
