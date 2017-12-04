using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfMergeUtility
{
    class Program
    {
        static void Main(string[] args) {
            // Use Inkscape to save the svg files as pdfs
            foreach (var svg in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.svg")) {
                Process inkscape = Process.Start(new ProcessStartInfo(@"C:\Program Files\Inkscape\inkscape.exe", $"--without-gui --export-pdf={Path.GetFileNameWithoutExtension(svg)}.pdf {svg}"));
            }

            // Now take the available pdf files and compile them all into one merged document.
            using (var doc = new PdfDocument()) {
                foreach (var pdf in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.pdf")) {
                    using (var import = PdfReader.Open(pdf, PdfDocumentOpenMode.Import)) {
                        foreach (PdfPage pdfPage in import.Pages) {
                            doc.AddPage(pdfPage);
                        }
                    }
                }
                doc.Save(Path.Combine(Directory.GetCurrentDirectory(), "MergedDocument.pdf"));
            }
        }
    }
}
