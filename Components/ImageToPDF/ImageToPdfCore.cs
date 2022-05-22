using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using static Components.ImageToPDF.ImageToPdf;


namespace Components.ImageToPDF
{
    class ImageToPdfCore
    {
        public static void ConvertToPdf()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(stream));
                ImageData imageData = ImageDataFactory.Create(ImageFile);
                Image image = new Image(imageData);

                float imageRatio = image.GetImageHeight() / image.GetImageWidth();
                float docWidth;
                float docHeight;

                if (image.GetImageWidth() > 595)
                {
                    image.SetWidth(595);
                    float newHeight = 595 * imageRatio;
                    image.SetHeight(newHeight);
                    docWidth = 595;
                    docHeight = newHeight;
                }
                else
                {
                    docWidth = image.GetImageWidth();
                    docHeight = image.GetImageHeight();
                }

                Document document = new Document(pdfDoc, new PageSize(docWidth, docHeight));
                document.SetMargins(0, 0, 0, 0);
                document.Add(image);
                pdfDoc.Close();

                FinalConvertedPdfURL = Format + Convert.ToBase64String(stream.ToArray());
            }

            IsSubmitComplete = true;
            IsConversionComplete = true;
        }

        public static void RefreshApp()
        {
            IsConversionComplete = false;
            IsSubmitComplete = false;
            IsUploadComplete = false;
            ImageFile = null;
            TotalSize = 0;
            FileType = "image/jpg";
            SubmitMessage = string.Empty;
            DownloadMessage = string.Empty;
            UploadMessage = string.Empty;
            UploadErrorMessage = string.Empty;
            FinalConvertedPdfURL = string.Empty;
        }
    }
}