using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using static Components.Merger.PdfMerger;


namespace Components.Merger
{
    class PdfMergerCore
    {
        public static void MergePdf()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(stream));
                iText.Kernel.Utils.PdfMerger merger = new iText.Kernel.Utils.PdfMerger(pdfDoc);

                foreach (byte[] pdf in Pdfs)
                {
                    PdfDocument currentPdf = new PdfDocument(new PdfReader(new MemoryStream(pdf)));
                    merger.Merge(currentPdf, 1, currentPdf.GetNumberOfPages());
                    currentPdf.Close();
                }

                merger.Close();
                pdfDoc.Close();

                FinalMergedPdfURL = Format + Convert.ToBase64String(stream.ToArray());
            }

            IsSubmitComplete = true;
            IsMergeComplete = true;
        }

        public static void RefreshApp()
        {
            IsMergeComplete = false;
            IsSubmitComplete = false;
            IsUploadComplete = false;
            Pdfs.Clear();
            TotalFiles = 0;
            TotalSize = 0;
            FileType = "application/pdf";
            SubmitMessage = string.Empty;
            DownloadMessage = string.Empty;
            UploadMessage = string.Empty;
            UploadErrorMessage = string.Empty;
            FinalMergedPdfURL = string.Empty;
        }

        // public static void Submit()
        // {
        //     Message = "Working on it...";
        //     MergePdf();
        // }
    }
}