namespace Blazor.PDF.Toolkit.Components.Core;

public class CoreShared
{
    public static int GetTotalPagesFromPdf(byte[] fileBuffer)
    {
        PdfDocument pdfDocument = new(new PdfReader(new MemoryStream(fileBuffer)));
        int totalPages = pdfDocument.GetNumberOfPages();
        pdfDocument.Close();
        return totalPages;
    }

    public static void RefreshCore()
    {
        Core.IsUploadComplete = false;
        Core.IsUploadInitiated = false;
        Core.IsUploadFailed = false;
        Core.UploadMessage = string.Empty;
        Core.UploadErrorMessage = string.Empty;
        Core.SubmitMessage = string.Empty;
        Core.DownloadMessage = string.Empty;
        Core.FinalPdfFilename = string.Empty;
        Core.FinalPdfUrl = string.Empty;
    }
}