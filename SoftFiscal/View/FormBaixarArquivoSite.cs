using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;


using System.Net;
using System.IO;



namespace SoftFiscal.View
{
    public partial class FormBaixarArquivoSite : Form
    {
        public FormBaixarArquivoSite()
        {
            InitializeComponent();
            LbStatusDownload.Text = "Download!";
        }

        public FormBaixarArquivoSite(string ArquivoZip, string FileWebDownloadthis)
        {
            InitializeComponent();
            this.ArquivoZip = ArquivoZip;
            LbStatusDownload.Text = FileWebDownloadthis;
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(FileWebDownloadthis), ArquivoZip);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            LbStatusDownload.Text = "Download completed!";
            //MessageBox.Show("Download completed!");
            this.Close();
        }

        private void btnSavetoLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectedFolder = new FolderBrowserDialog();

            if (selectedFolder.ShowDialog() == DialogResult.OK)
            {
                filepath = selectedFolder.SelectedPath;
            }
        }
        //public string FileWebDownloadthis = "http://vciga.dyndns.org/siga1/ALEX/programas/WRAR_350_auto.zip";
        private string ArquivoZip;
        public string filepath { get; set; }

        private void FormBaixarArquivoSite_Load(object sender, EventArgs e)
        {

        }

        private void LbStatusDownload_Click(object sender, EventArgs e)
        {

        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
