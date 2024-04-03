namespace Blazor.PDF.Toolkit.Components.ImageConverter;

public class ImageConverterCore
{
    public static void ConvertImageToPdf()
    {
        using MemoryStream stream = new();
        PdfDocument pdfDocument = new(new PdfWriter(stream));
        ImageData imageData = ImageDataFactory.Create(ImageConverter.UploadedImage!.Content!);
        Image image = new(imageData);

        // Width of an A4 Page in 72 DPI = 595 Pixels
        const int refWidth = 595;
        // Width of an A4 Page in 96 DPI = 794 Pixels
        const int refWidthAlt = 794;

        float docWidth = 0;
        float docHeight = 0;
        float imageWidth = image.GetImageWidth();
        float imageHeight = image.GetImageHeight();

        float imageRatio = imageHeight / imageWidth;
        // imageRatio > 1 => Portrait Image
        // imageRatio < 1 => Landscape Image

        if (imageRatio > 1)
        {
            if (imageWidth > refWidth)
            {
                image.SetWidth(refWidth);
                image.SetHeight(refWidth * imageRatio);
                docWidth = refWidth;
                docHeight = refWidth * imageRatio;
            }
            else
            {
                docWidth = imageWidth;
                docHeight = imageHeight;
            }
        }
        else
        {
            if (imageWidth > refWidthAlt)
            {
                image.SetWidth(refWidthAlt);
                image.SetHeight(refWidthAlt * imageRatio);
                docWidth = refWidthAlt;
                docHeight = refWidthAlt * imageRatio;
            }
            else
            {
                docWidth = imageWidth;
                docHeight = imageHeight;
            }
        }

        Document document = new(pdfDocument, new PageSize(docWidth, docHeight));
        document.SetMargins(0, 0, 0, 0);
        document.Add(image);

        document.Close();
        pdfDocument.Close();

        string fileName = ImageConverter.UploadedImage!.FileName!;
        Core.Core.FinalPdfFilename = $"{fileName[..(fileName.Length - 4)]} (PDF)";
        Core.Core.FinalPdfUrl = $"data:application/pdf;base64,{Convert.ToBase64String(stream.ToArray())}";
    }

    public static void RefreshImageConverter()
    {
        ImageConverter.UploadedImage = null;
        ImageConverter.IsConversionComplete = false;
        ImageConverter.IsConversionInitiated = false;
        ImageConverter.ImageOrientation = null;
        ImageConverter.PreviewImageUrl = "";
    }
}