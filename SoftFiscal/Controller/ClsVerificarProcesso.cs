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



        internal void Fecharprocesso()
        {
            try
            {
                // Verificando se o sistema já está em execução
                Process execucao = Process.GetCurrentProcess();
                string nomeProcesso = execucao.ProcessName;
                if (Process.GetProcessesByName(nomeProcesso).Length > 1)
                {
                    MessageBox.Show(@"Programa " + nomeProcesso + @", em execusão neste momento. ", nomeProcesso + @" sendo executado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception erroreexecutar)
            {
                MessageBox.Show(erroreexecutar + "\r\n" + @" Comando nao executado ", @"Error ao Processa Arquivos ");
            }
        }
    }
}
