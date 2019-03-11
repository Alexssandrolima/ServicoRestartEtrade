using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;

using System.Security;
using System.Security.Principal;

using System.ServiceProcess;

using System.Reflection;

namespace SoftFiscal.Controller
{
    class ClsExisteWinrar
    {
        //pasta 64
        public static string pastaWinrar86 = @"C:\Program Files (x86)\WinRAR\";
        // pasta 32
        public static string pastaWinrar = @"C:\Program Files\WinRAR\";
        public static string spasta_Alex = @"C:\_alex\";
        public static string instaladorWinrar = @"C:\_alex\WRAR350.zip";
        public static string eXecutavelinstaladorWinrar = @"C:\_alex\WRAR350.exe";
        public static string ArquivoZip = "WRAR350.zip";
        public static bool bEncontrouwinrar86SimNao { get; set; }
        public static bool bEncontrouwinrarSimNao { get; set; }
        public static string Caminho_Nome_Diretorio { get; set; }
        public static bool repostawindows { get; set; }
        public static string spastaEncontrada { get; set; }
        public static bool bEncontrouArquivowinrarEXESimNao { get; set; }

        internal static string METODOEXISTEWINRAR()
        {
            //spastaEncontrada = @" ";
            bool bEncontrouPastaAlexSimNao;
            bool bEncontrouArquivoSimNao;
            //verificar se existe o diretorio.
            MetodotestarpastaExiste();

            if (!bEncontrouwinrar86SimNao && !bEncontrouwinrarSimNao)
            {
                bEncontrouPastaAlexSimNao = Directory.Exists(spasta_Alex);
                if (!bEncontrouPastaAlexSimNao) Directory.CreateDirectory(spasta_Alex);
                if (!bEncontrouPastaAlexSimNao) bEncontrouPastaAlexSimNao = Directory.Exists(spasta_Alex);
                if (!bEncontrouPastaAlexSimNao) MessageBox.Show("Erro ao encontrar a pasta " + spasta_Alex, "Erro ao Criar pasta!");
                if (!bEncontrouPastaAlexSimNao) return "Erro ao encontrar a pasta " + spasta_Alex;
                bEncontrouArquivowinrarEXESimNao = File.Exists(eXecutavelinstaladorWinrar);
                if (!bEncontrouArquivowinrarEXESimNao)
                {
                    bEncontrouArquivoSimNao = File.Exists(instaladorWinrar);
                    if (bEncontrouArquivoSimNao) ZipFile.ExtractToDirectory(instaladorWinrar, spasta_Alex);

                    if (!bEncontrouArquivoSimNao)
                    {
                        if (!bEncontrouArquivoSimNao) MetodoBaixarArquivoWinrarSite();
                        bEncontrouArquivoSimNao = File.Exists(instaladorWinrar);
                        if (bEncontrouArquivoSimNao) ZipFile.ExtractToDirectory(instaladorWinrar, spasta_Alex);
                        if (!bEncontrouArquivoSimNao) return "Erro ao encontrar a pasta " + instaladorWinrar;
                    }
                }
                bEncontrouArquivowinrarEXESimNao = File.Exists(eXecutavelinstaladorWinrar);
                    ProcessStartInfo proc = new ProcessStartInfo();
                    //O objeto Process deve ter a propriedade UseShellExecute definida como false para poder usar variáveis de ambiente.
                    proc.UseShellExecute = true;
                    //                proc.UseShellExecute = false;
                    proc.WorkingDirectory = spasta_Alex;
                    proc.FileName = eXecutavelinstaladorWinrar;
                    proc.Verb = "runas";
                    try
                    {
                        if (bEncontrouArquivowinrarEXESimNao) Process.Start(proc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" -> Erro ao executar arquivo wrar350.exe como administrador! \n\n" + ex.ToString());
                        return "* -> Erro ao executar arquivo wrar350.exe como administrador!";
                    }
                MetodotestarpastaExiste();
                if (bEncontrouwinrar86SimNao || bEncontrouwinrarSimNao)
                {
                    if (bEncontrouwinrarSimNao) return pastaWinrar;
                    if (bEncontrouwinrar86SimNao) return pastaWinrar86;
                }
            }
            if (bEncontrouwinrarSimNao) return pastaWinrar;
            if (bEncontrouwinrar86SimNao) return pastaWinrar86;
            return spastaEncontrada;
        }

        private static void MetodoBaixarArquivoWinrarSite()
        {
            string FileWebDownloadthis = "http://vciga.dyndns.org/siga1/ALEX/programas/WRAR_350_auto.zip";
            View.FormBaixarArquivoSite FmBaixarArquivo = new View.FormBaixarArquivoSite(instaladorWinrar, FileWebDownloadthis);
            FmBaixarArquivo.ShowDialog();
        }

        private static void MetodotestarpastaExiste()
        {
            bEncontrouwinrar86SimNao    = Directory.Exists(pastaWinrar86);
            bEncontrouwinrarSimNao      = Directory.Exists(pastaWinrar);
        }

        internal static bool IsRunAsAdmin()
        {
            try
            {
                //#if (DEBUG)
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(id);
                repostawindows = principal.IsInRole(WindowsBuiltInRole.Administrator);
                return repostawindows = principal.IsInRole(WindowsBuiltInRole.Administrator);
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

    }  
}
