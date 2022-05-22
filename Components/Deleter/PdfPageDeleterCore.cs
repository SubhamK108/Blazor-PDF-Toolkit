using System;
using System.IO;
using iText.Kernel.Pdf;
using static Components.Deleter.PdfPageDeleter;


namespace Components.Deleter
{
    class PdfPageDeleterCore
    {
        public static void DeletePagesFromPdf(string pages)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader pdfReader = new PdfReader(new MemoryStream(PdfFile));
                PdfWriter pdfWriter = new PdfWriter(stream);
                PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter);

                if (pages.Contains('-'))
                {
                    int fromPage = Convert.ToInt32(pages.Split('-')[0]);
                    int toPage = Convert.ToInt32(pages.Split('-')[1]);

                    for (int i = 0; i < (toPage - fromPage + 1); i++)
                    {
                        pdfDocument.RemovePage(fromPage);
                    }
                }
                else
                {
                    int page = Convert.ToInt32(pages);
                    pdfDocument.RemovePage(page);
                }

                pdfDocument.Close();
                pdfReader.Close();
                pdfWriter.Close();

                FinalDeletedPdfURL = Format + Convert.ToBase64String(stream.ToArray());
            }

            IsSubmitComplete = true;
            IsDeletionComplete = true;
        }

        public static void GetTotalPages()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfDocument pdfDocument = new PdfDocument(new PdfReader(new MemoryStream(PdfFile)));
                TotalPages = pdfDocument.GetNumberOfPages();
                pdfDocument.Close();
            }
        }

        public static void RefreshApp()
        {
            IsDeletionComplete = false;
            IsSubmitComplete = false;
            IsUploadComplete = false;
            PdfFile = null;
            TotalPages = 0;
            PageValidationErrorMessage = string.Empty;
            TotalSize = 0;
            FileType = "application/pdf";
            SubmitMessage = string.Empty;
            DownloadMessage = string.Empty;
            UploadMessage = string.Empty;
            UploadErrorMessage = string.Empty;
            FinalDeletedPdfURL = string.Empty;
        }
    }
}