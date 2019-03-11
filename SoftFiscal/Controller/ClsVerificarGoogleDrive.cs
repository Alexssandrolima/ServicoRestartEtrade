using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Compression;



namespace SoftFiscal.Controller
{
    class ClsVerificarGoogleDrive
    {
        public static string spasta_Alex = @"C:\_alex\";
        public static string instaladorGoogleDrive = @"C:\_alex\installbackupandsync.zip";
        public static string ExecitaveçinstaladorGoogleDrive = @"C:\_alex\installbackupandsync.exe";
        public static bool bEncontrouArquivoinstaladorGoogleDriveSimNao { get; set; }
        public static bool bEncontrouPastaAlexSimNao { get; set; }
        public static object bEncontrouArquivogoogledriverpastaSimNao { get; set; }
        public static bool bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao { get; set; }

        internal static string MetodoExisteGdrive()
        {
            RegistryKey RK = Registry.CurrentUser.OpenSubKey("Software\\Google\\Drive");
            if (RK == null)
            {
                MessageBox.Show("não instalado Flash Instalado");
                //verificar pasta alex instalado no drive c
                bEncontrouPastaAlexSimNao = metodoVerificarPastaAlexBaixarArquivoGoogledrivedo();
                if (!bEncontrouPastaAlexSimNao) return "Erro ao encontrar a pasta " + spasta_Alex;
                //baixar arquivo google drive e se não existir.
                bEncontrouArquivogoogledriverpastaSimNao = metodoVerificarArquivoGoogledrivedo();
                if (!bEncontrouPastaAlexSimNao) return "Erro ao baixar  " + instaladorGoogleDrive;
                //metodoBaixarArquivoGoogledrivedoSite();
                return "* -> Instalado com exito o GOOGLE DRIVE.";
            }
            return "* -> Verificado com exito o GOOGLE DRIVE.";
        }

        private static object metodoVerificarArquivoGoogledrivedo()
        {
            bEncontrouArquivoinstaladorGoogleDriveSimNao = File.Exists(ExecitaveçinstaladorGoogleDrive);
                if (!bEncontrouArquivoinstaladorGoogleDriveSimNao)
                {
                    bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao = File.Exists(instaladorGoogleDrive);
                    if (bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao) ZipFile.ExtractToDirectory(instaladorGoogleDrive, spasta_Alex);
                    if (!bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao)
                    {
                        if (!bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao) metodoBaixarArquivoGoogledrivedoSite();
                        bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao = File.Exists(instaladorGoogleDrive);
                        if (bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao) ZipFile.ExtractToDirectory(instaladorGoogleDrive, spasta_Alex);
                        if (!bEncontrouArquivoZipadoinstaladorGoogleDriveSimNao) return "Erro ao encontrar a pasta " + instaladorGoogleDrive;
                    }
                }
                bEncontrouArquivoinstaladorGoogleDriveSimNao = File.Exists(ExecitaveçinstaladorGoogleDrive);
                    ProcessStartInfo proc = new ProcessStartInfo();
                    //O objeto Process deve ter a propriedade UseShellExecute definida como false para poder usar variáveis de ambiente.
                    proc.UseShellExecute = false;
                    //                proc.UseShellExecute = false;
                    proc.WorkingDirectory = spasta_Alex;
                    proc.FileName = ExecitaveçinstaladorGoogleDrive;
                    proc.Verb = "runas";
                    try
                    {
                        if (bEncontrouArquivoinstaladorGoogleDriveSimNao) Process.Start(proc);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" -> Erro ao executar arquivo " + ExecitaveçinstaladorGoogleDrive + " como administrador! \n\n" + ex.ToString());
                        return "* -> Error Instalado o Google Drive no computador... " + ex.Message;
                    }
            return "* -> Instalado o Google Drive no computador...";
        }

        private static bool metodoVerificarPastaAlexBaixarArquivoGoogledrivedo()
        {
            bEncontrouPastaAlexSimNao = Directory.Exists(spasta_Alex);
            if (!bEncontrouPastaAlexSimNao) Directory.CreateDirectory(spasta_Alex);
            if (!bEncontrouPastaAlexSimNao) bEncontrouPastaAlexSimNao = Directory.Exists(spasta_Alex);
            if (!bEncontrouPastaAlexSimNao) MessageBox.Show("Erro ao encontrar a pasta " + spasta_Alex, "Erro ao Criar pasta!");
            return bEncontrouPastaAlexSimNao;
        }

        private static void metodoBaixarArquivoGoogledrivedoSite()
        {
            string FileWebDownloadthis = "http://vciga.dyndns.org/siga1/ALEX/installbackupandsync.zip";
            View.FormBaixarArquivoSite FmBaixarArquivo = new View.FormBaixarArquivoSite(instaladorGoogleDrive, FileWebDownloadthis);
            FmBaixarArquivo.ShowDialog();

        }

        //procurar andre aveslima

        //private static void Upload(Google.Apis.Drive.v3.DriveService servico, string caminhoArquivo)
        //{
        //    var arquivo = new Google.Apis.Drive.v3.Data.File();
        //    arquivo.Name = System.IO.Path.GetFileName(caminhoArquivo);
        //    arquivo.MimeType = MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(caminhoArquivo));
        //    using (var stream = new System.IO.FileStream(caminhoArquivo, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        //    {
        //        var request = servico.Files.Create(arquivo, stream, arquivo.MimeType);
        //        request.Upload();
        //    }
        //}


        //private void Lista()
        //{
        //    var credenciais = Autenticar();
        //    using (var servico = AbrirServico(credenciais))
        //    {
        //        Upload(servico, "arquivo.txt");
        //    }
        //}

    }
    
}
