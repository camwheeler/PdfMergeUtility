using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfMergeUtility
{
    public partial class PdfMerge : Form
    {
        public PdfMerge()
        {
            InitializeComponent();
        }

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                txtSourcePath.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                txtSaveAs.Text = saveFileDialog.FileName;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            object Convert(string str) {
                try {
                    return int.Parse(str);
                }
                catch {
                    return str;
                }
            }

            var files = Directory.EnumerateFiles(txtSourcePath.Text, "*.svg").OrderBy(
                str => Regex.Split(str.Replace(" ", ""), "([0-9]+)").Select(Convert),
                new EnumerableComparer<object>());
            
            // Use Inkscape to save the svg files as pdfs
            var tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
            Directory.CreateDirectory(tempPath);
            foreach (var svg in files)
            {
                Process inkscape = Process.Start(new ProcessStartInfo(@"C:\Program Files\Inkscape\inkscape.exe", $"--without-gui --export-pdf={Path.Combine(tempPath, Path.GetFileNameWithoutExtension(svg))}.pdf {svg}"));
            }

            // Now take the available pdf files and compile them all into one merged document.
            using (var doc = new PdfDocument())
            {
                foreach (var pdf in files.Select(f => Path.Combine(tempPath, $"{Path.GetFileNameWithoutExtension(f)}.pdf")))
                {
                    // Allow time for the files to finish conversion
                    while(!File.Exists(pdf))
                        Thread.Sleep(10);

                    using (var import = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        foreach (PdfPage pdfPage in import.Pages)
                        {
                            doc.AddPage(pdfPage);
                        }
                    }
                }
                doc.Save(txtSaveAs.Text);
            }

            // Cleanup
            Directory.Delete(tempPath, true);

            MessageBox.Show("Success!", "PdfMerge Status", MessageBoxButtons.OK);
        }
    }
}
