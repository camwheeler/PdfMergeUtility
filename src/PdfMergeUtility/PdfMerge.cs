using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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
            var tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
            try {
                Directory.CreateDirectory(tempPath);
                var files = Directory.EnumerateFiles(txtSourcePath.Text, "*.svg").OrderBy(
                    str => Regex.Split(str.Replace(" ", ""), "([0-9]+)").Select(Convert),
                    new EnumerableComparer<object>());

                List<Task> inkscapeTasks = new List<Task>();
                // Use Inkscape to save the svg files as pdfs
                foreach (var svg in files) {
                    var pdf = $"{Path.Combine(tempPath, Path.GetFileNameWithoutExtension(svg))}.pdf";
                    inkscapeTasks.Add(Task.Run(() => Process.Start(new ProcessStartInfo(@"C:\Program Files\Inkscape\inkscape.exe", $"--without-gui --export-pdf=\"{pdf}\" \"{svg}\""))?.WaitForExit()));
                }

                Task.WaitAll(inkscapeTasks.ToArray());

                // Now take the available pdf files and compile them all into one merged document.
                using (var doc = new PdfDocument()) {
                    foreach (var pdf in files.Select(f => Path.Combine(tempPath, $"{Path.GetFileNameWithoutExtension(f)}.pdf"))) {
                        // Allow time for the files to finish conversion
                        while (!File.Exists(pdf))
                            Thread.Sleep(10);

                        using (var import = PdfReader.Open(pdf, PdfDocumentOpenMode.Import)) {
                            foreach (PdfPage pdfPage in import.Pages) {
                                doc.AddPage(pdfPage);
                            }
                        }
                    }
                    doc.Save(txtSaveAs.Text);
                }
                
                MessageBox.Show("Success!", "PdfMerge Status", MessageBoxButtons.OK);
            }
            catch (Exception ex) {
                using (var logfile = File.OpenWrite(@"C:\Temp\PdfMerge.log"))
                using (var log = new StreamWriter(logfile)) {
                    log.Write(ex.Message);
                    log.Write(ex.StackTrace);
                }
            }
            finally
            {
                // Cleanup
                Directory.Delete(tempPath, true);
            }
        }

        private object Convert(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return str;
            }
        }
    }
}
