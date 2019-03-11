using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceProcess;
using System.Diagnostics;
using System.IO;

using System.Reflection;

using System.Windows.Forms;
using System.Security;
using System.Security.Principal;

namespace SoftFiscal
{
    class Security
    {
        internal static void AdministradorReiniciar()
        {
            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                //O objeto Process deve ter a propriedade UseShellExecute definida como false para poder usar variáveis de ambiente.
                proc.UseShellExecute = true;
//                proc.UseShellExecute = false;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;
                proc.Verb = "runas";
                //var processes = Process.GetProcesses("SoftFiscal.vshost");
                try
                {
                    Process.Start(proc);
                    //Application.Current.Shutdown();
                    //var processes2 = Process.GetProcesses("SoftFiscal");
                    //Application.Exit();
                    //                    Application.Current.Shutdown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" -> Este programa deve ser executado como administrador! \n\n" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show(" -> Ocorreu um erro inesperado ao verificar se esta rodando como administrador");
            }
        }

        internal static bool IsRunAsAdmin()
        {
            try
            {
//#if (DEBUG)
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(id);
                repostawindows = principal.IsInRole(WindowsBuiltInRole.Administrator);
                return false;
//#endif
//#if (RELEASE)
//                WindowsIdentity id = WindowsIdentity.GetCurrent();
//                WindowsPrincipal principal = new WindowsPrincipal(id);
//                repostawindows = principal.IsInRole(WindowsBuiltInRole.Administrator);
//                return repostawindows;
//#endif
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AdminRelauncher()
        {
            throw new NotImplementedException();
        }

        public static bool repostawindows { get; set; }
    }
}
