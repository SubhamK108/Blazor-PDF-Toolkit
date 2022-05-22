using System;
using System.IO;
using iText.Kernel.Pdf;
using static Components.Encryptor.PdfEncryptor;


namespace Components.Encryptor
{
    class PdfEncryptorCore
    {
        public static void EncryptPdf(string password)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfReader pdfReader = new PdfReader(new MemoryStream(PdfFile));
                byte[] ownerPassword = System.Text.Encoding.Default.GetBytes(password);
                WriterProperties writerProperties = new WriterProperties();
                writerProperties.SetStandardEncryption(ownerPassword, ownerPassword, EncryptionConstants.ALLOW_PRINTING, EncryptionConstants.ENCRYPTION_AES_256);

                PdfWriter pdfWriter = new PdfWriter(stream, writerProperties);
                PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter);

                pdfDocument.Close();
                pdfReader.Close();
                pdfWriter.Close();

                FinalEncryptedPdfURL = Format + Convert.ToBase64String(stream.ToArray());
            }

            IsSubmitComplete = true;
            IsEncryptionComplete = true;
        }

        public static void RefreshApp()
        {
            IsEncryptionComplete = false;
            IsSubmitComplete = false;
            IsUploadComplete = false;
            PdfFile = null;
            TotalSize = 0;
            FileType = "application/pdf";
            SubmitMessage = string.Empty;
            DownloadMessage = string.Empty;
            UploadMessage = string.Empty;
            UploadErrorMessage = string.Empty;
            FinalEncryptedPdfURL = string.Empty;
        }
    }
}