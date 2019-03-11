using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;

namespace SoftFiscal.Controller
{
    class ClsZiparArquivoWinrar
    {
        public static string pastaGOOGLEDRIVE = @"C:\_GOOGLEDRIVE\";

        public static string sFileetrade = @"C:\Etrade\etrade.mdf";
        public static string sFileetrade_log = @"C:\\Etrade\\etrade_log.ldf";

        //ARQUIVO QUE ESTA O WINRAR É O sPastaWwinrar = @"C:\Program Files (x86)\WinRAR\"

        internal static string METODOZiparArquivoWinrar(string sPastaWwinrar)
        {
           string sPastaarquivodoWwinrar = sPastaWwinrar;      //verificar se esta achando a pasta winrar para zipar os arquivos mfd e ldf

           bParaServidorSql = Controller.ClsPararServicoMsSql.MetodoPararServicoSql();
           //MessageBox.Show("-->" + bParaServidorSql);
           if (!bParaServidorSql) bParaServidorSql = Controller.ClsPararServicoMsSql.MetodoPararServicoSql();
           if (!bParaServidorSql) return "Error ao parar o serviço do windows";
            //bool bParaServidorSql = Controller.ClsPararServidorMsSql2014.METODOParaServidorSqlB();
            //if (!bParaServidorSql) return "Erro ao para os processos";

            MetodotestarpastaExisteGoogleDrive();
            if (!bEncontrouwinrarSimNao) return "Erro ao encontrar a pasta " + pastaGOOGLEDRIVE;


//            %TRACE% %Zip7ZIP% u %BACKUP%\etrade_mdf_%Date%-%time%.zip C:\Etrade\etrade.mdf
//            If exist C:\Etrade\etrade.mdf (%Zip7ZIP% u %BACKUP%\etrade_mdf_%Date%-%time% C:\Etrade\etrade.mdf) else (echo erro zipcompactado)



            if (bEncontrouwinrarSimNao)
            {
                bFileExistMDFSimNao = File.Exists(sFileetrade);
                bFileExistldfSimNao = File.Exists(sFileetrade_log);


                //"C:\\Program Files (x86)\\Winrar\\Rar.exe -ut C:\\_GOOGLEDRIVE\\etrade_mdf C:\\Etrade\\etrade.mdf"

                //string testando = sPastaWwinrar + "Rar.exe -ut " + pastaGOOGLEDRIVE + "etrade.mdf C:\\Etrade\\etrade.mdf";

                string sExecutavelwinrar        = sPastaarquivodoWwinrar + "WinRar.exe";

                //Capturar hora
                string hora = DateTime.Now.ToShortTimeString();


                //Capturar data
                string data = DateTime.Now.ToShortDateString();
                string[] palavras = data.Split('/');
                string sSalvarDataArquivo = palavras[2] + palavras[1] + palavras[0]; 
                string etrademdfArguments = @" u -t " + pastaGOOGLEDRIVE + "etrade_mdf_"+ sSalvarDataArquivo +" C:\\Etrade\\etrade.mdf";
                string etradelogldfArguments = @" u -t " + pastaGOOGLEDRIVE + "etrade_log_ldf_" + sSalvarDataArquivo + " C:\\Etrade\\etrade_log.ldf";




                //if (bEncontrouwinrarSimNao) MessageBox.Show(etrademdf);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();

                if (bFileExistMDFSimNao)
                {
                    try
                    {
                        proc.StartInfo.Arguments = etrademdfArguments;
                        proc.StartInfo.WorkingDirectory = @"C:\Etrade\";
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.FileName = sExecutavelwinrar;
                        proc.StartInfo.UseShellExecute = false;
                        proc.Start();
                        proc.WaitForExit();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error etrademdf ->" + ex.Message, "Entre em contato com o suporte!");
                    }
                }
                if (bFileExistldfSimNao)
                {
                    try
                    {
                        proc.StartInfo.Arguments = etradelogldfArguments;
                        proc.StartInfo.WorkingDirectory = @"C:\Etrade\";
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.FileName = sExecutavelwinrar;
                        proc.StartInfo.UseShellExecute = false;
                        proc.Start();
                        proc.WaitForExit();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error etradelogldf ->" + ex.Message, "Entre em contato com o suporte!");
                    }
                }

            }


            //if (bEncontrouwinrarSimNao) System.Diagnostics.Process.Start(sPastaWwinrar + @"Rar.exe");
            //if (bEncontrouwinrarSimNao) MessageBox.Show(sPastaWwinrar + @"Rar.exe");



            bParaServidorSql = Controller.ClsPararServicoMsSql.MetodoIniciarServicoSql();
            if (!bParaServidorSql) bParaServidorSql = Controller.ClsPararServicoMsSql.MetodoIniciarServicoSql();
            if (!bParaServidorSql) return "Error ao iniciar o serviço do windows";
            return pastaGOOGLEDRIVE + " >> Consegiu parar e iniciar o serviço do windows corretamente...  ";
        }


        private static void MetodotestarpastaExisteGoogleDrive()
        {
            bEncontrouwinrarSimNao = Directory.Exists(pastaGOOGLEDRIVE);
            if (!bEncontrouwinrarSimNao) Directory.CreateDirectory(pastaGOOGLEDRIVE);
            if (!bEncontrouwinrarSimNao) bEncontrouwinrarSimNao = Directory.Exists(pastaGOOGLEDRIVE);
            //if (!bEncontrouwinrarSimNao) MessageBox.Show("Erro ao encontrar a pasta " + pastaGOOGLEDRIVE, "Erro ao Criar pasta!");
        }

        public static bool bEncontrouwinrarSimNao { get; set; }

        public static bool bEncontrouPastaAlexSimNao { get; set; }

        public static bool bFileExistMDFSimNao { get; set; }

        public static bool bFileExistldfSimNao { get; set; }

        public static bool bParaServidorSql { get; set; }
    }
}
